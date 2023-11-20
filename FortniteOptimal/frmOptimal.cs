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

        public frmOptimal()
        {
            InitializeComponent();
            SetValuesToConfig();
        }

        // start here
        private void SetValuesToConfig()
        {
            if (config.AutoLaunch == 1)
            {
                EpicGamesLauncher.Launch();
                if (config.AutoClose == 1) { Load += (s, e) => Close(); } // Close Immediately
                chkLaunch.Checked = true;
            }
            if (config.AutoClose == 1)
            {
                chkClose.Checked = true;
            }
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
                txtCustomPrograms.Visible = false;
                btnCustomProgramsAdd.Visible = false;
                btnCustomProgramsRemove.Visible = false;
                lstCustomPrograms.Visible = false;
            }
            if (config.KillProcesses == 1)
            {
                chkKillProcesses.Checked = true;
                txtKillProcesses.Visible = true;
                lstKillProcesses.Visible = true;
                btnKillProcessesAdd.Visible = true;
                btnKillProcessesRemove.Visible = true;
            }
            else
            {
                chkKillProcesses.Checked = false;
                btnKillProcessesAdd.Visible = false;
                btnKillProcessesRemove.Visible = false;
                txtKillProcesses.Visible = false;
                lstKillProcesses.Visible = false;
            }
        }

        // Set value given by checkbox and property
        private void CheckClicked(CheckBox checkBox, PropertyInfo? setting)
        {
            if (setting != null)
            {
                if (checkBox.Checked)
                {
                    setting.SetValue(config, 1);
                }
                else
                {
                    setting.SetValue(config, 0);
                }
                config.Save();
            }
        }

        private void btnLaunch_Click(object? sender = null, EventArgs? e = null)
        {
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
            if (chkCustomPrograms.Checked == true)
            {
                if (config.Programs.Count > 0)
                {
                    foreach (string program in config.Programs)
                    {
                        try
                        {
                            Process.Start(program);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while trying to open: " + ex.Message, "Program Error");
                        }
                    }
                }
            }
            if (chkKillProcesses.Checked == true)
            {
                if (config.Processes.Count > 0)
                {
                    foreach (string processToKill in config.Processes)
                    {
                        var processes = Process.GetProcessesByName(processToKill);
                        if (processes.Length == 0)
                        {
                            MessageBox.Show("An error occurred while trying to kill process: " + processToKill, "Program Error");
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
            }
            else
                MessageBox.Show("No Processes To Kill.", "Error");
            EpicGamesLauncher.Launch();
            if (chkClose.Checked == true)
            {
                this.Close();
            }
        }

        private void chkLaunch_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkLaunch, typeof(Config).GetProperty("AutoLaunch"));
        }
        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkClose, typeof(Config).GetProperty("AutoClose"));
        }
        private void chkCustomSettings_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkCustomSettings, typeof(Config).GetProperty("UseCustomSettings"));
            //SetValues("UseCustomSettings", chkCustomSettings);

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
                        MessageBox.Show("No .ini files found in the directory.");
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
            CheckClicked(chkCustomPrograms, typeof(Config).GetProperty("UseCustomPrograms"));
            if (chkCustomPrograms.Checked)
            {
                txtCustomPrograms.Visible = true;
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
                txtCustomPrograms.Visible = false;
                btnCustomProgramsAdd.Visible = false;
                btnCustomProgramsRemove.Visible = false;
                lstCustomPrograms.Visible = false;
            }
        }
        private void btnCustomProgramsAdd_Click(object sender, EventArgs e)
        {
            config.Programs.Add(txtCustomPrograms.Text);
            config.Save();
            lstCustomPrograms.Items.Clear();
            txtCustomPrograms.Clear();

            foreach (string program in config.Programs)
            {
                lstCustomPrograms.Items.Add(program);
            }
        }

        private void btnCustomProgramsRemove_Click(object sender, EventArgs e)
        {
            // remove selected program in custom program list
            string selectedProgram = lstCustomPrograms.Text;
            lstCustomPrograms.Items.Remove(selectedProgram);
            config.Programs.Remove(selectedProgram);
            config.Save();
        }

        private void lstConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            config.CustomSetting = lstConfig.Text;
            config.Save();
        }

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

        private void chkKillProcesses_CheckedChanged(object sender, EventArgs e)
        {
            CheckClicked(chkKillProcesses, typeof(Config).GetProperty("KillProcesses"));
            if (chkKillProcesses.Checked)
            {
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
    }
}