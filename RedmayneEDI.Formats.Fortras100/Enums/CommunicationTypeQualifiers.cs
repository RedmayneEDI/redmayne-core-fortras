using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.Enums
{
    /// <summary>
    /// An Enum representation of the different Fortras communication properties.
    /// </summary>
    public enum CommunicationTypeQualifier
    {
        /// <summary>
        /// Contact name
        /// </summary>
        KPE = 1,
        /// <summary>
        /// Telephone number
        /// </summary>
        TEL = 2,
        /// <summary>
        /// Email Address
        /// </summary>
        EML = 4
    }

    /// <summary>
    /// Constant string representations of the different Fortras communication properties.
    /// </summary>
    public class CommunicationTypeQualifiers
    {
        /// <summary>
        /// KPE: Indicates that this field is the Name of the contact point
        /// </summary>
        public static string Name = "KPE";
        /// <summary>
        /// TEL: This field is a telephone number.
        /// </summary>
        public static string Telephone = "TEL";
        /// <summary>
        /// EML: The data in this field is an email address.
        /// </summary>
        public static string Email = "EML";
    }
}
