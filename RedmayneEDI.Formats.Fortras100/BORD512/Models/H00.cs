namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class H00
    {
        private int max_length = 231;

        public string Sequential_Waybill_Item { get; set; }
        public string Text_Code_1 { get; set; }
        public string Additional_Text_1 { get; set; }
        public string Text_Code_2 { get; set; }
        public string Additional_Text_2 { get; set; }
        public string Text_Code_3 { get; set; }
        public string Additional_Text_3 { get; set; }
        public string Text_Code_4 { get; set; }
        public string Additional_Text_4 { get; set; }
        public string Text_Code_5 { get; set; }
        public string Additional_Text_5 { get; set; }
        public string Text_Code_6 { get; set; }
        public string Additional_Text_6 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(H00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(H00)} length is invalid. Maximum length expected after {nameof(H00)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Text_Code_1 = Formatting.SafeSubstring(line, 3, 3);
            Additional_Text_1 = Formatting.SafeSubstring(line, 6, 35);
            Text_Code_2 = Formatting.SafeSubstring(line, 41, 3);
            Additional_Text_2 = Formatting.SafeSubstring(line, 44, 35);
            Text_Code_3 = Formatting.SafeSubstring(line, 79, 3);
            Additional_Text_3 = Formatting.SafeSubstring(line, 82, 35);
            Text_Code_4 = Formatting.SafeSubstring(line, 117, 3);
            Additional_Text_4 = Formatting.SafeSubstring(line, 120, 35);
            Text_Code_5 = Formatting.SafeSubstring(line, 155, 3);
            Additional_Text_5 = Formatting.SafeSubstring(line, 158, 35);
            Text_Code_6 = Formatting.SafeSubstring(line, 193, 3);
            Additional_Text_6 = Formatting.SafeSubstring(line, 196, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(H00)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Text_Code_1, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_1, 35)}" +
                $"{Formatting.SafeTruncate(Text_Code_2, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_2, 35)}" +
                $"{Formatting.SafeTruncate(Text_Code_3, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_3, 35)}" +
                $"{Formatting.SafeTruncate(Text_Code_4, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_4, 35)}" +
                $"{Formatting.SafeTruncate(Text_Code_5, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_5, 35)}" +
                $"{Formatting.SafeTruncate(Text_Code_6, 3)}" +
                $"{Formatting.SafeTruncate(Additional_Text_6, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
