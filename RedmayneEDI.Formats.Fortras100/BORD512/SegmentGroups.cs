using RedmayneEDI.Formats.Fortras100.BORD512.Models;
using System;
using System.Collections.Generic;

namespace RedmayneEDI.Formats.Fortras100.BORD512
{
    /// <summary>
    /// A representation of a Consignment. One unit of work to represent the movement of goods from order origin to destination.
    /// </summary>
    public class CONSIGNMENT
    {
        /// <summary>
        /// A Collection of Addresses relating to the Consignment.
        /// </summary>
        public List<ADDRESS> ADDRESSES { get; set; }
        /// <summary>
        /// A Collection of Customs Information for the Consignment.
        /// </summary>
        public List<C00> C00 { get; set; }
        /// <summary>
        /// A Collection of the item details that make up this Consignment.
        /// </summary>
        public List<CONSIGNMENT_LINE> CONSIGNMENT_LINES { get; set; }
        /// <summary>
        /// Summary information for the Consignment.
        /// </summary>
        public G00 G00 { get; set; }
        /// <summary>
        /// A Collection of free-text information relating to the Consignment.
        /// </summary>
        public TEXT TEXTS { get; set; }
        /// <summary>
        /// Invoicing-related information for the Consignment.
        /// </summary>
        public List<I00> I00 { get; set; }

        public CONSIGNMENT()
        {
            ADDRESSES = new List<ADDRESS>();
            C00 = new List<C00>();
            CONSIGNMENT_LINES = new List<CONSIGNMENT_LINE>();
            G00 = new G00();
            TEXTS = new TEXT();
            I00 = new List<I00>();
        }

        public override string ToString()
        {
            int i = 1;
            foreach (var consignment_line in CONSIGNMENT_LINES)
            {
                consignment_line.SetConsignmentPosition(i++);
            }

            return $"{Formatting.RecordSet<ADDRESS>(ADDRESSES, 999)}" +
                $"{Formatting.RecordSet<C00>(C00, 999)}" +
                $"{Formatting.RecordSet<CONSIGNMENT_LINE>(CONSIGNMENT_LINES, 999)}" +
                $"{G00}" +
                $"{TEXTS}" +
                $"{Formatting.RecordSet<I00>(I00, 9)}";
        }

        public void SetSequentialWaybillItem(int waybillItemNumber)
        {
            foreach (var address in ADDRESSES)
            {
                address.SetSequentialWaybillItem(waybillItemNumber);
            }
            foreach (var c00 in C00)
            {
                c00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
            foreach (var consignment_line in CONSIGNMENT_LINES)
            {
                consignment_line.SetSequentialWaybillItem(waybillItemNumber);
            }
            G00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            TEXTS.SetSequentialWaybillItem(waybillItemNumber);
            foreach (var i00 in I00)
            {
                i00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
        }
    }

    /// <summary>
    /// A representation of an Address for a Consignment.
    /// </summary>
    public class ADDRESS
    {
        /// <summary>
        /// Address information.
        /// </summary>
        public B00 B00 { get; set; }
        /// <summary>
        /// Contact information for the address.
        /// </summary>
        public List<B10> B10 { get; set; }

        public ADDRESS()
        {
            B00 = new B00();
            B10 = new List<B10>();
        }

        public override string ToString()
        {
            return $"{B00}" +
                $"{Formatting.RecordSet<B10>(B10, 9)}";
        }

        public void SetSequentialWaybillItem(int waybillItemNumber)
        {
            B00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            foreach (var b10 in B10)
            {
                b10.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
        }
    }

    /// <summary>
    /// Details of a line item within the Consignment.
    /// </summary>
    public class CONSIGNMENT_LINE 
    {
        public D00 D00 { get; set; }
        public List<D10> D10 { get; set; }
        /// <summary>
        /// Hazardous/ADR information for the Consignment line, if required.
        /// </summary>
        public DANGEROUS_GOODS DANGEROUS_GOODS { get; set; }
        public List<F00> F00 { get; set; }

        public CONSIGNMENT_LINE()
        {
            D00 = new D00();
            D10 = new List<D10>();
            F00 = new List<F00>();
        }

        public override string ToString()
        {
            return $"{D00}" +
                $"{Formatting.RecordSet<D10>(D10, 99)}" +
                $"{DANGEROUS_GOODS}" +
                $"{Formatting.RecordSet<F00>(F00, 999)}";
        }

        public void SetSequentialWaybillItem(int waybillItemNumber)
        {
            D00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            foreach (var d10 in D10)
            {
                d10.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
            if (DANGEROUS_GOODS != null)
            {
                DANGEROUS_GOODS.SetSequentialWaybillItem(waybillItemNumber);
            }
            foreach (var f00 in F00)
            {
                f00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
        }

        public void SetConsignmentPosition(int consignmentPosition)
        {
            D00.Consignment_Position = $"{consignmentPosition}";
            foreach (var d10 in D10)
            {
                d10.Consignment_Position = $"{consignmentPosition}";
            }
            if (DANGEROUS_GOODS != null)
            {
                DANGEROUS_GOODS.SetConsignmentPosition(consignmentPosition);
            }
            foreach (var f00 in F00)
            {
                f00.Consignment_Position = $"{consignmentPosition}";
            }
        }
    }

    /// <summary>
    /// Hazardous/ADR Information structure.
    /// </summary>
    public class DANGEROUS_GOODS
    {
        public List<E00> E00 { get; set; }
        public List<E10> E10 { get; set; }

        public DANGEROUS_GOODS()
        {
            E00 = new List<E00>();
            E10 = new List<E10>();
        }

        public override string ToString()
        {
            return $"{Formatting.RecordSet<E00>(E00, 9)}" +
                $"{Formatting.RecordSet<E10>(E10, 4)}";
        }

        public void SetSequentialWaybillItem(int waybillItemNumber)
        {
            foreach (var e00 in E00)
            {
                e00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
            foreach (var e10 in E10)
            {
                e10.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
        }
        public void SetConsignmentPosition(int consignmentPosition)
        {
            foreach (var e00 in E00)
            {
                e00.Consignment_Position = $"{consignmentPosition}";
            }
            foreach (var e10 in E10)
            {
                e10.Consignment_Position = $"{consignmentPosition}";
            }
        }
    }

    /// <summary>
    /// Free-Text information collection.
    /// </summary>
    public class TEXT 
    {
        public List<H00> H00 { get; set; }
        public List<H10> H10 { get; set; }

        public TEXT()
        {
            H00 = new List<H00>();
            H10 = new List<H10>();
        }

        public override string ToString()
        {
            return $"{Formatting.RecordSet<H00>(H00, 4)}" +
                $"{Formatting.RecordSet<H10>(H10, 9)}";
        }

        public void SetSequentialWaybillItem(int waybillItemNumber)
        {
            foreach (var h00 in H00)
            {
                h00.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
            foreach (var h10 in H10)
            {
                h10.Sequential_Waybill_Item = $"{waybillItemNumber}";
            }
        }
    }
}
