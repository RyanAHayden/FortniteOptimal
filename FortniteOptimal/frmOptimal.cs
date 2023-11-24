using System.Configuration;
using System.Collections.Specialized;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Reflection;
using FortniteOptimal;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Principal;
using System.ComponentModel;

namespace FortniteOptimal
{
    public partial class frmOptimal : Form
    {
        private string gameConfig = Directory.GetCurrentDirectory() + @"\GameUserSettings\";
        private Config config = new Config();
        private bool ignoreErrors = false;
        public bool ShouldQuit { get; set; }

        public frmOptimal()
        {
            InitializeComponent();
            SetValuesToConfig();

            // Set tooltips
            toolTip1.SetToolTip(btnLaunch, "Open Fortnite");
            toolTip1.SetToolTip(btnClose, "Close Fortnite");
            toolTip1.SetToolTip(chkLaunch, "Automatically launch Fortnite when opening this software");
            toolTip1.SetToolTip(chkClose, "Automatically close this software when opening Fortnite");
            toolTip1.SetToolTip(chkCustomSettings, @"Set Fortnite's GameUserSettings to specified config in ..\GameUserSettings\");
            toolTip1.SetToolTip(chkCustomPrograms, "Automatically open specified programs when opening Fortnite");
            toolTip1.SetToolTip(chkKillProcesses, "Automatically close specified processes when opening Fortnite");
            toolTip1.SetToolTip(chkKillProcessIgnore, "Don't popup errors for programs that can't be found");
        }

        // Checks all current values given in config and sets them visibly
        private void SetValuesToConfig()
        {
            if (config.UseCustomSettings == 1)
            {
                if (!Directory.Exists(gameConfig))
                    Directory.CreateDirectory(gameConfig);
                chkCustomSettings.Checked = true;
                lstConfig.SelectedItem = config.CustomSetting; // Set selected config to the one previously selected
            }
            else
            {
                lstConfig.Visible = false;
            }
            if (config.UseCustomPrograms == 1)
            {
                chkCustomPrograms.Checked = true;
            }
            else
            {
                btnCustomProgramsAdd.Visible = false;
                btnCustomProgramsRemove.Visible = false;
                lstCustomPrograms.Visible = false;
            }
            if (config.KillProcesses == 1)
            {
                chkKillProcessIgnore.Visible = true;
                chkKillProcesses.Checked = true;
                txtKillProcesses.Visible = true;
                lstKillProcesses.Visible = true;
                btnKillProcessesAdd.Visible = true;
                btnKillProcessesRemove.Visible = true;
            }
            else
            {
                chkKillProcessIgnore.Visible = false;
                btnKillProcessesAdd.Visible = false;
                btnKillProcessesRemove.Visible = false;
                txtKillProcesses.Visible = false;
                lstKillProcesses.Visible = false;
            }
            if (config.IgnoreErrors == 1)
            {
                chkKillProcessIgnore.Checked = true;
            }
            if (config.AutoLaunch == 1)
            {
                btnLaunch_Click();
                chkLaunch.Checked = true;
            }
            if (config.AutoClose == 1)
            {
                chkClose.Checked = true;
            }
        }



        // Set config's value given by checkbox, property, and config class
        private void CheckClicked(CheckBox checkBox, PropertyInfo? setting, Config config)
        {
            if (setting != null)
            { // Check if the checkBox is checked, if it is set the setting's value to 1, if not, set it to 0
                setting.SetValue(config, checkBox.Checked ? 1 : 0);
                config.Save();
            }
        }

        private void btnLaunch_Click(object? sender = null, EventArgs? e = null)
        {
            // Settings checks

            // Change the game's config to user-given config
            if (chkCustomSettings.Checked == true)
            {
                string chosenGameConfig = gameConfig + config.CustomSetting;
                string fortniteConfigLocation = @"C:\Users\" + Environment.UserName + @"\AppData\Local\FortniteGame\Saved\Config\WindowsClient\";

                if (File.Exists(chosenGameConfig))
                {
                    string bakFilePath = fortniteConfigLocation + "GameUserSettings.ini.bak";   // Check for backup GameUserSettings
                    try
                    {
                        if (File.Exists(bakFilePath))
                        {
                            File.Delete(bakFilePath);
                        }
                        string originalConfig = fortniteConfigLocation + "GameUserSettings.ini";   // Check for GameUserSettings
                        if (File.Exists(originalConfig))
                        {
                            File.Move(originalConfig, bakFilePath);
                        }
                        File.Copy(chosenGameConfig, fortniteConfigLocation + "GameUserSettings.ini");
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("Unauthorized Access, is your GameUserSettings read-only?\n " + ex, "Authority Error");
                    }
                }
                else
                { MessageBox.Show("Unknown Config: " + config.CustomSetting, "Config Error"); }
            }
            // Launch user-given programs
            if (chkCustomPrograms.Checked == true)
            {
                if (config.Programs.Count > 0)
                {
                    foreach (string program in config.Programs)
                    {
                        try // Try to open the user-given program, catch any exceptions.
                        { Process.Start(program); }
                        catch (Exception ex)
                        { MessageBox.Show("An error occurred while trying to open: " + ex.Message, "Program Error"); }
                    }
                }
            }
            // Kill user-given programs
            if (chkKillProcesses.Checked == true)
            {
                if (config.Processes.Count > 0)
                {
                    foreach (string processToKill in config.Processes)
                    {
                        var processes = Process.GetProcessesByName(processToKill);
                        if (processes.Length == 0)
                        {
                            if (!ignoreErrors)
                            {
                                MessageBox.Show("An error occurred while trying to kill process: " + processToKill, "Program Error");
                            }
                        }
                        else
                        {
                            foreach (var process in processes)
                            {
                                process.Kill();
                            }
                        }
                    }
                }
                else
                {
                    if (!ignoreErrors)
                    {
                        MessageBox.Show("No Processes To Kill.", "Error");
                    }
                }
            }
            // Launch
            EpicGamesLauncher.Launch();
            // Close program if Auto-Close is enabled
            if (config.AutoClose == 1)
            {
                this.Close();
            }
        }

        // End Fortnite's processes
        private void btnClose_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("FortniteClient-Win64-Shipping"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("FortniteLauncher"))
            {
                process.Kill();
            }
        }

        private void chkLaunch_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkLaunch, typeof(Config).GetProperty("AutoLaunch"), config);
        }
        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkClose, typeof(Config).GetProperty("AutoClose"), config);
        }

        private void chkCustomSettings_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkCustomSettings, typeof(Config).GetProperty("UseCustomSettings"), config);

            // Show the user's custom configs in \GameUserSettings\
            if (chkCustomSettings.Checked == true)
            {
                lstConfig.Visible = true;
                try
                {
                    if (!Directory.Exists(gameConfig))
                        Directory.CreateDirectory(gameConfig);

                    // Get all .ini files in the specified directory
                    string[] iniFiles = Directory.GetFiles(gameConfig, "*.ini");

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
                        MessageBox.Show(@"No .ini files found in the directory: ..\GameUserSettings\", "Custom Settings Error");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur (e.g., directory not found, access denied)
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                lstConfig.Visible = false;
                lstConfig.Items.Clear();
            }
        }
        private void chkCustomPrograms_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkCustomPrograms, typeof(Config).GetProperty("UseCustomPrograms"), config);
            if (chkCustomPrograms.Checked)
            {
                btnCustomProgramsAdd.Visible = true;
                btnCustomProgramsRemove.Visible = true;
                lstCustomPrograms.Visible = true;
                if (config.Programs.Count > 0)
                {
                    foreach (string program in config.Programs)
                    {
                        lstCustomPrograms.Items.Add(program);
                    }
                }
            }
            else
            {
                lstCustomPrograms.Items.Clear();
                btnCustomProgramsAdd.Visible = false;
                btnCustomProgramsRemove.Visible = false;
                lstCustomPrograms.Visible = false;
            }
        }
        private void btnCustomProgramsAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
                openFileDialog.Title = "Select an Executable File";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    config.Programs.Add(selectedFilePath);
                    config.Save();
                    lstCustomPrograms.Items.Clear();
                    foreach (string program in config.Programs)
                    {
                        lstCustomPrograms.Items.Add(program);
                    }
                }
            }
        }
        private void btnCustomProgramsRemove_Click(object sender, EventArgs e)
        {
            // Remove selected program in program list
            string selectedProgram = lstCustomPrograms.Text;
            lstCustomPrograms.Items.Remove(selectedProgram);
            if (config.Programs.Remove(selectedProgram)) { config.Save(); }

        }

        // Set custom config based on user selection
        private void lstConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.CustomSetting = lstConfig.Text;
            config.Save();
        }


        private void chkKillProcesses_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkKillProcesses, typeof(Config).GetProperty("KillProcesses"), config);
            if (chkKillProcesses.Checked)
            {
                chkKillProcessIgnore.Visible = true;
                txtKillProcesses.Visible = true;
                lstKillProcesses.Visible = true;
                btnKillProcessesAdd.Visible = true;
                btnKillProcessesRemove.Visible = true;

                if (config.Processes.Count > 0)
                {
                    foreach (string process in config.Processes)
                    {
                        lstKillProcesses.Items.Add(process);
                    }
                }
            }
            else
            {
                lstKillProcesses.Items.Clear();
                chkKillProcessIgnore.Visible = false;
                btnKillProcessesAdd.Visible = false;
                btnKillProcessesRemove.Visible = false;
                txtKillProcesses.Visible = false;
                lstKillProcesses.Visible = false;
            }
        }

        private void btnKillProcessesAdd_Click(object sender, EventArgs e)
        {
            config.Processes.Add(txtKillProcesses.Text);
            config.Save();
            lstKillProcesses.Items.Clear();
            txtKillProcesses.Clear();

            foreach (string process in config.Processes)
            {
                lstKillProcesses.Items.Add(process);
            }
        }

        private void btnKillProcessesRemove_Click(object sender, EventArgs e)
        {
            string selectedProcess = lstKillProcesses.Text;
            lstKillProcesses.Items.Remove(selectedProcess);
            config.Processes.Remove(selectedProcess);
            config.Save();
        }

        private void chkKillProcessIgnore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKillProcessIgnore.Checked)
            {
                ignoreErrors = true;
                config.IgnoreErrors = 1;
                config.Save();
            }
            else
            {
                ignoreErrors = false;
                config.IgnoreErrors = 0;
                config.Save();
            }
        }
    }
}