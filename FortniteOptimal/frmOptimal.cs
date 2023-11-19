using System.Configuration;
using System.Collections.Specialized;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Reflection;
using FortniteOptimal;

namespace FortniteOptimal
{
    public partial class frmOptimal : Form
    {
        //private string config = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\config.ini";
        //private Dictionary<string, int> configValues = new();
        //private Dictionary<string, CheckBox> configValueCheckBoxes = new();

        private string fortniteConfigLocation = @"C:\" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + @"\Administrator\AppData\Local\FortniteGame\Saved\Config\WindowsClient";

        private Config config = new Config();

        public frmOptimal()
        {
            InitializeComponent();

            

            //config.AutoLaunch = 1;

        }
        private void btnLaunch_Click(object sender = null, EventArgs e = null)
        {
            if (chkCustomSettings.Checked == true)
            {

            }
            EpicGamesLauncher.Launch();
        }

        private void chkLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLaunch.Checked == true)
            {
                config.AutoLaunch = 1;
                config.Save();
            }
            else
            {
                config.AutoLaunch = 0;
                config.Save();
            }
            //config.AutoLaunch = 1;
            //SetValues("AutoLaunch", chkLaunch);
        }
        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            //SetValues("AutoClose", chkClose);
        }
        private void chkCustomSettings_CheckedChanged(object sender, EventArgs e)
        {
            //SetValues("UseCustomSettings", chkCustomSettings);
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
            //SetValues("UseCustomPrograms", chkCustomPrograms);
        }
        private void btnCustomProgramsAdd_Click(object sender, EventArgs e)
        {
            // Assuming you have an instance of the Config class named 'config'
            // (you might have created it earlier in your code)

            // Add a custom program to the list
            config.Programs.Add(txtCustomPrograms.Text);

            // Save the updated configuration
            config.Save();

            // Clear the ListBox
            lstCustomPrograms.Items.Clear();

            // Populate the ListBox with the updated list of programs
            foreach (string program in config.Programs)
            {
                lstConfig.Items.Add(program);
            }

            // config.Programs.Add(txtCustomPrograms.Text);
            // config.Save();
            // lstConfig.Items.Clear();
            // foreach (string program in config.Programs)
            // {
            //     lstCustomPrograms.Items.Add(config.Programs);
            // }
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