using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CwordTester
{
    class Config
    {

        [JsonProperty("crosswords_folder")]
        public string crosswordsFolder;

        [JsonProperty("reports_folder")]
        public string reportsFolder;

        [JsonIgnore]
        public string configFile;

        private Config()
        {

        }

        public static Config Load(string configFile)
        {
            try
            {
                CreateIfNotExist(configFile);
                var json = File.ReadAllText(configFile);
                var config = JsonConvert.DeserializeObject<Config>(json);
                config.configFile = configFile;
                return config;
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
                return null;
            }
        }

        public void Store()
        {
            var json = JsonConvert.SerializeObject(this);
            File.WriteAllText(configFile, json);
        }

        private static void CreateIfNotExist(string configFile)
        {
            if (!File.Exists(configFile))
            {
                var newConfig = new Config();
                newConfig.configFile = configFile;
                newConfig.crosswordsFolder = Application.StartupPath + "\\" + "crosswords";
                newConfig.reportsFolder = Application.StartupPath + "\\" + "reports";
                newConfig.Store();
            }
        }
    }
}
