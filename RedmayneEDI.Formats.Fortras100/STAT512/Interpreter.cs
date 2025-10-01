using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.STAT512
{
    public class Interpreter
    {
        /// <summary>
        /// The character pattern used to separate elements of the document map.
        /// </summary>
        private string lineSeparator = "@#//";

        /// <summary>
        /// The character pattern used to substitue EOL characters during initial cleanup.
        /// </summary>
        private string tempLineBreak = "@~#CRLF@~#";

        /// <summary>
        /// The Encoding used for reading in files. If not set, the system Default value will be used.
        /// </summary>
        public Encoding FileFormatEncoding { get; set; }

        public FortrasDocument ReadFile(string filePath)
        {
            FileInfo sourceFile = new FileInfo(filePath);
            if (!sourceFile.Exists)
            {
                throw new FileNotFoundException($"Unable to read file {filePath}");
            }

            string body = File.ReadAllText(sourceFile.FullName, (FileFormatEncoding != null ? FileFormatEncoding : Encoding.Default));
            return ReadString(body);
        }

        public FortrasDocument ReadString(string body)
        {
            var fortrasDocument = new FortrasDocument();

            List<string> newLines = new List<string>();

            string lb = Formatting.GetEOLFormat(body);
            if (string.IsNullOrEmpty(lb)) { throw new Exception("The document does not contain any recognisable line break characters!"); }

            // The conversion steps here help remove situations where data fields may contain line breaks that are not the file's EOL character.
            body = body.Replace(lb, tempLineBreak).Replace("\r", "").Replace("\n", "").Replace(tempLineBreak, lb);

            // Break the document into lines.
            string[] lines = body.Trim().Split(new string[] { lb }, StringSplitOptions.None);

            // A Line counter to track our position for logging
            int l = 0;

            // Document conversion requires a number of operational passes.
            // First Pass; check and validate all lines in the file to make sure the lines are expected in the document and build an initial document map.
            // Second Pass; Scan the document map for nested elements and group them together.
            // Third Pass; Populate the document model from the grouped map.

            // First Pass; We loop through the document lines to identify any incorrect lines and add the nesting markup
            List<string> validatedLines = new List<string>();
            foreach (string line in lines)
            {
                l++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    throw new Exception($"Line {l} does not contain any data.");
                }

                string line_header = line.Substring(0, 3);
                if (line.StartsWith("@")) { line_header = line.Substring(0, 4); }

                if (!fortrasDocument.ValidLineIdentifier(line))
                {
                    throw new Exception($"Line {l} has an unrecognised Record Type of [{line_header}].");
                }

                string fortrasPath = fortrasDocument.GetPathToLine(line_header);

                validatedLines.Add($"{fortrasPath}{lineSeparator}{line_header}{lineSeparator}{line.Substring(line_header.Length)}");
            }

            // Second Pass; Create sequential nesting
            List<string> nestedLines = new List<string>();
            Dictionary<string, int> nodeTracker = new Dictionary<string, int>();
            string lastLine = "";
            string lastPath = "";

            // We'll loop through each validated line and check that any "_GROUP" lines are numbered.
            // This will help ensure the finished XML is correctly grouped together.
            foreach (string line in validatedLines)
            {
                string[] chunks = line.Split(new string[] { lineSeparator }, StringSplitOptions.None);
                string line_header = chunks[1];
                string[] nodes = chunks[0].Split('/');

                for (int i = 0; i < nodes.Length; i++)
                {
                    // Prepare any grouping for index values to be added
                    if (nodes[i].ToUpper().Contains("_GROUP"))
                    {
                        if (!nodeTracker.ContainsKey(nodes[i])) { nodeTracker.Add(nodes[i], 0); }
                    }
                    if (nodes[i].Equals(chunks[1]))
                    {
                        if (string.Compare(lastLine, chunks[1], StringComparison.Ordinal) > 0)
                        {
                            string common = fortrasDocument.FindCommonParent(lastPath, nodes);
                            if (!string.IsNullOrEmpty(common)) { nodeTracker[common] += 1; }
                        }
                        else if (lastLine.Equals(chunks[1]))
                        {
                            // If this line is equal to the last, check to see if it should be unique
                            if (fortrasDocument.MaxOccurance(line_header) == 1)
                            {
                                //NOTE: usage of _LAST suffix to cause the two line identifiers to be different to one another,
                                // otherwise the function finds the current node not the parent.
                                string common = fortrasDocument.FindCommonParent($"{lastPath}_LAST", nodes);
                                if (!string.IsNullOrEmpty(common)) { nodeTracker[common] += 1; }
                            }
                        }
                        lastLine = chunks[1];
                        lastPath = chunks[0];
                    }
                }

                // Make sure that all nesting is numbered correctly
                string newGrouping = chunks[0];
                foreach (KeyValuePair<string, int> pair in nodeTracker)
                {
                    newGrouping = newGrouping.Replace(pair.Key, $"{pair.Key}[{pair.Value}]");
                }

                nestedLines.Add(line.Replace(chunks[0], newGrouping));
            }

            // Third Pass; Populate the STAT object from the nested lines
            Dictionary<int, int> consignmentMap = new Dictionary<int, int>();
            Dictionary<int, Dictionary<int, int>> consignmentBarcodesMap = new Dictionary<int, Dictionary<int, int>>();
            foreach (string line in nestedLines)
            {
                try
                {
                    string[] chunks = line.Split(new string[] { lineSeparator }, StringSplitOptions.None);
                    string line_header = chunks[1];
                    string[] nodes = chunks[0].Split('/');

                    if (line_header.Equals("@@PH"))
                    {
                        fortrasDocument.PH.Parse(chunks[2]);
                    }
                    else if (line_header.Equals("Q00"))
                    {
                        fortrasDocument.Q00.Parse(chunks[2]);
                    }
                    else if (line_header.Equals("Z00"))
                    {
                        fortrasDocument.Z00.Parse(chunks[2]);
                    }
                    else if (line_header.Equals("@@PT"))
                    {
                        fortrasDocument.PT.Parse(chunks[2]);
                    }
                    else if (nodes[0].StartsWith("CONSIGNMENT_GROUP"))
                    {
                        int consignment_position = int.Parse(Regex.Match(nodes[0], @"\d+").Value);
                        if (!consignmentMap.ContainsKey(consignment_position)) 
                        {
                            fortrasDocument.CONSIGNMENTS.Add(new CONSIGNMENT());
                            consignmentMap.Add(consignment_position, fortrasDocument.CONSIGNMENTS.Count - 1);
                            consignmentBarcodesMap.Add(consignment_position, new Dictionary<int, int>());
                        }
                        var consignment = fortrasDocument.CONSIGNMENTS[consignmentMap[consignment_position]];

                        if (nodes[1].Equals("Q10"))
                        {
                            consignment.Q10.Parse(chunks[2]);
                        }
                        if (nodes[1].Equals("Q11"))
                        {
                            var q11 = new Models.Q11();
                            q11.Parse(chunks[2]);
                            consignment.Q11.Add(q11);
                        }
                        if (nodes[1].StartsWith("BARCODE_GROUP"))
                        {
                            int barcode_position = int.Parse(Regex.Match(nodes[1], @"\d+").Value);
                            if (!consignmentBarcodesMap[consignment_position].ContainsKey(barcode_position))
                            {
                                consignment.BARCODES.Add(new BARCODE());
                                consignmentBarcodesMap[consignment_position].Add(barcode_position, consignment.BARCODES.Count - 1);
                            }
                            var barcode = consignment.BARCODES[consignmentBarcodesMap[consignment_position][barcode_position]];
                            if (nodes[2].Equals("Q20"))
                            {
                                barcode.Q20.Parse(chunks[2]);
                            }
                            if (nodes[2].Equals("Q30"))
                            {
                                var q30 = new Models.Q30();
                                q30.Parse(chunks[2]);
                                barcode.Q30.Add(q30);
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }

            return fortrasDocument;
        }
    }
}
