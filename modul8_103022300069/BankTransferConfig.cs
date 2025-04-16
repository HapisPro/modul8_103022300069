using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace modul8_103022300069
{
        public class Transfer
        {
            public double treshold { get; set; }
            public double low_fee { get; set; }
            public double high_fee { get; set; }
        }
        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }

        class BankTransferConfig
        {
            public string lang { get; set; }
            public Transfer transfer {  get; set; }
            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }

            string path = Path.GetFullPath("../../../../datas/bank_transfer_config.json");

            public BankTransferConfig()
                {
                try
                {
                    ReadConfigFile();
                }
                catch {
                    setDefault();
                    WriteNewConfigFile();
                }
            }

            public void setDefault()
            {
                this.lang = "en";
                this.transfer.treshold = 25000000;
                this.transfer.low_fee = 6500;
                this.transfer.high_fee = 15000;
                this.methods = new List<string>();
                methods.Add("RTO(real - time)");
                methods.Add("SKN");
                methods.Add("RTGS");
                methods.Add("BI FAST");
                this.confirmation.en = "yes";
                this.confirmation.id = "ya";
            }

            public BankTransferConfig ReadConfigFile()
            {
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<BankTransferConfig>(jsonString);
            }
        
            public void WriteNewConfigFile()
            {
                BankTransferConfig config = new BankTransferConfig();
                string jsonString = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, jsonString);
            }

            public void ubahBahasa()
            {
                lang = lang == "en" ? "id" : "en";
                WriteNewConfigFile(this);
            }
    }
}
