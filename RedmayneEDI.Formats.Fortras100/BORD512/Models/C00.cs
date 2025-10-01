namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    /// <summary>
    /// Customs Information for a Consignment.
    /// </summary>
    public class C00
    {
        private int max_length = 237;

        public string Sequential_Waybill_Item { get; set; }
        public string Duty_Payment_Type { get; set; }
        public string Customs_Procedure { get; set; }
        public string Customs_Office { get; set; }
        public string Country_Of_Origin { get; set; }
        public string Country_Of_Loading { get; set; }
        public string Consignor_Country { get; set; }
        public string Destination_Country { get; set; }
        public string Destination_Land { get; set; }
        public string Country_Of_Importer { get; set; }
        public string Statistics_Status { get; set; }
        public string Point_Of_Delivery { get; set; }
        public string Transit_Value { get; set; }
        public string Transit_Value_Currency { get; set; }
        public string Business_Type { get; set; }
        public string Mode_Of_Transport_To_Border { get; set; }
        public string Domestic_Mode_Of_Transport { get; set; }
        public string Customs_Office_Of_Entry { get; set; }
        public string Preceding_Document_Type { get; set; }
        public string Preceding_Document_Number { get; set; }
        public string Appendix_Type_1 { get; set; }
        public string Appendix_Number_1 { get; set; }
        public string Appendix_Date_1 { get; set; }
        public string Appendix_Type_2 { get; set; }
        public string Appendix_Number_2 { get; set; }
        public string Appendix_Date_2 { get; set; }
        public string Appendix_Type_3 { get; set; }
        public string Appendix_Number_3 { get; set; }
        public string Appendix_Date_3 { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(C00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(C00)} length is invalid. Maximum length expected after {nameof(C00)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Duty_Payment_Type = Formatting.SafeSubstring(line, 3, 3);
            Customs_Procedure = Formatting.SafeSubstring(line, 6, 4);
            Customs_Office = Formatting.SafeSubstring(line, 10, 8);
            Country_Of_Origin = Formatting.SafeSubstring(line, 18, 3);
            Country_Of_Loading = Formatting.SafeSubstring(line, 21, 3);
            Consignor_Country = Formatting.SafeSubstring(line, 24, 3);
            Destination_Country = Formatting.SafeSubstring(line, 27, 3);
            Destination_Land = Formatting.SafeSubstring(line, 30, 3);
            Country_Of_Importer = Formatting.SafeSubstring(line, 33, 3);
            Statistics_Status = Formatting.SafeSubstring(line, 36, 3);
            Point_Of_Delivery = Formatting.SafeSubstring(line, 39, 35);
            Transit_Value = Formatting.SafeSubstring(line, 74, 9);
            Transit_Value_Currency = Formatting.SafeSubstring(line, 83, 3);
            Business_Type = Formatting.SafeSubstring(line, 86, 3);
            Mode_Of_Transport_To_Border = Formatting.SafeSubstring(line, 89, 3);
            Customs_Office_Of_Entry = Formatting.SafeSubstring(line, 92, 8);
            Preceding_Document_Type = Formatting.SafeSubstring(line, 100, 10);
            Preceding_Document_Number = Formatting.SafeSubstring(line, 110, 25);
            Appendix_Type_1 = Formatting.SafeSubstring(line, 135, 6);
            Appendix_Number_1 = Formatting.SafeSubstring(line, 141, 20);
            Appendix_Date_1 = Formatting.SafeSubstring(line, 161, 8);
            Appendix_Type_2 = Formatting.SafeSubstring(line, 169, 6);
            Appendix_Number_2 = Formatting.SafeSubstring(line, 175, 20);
            Appendix_Date_2 = Formatting.SafeSubstring(line, 195, 8);
            Appendix_Type_3 = Formatting.SafeSubstring(line, 203, 6);
            Appendix_Number_3 = Formatting.SafeSubstring(line, 209, 20);
            Appendix_Date_3 = Formatting.SafeSubstring(line, 229, 8);
        }

        public override string ToString()
        {
            var line = $"{nameof(C00)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Duty_Payment_Type, 3)}" +
                $"{Formatting.SafeTruncate(Customs_Procedure, 4)}" +
                $"{Formatting.SafeTruncate(Customs_Office, 8)}" +
                $"{Formatting.SafeTruncate(Country_Of_Origin, 3)}" +
                $"{Formatting.SafeTruncate(Country_Of_Loading, 3)}" +
                $"{Formatting.SafeTruncate(Consignor_Country, 3)}" +
                $"{Formatting.SafeTruncate(Destination_Country, 3)}" +
                $"{Formatting.SafeTruncate(Destination_Land, 3)}" +
                $"{Formatting.SafeTruncate(Country_Of_Importer, 3)}" +
                $"{Formatting.SafeTruncate(Statistics_Status, 3)}" +
                $"{Formatting.SafeTruncate(Point_Of_Delivery, 35)}" +
                $"{Formatting.SafeTruncate(Transit_Value, 9)}" +
                $"{Formatting.SafeTruncate(Transit_Value_Currency, 3)}" +
                $"{Formatting.SafeTruncate(Business_Type, 3)}" +
                $"{Formatting.SafeTruncate(Mode_Of_Transport_To_Border, 3)}" +
                $"{Formatting.SafeTruncate(Customs_Office_Of_Entry, 8)}" +
                $"{Formatting.SafeTruncate(Preceding_Document_Type, 10)}" +
                $"{Formatting.SafeTruncate(Preceding_Document_Number, 25)}" +
                $"{Formatting.SafeTruncate(Appendix_Type_1, 6)}" +
                $"{Formatting.SafeTruncate(Appendix_Number_1, 20)}" +
                $"{Formatting.SafeTruncate(Appendix_Date_1, 8)}" +
                $"{Formatting.SafeTruncate(Appendix_Type_2, 6)}" +
                $"{Formatting.SafeTruncate(Appendix_Number_2, 20)}" +
                $"{Formatting.SafeTruncate(Appendix_Date_2, 8)}" +
                $"{Formatting.SafeTruncate(Appendix_Type_3, 6)}" +
                $"{Formatting.SafeTruncate(Appendix_Number_3, 20)}" +
                $"{Formatting.SafeTruncate(Appendix_Date_3, 8)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
