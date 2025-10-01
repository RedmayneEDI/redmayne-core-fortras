using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class H10
    {
        private int max_length = 222;

        public string Sequential_Waybill_Item { get; set; }
        public string Qualifier_for_Text_Usage_1 { get; set; }
        public string Any_Text_1 { get; set; }
        public string Qualifier_for_Text_Usage_2 { get; set; }
        public string Any_Text_2 { get; set; }
        public string Qualifier_for_Text_Usage_3 { get; set; }
        public string Any_Text_3 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(H10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(H10)} length is invalid. Maximum length expected after {nameof(H10)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Qualifier_for_Text_Usage_1 = Formatting.SafeSubstring(line, 3, 3);
            Any_Text_1 = Formatting.SafeSubstring(line, 6, 70);
            Qualifier_for_Text_Usage_2 = Formatting.SafeSubstring(line, 76, 3);
            Any_Text_2 = Formatting.SafeSubstring(line, 79, 70);
            Qualifier_for_Text_Usage_3 = Formatting.SafeSubstring(line, 149, 3);
            Any_Text_3 = Formatting.SafeSubstring(line, 152, 70);
        }

        public override string ToString()
        {
            var line = $"{nameof(H10)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Qualifier_for_Text_Usage_1, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_1, 70)}" +
                $"{Formatting.SafeTruncate(Qualifier_for_Text_Usage_2, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_2, 70)}" +
                $"{Formatting.SafeTruncate(Qualifier_for_Text_Usage_3, 3)}" +
                $"{Formatting.SafeTruncate(Any_Text_3, 70)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
