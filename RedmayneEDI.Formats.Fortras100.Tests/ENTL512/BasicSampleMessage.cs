using RedmayneEDI.Formats.Fortras100.ENTL512;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RedmayneEDI.Formats.Fortras100.Tests.ENTL512
{
    /// <summary>
    /// Generates a sample standard manifest Fortras ENTL512 message.
    /// </summary>
    public class BasicSampleMessage
    {
        public FortrasDocument Document { get; set; }

        public BasicSampleMessage()
        {
            Document = new FortrasDocument();

            // Send the Sending and Receiving Party ID's
            Document.PH.Sending_Party = "FORWARDER";
            Document.PH.Receiving_Party = "SHIPPER";

            Document.M00 = new Formats.Fortras100.ENTL512.Models.M00()
            {
                Release_Version = "1",
                Waybill_Consignor = "FORWARDER",
                Waybill_Consignee = "SHIPPER",
                Code_List = "STD",
                Arrival_Date = DateTime.UtcNow.AddHours(-6).ToString("ddMMyyyy"),
                Arrival_Time = DateTime.UtcNow.AddHours(-6).ToString("HHmm"),
                Data_Type_Qualifier = "STD",
                Unloading_Start_Date = DateTime.UtcNow.AddHours(-1).ToString("ddMMyyyy"),
                Unloading_Start_Time = DateTime.UtcNow.AddHours(-1).ToString("HHmm")
            };

            Document.LOADING_UNITS = new System.Collections.Generic.List<LOADING_UNIT>()
            {
                new LOADING_UNIT()
                {
                     M10 = new Formats.Fortras100.ENTL512.Models.M10()
                     {
                         Loading_Unit_Number = "1",
                         Condition_Of_Loading_Unit_1 = "OK",
                         Additional_Text_1 = "ITEM UNLOADED"
                     },
                     M20 = new Formats.Fortras100.ENTL512.Models.M20()
                     {
                         Lead_Seal_Number_1 = "SEAL1",
                         Condition_Lead_Seal_Number_1 = "OK"
                     }
                },
                new LOADING_UNIT()
                {
                     M10 = new Formats.Fortras100.ENTL512.Models.M10()
                     {
                         Loading_Unit_Number = "2",
                         Condition_Of_Loading_Unit_1 = "OK",
                         Additional_Text_1 = "ITEM UNLOADED"
                     },
                     M20 = new Formats.Fortras100.ENTL512.Models.M20()
                     {
                         Lead_Seal_Number_1 = "SEAL1",
                         Condition_Lead_Seal_Number_1 = "OK"
                     }
                }
            };
            Document.N00 = new List<Formats.Fortras100.ENTL512.Models.N00>()
            {
                new Formats.Fortras100.ENTL512.Models.N00()
                {
                    Waybill_Number_Sending_Depot = "WAYBILL123456",
                    Sequential_Waybill_Item = "1",
                    Status_Code_1 = "OK",
                    Packaging_Type_1 = "PX",
                    Text_Notes_1 = "UNLOADED OK"
                }
            };
            Document.UEZS = new List<UEZ>()
            {
                new UEZ()
                {
                     O20 = new List<Formats.Fortras100.ENTL512.Models.O20>()
                     {
                         new Formats.Fortras100.ENTL512.Models.O20()
                         {
                             Preliminary_Consignment_No_Receiving_Depot = "1",
                             Barcode_1 = "03123456",
                             Error_Message_Code_1 = "OK",
                             Additional_Text_1 = "SCANNED INTO WAREHOUSE"
                         },
                         new Formats.Fortras100.ENTL512.Models.O20()
                         {
                             Preliminary_Consignment_No_Receiving_Depot = "1",
                             Barcode_1 = "03123457",
                             Error_Message_Code_1 = "OK",
                             Additional_Text_1 = "SCANNED INTO WAREHOUSE"
                         }
                     }
                }
            };

        }

        public string CreateMessage(string outputDir = "")
        {
            // Create the output directory if provided and it doesn't exist.
            if (!string.IsNullOrWhiteSpace(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                var outputFile = Path.Combine(outputDir, "fortras512.entl.sample.txt");
                File.WriteAllText(outputFile, Document.ToString());
                System.Console.WriteLine($"Created {outputFile}");
                return outputFile;
            }
            else
            {
                System.Console.WriteLine(Document.ToString());
                return Document.ToString();
            }
        }
    }
}
