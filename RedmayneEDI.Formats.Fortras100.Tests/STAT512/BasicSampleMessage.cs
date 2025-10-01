using RedmayneEDI.Formats.Fortras100.STAT512;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace RedmayneEDI.Formats.Fortras100.Tests.STAT512
{
    /// <summary>
    /// Generates a sample standard manifest Fortras STAT512 message.
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

            Document.Q00 = new Formats.Fortras100.STAT512.Models.Q00()
            {
                Release_Version = "1",
                Sender_ID = "FORWARDER",
                Receiver_ID = "SHIPPER",
                Code_List = "STD",
                Causing_Party_ID = "DELIVERY"
            };

            Document.CONSIGNMENTS = new System.Collections.Generic.List<CONSIGNMENT>()
            {
                new CONSIGNMENT()
                {
                     Q10 = new Formats.Fortras100.STAT512.Models.Q10()
                     {
                          Event_Date = DateTime.UtcNow.AddHours(-1).ToString("yyyyMMdd"),
                          Event_Time = DateTime.UtcNow.AddHours(-1).ToString("HHmm"),
                          Sender_Shipment_ID = "WAYBILL123456",
                          Receiver_Shipment_ID = "NEWREF2023"
                     },
                     BARCODES = new List<BARCODE>()
                     {
                         new BARCODE()
                         {
                              Q20 = new Formats.Fortras100.STAT512.Models.Q20()
                              {
                                  Barcode = "003123456",
                                  Scan_Code = "DEL",
                                  Scan_Date = DateTime.UtcNow.AddHours(-1).ToString("yyyyMMdd"),
                                  Scan_Time = DateTime.UtcNow.AddHours(-1).ToString("HHmmss")
                              }
                         }
                     }
                },
                new CONSIGNMENT()
                {
                     Q10 = new Formats.Fortras100.STAT512.Models.Q10()
                     {
                          Event_Date = DateTime.UtcNow.ToString("yyyyMMdd"),
                          Event_Time = DateTime.UtcNow.ToString("HHmm"),
                          Sender_Shipment_ID = "WAYBILL123457",
                          Receiver_Shipment_ID = "NEWREF2024"
                     },
                     BARCODES = new List<BARCODE>()
                     {
                         new BARCODE()
                         {
                              Q20 = new Formats.Fortras100.STAT512.Models.Q20()
                              {
                                  Barcode = "003123457",
                                  Scan_Code = "DMG",
                                  Scan_Date = DateTime.UtcNow.ToString("yyyyMMdd"),
                                  Scan_Time = DateTime.UtcNow.ToString("HHmmss")
                              }
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
                var outputFile = Path.Combine(outputDir, "fortras512.stat.sample.txt");
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