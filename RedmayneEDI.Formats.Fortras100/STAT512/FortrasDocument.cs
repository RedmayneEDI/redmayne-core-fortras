using RedmayneEDI.Formats.Fortras100.Base;
using RedmayneEDI.Formats.Fortras100.STAT512.Models;
using System.Collections.Generic;

namespace RedmayneEDI.Formats.Fortras100.STAT512
{
    public class FortrasDocument
    {
        public PH PH { get; set; }
        public Q00 Q00 { get; set; }
        public List<CONSIGNMENT> CONSIGNMENTS { get; set; }
        public Z00 Z00 { get; set; }
        public PT PT { get; set; }

        /// <summary>
        /// When enabled, the automatic setting of the SequentialWaybillItem field is ignored.
        /// </summary>
        public bool SkipAutoSequentialWaybillItem { get { return _skipAutoSequentialWaybillItem; } set { _skipAutoSequentialWaybillItem = value; } }
        private bool _skipAutoSequentialWaybillItem = false;

        public FortrasDocument()
        {
            PH = new PH() { Message_Type = "STAT512" };
            Q00 = new Q00();
            CONSIGNMENTS = new List<CONSIGNMENT>();
            Z00 = new Z00();
            PT = new PT();
        }

        public override string ToString()
        {
            // Ensure there's a Carriage return defined
            if (string.IsNullOrWhiteSpace(Formatting.CRLF)) { Formatting.CRLF = "\n"; }

            string output = $"{Q00}" +
                $"{Formatting.RecordSet<CONSIGNMENT>(CONSIGNMENTS, 999)}";

            var lineCount = output.Split(Formatting.CRLF).Length;
            Z00.Total_Number_Of_Data_Records = $"{lineCount}";

            return $"{PH}{output}{Z00}{PT}";
        }

        public bool ValidLineIdentifier(string line)
        {
            var isValid = false;
            var lineIdentifiers = new List<string>()
            {
                "@@PH","Q00","Q10","Q11","Q20","Q30","Z00","@@PT"
            };
            foreach (var lineIdentifier in lineIdentifiers)
            {
                if (line.ToUpper().StartsWith(lineIdentifier.ToUpper())) { isValid = true; break; }
            }
            return isValid;
        }

        public string GetPathToLine(string identifier)
        {
            switch (identifier)
            {
                case "@@PH":
                case "Q00":
                case "Z00":
                case "@@PT":
                    return identifier;
                case "Q10":
                    return "CONSIGNMENT_GROUP/Q10";
                case "Q11":
                    return "CONSIGNMENT_GROUP/Q11";
                case "Q20":
                    return "CONSIGNMENT_GROUP/BARCODE_GROUP/Q20";
                case "Q30":
                    return "CONSIGNMENT_GROUP/BARCODE_GROUP/Q30";
                default:
                    return string.Empty;
            }

        }

        public int MaxOccurance(string identifier)
        {
            switch (identifier)
            {
                case "@@PH":
                case "Q00":
                case "Q10":
                case "Q20":
                case "Z00":
                case "@@PT":
                    return 1;
                case "CONSIGNMENT_GROUP":
                case "Q11":
                case "BARCODE_GROUP":
                case "Q30":
                    return 999;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Tries to locate the common parent between the given last path and the current node path.
        /// </summary>
        /// <param name="lastPath"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public string FindCommonParent(string lastPath, string[] nodes)
        {
            string[] lastNodes = lastPath.Split('/');
            string current = string.Empty;
            for (int i = 0; i < nodes.Length; i++)
            {
                if (lastNodes.Length > i && lastNodes[i] != null)
                {
                    if (lastNodes[i].Equals(nodes[i])) { current = nodes[i]; }
                }
            }
            return current;
        }
    }
}
