namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class E10
    {
        private int max_length = 371;

        public string Sequential_Waybill_Item { get; set; }
        public string Consignment_Position { get; set; }
        public string Qualifier_For_Text_Usage_1 { get; set; }
        public string Any_Text_1 { get; set; }
        public string Qualifier_For_Text_Usage_2 { get; set; }
        public string Any_Text_2 { get; set; }
        public string Qualifier_For_Text_Usage_3 { get; set; }
        public string Any_Text_3 { get; set; }
        public string Qualifier_For_Text_Usage_4 { get; set; }
        public string Any_Text_4 { get; set; }
        public string Qualifier_For_Text_Usage_5 { get; set; }
        public string Any_Text_5 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(E10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(E10)} length is invalid. Maximum length expected after {nameof(E10)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Consignment_Position = Formatting.SafeSubstring(line, 3, 3);
            Qualifier_For_Text_Usage_1 = Formatting.SafeSubstring(line, 6, 3);
            Any_Text_1 = Formatting.SafeSubstring(line, 9, 70);
            Qualifier_For_Text_Usage_2 = Formatting.SafeSubstring(line, 79, 3);
            Any_Text_2 = Formatting.SafeSubstring(line, 82, 70);
            Qualifier_For_Text_Usage_3 = Formatting.SafeSubstring(line, 152, 3);
            Any_Text_3 = Formatting.SafeSubstring(line, 155, 70);
            Qualifier_For_Text_Usage_4 = Formatting.SafeSubstring(line, 225, 3);
            Any_Text_4 = Formatting.SafeSubstring(line, 228, 70);
            Qualifier_For_Text_Usage_5 = Formatting.SafeSubstring(line, 298, 3);
            Any_Text_5 = Formatting.SafeSubstring(line, 301, 70);
        }

        public override string ToString()
        {
            return $"{nameof(E10)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Consignment_Position, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Qualifier_For_Text_Usage_1, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_1, 70)}" +
                $"{Formatting.SafeTruncate(Qualifier_For_Text_Usage_2, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_2, 70)}" +
                $"{Formatting.SafeTruncate(Qualifier_For_Text_Usage_3, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_3, 70)}" +
                $"{Formatting.SafeTruncate(Qualifier_For_Text_Usage_4, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_4, 70)}" +
                $"{Formatting.SafeTruncate(Qualifier_For_Text_Usage_5, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_5, 70)}" +
                $"{Formatting.CRLF}";
        }
    }
}
