namespace RedmayneEDI.Formats.Fortras100.Base
{
    /// <summary>
    /// The Fortras format initial document header.
    /// </summary>
    public class PH
    {
        public string Message_Type { get; set; }
        public string HEADER { get; set; }
        /// <summary>
        /// The Sending Party identifier. Usually pre-agreed with the partner.
        /// </summary>
        public string Sending_Party { get; set; }
        /// <summary>
        /// The Receiving Party identifier. Usually pre-agreed with the partner.
        /// </summary>
        public string Receiving_Party { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith($"@@{nameof(PH)}")) { line = line.Substring(4); }
            Message_Type = Formatting.SafeSubstring(line, 0, 8);
            HEADER = Formatting.SafeSubstring(line, 8, 14);
            Sending_Party = Formatting.SafeSubstring(line, 22, 8);
            Receiving_Party = Formatting.SafeSubstring(line, 30, 8);
        }

        public override string ToString()
        {
            return $"@@{nameof(PH)}{Formatting.SafeTruncate(Message_Type, 8)}" +
                $"{Formatting.SafeTruncate(HEADER, 14)}" +
                $"{Formatting.SafeTruncate(Sending_Party, 8)}" +
                $"{Formatting.SafeTruncate(Receiving_Party, 8)}" +
                $"{Formatting.CRLF}";
        }
    }
}
