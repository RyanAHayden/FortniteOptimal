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
            btnLaunch = new Button();
            chkLaunch = new CheckBox();
            chkClose = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            grpCustomPrograms = new GroupBox();
            btnCustomProgramsRemove = new Button();
            lstCustomPrograms = new ListBox();
            btnCustomProgramsAdd = new Button();
            txtCustomPrograms = new TextBox();
            grpCustomSettings.SuspendLayout();
            grpGame.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            grpCustomPrograms.SuspendLayout();
            SuspendLayout();
            // 
            // lstConfig
            // 
            lstConfig.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstConfig.FormattingEnabled = true;
            lstConfig.ItemHeight = 15;
            lstConfig.Location = new Point(20, 53);
            lstConfig.Name = "lstConfig";
            lstConfig.Size = new Size(163, 94);
            lstConfig.TabIndex = 1;
            lstConfig.SelectedIndexChanged += lstConfig_SelectedIndexChanged;
            // 
            // chkCustomSettings
            // 
            chkCustomSettings.AutoSize = true;
            chkCustomSettings.Location = new Point(20, 22);
            chkCustomSettings.Name = "chkCustomSettings";
            chkCustomSettings.Size = new Size(135, 19);
            chkCustomSettings.TabIndex = 0;
            chkCustomSettings.Text = "Use Custom Settings";
            chkCustomSettings.UseVisualStyleBackColor = true;
            chkCustomSettings.CheckedChanged += chkCustomSettings_CheckedChanged;
            // 
            // chkCustomPrograms
            // 
            chkCustomPrograms.AutoSize = true;
            chkCustomPrograms.Location = new Point(6, 22);
            chkCustomPrograms.Name = "chkCustomPrograms";
            chkCustomPrograms.Size = new Size(164, 19);
            chkCustomPrograms.TabIndex = 0;
            chkCustomPrograms.Text = "Launch Custom Programs";
            chkCustomPrograms.UseVisualStyleBackColor = true;
            chkCustomPrograms.CheckedChanged += chkCustomPrograms_CheckedChanged;
            // 
            // grpCustomSettings
            // 
            grpCustomSettings.Controls.Add(lstConfig);
            grpCustomSettings.Controls.Add(chkCustomSettings);
            grpCustomSettings.Location = new Point(3, 89);
            grpCustomSettings.Name = "grpCustomSettings";
            grpCustomSettings.Size = new Size(200, 160);
            grpCustomSettings.TabIndex = 1;
            grpCustomSettings.TabStop = false;
            grpCustomSettings.Text = "Custom Settings";
            // 
            // grpGame
            // 
            grpGame.BackColor = SystemColors.Control;
            grpGame.Controls.Add(btnLaunch);
            grpGame.Controls.Add(chkLaunch);
            grpGame.Controls.Add(chkClose);
            grpGame.ForeColor = SystemColors.ControlText;
            grpGame.Location = new Point(3, 3);
            grpGame.Name = "grpGame";
            grpGame.Size = new Size(200, 80);
            grpGame.TabIndex = 0;
            grpGame.TabStop = false;
            grpGame.Text = "Game";
            // 
            // btnLaunch
            // 
            btnLaunch.BackColor = Color.Lime;
            btnLaunch.FlatStyle = FlatStyle.Flat;
            btnLaunch.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLaunch.Location = new Point(6, 22);
            btnLaunch.Name = "btnLaunch";
            btnLaunch.Size = new Size(75, 23);
            btnLaunch.TabIndex = 0;
            btnLaunch.Text = "Launch";
            btnLaunch.UseVisualStyleBackColor = false;
            btnLaunch.Click += btnLaunch_Click;
            // 
            // chkLaunch
            // 
            chkLaunch.AutoSize = true;
            chkLaunch.Location = new Point(6, 51);
            chkLaunch.Name = "chkLaunch";
            chkLaunch.Size = new Size(96, 19);
            chkLaunch.TabIndex = 1;
            chkLaunch.Text = "Auto-Launch";
            chkLaunch.UseVisualStyleBackColor = true;
            chkLaunch.CheckedChanged += chkLaunch_CheckedChanged;
            // 
            // chkClose
            // 
            chkClose.AutoSize = true;
            chkClose.Location = new Point(108, 51);
            chkClose.Name = "chkClose";
            chkClose.Size = new Size(86, 19);
            chkClose.TabIndex = 2;
            chkClose.Text = "Auto-Close";
            chkClose.UseVisualStyleBackColor = true;
            chkClose.CheckedChanged += chkClose_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(grpGame);
            flowLayoutPanel1.Controls.Add(grpCustomSettings);
            flowLayoutPanel1.Controls.Add(grpCustomPrograms);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(206, 458);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // grpCustomPrograms
            // 
            grpCustomPrograms.Controls.Add(btnCustomProgramsRemove);
            grpCustomPrograms.Controls.Add(lstCustomPrograms);
            grpCustomPrograms.Controls.Add(btnCustomProgramsAdd);
            grpCustomPrograms.Controls.Add(txtCustomPrograms);
            grpCustomPrograms.Controls.Add(chkCustomPrograms);
            grpCustomPrograms.Location = new Point(3, 255);
            grpCustomPrograms.Name = "grpCustomPrograms";
            grpCustomPrograms.Size = new Size(200, 200);
            grpCustomPrograms.TabIndex = 2;
            grpCustomPrograms.TabStop = false;
            grpCustomPrograms.Text = "Custom Programs";
            // 
            // btnCustomProgramsRemove
            // 
            btnCustomProgramsRemove.Location = new Point(122, 71);
            btnCustomProgramsRemove.Name = "btnCustomProgramsRemove";
            btnCustomProgramsRemove.Size = new Size(65, 23);
            btnCustomProgramsRemove.TabIndex = 3;
            btnCustomProgramsRemove.Text = "&Remove";
            btnCustomProgramsRemove.UseVisualStyleBackColor = true;
            btnCustomProgramsRemove.Click += btnCustomProgramsRemove_Click;
            // 
            // lstCustomPrograms
            // 
            lstCustomPrograms.FormattingEnabled = true;
            lstCustomPrograms.ItemHeight = 15;
            lstCustomPrograms.Location = new Point(6, 100);
            lstCustomPrograms.Name = "lstCustomPrograms";
            lstCustomPrograms.Size = new Size(181, 94);
            lstCustomPrograms.TabIndex = 4;
            // 
            // btnCustomProgramsAdd
            // 
            btnCustomProgramsAdd.Location = new Point(6, 71);
            btnCustomProgramsAdd.Name = "btnCustomProgramsAdd";
            btnCustomProgramsAdd.Size = new Size(38, 23);
            btnCustomProgramsAdd.TabIndex = 2;
            btnCustomProgramsAdd.Text = "&Add";
            btnCustomProgramsAdd.UseVisualStyleBackColor = true;
            btnCustomProgramsAdd.Click += btnCustomProgramsAdd_Click;
            // 
            // txtCustomPrograms
            // 
            txtCustomPrograms.Location = new Point(6, 47);
            txtCustomPrograms.Name = "txtCustomPrograms";
            txtCustomPrograms.PlaceholderText = "Path to .exe";
            txtCustomPrograms.Size = new Size(181, 23);
            txtCustomPrograms.TabIndex = 1;
            // 
            // frmOptimal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 482);
            Controls.Add(flowLayoutPanel1);
            MaximizeBox = false;
            MinimumSize = new Size(260, 0);
            Name = "frmOptimal";
            ShowIcon = false;
            Text = "FNOP";
            grpCustomSettings.ResumeLayout(false);
            grpCustomSettings.PerformLayout();
            grpGame.ResumeLayout(false);
            grpGame.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            grpCustomPrograms.ResumeLayout(false);
            grpCustomPrograms.PerformLayout();
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
    }
}