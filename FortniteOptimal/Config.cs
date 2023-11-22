using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace FortniteOptimal
{
    public class Config
    {
        private const string ConfigFileName = "config.json";
        private string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);

        public int AutoLaunch { get; set; }
        public int AutoClose { get; set; }
        public int UseCustomSettings { get; set; }
        public string? CustomSetting { get; set; }
        public int UseCustomPrograms { get; set; }
        public List<string> Programs { get; set; } = new List<string>();
        public int KillProcesses { get; set; }
        public int IgnoreErrors { get; set; }
        public List<string> Processes { get; set; } = new List<string>();

        public Config()
        {
            if (File.Exists(configFilePath))
            {
                // Load configuration from the file
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(ConfigFileName, optional: false, reloadOnChange: true)
                    .Build();

                // Bind configuration values to the properties of the Config class
                configuration.Bind(this);
            }
            else
            {
                // If the config file doesn't exist, create a default one
                CreateDefaultConfig(configFilePath);
            }
        }

        private static void CreateDefaultConfig(string configFilePath)
        {
            // Create a default configuration object without causing recursion
            var defaultConfig = new DefaultConfig
            {
                AutoLaunch = 0,
                AutoClose = 0,
                UseCustomSettings = 0,
                CustomSetting = "",
                UseCustomPrograms = 0,
                Programs = new List<string>(),
                KillProcesses = 0,
                IgnoreErrors = 0,
                Processes = new List<string>()
            };

            // Serialize the default configuration to JSON and write it to the file
            var json = JsonConvert.SerializeObject(defaultConfig, Formatting.Indented);
            File.WriteAllText(configFilePath, json);
        }
        public void Save()
        {
            // Serialize the current configuration to JSON
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);

            // Write the JSON to the config file
            File.WriteAllText(configFilePath, json);
        }

        // Need to have a default config to avoid an infinite loop
        private class DefaultConfig
        {
            public int AutoLaunch { get; set; }
            public int AutoClose { get; set; }
            public int UseCustomSettings { get; set; }
            public string? CustomSetting { get; set; }
            public int UseCustomPrograms { get; set; }
            public List<string> Programs { get; set; } = new List<string>();
            public int KillProcesses { get; set; }
            public int IgnoreErrors { get; set; }
            public List<string> Processes { get; set; } = new List<string>();
        }
    }
}