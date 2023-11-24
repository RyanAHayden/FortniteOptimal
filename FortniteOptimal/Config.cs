using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace FortniteOptimal
{
    public class Config : IDisposable
    {
        private const string ConfigFileName = "config.json";
        private string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
        private bool disposed = false;

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
                using (var stream = new FileStream(ConfigFileName, FileMode.Open, FileAccess.Read))
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonStream(stream)
                        .Build();

                    // Bind configuration values to the properties of the Config class
                    configuration.Bind(this);
                }
            }
            else
            {
                // If the config file doesn't exist, create a default one
                CreateDefaultConfig(configFilePath);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources (if any)
                    // For example, close any open streams or release other managed objects
                }

                // Dispose unmanaged resources (if any)
                // For example, close a native resource or release unmanaged memory

                disposed = true;
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
            using (var stream = new FileStream(ConfigFileName, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(json);
            }
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