using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace modul8_103082400036
{
    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    // Class menampung "confirmation"
    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    // Class utama untuk JSON
    public class ConfigData
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }
    }

    public class BankTransferConfig
    {
        public ConfigData config;
        private const string filePath = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<ConfigData>(configJsonData);
        }

        private void SetDefault()
        {
            // Set nilai default 
            config = new ConfigData();
            config.lang = "en";

            config.transfer = new Transfer();
            config.transfer.threshold = 25000000;
            config.transfer.low_fee = 6500;
            config.transfer.high_fee = 15000;

            config.methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };

            config.confirmation = new Confirmation();
            config.confirmation.en = "yes";
            config.confirmation.id = "ya";
        }

        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
