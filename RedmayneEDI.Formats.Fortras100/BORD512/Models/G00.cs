namespace RedmayneEDI.Formats.Fortras100.BORD512.Models
{
    /// <summary>
    /// Consignment summary details
    /// </summary>
    public class G00
    {
        private int max_length = 235;

        public string Sequential_Waybill_Item { get; set; }
        public string Consignment_Number_Sending_Depot { get; set; }
        public string Actual_Consignment_Gross_Weight_In_Grams { get; set; }
        public string Delivery_Terms { get; set; }
        public string Direct_Delivery { get; set; }
        public string Pickup_Date { get; set; }
        public string Pickup_Time_From_HHMM { get; set; }
        public string Pickup_Time_To_HHMM { get; set; }
        public string Logistics_Model { get; set; }
        public string Consignment_Number_For_Receiving_Depot { get; set; }
        public string Consignor_ID_Original_Waybill { get; set; }
        public string Consignee_ID_Original_Waybill { get; set; }
        public string Material_Group { get; set; }
        public string Goods_Value { get; set; }
        public string Goods_Value_Currency { get; set; }
        public string Chargeable_Consignment_Weight_In_Grams { get; set; }
        public string Cubic_Metres { get; set; }
        public string Loading_Metres { get; set; }
        public string Number_Of_Pallet_Locations { get; set; }
        public string Number_Of_Additional_Loading_Tools_1 { get; set; }
        public string Packaging_Type_For_Additional_Loading_Tools_1 { get; set; }
        public string Number_Of_Additional_Loading_Tools_2 { get; set; }
        public string Packaging_Type_For_Additional_Loading_Tools_2 { get; set; }
        public string Direct_Pickup_Code { get; set; }
        public string Order_Date_TTMMJJJJ { get; set; }

        public void Parse(string rawText)
        {
            var line = rawText;
            if (line.ToUpper().StartsWith(nameof(G00))) { line = line.Substring(3); }
            if (line.Trim().Length > max_length) { throw new System.Exception($"{nameof(G00)} length is invalid. Maximum length expected after {nameof(G00)} code is {max_length} but processed {line.Trim().Length}"); }
            Sequential_Waybill_Item = Formatting.SafeSubstring(line, 0, 3);
            Consignment_Number_Sending_Depot = Formatting.SafeSubstring(line, 3, 35);
            Actual_Consignment_Gross_Weight_In_Grams = Formatting.SafeSubstring(line, 38, 9);
            Delivery_Terms = Formatting.SafeSubstring(line, 47, 3);
            Direct_Delivery = Formatting.SafeSubstring(line, 50, 1);
            Pickup_Date = Formatting.SafeSubstring(line, 51, 8);
            Pickup_Time_From_HHMM = Formatting.SafeSubstring(line, 59, 4);
            Pickup_Time_To_HHMM = Formatting.SafeSubstring(line, 63, 4);
            Logistics_Model = Formatting.SafeSubstring(line, 67, 6);
            Consignment_Number_For_Receiving_Depot = Formatting.SafeSubstring(line, 73, 35);
            Consignor_ID_Original_Waybill = Formatting.SafeSubstring(line, 108, 35);
            Consignee_ID_Original_Waybill = Formatting.SafeSubstring(line, 143, 35);
            Material_Group = Formatting.SafeSubstring(line, 178, 3);
            Goods_Value = Formatting.SafeSubstring(line, 181, 11);
            Goods_Value_Currency = Formatting.SafeSubstring(line, 192, 3);
            Chargeable_Consignment_Weight_In_Grams = Formatting.SafeSubstring(line, 195, 9);
            Cubic_Metres = Formatting.SafeSubstring(line, 204, 5);
            Loading_Metres = Formatting.SafeSubstring(line, 209, 3);
            Number_Of_Pallet_Locations = Formatting.SafeSubstring(line, 212, 4);
            Number_Of_Additional_Loading_Tools_1 = Formatting.SafeSubstring(line, 216, 2);
            Packaging_Type_For_Additional_Loading_Tools_1 = Formatting.SafeSubstring(line, 218, 3);
            Number_Of_Additional_Loading_Tools_2 = Formatting.SafeSubstring(line, 221, 2);
            Packaging_Type_For_Additional_Loading_Tools_2 = Formatting.SafeSubstring(line, 223, 3);
            Direct_Pickup_Code = Formatting.SafeSubstring(line, 226, 1);
            Order_Date_TTMMJJJJ = Formatting.SafeSubstring(line, 227, 8);
        }

        public override string ToString()
        {
            var line = $"{nameof(G00)}{Formatting.SafeTruncate(Sequential_Waybill_Item, 3, '0', true)}" +
                $"{Formatting.SafeTruncate(Consignment_Number_Sending_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Actual_Consignment_Gross_Weight_In_Grams, 9, '0', true)}" +
                $"{Formatting.SafeTruncate(Delivery_Terms, 3)}" +
                $"{Formatting.SafeTruncate(Direct_Delivery, 1)}" +
                $"{Formatting.SafeTruncate(Pickup_Date, 8)}" +
                $"{Formatting.SafeTruncate(Pickup_Time_From_HHMM, 4)}" +
                $"{Formatting.SafeTruncate(Pickup_Time_To_HHMM, 4)}" +
                $"{Formatting.SafeTruncate(Logistics_Model, 6)}" +
                $"{Formatting.SafeTruncate(Consignment_Number_For_Receiving_Depot, 35)}" +
                $"{Formatting.SafeTruncate(Consignor_ID_Original_Waybill, 35)}" +
                $"{Formatting.SafeTruncate(Consignee_ID_Original_Waybill, 35)}" +
                $"{Formatting.SafeTruncate(Material_Group, 3)}" +
                $"{Formatting.SafeTruncate(Goods_Value, 11, '0', true)}" +
                $"{Formatting.SafeTruncate(Goods_Value_Currency, 3)}" +
                $"{Formatting.SafeTruncate(Chargeable_Consignment_Weight_In_Grams, 9, '0', true)}" +
                $"{Formatting.SafeTruncate(Cubic_Metres, 5, '0', true)}" +
                $"{Formatting.SafeTruncate(Loading_Metres, 3)}" +
                $"{Formatting.SafeTruncate(Number_Of_Pallet_Locations, 4)}" +
                $"{Formatting.SafeTruncate(Number_Of_Additional_Loading_Tools_1, 2)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_For_Additional_Loading_Tools_1, 3)}" +
                $"{Formatting.SafeTruncate(Number_Of_Additional_Loading_Tools_2, 2)}" +
                $"{Formatting.SafeTruncate(Packaging_Type_For_Additional_Loading_Tools_2, 3)}" +
                $"{Formatting.SafeTruncate(Direct_Pickup_Code, 1)}" +
                $"{Formatting.SafeTruncate(Order_Date_TTMMJJJJ, 8)}" +
                $"{Formatting.CRLF}";
            if (Formatting.TrimLines) { line = line.Trim() + $"{Formatting.CRLF}"; }
            return line;
        }
    }
}
