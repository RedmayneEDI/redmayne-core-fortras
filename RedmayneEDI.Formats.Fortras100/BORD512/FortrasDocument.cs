using RedmayneEDI.Formats.Fortras100.Base;
using RedmayneEDI.Formats.Fortras100.BORD512.Models;
using System.Collections.Generic;

namespace RedmayneEDI.Formats.Fortras100.BORD512
{
    public class FortrasDocument
    {
        public PH PH { get; set; }
        public A00 A00 { get; set; }
        public A10 A10 { get; set; }
        public List<CONSIGNMENT> CONSIGNMENTS { get; set; }
        public J00 J00 { get; set; }
        public Z00 Z00 { get; set; }
        public PT PT { get; set; }

        /// <summary>
        /// When enabled, the automatic setting of the SequentialWaybillItem field is ignored.
        /// </summary>
        public bool SkipAutoSequentialWaybillItem { get { return _skipAutoSequentialWaybillItem; } set { _skipAutoSequentialWaybillItem = value; } }
        private bool _skipAutoSequentialWaybillItem = false;

        public FortrasDocument()
        {
            PH = new PH() { Message_Type = "BORD512" };
            A00 = new A00();
            CONSIGNMENTS = new List<CONSIGNMENT>();
            J00 = new J00();
            Z00 = new Z00();
            PT = new PT();
        }

        public override string ToString()
        {
            // Ensure there's a Carriage return defined
            if (string.IsNullOrWhiteSpace(Formatting.CRLF)) { Formatting.CRLF = "\n"; }

            // Apply Sequential Waybill Item Numbers
            if (!_skipAutoSequentialWaybillItem)
            {
                int i = 1;
                foreach (var consignment in CONSIGNMENTS)
                {
                    consignment.SetSequentialWaybillItem(i++);
                }
            }

            string output = $"{A00}" +
                $"{A10}" +
                $"{Formatting.RecordSet<CONSIGNMENT>(CONSIGNMENTS, 999)}" +
                $"{J00}";

            var lineCount = output.Split(Formatting.CRLF).Length;
            Z00.Total_Number_Of_Data_Records = $"{lineCount}";

            return $"{PH}{output}{Z00}{PT}";
        }

        public bool ValidLineIdentifier(string line)
        {
            var isValid = false;
            var lineIdentifiers = new List<string>()
            {
                "@@PH", "A00", "A10", "B00", "B10", "C00", "D00", "D10", "E00", "E10", "F00", "G00", "H00", "H10", "I00", "J00", "Z00", "@@PT"
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
                case "A00":
                case "A10":
                case "J00":
                case "Z00":
                case "@@PT":
                    return identifier;
                case "B00":
                    return "CONSIGNMENT_GROUP/ADDRESS_GROUP/B00";
                case "B10":
                    return "CONSIGNMENT_GROUP/ADDRESS_GROUP/B10";
                case "C00":
                    return "CONSIGNMENT_GROUP/C00";
                case "D00":
                    return "CONSIGNMENT_GROUP/CONSIGNMENT_LINE_GROUP/D00";
                case "D10":
                    return "CONSIGNMENT_GROUP/CONSIGNMENT_LINE_GROUP/D10";
                case "E00":
                    return "CONSIGNMENT_GROUP/CONSIGNMENT_LINE_GROUP/DANGEROUS_GOODS_GROUP/E00";
                case "E10":
                    return "CONSIGNMENT_GROUP/CONSIGNMENT_LINE_GROUP/DANGEROUS_GOODS_GROUP/E10";
                case "F00":
                    return "CONSIGNMENT_GROUP/CONSIGNMENT_LINE_GROUP/F00";
                case "G00":
                    return "CONSIGNMENT_GROUP/G00";
                case "H00":
                    return "CONSIGNMENT_GROUP/TEXTS_GROUP/H00";
                case "H10":
                    return "CONSIGNMENT_GROUP/TEXTS_GROUP/H10";
                case "I00":
                    return "CONSIGNMENT_GROUP/I00";
                default:
                    return string.Empty;
            }

        }

        public int MaxOccurance(string identifier)
        {
            switch (identifier)
            {
                case "@@PH":
                case "A00":
                case "A10":
                case "J00":
                case "Z00":
                case "B00":
                case "D00":
                case "DANGEROUS_GOODS_GROUP":
                case "G00":
                case "TEXTS_GROUP":
                    return 1;
                case "CONSIGNMENT_GROUP":
                case "ADDRESS_GROUP":
                case "C00":
                case "CONSIGNMENT_LINE_GROUP":
                case "F00":
                    return 999;
                case "B10":
                case "E00":
                case "H10":
                case "I00":
                    return 9;
                case "D10":
                    return 99;
                case "E10":
                case "H00":
                    return 4;
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
