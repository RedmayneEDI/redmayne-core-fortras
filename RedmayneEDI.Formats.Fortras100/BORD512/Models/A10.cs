namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class A10
    {
        private int max_length = 350;

        public string Loading_Units_1 { get; set; }
        public string Lead_Seal_1 { get; set; }
        public string Lead_Seal_2 { get; set; }
        public string Lead_Seal_3 { get; set; }
        public string Lead_Seal_4 { get; set; }
        public string Loading_Units_2 { get; set; }
        public string Lead_Seal2_1 { get; set; }
        public string Lead_Seal2_2 { get; set; }
        public string Lead_Seal2_3 { get; set; }
        public string Lead_Seal2_4 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(A10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(A10)} length is invalid. Maximum length expected after {nameof(A10)} code is {max_length} but processed {line.Trim().Length}"); }
            Loading_Units_1 = Formatting.SafeSubstring(line, 0, 35);
            Lead_Seal_1 = Formatting.SafeSubstring(line, 35, 35);
            Lead_Seal_2 = Formatting.SafeSubstring(line, 70, 35);
            Lead_Seal_3 = Formatting.SafeSubstring(line, 105, 35);
            Lead_Seal_4 = Formatting.SafeSubstring(line, 140, 35);
            Loading_Units_2 = Formatting.SafeSubstring(line, 175, 35);
            Lead_Seal2_1 = Formatting.SafeSubstring(line, 210, 35);
            Lead_Seal2_2 = Formatting.SafeSubstring(line, 245, 35);
            Lead_Seal2_3 = Formatting.SafeSubstring(line, 280, 35);
            Lead_Seal2_4 = Formatting.SafeSubstring(line, 315, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(A10)}{Formatting.SafeTruncate(Loading_Units_1, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal_1, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal_2, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal_3, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal_4, 35)}" +
                $"{Formatting.SafeTruncate(Loading_Units_2, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal2_1, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal2_2, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal2_3, 35)}" +
                $"{Formatting.SafeTruncate(Lead_Seal2_4, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
