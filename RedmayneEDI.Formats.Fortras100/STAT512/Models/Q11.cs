using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.STAT512.Models
{
    public class Q11
    {
        private int max_length = 210;

        public string Additional_Text2 { get; set; }
        public string Additional_Text3 { get; set; }
        public string Additional_Text4 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(Q11))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(Q11)} length is invalid. Maximum length expected after {nameof(Q11)} code is {max_length} but processed {line.Trim().Length}"); }
            Additional_Text2 = Formatting.SafeSubstring(line, 0, 70);
            Additional_Text3 = Formatting.SafeSubstring(line, 70, 70);
            Additional_Text4 = Formatting.SafeSubstring(line, 140, 70);
        }

        public override string ToString()
        {
            var line = $"{nameof(Q11)}{Formatting.SafeTruncate(Additional_Text2, 70)}" +
                $"{Formatting.SafeTruncate(Additional_Text3, 70)}" +
                $"{Formatting.SafeTruncate(Additional_Text4, 70)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
