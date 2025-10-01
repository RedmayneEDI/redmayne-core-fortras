using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.STAT512.Models
{
    public class Q10
    {
        private int max_length = 276;

        public string Sender_Shipment_ID { get; set; }
        public string Receiver_Shipment_ID { get; set; }
        public string Pick_Up_Order_No { get; set; }
        public string Status_Code { get; set; }
        public string Event_Date { get; set; }
        public string Event_Time { get; set; }
        public string Shipment_No { get; set; }
        public string Wait_Time { get; set; }
        public string Acknowledging_Party { get; set; }
        public string Additional_Text { get; set; }
        public string Reference_No { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(Q10))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(Q10)} length is invalid. Maximum length expected after {nameof(Q10)} code is {max_length} but processed {line.Trim().Length}"); }
            Sender_Shipment_ID = Formatting.SafeSubstring(line, 0, 35);
            Receiver_Shipment_ID = Formatting.SafeSubstring(line, 35, 35);
            Pick_Up_Order_No = Formatting.SafeSubstring(line, 70, 35);
            Status_Code = Formatting.SafeSubstring(line, 105, 3);
            Event_Date = Formatting.SafeSubstring(line, 108, 8);
            Event_Time = Formatting.SafeSubstring(line, 116, 4);
            Shipment_No = Formatting.SafeSubstring(line, 120, 35);
            Wait_Time = Formatting.SafeSubstring(line, 155, 4);
            Acknowledging_Party = Formatting.SafeSubstring(line, 159, 35);
            Additional_Text = Formatting.SafeSubstring(line, 194, 70);
            Reference_No = Formatting.SafeSubstring(line, 264, 12);
        }

        public override string ToString()
        {
            var line = $"{nameof(Q10)}{Formatting.SafeTruncate(Sender_Shipment_ID, 35)}" +
                $"{Formatting.SafeTruncate(Receiver_Shipment_ID, 35)}" +
                $"{Formatting.SafeTruncate(Pick_Up_Order_No, 35)}" +
                $"{Formatting.SafeTruncate(Status_Code, 3)}" +
                $"{Formatting.SafeTruncate(Event_Date, 8)}" +
                $"{Formatting.SafeTruncate(Event_Time, 4)}" +
                $"{Formatting.SafeTruncate(Shipment_No, 35)}" +
                $"{Formatting.SafeTruncate(Wait_Time, 4)}" +
                $"{Formatting.SafeTruncate(Acknowledging_Party, 35)}" +
                $"{Formatting.SafeTruncate(Additional_Text, 70)}" +
                $"{Formatting.SafeTruncate(Reference_No, 12)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
