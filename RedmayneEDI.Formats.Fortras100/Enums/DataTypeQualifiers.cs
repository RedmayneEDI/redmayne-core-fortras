using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.Enums
{
    /// <summary>
    /// An Enum representation of Fortras Bordero message types.
    /// </summary>
    public enum DataTypeQualifer
    {
        /// <summary>
        /// Standard Manifest Message. 
        /// </summary>
        STD = 1,
        /// <summary>
        /// Abholung Collection Request Message.
        /// </summary>
        ABH = 2
    }

    /// <summary>
    /// Constant string representation of Fortras Bordero message types.
    /// </summary>
    public class DataTypeQualifiers
    {
        /// <summary>
        /// Standard Manifest Message. 
        /// The Consignments are live in-transit between origin and destination.
        /// </summary>
        public const string Standard = "STD";
        /// <summary>
        /// Collection Request Message. 
        /// The Consignments are not yet collected, and collection should be arranged based on the information in the message.
        /// </summary>
        public const string Abholung = "ABH";
    }
}
