using System.IO;
using Modul2HW5.Configs;
using Modul2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Modul2HW5.Services
{
    public class ConfigService : IConfigService
    {
        public ConfigService()
        {
            Serialization(GetConfig());
            var config = DeSerialization();
            LoggerConfig = config.LoggerConfig;
        }

        public LoggerConfig LoggerConfig { get; set; }
        private Config GetConfig()
        {
            return new Config
            {
                LoggerConfig = new LoggerConfig
                {
                    DirectoryName = @"Logs\",
                    DirectorySize = 3,
                    FileExtension = ".txt"
                }
            };
        }

        private void Serialization(Config newConfig)
        {
            var config = newConfig;
            var json = JsonConvert.SerializeObject(config);
            File.WriteAllText("Config.json", json);
        }

        private Config DeSerialization()
        {
            var readFile = File.ReadAllText("Config.json");
            var config = JsonConvert.DeserializeObject<Config>(readFile);
            return config;
        }
    }
}
