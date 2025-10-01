using RedmayneEDI.Formats.Fortras100.Base;
using RedmayneEDI.Formats.Fortras100.ENTL512.Models;
using System.Collections.Generic;

namespace RedmayneEDI.Formats.Fortras100.ENTL512
{
    public class FortrasDocument
    {
        public PH PH { get; set; }
        public M00 M00 { get; set; }
        public List<LOADING_UNIT> LOADING_UNITS { get; set; }
        public List<N00> N00 { get; set; }
        public List<UEZ> UEZS { get; set; }
        public Z00 Z00 { get; set; }
        public PT PT { get; set; }

        /// <summary>
        /// When enabled, the automatic setting of the SequentialWaybillItem field is ignored.
        /// </summary>
        public bool SkipAutoSequentialWaybillItem { get { return _skipAutoSequentialWaybillItem; } set { _skipAutoSequentialWaybillItem = value; } }
        private bool _skipAutoSequentialWaybillItem = false;

        public FortrasDocument()
        {
            PH = new PH() { Message_Type = "ENTL512" };
            M00 = new M00();
            LOADING_UNITS = new List<LOADING_UNIT>();
            N00 = new List<N00>();
            UEZS = new List<UEZ>();
            Z00 = new Z00();
            PT = new PT();
        }

        public override string ToString()
        {
            // Ensure there's a Carriage return defined
            if (string.IsNullOrWhiteSpace(Formatting.CRLF)) { Formatting.CRLF = "\n"; }

            string output = $"{M00}" +
                $"{Formatting.RecordSet<LOADING_UNIT>(LOADING_UNITS, 999)}" +
                $"{Formatting.RecordSet<N00>(N00, 999)}" +
                $"{Formatting.RecordSet<UEZ>(UEZS, 999)}";

            var lineCount = output.Split(Formatting.CRLF).Length;
            Z00.Total_Number_Of_Data_Records = $"{lineCount}";

            return $"{PH}{output}{Z00}{PT}";
        }

        /// <summary>
        /// Identifies if the given line is valid for the message type.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool ValidLineIdentifier(string line)
        {
            var isValid = false;
            var lineIdentifiers = new List<string>()
            {
                "@@PH", "M00", "M10", "M20", "N00", "O00", "O10", "O20", "Z00", "@@PT"
            };
            foreach (var lineIdentifier in lineIdentifiers)
            {
                if (line.ToUpper().StartsWith(lineIdentifier.ToUpper())) { isValid = true; break; }
            }
            return isValid;
        }

        /// <summary>
        /// Returns the given identifier's document path. Nesting is indicated with a forward slash.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public string GetPathToLine(string identifier)
        {
            switch (identifier)
            {
                case "@@PH":
                case "M00":
                case "N00":
                case "Z00":
                case "@@PT":
                    return identifier;
                case "M10":
                    return "LOADING_UNITS_GROUP/M10";
                case "M20":
                    return "LOADING_UNITS_GROUP/M20";
                case "O00":
                    return "UEZ_GROUP/O00";
                case "O10":
                    return "UEZ_GROUP/O10";
                case "O20":
                    return "UEZ_GROUP/O20";
                default:
                    return string.Empty;
            }

        }

        /// <summary>
        /// Returns the maximum number of repetitions allowed for the given line identifier within the document.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public int MaxOccurance(string identifier)
        {
            switch (identifier)
            {
                case "@@PH":
                case "M00":
                case "M10":
                case "M20":
                case "Z00":
                case "@@PT":
                    return 1;
                case "O00":
                    return 2;
                case "LOADING_UNITS_GROUP":
                case "N00":
                case "UEZ_GROUP":
                case "O10":
                case "O20":
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
