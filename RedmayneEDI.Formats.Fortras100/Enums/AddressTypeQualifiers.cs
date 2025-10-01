using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.Enums
{
    /// <summary>
    /// An Enum representation of the different Fortras address types.
    /// </summary>
    public enum AddressTypeQualifier
    {
        /// <summary>
        /// The Shipper/Consignor of the consignment.
        /// </summary>
        SHP = 1,
        /// <summary>
        /// The Recipient/Consignee of the consignment.
        /// </summary>
        CON = 2,
        /// <summary>
        /// The location where the consignment will be loaded.
        /// </summary>
        LOA = 4,
        /// <summary>
        /// A Neutral sending address for display to receving parties.
        /// </summary>
        NES = 8,
        /// <summary>
        /// A Neutral receiving address for display to sending parties.
        /// </summary>
        NEC = 16,
        /// <summary>
        /// The Payee of the invoice for the consignment.
        /// </summary>
        INV = 32,
        /// <summary>
        /// The address to which the invoice will be dispatched if different to the payee.
        /// </summary>
        CAD = 64,
        /// <summary>
        /// The Customs Agent or Declarant of the consignment.
        /// </summary>
        ZLA = 128,
        /// <summary>
        /// The Freight Forwarder who will receive the consignment from the Shipper.
        /// </summary>
        DLF = 256,
        /// <summary>
        /// A party that should be notified about this consignment.
        /// </summary>
        NOT = 512,
        /// <summary>
        /// For ABH messages, the ordering party (or customer) placing the collection request.
        /// </summary>
        ORD = 1024,
        /// <summary>
        /// For ABH messages, the ordering partner (or Shipper) raising the collection request on behalf of the customer.
        /// </summary>
        ORP = 2048
    }

    /// <summary>
    /// Constant string representations of the different Fortras address types.
    /// </summary>
    public class AddressTypeQualifiers
    {
        /// <summary>
        /// SHP: The Shipper/Consignor of the consignment.
        /// </summary>
        public static string Shipper = "SHP";
        /// <summary>
        /// CON: The Recipient/Consignee of the consignment.
        /// </summary>
        public static string Consignee = "CON";
        /// <summary>
        /// LOA: The location where the consignment will be loaded.
        /// </summary>
        public static string LoadingPoint = "LOA";
        /// <summary>
        /// NES: A Neutral sending address for display to receving parties.
        /// </summary>
        public static string NeutralSender = "NES";
        /// <summary>
        /// NEC: A Neutral receiving address for display to sending parties.
        /// </summary>
        public static string NeutralConsignee = "NEC";
        /// <summary>
        /// INV: The Payee of the invoice for the consignment.
        /// </summary>
        public static string InvoicePayee = "INV";
        /// <summary>
        /// CAD: The address to which the invoice will be dispatched if different to the payee.
        /// </summary>
        public static string InvoiceAddress = "CAD";
        /// <summary>
        /// ZLA: The Customs Agent or Declarant of the consignment.
        /// </summary>
        public static string CustomsDeclarant = "ZLA";
        /// <summary>
        /// DLF: The Freight Forwarder who will receive the consignment from the Shipper.
        /// </summary>
        public static string FreightForwarder = "DLF";
        /// <summary>
        /// NOT: A party that should be notified about this consignment.
        /// </summary>
        public static string NotifyParty = "NOT";
        /// <summary>
        /// ORD: For ABH messages, the ordering party (or customer) placing the collection request.
        /// </summary>
        public static string OrderingParty = "ORD";
        /// <summary>
        /// ORP: For ABH messages, the ordering partner (or Shipper) raising the collection request on behalf of the customer.
        /// </summary>
        public static string OrderingPartner = "ORP";
    }
}
