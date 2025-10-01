using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.Base
{
    /// <summary>
    /// The Fortras message summary line that tails the body of all messages.
    /// </summary>
    public class Z00
    {
        /// <summary>
        /// The total number of valid lines within the document, excluding @@ and Z lines.
        /// </summary>
        public string Total_Number_Of_Data_Records { get; set; }
        /// <summary>
        /// The date the message was created on, in DDMMYYYY format.
        /// </summary>
        public string Date_Of_Creation_DDMMYYYY { get; set; }
        /// <summary>
        /// The Time of the message creation, in HHMMSS format.
        /// </summary>
        public string Time_Of_Creation_HHMMSS { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith($"{nameof(Z00)}")) { line = line.Substring(3); }
            Total_Number_Of_Data_Records = Formatting.SafeSubstring(line, 0, 6);
            Date_Of_Creation_DDMMYYYY = Formatting.SafeSubstring(line, 6, 8);
            Time_Of_Creation_HHMMSS = Formatting.SafeSubstring(line, 14, 6);
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Date_Of_Creation_DDMMYYYY)) { Date_Of_Creation_DDMMYYYY = DateTime.UtcNow.ToString("ddMMyyyy"); }
            if (string.IsNullOrWhiteSpace(Time_Of_Creation_HHMMSS)) { Time_Of_Creation_HHMMSS = DateTime.UtcNow.ToString("HHmmss"); }

            return $"{nameof(Z00)}{Formatting.SafeTruncate(Total_Number_Of_Data_Records, 6, '0', true)}" +
                $"{Formatting.SafeTruncate(Date_Of_Creation_DDMMYYYY, 8)}" +
                $"{Formatting.SafeTruncate(Time_Of_Creation_HHMMSS, 6)}" +
                $"{Formatting.CRLF}";
        }
    }
}
