using System.Configuration;
using System.Collections.Specialized;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Reflection;

namespace FortniteOptimal
{
    public partial class frmOptimal : Form
    {
        private string config = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.ini";
        private Dictionary<string, int> configValues = new();
        private Dictionary<string, CheckBox> configValueCheckBoxes = new();

        private string fortniteConfigLocation = @"C:\" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + @"\Administrator\AppData\Local\FortniteGame\Saved\Config\WindowsClient";

        public frmOptimal()
        {
            InitializeComponent();

            //Config config = new();

           // Create config
           if (!File.Exists(config)) { using (FileStream fs = File.Create(config)) { } }
           else
           {
               // Read the dictionary from the INI file
               configValues = ReadDictionaryFromIni(config);
           }
           if (configValues.Count > 0)
           {
               CheckValues();
           }
           if (CheckValue("AutoLaunch")) // Launch the program instantly if AutoLaunch = 1
           {
               EpicGamesLauncher.Launch();
               if (CheckValue("AutoClose")) // Close the program instantly if AutoClose = 1
               {
                   Load += (s, e) => Close();
               }
           }
        }

        private void CheckValues()
        {
            foreach (string key in configValues.Keys)
            {
                if (configValues[key] == 1)
                {
                    if (ValueToCheckBox(key) != null)
                    {
                        //if (ValueToCheckBox(key) == chkLaunch) { System.Threading.Thread.Sleep(1000); this.Close(); }
                        ValueToCheckBox(key).Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Unknown setting in config.ini: \n" + key + "\nIgnoring.", "Config Error");
                        continue;
                    }
                    //configValueCheckBoxes[key].Checked = true;
                    //chkLaunch.Checked = true; // FIX, make a second dictionary that maps names to checkboxes
                    //EpicGamesLauncher.Launch();
                }
            }
        }
        private bool CheckValue(string value) // Returns whether a value in the config is 1 or 0
        {
            foreach (string key in configValues.Keys)
            {
                if (key == value)
                {
                    if (configValues[key] == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            MessageBox.Show("Value not found: " + value, "Check Value Error");
            return false;
        }
        private CheckBox? ValueToCheckBox(string key) // Table matching Values from the config to their checkboxes
        {
            switch (key)
            {
                case "AutoClose":
                    return chkClose;
                case "AutoLaunch":
                    return chkLaunch;
                case "UseCustomSettings":
                    return chkCustomSettings;
                case "UseCustomPrograms":
                    return chkCustomPrograms;
                default:
                    return null;
            }
        }
        private void SetValues(string valueName, CheckBox chkBox)
        {
            if (!configValueCheckBoxes.ContainsKey(valueName)) { configValueCheckBoxes.Add(valueName, chkBox); }

            if (chkBox.Checked == true)
            {
                if (!configValues.ContainsKey(valueName)) { configValues.Add(valueName, 1); }
                else { configValues[valueName] = 1; }
            }
            else
            {
                if (!configValues.ContainsKey(valueName)) { configValues.Add(valueName, 0); }
                else { configValues[valueName] = 0; }
            }
            WriteDictionaryToIni(configValues, config);
        }

        private void btnLaunch_Click(object sender = null, EventArgs e = null)
        {
            if (chkCustomSettings.Checked == true)
            {
                string selectedConfig = lstConfig.Text;
                if (selectedConfig != string.Empty)
                {
                    //MessageBox.Show(selectedConfig, "");

                    string selectedConfigLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + selectedConfig + "\\";
                    //C:\Users\Administrator\AppData\Local\FortniteGame\Saved\Config\WindowsClient

                }
                else
                {
                    MessageBox.Show("No Config Selected!", "Error");
                    return;
                }
            }
            EpicGamesLauncher.Launch();
            if (CheckValue("AutoClose"))
            {
                this.Close();
            }
            //if (chkClose.Checked == true)
            //{
            //    this.Close();
            //}
        }

        private void chkLaunch_CheckedChanged(object sender, EventArgs e)
        {
            SetValues("AutoLaunch", chkLaunch);
        }
        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            SetValues("AutoClose", chkClose);
        }
        private void WriteDictionaryToIni(Dictionary<string, int> dictionary, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var kvp in dictionary)
                {
                    // Format each key-value pair as a line in the INI file
                    string line = $"{kvp.Key}={kvp.Value}";
                    sw.WriteLine(line);
                }
            }
        }
        private Dictionary<string, int> ReadDictionaryFromIni(string filePath)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            // Read lines from the INI file
            string[] lines = File.ReadAllLines(filePath);

            // Parse each line and populate the dictionary
            foreach (string line in lines)
            {
                // Split the line into key and value
                string[] parts = line.Split('=');

                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();
                    if (int.TryParse(parts[1], out int value))
                    {
                        result[key] = value;
                    }
                    // If the value is not an integer, you might want to handle this case accordingly
                }
                // If the line doesn't follow the expected format, you might want to handle this case accordingly
            }

            return result;
        }

        private void chkCustomSettings_CheckedChanged(object sender, EventArgs e)
        {
            SetValues("UseCustomSettings", chkCustomSettings);
            try
            {
                string gameUsr = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\GameUserSettings\";
                if (!Directory.Exists(gameUsr))
                    Directory.CreateDirectory(gameUsr);


                // Get all .ini files in the specified directory
                string[] iniFiles = Directory.GetFiles(gameUsr, "*.ini");

                // Check if there are any .ini files
                if (iniFiles.Length > 0)
                {
                    // Populate the ListBox with the file names
                    foreach (string iniFile in iniFiles)
                    {
                        // Add each file name to the ListBox
                        lstConfig.Items.Add(Path.GetFileName(iniFile));
                    }
                }
                else
                {
                    // No .ini files found
                    MessageBox.Show("No .ini files found in the directory.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur (e.g., directory not found, access denied)
                MessageBox.Show($"An error occurred: {ex.Message}");

            }
            if (!chkCustomSettings.Checked)
                lstConfig.Items.Clear();
        }
        private void chkCustomPrograms_CheckedChanged(object sender, EventArgs e)
        {
            //
            SetValues("UseCustomPrograms", chkCustomPrograms);
        }
        private void btnCustomProgramsAdd_Click(object sender, EventArgs e)
        {
            // Use a function to add the text in textbox (if its not null) to a seperate config exclusively for launching custom programs
        }

        private void btnCustomProgramsRemove_Click(object sender, EventArgs e)
        {
            // remove selected program in custom program list
        }

        private void lstConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lstConfig.Text
        }
    }
}