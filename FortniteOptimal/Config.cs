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

        //private void ReadValues()
        //{
        //    if (File.Exists(configFile))
        //    {
        //
        //    }
        //}
    }
}
