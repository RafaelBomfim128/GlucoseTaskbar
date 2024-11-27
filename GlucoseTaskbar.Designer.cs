namespace GlucoseTaskbar
{
    partial class GlucoseTaskbar
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlucoseTaskbar));
            GlucoseValueLabel = new Label();
            LastUpdateLabel = new Label();
            DeltaLabel = new Label();
            DataFetchTimer = new System.Windows.Forms.Timer(components);
            SavePositionTimer = new System.Windows.Forms.Timer(components);
            MenuContextMenuStrip = new ContextMenuStrip(components);
            SettingsToolStripMenuItem = new ToolStripMenuItem();
            RefreshDataToolStripMenuItem = new ToolStripMenuItem();
            LockPositionToolStripMenuItem = new ToolStripMenuItem();
            MoveToToolStripMenuItem = new ToolStripMenuItem();
            BottomLeftCornerToolStripMenuItem = new ToolStripMenuItem();
            CenterScreenToolStripMenuItem = new ToolStripMenuItem();
            BottomRightCornerToolStripMenuItem = new ToolStripMenuItem();
            SaveCustomPositionToolStripMenuItem = new ToolStripMenuItem();
            RestoreCustomPositionToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            TipsToolTip = new ToolTip(components);
            ForceAlwaysInFrontTimer = new System.Windows.Forms.Timer(components);
            toolStripMenuItem6 = new ToolStripMenuItem();
            MenuContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // GlucoseValueLabel
            // 
            GlucoseValueLabel.AutoSize = true;
            GlucoseValueLabel.Font = new Font("Microsoft Sans Serif", 18F);
            GlucoseValueLabel.ForeColor = Color.Green;
            GlucoseValueLabel.Location = new Point(-4, -4);
            GlucoseValueLabel.Name = "GlucoseValueLabel";
            GlucoseValueLabel.Size = new Size(53, 29);
            GlucoseValueLabel.TabIndex = 0;
            GlucoseValueLabel.Text = "N/A";
            TipsToolTip.SetToolTip(GlucoseValueLabel, "Blood glucose");
            // 
            // LastUpdateLabel
            // 
            LastUpdateLabel.AutoSize = true;
            LastUpdateLabel.Font = new Font("Microsoft Sans Serif", 9F);
            LastUpdateLabel.ForeColor = Color.Green;
            LastUpdateLabel.Location = new Point(-1, 23);
            LastUpdateLabel.Name = "LastUpdateLabel";
            LastUpdateLabel.Size = new Size(26, 15);
            LastUpdateLabel.TabIndex = 1;
            LastUpdateLabel.Text = "N/A";
            TipsToolTip.SetToolTip(LastUpdateLabel, "Last update");
            // 
            // DeltaLabel
            // 
            DeltaLabel.AutoSize = true;
            DeltaLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            DeltaLabel.ForeColor = Color.FromArgb(200, 0, 0);
            DeltaLabel.Location = new Point(74, 2);
            DeltaLabel.Name = "DeltaLabel";
            DeltaLabel.Size = new Size(34, 17);
            DeltaLabel.TabIndex = 2;
            DeltaLabel.Text = "N/A";
            TipsToolTip.SetToolTip(DeltaLabel, "Delta");
            // 
            // DataFetchTimer
            // 
            DataFetchTimer.Interval = 15000;
            DataFetchTimer.Tick += DataFetchTimer_Tick;
            // 
            // SavePositionTimer
            // 
            SavePositionTimer.Interval = 200;
            SavePositionTimer.Tick += SavePositionTimer_Tick;
            // 
            // MenuContextMenuStrip
            // 
            MenuContextMenuStrip.Items.AddRange(new ToolStripItem[] { SettingsToolStripMenuItem, RefreshDataToolStripMenuItem, LockPositionToolStripMenuItem, MoveToToolStripMenuItem, ExitToolStripMenuItem });
            MenuContextMenuStrip.Name = "MenuContextMenuStrip";
            MenuContextMenuStrip.Size = new Size(146, 114);
            // 
            // SettingsToolStripMenuItem
            // 
            SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            SettingsToolStripMenuItem.Size = new Size(145, 22);
            SettingsToolStripMenuItem.Text = "Settings";
            SettingsToolStripMenuItem.Click += SettingsToolStripMenuItem_Click;
            // 
            // RefreshDataToolStripMenuItem
            // 
            RefreshDataToolStripMenuItem.Name = "RefreshDataToolStripMenuItem";
            RefreshDataToolStripMenuItem.Size = new Size(145, 22);
            RefreshDataToolStripMenuItem.Text = "Refresh data";
            RefreshDataToolStripMenuItem.Click += RefreshDataToolStripMenuItem_Click;
            // 
            // LockPositionToolStripMenuItem
            // 
            LockPositionToolStripMenuItem.CheckOnClick = true;
            LockPositionToolStripMenuItem.Name = "LockPositionToolStripMenuItem";
            LockPositionToolStripMenuItem.Size = new Size(145, 22);
            LockPositionToolStripMenuItem.Text = "Lock position";
            LockPositionToolStripMenuItem.Click += LockPositionToolStripMenuItem_Click;
            // 
            // MoveToToolStripMenuItem
            // 
            MoveToToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { BottomLeftCornerToolStripMenuItem, CenterScreenToolStripMenuItem, BottomRightCornerToolStripMenuItem, SaveCustomPositionToolStripMenuItem, RestoreCustomPositionToolStripMenuItem });
            MoveToToolStripMenuItem.Name = "MoveToToolStripMenuItem";
            MoveToToolStripMenuItem.Size = new Size(145, 22);
            MoveToToolStripMenuItem.Text = "Move to";
            // 
            // BottomLeftCornerToolStripMenuItem
            // 
            BottomLeftCornerToolStripMenuItem.Name = "BottomLeftCornerToolStripMenuItem";
            BottomLeftCornerToolStripMenuItem.Size = new Size(202, 22);
            BottomLeftCornerToolStripMenuItem.Text = "Bottom left corner";
            BottomLeftCornerToolStripMenuItem.Click += BottomLeftCornerToolStripMenuItem_Click;
            // 
            // CenterScreenToolStripMenuItem
            // 
            CenterScreenToolStripMenuItem.Name = "CenterScreenToolStripMenuItem";
            CenterScreenToolStripMenuItem.Size = new Size(202, 22);
            CenterScreenToolStripMenuItem.Text = "Center screen";
            CenterScreenToolStripMenuItem.Click += CenterScreenToolStripMenuItem_Click;
            // 
            // BottomRightCornerToolStripMenuItem
            // 
            BottomRightCornerToolStripMenuItem.Name = "BottomRightCornerToolStripMenuItem";
            BottomRightCornerToolStripMenuItem.Size = new Size(202, 22);
            BottomRightCornerToolStripMenuItem.Text = "Bottom right corner";
            BottomRightCornerToolStripMenuItem.Click += BottomRightCornerToolStripMenuItem_Click;
            // 
            // SaveCustomPositionToolStripMenuItem
            // 
            SaveCustomPositionToolStripMenuItem.Name = "SaveCustomPositionToolStripMenuItem";
            SaveCustomPositionToolStripMenuItem.Size = new Size(202, 22);
            SaveCustomPositionToolStripMenuItem.Text = "Save custom position";
            SaveCustomPositionToolStripMenuItem.Click += SaveCustomPositionToolStripMenuItem_Click;
            // 
            // RestoreCustomPositionToolStripMenuItem
            // 
            RestoreCustomPositionToolStripMenuItem.Name = "RestoreCustomPositionToolStripMenuItem";
            RestoreCustomPositionToolStripMenuItem.Size = new Size(202, 22);
            RestoreCustomPositionToolStripMenuItem.Text = "Restore custom position";
            RestoreCustomPositionToolStripMenuItem.Click += RestoreCustomPositionToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(145, 22);
            ExitToolStripMenuItem.Text = "Exit";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // TipsToolTip
            // 
            TipsToolTip.AutomaticDelay = 750;
            // 
            // ForceAlwaysInFrontTimer
            // 
            ForceAlwaysInFrontTimer.Interval = 200;
            ForceAlwaysInFrontTimer.Tick += ForceAlwaysInFrontTimer_Tick;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(199, 22);
            toolStripMenuItem6.Text = "Save custom position";
            // 
            // GlucoseTaskbar
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(130, 40);
            Controls.Add(DeltaLabel);
            Controls.Add(LastUpdateLabel);
            Controls.Add(GlucoseValueLabel);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(1, 1);
            Name = "GlucoseTaskbar";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Glucose Taskbar";
            TopMost = true;
            Load += GlucoseTaskbar_LoadAsync;
            LocationChanged += GlucoseTaskbar_LocationChanged;
            MouseDown += GlucoseTaskbar_MouseDown;
            MenuContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label GlucoseValueLabel;
        private Label LastUpdateLabel;
        private Label DeltaLabel;
        private System.Windows.Forms.Timer DataFetchTimer;
        private System.Windows.Forms.Timer SavePositionTimer;
        private ContextMenuStrip MenuContextMenuStrip;
        private ToolStripMenuItem SettingsToolStripMenuItem;
        private ToolTip TipsToolTip;
        private System.Windows.Forms.Timer ForceAlwaysInFrontTimer;
        private ToolStripMenuItem LockPositionToolStripMenuItem;
        private ToolStripMenuItem MoveToToolStripMenuItem;
        private ToolStripMenuItem BottomLeftCornerToolStripMenuItem;
        private ToolStripMenuItem BottomRightCornerToolStripMenuItem;
        private ToolStripMenuItem CenterScreenToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem SaveCustomPositionToolStripMenuItem;
        private ToolStripMenuItem RestoreCustomPositionToolStripMenuItem;
        private ToolStripMenuItem RefreshDataToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
    }
}