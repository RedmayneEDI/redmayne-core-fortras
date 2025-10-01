namespace RedmayneEDI.Formats.Fortras100.STAT512.Models
{
    public class Q00
    {
        private int max_length = 181;

        public string Release_Version { get; set; }
        public string Code_List { get; set; }
        public string Sender_ID { get; set; }
        public string Receiver_ID { get; set; }
        public string Causing_Party_ID { get; set; }
        public string Routing_ID_1 { get; set; }
        public string Routing_ID_2 { get; set; }
        
        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(Q00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(Q00)} length is invalid. Maximum length expected after {nameof(Q00)} code is {max_length} but processed {line.Trim().Length}"); }
            Release_Version = Formatting.SafeSubstring(line, 0, 3);
            Code_List = Formatting.SafeSubstring(line, 3, 3);
            Sender_ID = Formatting.SafeSubstring(line, 6, 35);
            Receiver_ID = Formatting.SafeSubstring(line, 41, 35);
            Causing_Party_ID = Formatting.SafeSubstring(line, 76, 35);
            Routing_ID_1 = Formatting.SafeSubstring(line, 111, 35);
            Routing_ID_2 = Formatting.SafeSubstring(line, 146, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(Q00)}{Formatting.SafeTruncate(Release_Version, 3)}" +
                $"{Formatting.SafeTruncate(Code_List, 3)}" +
                $"{Formatting.SafeTruncate(Sender_ID, 35)}" +
                $"{Formatting.SafeTruncate(Receiver_ID, 35)}" +
                $"{Formatting.SafeTruncate(Causing_Party_ID, 35)}" +
                $"{Formatting.SafeTruncate(Routing_ID_1, 35)}" +
                $"{Formatting.SafeTruncate(Routing_ID_2, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
