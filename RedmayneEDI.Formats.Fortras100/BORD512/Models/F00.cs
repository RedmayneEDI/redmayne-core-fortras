namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class F00
    {
        private int max_length = 231;

        public string Sequential_Waybill_Item { get; set; }
        public string Consignment_Position { get; set; }
        public string Barcode { get; set; }
        public string Reference_Qualifier_1 { get; set; }
        public string Reference_Number_1 { get; set; }
        public string Reference_Qualifier_2 { get; set; }
        public string Reference_Number_2 { get; set; }
        public string Reference_Qualifier_3 { get; set; }
        public string Reference_Number_3 { get; set; }
        public string Reference_Qualifier_4 { get; set; }
        public string Reference_Number_4 { get; set; }
        public string Reference_Qualifier_5 { get; set; }
        public string Reference_Number_5 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(F00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(F00)} length is invalid. Maximum length expected after {nameof(F00)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Consignment_Position = Formatting.SafeSubstring(line, 3, 3);
            Barcode = Formatting.SafeSubstring(line, 6, 35);
            Reference_Qualifier_1 = Formatting.SafeSubstring(line, 41, 3);
            Reference_Number_1 = Formatting.SafeSubstring(line, 44, 35);
            Reference_Qualifier_2 = Formatting.SafeSubstring(line, 79, 3);
            Reference_Number_2 = Formatting.SafeSubstring(line, 82, 35);
            Reference_Qualifier_3 = Formatting.SafeSubstring(line, 117, 3);
            Reference_Number_3 = Formatting.SafeSubstring(line, 120, 35);
            Reference_Qualifier_4 = Formatting.SafeSubstring(line, 155, 3);
            Reference_Number_4 = Formatting.SafeSubstring(line, 158, 35);
            Reference_Qualifier_5 = Formatting.SafeSubstring(line, 193, 3);
            Reference_Number_5 = Formatting.SafeSubstring(line, 196, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(F00)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Consignment_Position, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Barcode, 35)}" +
                $"{Formatting.SafeTruncate(Reference_Qualifier_1, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Number_1, 35)}" +
                $"{Formatting.SafeTruncate(Reference_Qualifier_2, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Number_2, 35)}" +
                $"{Formatting.SafeTruncate(Reference_Qualifier_3, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Number_3, 35)}" +
                $"{Formatting.SafeTruncate(Reference_Qualifier_4, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Number_4, 35)}" +
                $"{Formatting.SafeTruncate(Reference_Qualifier_5, 3)}" +
                $"{Formatting.SafeTruncate(Reference_Number_5, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
