namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    /// <summary>
    /// A model for storing contact information for a Consignment.
    /// </summary>
    public class B10
    {
        private int max_length = 262;

        public string Sequential_Waybill_Item { get; set; }
        public string Communication_Type_Qualifier { get; set; }
        public string Content { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(B10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(B10)} length is invalid. Maximum length expected after {nameof(B10)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Communication_Type_Qualifier = Formatting.SafeSubstring(line, 3, 3);
            Content = Formatting.SafeSubstring(line, 6, 256);
        }

        public override string ToString()
        {
            var line = $"{nameof(B10)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Communication_Type_Qualifier, 3)}" +
                $"{Formatting.SafeTruncate(Content, 256)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
