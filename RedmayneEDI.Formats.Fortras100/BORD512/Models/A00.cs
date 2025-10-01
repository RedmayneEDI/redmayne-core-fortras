using System.Linq.Expressions;

namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    public class A00
    {
        private int max_length = 427;

        public string Data_Type_Qualifier { get; set; }
        public string Release_Version { get; set; }
        public string Waybill_Number { get; set; }
        public string Waybill_Date { get; set; }
        public string Transport_Type { get; set; }
        public string Product { get; set; }
        public string Code_List { get; set; }
        public string Currency { get; set; }
        public string Waybill_Consignor_ID { get; set; }
        public string Waybill_Consignee_ID { get; set; }
        public string Freight_Operator { get; set; }
        public string Freight_Operator_Country { get; set; }
        public string Freight_Operator_Postcode { get; set; }
        public string Freight_Operator_Town { get; set; }
        public string Vehicle_License_Number_1 { get; set; }
        public string Vehicle_License_Number_2 { get; set; }
        public string Routing_ID_1 { get; set; }
        public string Routing_ID_2 { get; set; }
        public string Test_Code { get; set; }
        public string Arrival_Date { get; set; }
        public string Arrival_Time { get; set; }
        public string Arrival_Time_Qualifier { get; set; }
        public string Traffic_Type_2 { get; set; }
        public string Driver_Name { get; set; }
        public string Driver_Phone { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(A00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(A00)} length is invalid. Maximum length expected after {nameof(A00)} code is {max_length} but processed {line.Trim().Length}"); }
            Data_Type_Qualifier = Formatting.SafeSubstring(line, 0, 3);
            Release_Version = Formatting.SafeSubstring(line, 3, 3);
            Waybill_Number = Formatting.SafeSubstring(line, 6, 35);
            Waybill_Date = Formatting.SafeSubstring(line, 41, 8);
            Transport_Type = Formatting.SafeSubstring(line, 49, 3);
            Product = Formatting.SafeSubstring(line, 52, 3);
            Code_List = Formatting.SafeSubstring(line, 55, 3);
            Currency = Formatting.SafeSubstring(line, 58, 3);
            Waybill_Consignor_ID = Formatting.SafeSubstring(line, 61, 35);
            Waybill_Consignee_ID = Formatting.SafeSubstring(line, 96, 35);
            Freight_Operator = Formatting.SafeSubstring(line, 131, 35);
            Freight_Operator_Country = Formatting.SafeSubstring(line, 166, 3);
            Freight_Operator_Postcode = Formatting.SafeSubstring(line, 169, 9);
            Freight_Operator_Town = Formatting.SafeSubstring(line, 178, 35);
            Vehicle_License_Number_1 = Formatting.SafeSubstring(line, 213, 35);
            Vehicle_License_Number_2 = Formatting.SafeSubstring(line, 248, 35);
            Routing_ID_1 = Formatting.SafeSubstring(line, 283, 35);
            Routing_ID_2 = Formatting.SafeSubstring(line, 318, 35);
            Test_Code = Formatting.SafeSubstring(line, 353, 1);
            Arrival_Date = Formatting.SafeSubstring(line, 354, 8);
            Arrival_Time = Formatting.SafeSubstring(line, 362, 4);
            Arrival_Time_Qualifier = Formatting.SafeSubstring(line, 366, 3);
            Traffic_Type_2 = Formatting.SafeSubstring(line, 369, 3);
            Driver_Name = Formatting.SafeSubstring(line, 372, 35);
            Driver_Phone = Formatting.SafeSubstring(line, 407, 20);
        }

        public override string ToString()
        {
            var line = $"{nameof(A00)}{Formatting.SafeTruncate(Data_Type_Qualifier, 3)}" +
                $"{Formatting.SafeTruncate(Release_Version, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Waybill_Number, 35)}" +
                $"{Formatting.SafeTruncate(Waybill_Date, 8)}" +
                $"{Formatting.SafeTruncate(Transport_Type, 3)}" +
                $"{Formatting.SafeTruncate(Product, 3)}" +
                $"{Formatting.SafeTruncate(Code_List, 3)}" +
                $"{Formatting.SafeTruncate(Currency, 3)}" +
                $"{Formatting.SafeTruncate(Waybill_Consignor_ID, 35)}" +
                $"{Formatting.SafeTruncate(Waybill_Consignee_ID, 35)}" +
                $"{Formatting.SafeTruncate(Freight_Operator, 35)}" +
                $"{Formatting.SafeTruncate(Freight_Operator_Country, 3)}" +
                $"{Formatting.SafeTruncate(Freight_Operator_Postcode, 9)}" +
                $"{Formatting.SafeTruncate(Freight_Operator_Town, 35)}" +
                $"{Formatting.SafeTruncate(Vehicle_License_Number_1, 35)}" +
                $"{Formatting.SafeTruncate(Vehicle_License_Number_2, 35)}" +
                $"{Formatting.SafeTruncate(Routing_ID_1, 35)}" +
                $"{Formatting.SafeTruncate(Routing_ID_2, 35)}" +
                $"{Formatting.SafeTruncate(Test_Code, 1)}" +
                $"{Formatting.SafeTruncate(Arrival_Date, 8)}" +
                $"{Formatting.SafeTruncate(Arrival_Time, 4)}" +
                $"{Formatting.SafeTruncate(Arrival_Time_Qualifier, 3)}" +
                $"{Formatting.SafeTruncate(Traffic_Type_2, 3)}" +
                $"{Formatting.SafeTruncate(Driver_Name, 35)}" +
                $"{Formatting.SafeTruncate(Driver_Phone, 20)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
