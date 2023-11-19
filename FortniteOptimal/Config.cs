using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FortniteOptimal
{
    internal class Config
    {
        public int AutoLaunch { get; set; }
        public int AutoClose { get; set; }
        public int UseCustomSettings { get; set; }
        public int UseCustomPrograms { get; set; }
        public string Program { get; set; }
        //private string configFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.ini";
        //private string configFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.json";
        public Config()
        {
            // Create a configuration builder
            var configurationBuilder = new ConfigurationBuilder();

            //// Set the base path to the location of your appsettings.json file
            //configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            //
            //// Add the appsettings.json file
            //configurationBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: true);

            var configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
            configurationBuilder.AddJsonFile(configFilePath, optional: false, reloadOnChange: true);


            // Build the configuration
            string configFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.json";
            if (!File.Exists(configFile))
            {
                CreateDefaultConfig(configFile);
            }
            var configuration = configurationBuilder.Build();

            // Create an instance of AppSettings and bind the configuration values to it
            var appSettings = new Config();
            configuration.GetSection("Config").Bind(appSettings);

            // Update the values if needed
            appSettings.AutoLaunch = 1;
            appSettings.AutoClose = 1;
            appSettings.UseCustomSettings = 1;
            appSettings.UseCustomPrograms = 1;
            appSettings.Program = "New program path";

            // Save the updated values back to the configuration file
            configuration.GetSection("Config").Bind(appSettings);
            configurationBuilder.AddJsonFile("Config.json", optional: false, reloadOnChange: true);


            ////var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("config.json").Build();
            //// Create config
            //if (!File.Exists(configFile))
            //{
            //    using (FileStream fs = File.Create(configFile)) { }
            //}
            //else
            //{
            //
            //    // Read the dictionary from the INI file
            //    //configValues = ReadDictionaryFromIni(configFile);
            //}
            // if (configValues.Count > 0)
            // {
            //     CheckValues();
            // }
            // if (CheckValue("AutoLaunch")) // Launch the program instantly if AutoLaunch = 1
            // {
            //     EpicGamesLauncher.Launch();
            //     if (CheckValue("AutoClose")) // Close the program instantly if AutoClose = 1
            //     {
            //         Load += (s, e) => Close();
            //     }
            // }
            
        }
        private void CreateDefaultConfig(string configFilePath)
        {
            // Create a default configuration object
            var defaultConfig = new Config
            {
                AutoLaunch = 0,
                AutoClose = 0,
                UseCustomSettings = 0,
                UseCustomPrograms = 0,
                Program = ""
            };

            // Serialize the default configuration to JSON and write it to the file
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(defaultConfig, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(configFilePath, json);
        }

        //private void ReadValues()
        //{
        //    if (File.Exists(configFile))
        //    {
        //
        //    }
        //}
    }
}
