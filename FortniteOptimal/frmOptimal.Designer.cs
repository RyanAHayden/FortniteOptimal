namespace FortniteOptimal
{
    partial class frmOptimal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstConfig = new ListBox();
            chkCustomSettings = new CheckBox();
            chkCustomPrograms = new CheckBox();
            grpCustomSettings = new GroupBox();
            grpGame = new GroupBox();
            btnClose = new Button();
            btnLaunch = new Button();
            chkLaunch = new CheckBox();
            chkClose = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            grpCustomPrograms = new GroupBox();
            btnCustomProgramsRemove = new Button();
            lstCustomPrograms = new ListBox();
            btnCustomProgramsAdd = new Button();
            txtCustomPrograms = new TextBox();
            grpKillProcesses = new GroupBox();
            btnKillProcessesAdd = new Button();
            btnKillProcessesRemove = new Button();
            lstKillProcesses = new ListBox();
            txtKillProcesses = new TextBox();
            chkKillProcesses = new CheckBox();
            grpCustomSettings.SuspendLayout();
            grpGame.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            grpCustomPrograms.SuspendLayout();
            grpKillProcesses.SuspendLayout();
            SuspendLayout();
            // 
            // lstConfig
            // 
            lstConfig.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lstConfig.FormattingEnabled = true;
            lstConfig.ItemHeight = 15;
            lstConfig.Location = new Point(6, 44);
            lstConfig.Name = "lstConfig";
            lstConfig.Size = new Size(188, 64);
            lstConfig.TabIndex = 1;
            lstConfig.SelectedIndexChanged += lstConfig_SelectedIndexChanged;
            // 
            // chkCustomSettings
            // 
            chkCustomSettings.AutoSize = true;
            chkCustomSettings.FlatStyle = FlatStyle.Flat;
            chkCustomSettings.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            chkCustomSettings.Location = new Point(6, 21);
            chkCustomSettings.Name = "chkCustomSettings";
            chkCustomSettings.Size = new Size(178, 21);
            chkCustomSettings.TabIndex = 0;
            chkCustomSettings.Text = "Use Custom Settings";
            chkCustomSettings.UseVisualStyleBackColor = true;
            chkCustomSettings.CheckedChanged += chkCustomSettings_CheckedChanged;
            // 
            // chkCustomPrograms
            // 
            chkCustomPrograms.AutoSize = true;
            chkCustomPrograms.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            chkCustomPrograms.Location = new Point(6, 21);
            chkCustomPrograms.Name = "chkCustomPrograms";
            chkCustomPrograms.Size = new Size(150, 21);
            chkCustomPrograms.TabIndex = 0;
            chkCustomPrograms.Text = "Launch Programs";
            chkCustomPrograms.UseVisualStyleBackColor = true;
            chkCustomPrograms.CheckedChanged += chkCustomPrograms_CheckedChanged;
            // 
            // grpCustomSettings
            // 
            grpCustomSettings.AutoSize = true;
            grpCustomSettings.Controls.Add(lstConfig);
            grpCustomSettings.Controls.Add(chkCustomSettings);
            grpCustomSettings.FlatStyle = FlatStyle.Flat;
            grpCustomSettings.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            grpCustomSettings.Location = new Point(3, 147);
            grpCustomSettings.MaximumSize = new Size(200, 160);
            grpCustomSettings.MinimumSize = new Size(200, 0);
            grpCustomSettings.Name = "grpCustomSettings";
            grpCustomSettings.Size = new Size(200, 132);
            grpCustomSettings.TabIndex = 1;
            grpCustomSettings.TabStop = false;
            grpCustomSettings.Text = "Custom Settings";
            // 
            // grpGame
            // 
            grpGame.BackColor = SystemColors.Control;
            grpGame.Controls.Add(btnClose);
            grpGame.Controls.Add(btnLaunch);
            grpGame.Controls.Add(chkLaunch);
            grpGame.Controls.Add(chkClose);
            grpGame.FlatStyle = FlatStyle.Flat;
            grpGame.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            grpGame.ForeColor = SystemColors.ControlText;
            grpGame.Location = new Point(3, 3);
            grpGame.Name = "grpGame";
            grpGame.Size = new Size(200, 138);
            grpGame.TabIndex = 0;
            grpGame.TabStop = false;
            grpGame.Text = "Game";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(6, 52);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(188, 25);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnLaunch
            // 
            btnLaunch.BackColor = Color.Lime;
            btnLaunch.FlatStyle = FlatStyle.Flat;
            btnLaunch.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLaunch.Location = new Point(6, 21);
            btnLaunch.Name = "btnLaunch";
            btnLaunch.Size = new Size(188, 25);
            btnLaunch.TabIndex = 0;
            btnLaunch.Text = "Launch";
            btnLaunch.UseVisualStyleBackColor = false;
            btnLaunch.Click += btnLaunch_Click;
            // 
            // chkLaunch
            // 
            chkLaunch.AutoSize = true;
            chkLaunch.FlatStyle = FlatStyle.Flat;
            chkLaunch.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            chkLaunch.Location = new Point(6, 83);
            chkLaunch.Name = "chkLaunch";
            chkLaunch.Size = new Size(114, 21);
            chkLaunch.TabIndex = 1;
            chkLaunch.Text = "Auto-Launch";
            chkLaunch.UseVisualStyleBackColor = true;
            chkLaunch.CheckedChanged += chkLaunch_CheckedChanged;
            // 
            // chkClose
            // 
            chkClose.AutoSize = true;
            chkClose.FlatStyle = FlatStyle.Flat;
            chkClose.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            chkClose.Location = new Point(6, 110);
            chkClose.Name = "chkClose";
            chkClose.Size = new Size(146, 21);
            chkClose.TabIndex = 2;
            chkClose.Text = "Auto-Close FNOP";
            chkClose.UseVisualStyleBackColor = true;
            chkClose.CheckedChanged += chkClose_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(grpGame);
            flowLayoutPanel1.Controls.Add(grpCustomSettings);
            flowLayoutPanel1.Controls.Add(grpCustomPrograms);
            flowLayoutPanel1.Controls.Add(grpKillProcesses);
            flowLayoutPanel1.Location = new Point(12, 11);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(206, 678);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // grpCustomPrograms
            // 
            grpCustomPrograms.AutoSize = true;
            grpCustomPrograms.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpCustomPrograms.Controls.Add(btnCustomProgramsRemove);
            grpCustomPrograms.Controls.Add(lstCustomPrograms);
            grpCustomPrograms.Controls.Add(btnCustomProgramsAdd);
            grpCustomPrograms.Controls.Add(txtCustomPrograms);
            grpCustomPrograms.Controls.Add(chkCustomPrograms);
            grpCustomPrograms.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            grpCustomPrograms.Location = new Point(3, 285);
            grpCustomPrograms.MinimumSize = new Size(200, 0);
            grpCustomPrograms.Name = "grpCustomPrograms";
            grpCustomPrograms.Size = new Size(200, 192);
            grpCustomPrograms.TabIndex = 2;
            grpCustomPrograms.TabStop = false;
            grpCustomPrograms.Text = "Custom Programs";
            // 
            // btnCustomProgramsRemove
            // 
            btnCustomProgramsRemove.Location = new Point(129, 73);
            btnCustomProgramsRemove.Name = "btnCustomProgramsRemove";
            btnCustomProgramsRemove.Size = new Size(65, 25);
            btnCustomProgramsRemove.TabIndex = 3;
            btnCustomProgramsRemove.Text = "Remove";
            btnCustomProgramsRemove.UseVisualStyleBackColor = true;
            btnCustomProgramsRemove.Click += btnCustomProgramsRemove_Click;
            // 
            // lstCustomPrograms
            // 
            lstCustomPrograms.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lstCustomPrograms.HorizontalScrollbar = true;
            lstCustomPrograms.ItemHeight = 15;
            lstCustomPrograms.Location = new Point(6, 104);
            lstCustomPrograms.Name = "lstCustomPrograms";
            lstCustomPrograms.RightToLeft = RightToLeft.Yes;
            lstCustomPrograms.Size = new Size(188, 64);
            lstCustomPrograms.TabIndex = 4;
            // 
            // btnCustomProgramsAdd
            // 
            btnCustomProgramsAdd.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCustomProgramsAdd.Location = new Point(6, 73);
            btnCustomProgramsAdd.Name = "btnCustomProgramsAdd";
            btnCustomProgramsAdd.Size = new Size(40, 25);
            btnCustomProgramsAdd.TabIndex = 2;
            btnCustomProgramsAdd.Text = "Add";
            btnCustomProgramsAdd.UseVisualStyleBackColor = true;
            btnCustomProgramsAdd.Click += btnCustomProgramsAdd_Click;
            // 
            // txtCustomPrograms
            // 
            txtCustomPrograms.AllowDrop = true;
            txtCustomPrograms.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            txtCustomPrograms.Location = new Point(6, 44);
            txtCustomPrograms.Name = "txtCustomPrograms";
            txtCustomPrograms.PlaceholderText = "Path to .exe";
            txtCustomPrograms.Size = new Size(181, 23);
            txtCustomPrograms.TabIndex = 1;
            txtCustomPrograms.WordWrap = false;
            // 
            // grpKillProcesses
            // 
            grpKillProcesses.AutoSize = true;
            grpKillProcesses.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpKillProcesses.Controls.Add(btnKillProcessesAdd);
            grpKillProcesses.Controls.Add(btnKillProcessesRemove);
            grpKillProcesses.Controls.Add(lstKillProcesses);
            grpKillProcesses.Controls.Add(txtKillProcesses);
            grpKillProcesses.Controls.Add(chkKillProcesses);
            grpKillProcesses.Location = new Point(3, 483);
            grpKillProcesses.MinimumSize = new Size(200, 0);
            grpKillProcesses.Name = "grpKillProcesses";
            grpKillProcesses.Size = new Size(200, 192);
            grpKillProcesses.TabIndex = 3;
            grpKillProcesses.TabStop = false;
            grpKillProcesses.Text = "Kill Processes";
            // 
            // btnKillProcessesAdd
            // 
            btnKillProcessesAdd.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnKillProcessesAdd.Location = new Point(6, 79);
            btnKillProcessesAdd.Name = "btnKillProcessesAdd";
            btnKillProcessesAdd.Size = new Size(40, 25);
            btnKillProcessesAdd.TabIndex = 2;
            btnKillProcessesAdd.Text = "Add";
            btnKillProcessesAdd.UseVisualStyleBackColor = true;
            btnKillProcessesAdd.Click += btnKillProcessesAdd_Click;
            // 
            // btnKillProcessesRemove
            // 
            btnKillProcessesRemove.Location = new Point(129, 79);
            btnKillProcessesRemove.Name = "btnKillProcessesRemove";
            btnKillProcessesRemove.Size = new Size(65, 25);
            btnKillProcessesRemove.TabIndex = 3;
            btnKillProcessesRemove.Text = "Remove";
            btnKillProcessesRemove.UseVisualStyleBackColor = true;
            btnKillProcessesRemove.Click += btnKillProcessesRemove_Click;
            // 
            // lstKillProcesses
            // 
            lstKillProcesses.FormattingEnabled = true;
            lstKillProcesses.ItemHeight = 18;
            lstKillProcesses.Location = new Point(6, 110);
            lstKillProcesses.Name = "lstKillProcesses";
            lstKillProcesses.Size = new Size(188, 58);
            lstKillProcesses.TabIndex = 4;
            // 
            // txtKillProcesses
            // 
            txtKillProcesses.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            txtKillProcesses.Location = new Point(6, 51);
            txtKillProcesses.Name = "txtKillProcesses";
            txtKillProcesses.PlaceholderText = "Process name w/o .exe";
            txtKillProcesses.Size = new Size(188, 23);
            txtKillProcesses.TabIndex = 1;
            // 
            // chkKillProcesses
            // 
            chkKillProcesses.AutoSize = true;
            chkKillProcesses.Font = new Font("Consolas", 8F, FontStyle.Regular, GraphicsUnit.Point);
            chkKillProcesses.Location = new Point(6, 24);
            chkKillProcesses.Name = "chkKillProcesses";
            chkKillProcesses.Size = new Size(142, 21);
            chkKillProcesses.TabIndex = 0;
            chkKillProcesses.Text = "Kill Processes";
            chkKillProcesses.UseVisualStyleBackColor = true;
            chkKillProcesses.CheckedChanged += chkKillProcesses_CheckedChanged;
            // 
            // frmOptimal
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 671);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MaximizeBox = false;
            MinimumSize = new Size(250, 0);
            Name = "frmOptimal";
            ShowIcon = false;
            Text = "FNOP";
            grpCustomSettings.ResumeLayout(false);
            grpCustomSettings.PerformLayout();
            grpGame.ResumeLayout(false);
            grpGame.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            grpCustomPrograms.ResumeLayout(false);
            grpCustomPrograms.PerformLayout();
            grpKillProcesses.ResumeLayout(false);
            grpKillProcesses.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lstConfig;
        private CheckBox chkCustomSettings;
        private CheckBox chkCustomPrograms;
        private GroupBox grpCustomSettings;
        private GroupBox grpGame;
        private Button btnLaunch;
        private CheckBox chkLaunch;
        private CheckBox chkClose;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox grpCustomPrograms;
        private ListBox lstCustomPrograms;
        private Button btnCustomProgramsAdd;
        private TextBox txtCustomPrograms;
        private Button btnCustomProgramsRemove;
        private Button btnClose;
        private GroupBox grpKillProcesses;
        private CheckBox chkKillProcesses;
        private TextBox txtKillProcesses;
        private ListBox lstKillProcesses;
        private Button btnKillProcessesAdd;
        private Button btnKillProcessesRemove;
    }
}