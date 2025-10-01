using RedmayneEDI.Formats.Fortras100.BORD512.Models;

namespace RedmayneEDI.Formats.Fortras100.ENTL512.Models
{
    public class M00
    {
        private int max_length = 318;

        public string Data_Type_Qualifier { get; set; }
        public string Release_Version { get; set; }
        public string Waybill_Consignor { get; set; }
        public string Waybill_Consignee { get; set; }
        public string Code_List { get; set; }
        public string Waybill_Number { get; set; }
        public string Waybill_Date { get; set; }
        public string Arrival_Date { get; set; }
        public string Arrival_Time { get; set; }
        public string Time_Limit_Status { get; set; }
        public string Unloading_Start_Date { get; set; }
        public string Unloading_Start_Time { get; set; }
        public string Unloading_End_Date { get; set; }
        public string Unloading_End_Time { get; set; }
        public string Euro_Pallets_Sending_Depot { get; set; }
        public string Box_Pallets_Sending_Depot { get; set; }
        public string Euro_Pallets_Receiving_Depot { get; set; }
        public string Box_Pallets_Receiving_Depot { get; set; }
        public string Unloading_Notes { get; set; }
        public string Routing_ID_1 { get; set; }
        public string Routing_ID_2 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(M00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(M00)} length is invalid. Maximum length expected after {nameof(M00)} code is {max_length} but processed {line.Trim().Length}"); }
            Data_Type_Qualifier = Formatting.SafeSubstring(line,0, 3);
            Release_Version = Formatting.SafeSubstring(line,3, 3);
            Waybill_Consignor = Formatting.SafeSubstring(line,6, 35);
            Waybill_Consignee = Formatting.SafeSubstring(line,41, 35);
            Code_List = Formatting.SafeSubstring(line,76, 3);
            Waybill_Number = Formatting.SafeSubstring(line,79, 35);
            Waybill_Date = Formatting.SafeSubstring(line,114, 8);
            Arrival_Date = Formatting.SafeSubstring(line,122, 8);
            Arrival_Time = Formatting.SafeSubstring(line,130, 4);
            Time_Limit_Status = Formatting.SafeSubstring(line,134, 4);
            Unloading_Start_Date = Formatting.SafeSubstring(line,138, 8);
            Unloading_Start_Time = Formatting.SafeSubstring(line,146, 4);
            Unloading_End_Date = Formatting.SafeSubstring(line,150, 8);
            Unloading_End_Time = Formatting.SafeSubstring(line,158, 4);
            Euro_Pallets_Sending_Depot = Formatting.SafeSubstring(line,162, 4);
            Box_Pallets_Sending_Depot = Formatting.SafeSubstring(line,166, 4);
            Euro_Pallets_Receiving_Depot = Formatting.SafeSubstring(line,170, 4);
            Box_Pallets_Receiving_Depot = Formatting.SafeSubstring(line,174, 4);
            Unloading_Notes = Formatting.SafeSubstring(line,178, 70);
            Routing_ID_1 = Formatting.SafeSubstring(line,248, 35);
            Routing_ID_2 = Formatting.SafeSubstring(line,283, 35);
        }

        public override string ToString()
        {
            var line = $"{nameof(M00)}{Formatting.SafeTruncate(Data_Type_Qualifier, 3)}" +
                $"{Formatting.SafeTruncate(Release_Version, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Waybill_Consignor, 35)}" +
                $"{Formatting.SafeTruncate(Waybill_Consignee, 35)}" +
                $"{Formatting.SafeTruncate(Code_List, 3)}" +
                $"{Formatting.SafeTruncate(Waybill_Number, 35)}" +
                $"{Formatting.SafeTruncate(Waybill_Date, 8)}" +
                $"{Formatting.SafeTruncate(Arrival_Date, 8)}" +
                $"{Formatting.SafeTruncate(Arrival_Time, 4)}" +
                $"{Formatting.SafeTruncate(Time_Limit_Status, 4)}" +
                $"{Formatting.SafeTruncate(Unloading_Start_Date, 8)}" +
                $"{Formatting.SafeTruncate(Unloading_Start_Time, 4)}" +
                $"{Formatting.SafeTruncate(Unloading_End_Date, 8)}" +
                $"{Formatting.SafeTruncate(Unloading_End_Time, 4)}" +
                $"{Formatting.SafeTruncate(Euro_Pallets_Sending_Depot, 4)}" +
                $"{Formatting.SafeTruncate(Box_Pallets_Sending_Depot, 4)}" +
                $"{Formatting.SafeTruncate(Euro_Pallets_Receiving_Depot, 4)}" +
                $"{Formatting.SafeTruncate(Box_Pallets_Receiving_Depot, 4)}" +
                $"{Formatting.SafeTruncate(Unloading_Notes, 70)}" +
                $"{Formatting.SafeTruncate(Routing_ID_1, 35)}" +
                $"{Formatting.SafeTruncate(Routing_ID_2, 35)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
