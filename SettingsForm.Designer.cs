namespace GlucoseTaskbar
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            LanguageLabel = new Label();
            LanguageComboBox = new ComboBox();
            SaveButton = new Button();
            ViewSettingsScreenLabel = new Label();
            LogsTabPage = new TabPage();
            SaveLogsButton = new Button();
            ClearLogsButton = new Button();
            LogsRichTextBox = new RichTextBox();
            NotificationsTabPage = new TabPage();
            NotificationsLabel = new Label();
            ComingSoonNotificationsLabel = new Label();
            LatestReadsTabPage = new TabPage();
            ComingSoonLastReadsLabel = new Label();
            LastReadsFormsPlot = new ScottPlot.WinForms.FormsPlot();
            LatestReadsLabel = new Label();
            TechnicalTabPage = new TabPage();
            WindowsStartupCheckBox = new CheckBox();
            AccelerateDataFetchCheckBox = new CheckBox();
            label1 = new Label();
            ProgramSizeNumericUpDown = new NumericUpDown();
            ProgramSizeLabel = new Label();
            ForceAlwaysOnTopCheckBox = new CheckBox();
            label2 = new Label();
            OpacityNumericUpDown = new NumericUpDown();
            OpacityLabel = new Label();
            DataRefreshNumericUpDown = new NumericUpDown();
            SecondsLabel = new Label();
            TechnicalSettingsLabel = new Label();
            DataRefreshLabel = new Label();
            MainTabPage = new TabPage();
            BatteryPanel = new Panel();
            NoneRadioButton = new RadioButton();
            BothRadioButton = new RadioButton();
            CellPhoneRadioButton = new RadioButton();
            SensorRadioButton = new RadioButton();
            ShowBatteryLabel = new Label();
            MaxTargetNumericUpDown = new NumericUpDown();
            TargetGlucoseLabel = new Label();
            MinTargetNumericUpDown = new NumericUpDown();
            MainSettingsLabel = new Label();
            NightscoutUrlLabel = new Label();
            NightscoutUrlTextBox = new TextBox();
            TokenTextBox = new TextBox();
            TokenLabel = new Label();
            TabsTabControl = new TabControl();
            label3 = new Label();
            DocumentationLabel = new Label();
            DocLinkLabel = new LinkLabel();
            LogsTabPage.SuspendLayout();
            NotificationsTabPage.SuspendLayout();
            LatestReadsTabPage.SuspendLayout();
            TechnicalTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProgramSizeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpacityNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataRefreshNumericUpDown).BeginInit();
            MainTabPage.SuspendLayout();
            BatteryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MaxTargetNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinTargetNumericUpDown).BeginInit();
            TabsTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // LanguageLabel
            // 
            LanguageLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LanguageLabel.AutoSize = true;
            LanguageLabel.Font = new Font("Microsoft Sans Serif", 10F);
            LanguageLabel.Location = new Point(604, 15);
            LanguageLabel.Margin = new Padding(4, 0, 4, 0);
            LanguageLabel.Name = "LanguageLabel";
            LanguageLabel.Size = new Size(76, 17);
            LanguageLabel.TabIndex = 4;
            LanguageLabel.Text = "Language:";
            // 
            // LanguageComboBox
            // 
            LanguageComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LanguageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LanguageComboBox.Font = new Font("Microsoft Sans Serif", 10F);
            LanguageComboBox.FormattingEnabled = true;
            LanguageComboBox.Items.AddRange(new object[] { "English (US)", "Português (Brasil)" });
            LanguageComboBox.Location = new Point(687, 12);
            LanguageComboBox.Name = "LanguageComboBox";
            LanguageComboBox.Size = new Size(132, 24);
            LanguageComboBox.TabIndex = 5;
            LanguageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SaveButton.Location = new Point(351, 506);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(144, 39);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ViewSettingsScreenLabel
            // 
            ViewSettingsScreenLabel.AutoSize = true;
            ViewSettingsScreenLabel.Location = new Point(12, 452);
            ViewSettingsScreenLabel.Margin = new Padding(4, 0, 4, 0);
            ViewSettingsScreenLabel.Name = "ViewSettingsScreenLabel";
            ViewSettingsScreenLabel.Size = new Size(531, 20);
            ViewSettingsScreenLabel.TabIndex = 19;
            ViewSettingsScreenLabel.Text = "To see this screen again, right-click on the program and then on \"Settings\"";
            // 
            // LogsTabPage
            // 
            LogsTabPage.BackColor = Color.White;
            LogsTabPage.Controls.Add(SaveLogsButton);
            LogsTabPage.Controls.Add(ClearLogsButton);
            LogsTabPage.Controls.Add(LogsRichTextBox);
            LogsTabPage.Location = new Point(4, 24);
            LogsTabPage.Name = "LogsTabPage";
            LogsTabPage.Padding = new Padding(3);
            LogsTabPage.Size = new Size(803, 409);
            LogsTabPage.TabIndex = 2;
            LogsTabPage.Text = "Logs";
            // 
            // SaveLogsButton
            // 
            SaveLogsButton.Location = new Point(344, 366);
            SaveLogsButton.Name = "SaveLogsButton";
            SaveLogsButton.Size = new Size(115, 31);
            SaveLogsButton.TabIndex = 9;
            SaveLogsButton.Text = "Save logs";
            SaveLogsButton.UseVisualStyleBackColor = true;
            SaveLogsButton.Click += SaveLogsButton_Click;
            // 
            // ClearLogsButton
            // 
            ClearLogsButton.Location = new Point(682, 366);
            ClearLogsButton.Name = "ClearLogsButton";
            ClearLogsButton.Size = new Size(115, 31);
            ClearLogsButton.TabIndex = 8;
            ClearLogsButton.Text = "Clear logs";
            ClearLogsButton.UseVisualStyleBackColor = true;
            ClearLogsButton.Click += ClearLogsButton_Click;
            // 
            // LogsRichTextBox
            // 
            LogsRichTextBox.Location = new Point(6, 6);
            LogsRichTextBox.Name = "LogsRichTextBox";
            LogsRichTextBox.Size = new Size(791, 356);
            LogsRichTextBox.TabIndex = 0;
            LogsRichTextBox.Text = "";
            // 
            // NotificationsTabPage
            // 
            NotificationsTabPage.BackColor = Color.White;
            NotificationsTabPage.Controls.Add(NotificationsLabel);
            NotificationsTabPage.Controls.Add(ComingSoonNotificationsLabel);
            NotificationsTabPage.Location = new Point(4, 24);
            NotificationsTabPage.Name = "NotificationsTabPage";
            NotificationsTabPage.Size = new Size(803, 409);
            NotificationsTabPage.TabIndex = 3;
            NotificationsTabPage.Text = "Notifications";
            // 
            // NotificationsLabel
            // 
            NotificationsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NotificationsLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            NotificationsLabel.Location = new Point(0, 3);
            NotificationsLabel.Margin = new Padding(4, 0, 4, 0);
            NotificationsLabel.Name = "NotificationsLabel";
            NotificationsLabel.Size = new Size(790, 30);
            NotificationsLabel.TabIndex = 11;
            NotificationsLabel.Text = "Notifications";
            NotificationsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ComingSoonNotificationsLabel
            // 
            ComingSoonNotificationsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComingSoonNotificationsLabel.BackColor = Color.Silver;
            ComingSoonNotificationsLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            ComingSoonNotificationsLabel.Location = new Point(6, 187);
            ComingSoonNotificationsLabel.Margin = new Padding(4, 0, 4, 0);
            ComingSoonNotificationsLabel.Name = "ComingSoonNotificationsLabel";
            ComingSoonNotificationsLabel.Size = new Size(790, 30);
            ComingSoonNotificationsLabel.TabIndex = 10;
            ComingSoonNotificationsLabel.Text = "Coming soon";
            ComingSoonNotificationsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // LatestReadsTabPage
            // 
            LatestReadsTabPage.BackColor = Color.White;
            LatestReadsTabPage.Controls.Add(ComingSoonLastReadsLabel);
            LatestReadsTabPage.Controls.Add(LastReadsFormsPlot);
            LatestReadsTabPage.Controls.Add(LatestReadsLabel);
            LatestReadsTabPage.Location = new Point(4, 29);
            LatestReadsTabPage.Name = "LatestReadsTabPage";
            LatestReadsTabPage.Padding = new Padding(3);
            LatestReadsTabPage.Size = new Size(803, 404);
            LatestReadsTabPage.TabIndex = 4;
            LatestReadsTabPage.Text = "Latest Reads";
            // 
            // ComingSoonLastReadsLabel
            // 
            ComingSoonLastReadsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ComingSoonLastReadsLabel.BackColor = Color.Silver;
            ComingSoonLastReadsLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            ComingSoonLastReadsLabel.Location = new Point(6, 187);
            ComingSoonLastReadsLabel.Margin = new Padding(4, 0, 4, 0);
            ComingSoonLastReadsLabel.Name = "ComingSoonLastReadsLabel";
            ComingSoonLastReadsLabel.Size = new Size(790, 30);
            ComingSoonLastReadsLabel.TabIndex = 9;
            ComingSoonLastReadsLabel.Text = "Coming soon";
            ComingSoonLastReadsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // LastReadsFormsPlot
            // 
            LastReadsFormsPlot.DisplayScale = 1F;
            LastReadsFormsPlot.Enabled = false;
            LastReadsFormsPlot.Location = new Point(55, 48);
            LastReadsFormsPlot.Name = "LastReadsFormsPlot";
            LastReadsFormsPlot.Size = new Size(647, 322);
            LastReadsFormsPlot.TabIndex = 8;
            LastReadsFormsPlot.MouseMove += LastReadsFormsPlot_MouseMove;
            // 
            // LatestReadsLabel
            // 
            LatestReadsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LatestReadsLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            LatestReadsLabel.Location = new Point(0, 3);
            LatestReadsLabel.Margin = new Padding(4, 0, 4, 0);
            LatestReadsLabel.Name = "LatestReadsLabel";
            LatestReadsLabel.Size = new Size(790, 30);
            LatestReadsLabel.TabIndex = 7;
            LatestReadsLabel.Text = "Latest Reads";
            LatestReadsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // TechnicalTabPage
            // 
            TechnicalTabPage.BackColor = Color.White;
            TechnicalTabPage.Controls.Add(WindowsStartupCheckBox);
            TechnicalTabPage.Controls.Add(AccelerateDataFetchCheckBox);
            TechnicalTabPage.Controls.Add(label1);
            TechnicalTabPage.Controls.Add(ProgramSizeNumericUpDown);
            TechnicalTabPage.Controls.Add(ProgramSizeLabel);
            TechnicalTabPage.Controls.Add(ForceAlwaysOnTopCheckBox);
            TechnicalTabPage.Controls.Add(label2);
            TechnicalTabPage.Controls.Add(OpacityNumericUpDown);
            TechnicalTabPage.Controls.Add(OpacityLabel);
            TechnicalTabPage.Controls.Add(DataRefreshNumericUpDown);
            TechnicalTabPage.Controls.Add(SecondsLabel);
            TechnicalTabPage.Controls.Add(TechnicalSettingsLabel);
            TechnicalTabPage.Controls.Add(DataRefreshLabel);
            TechnicalTabPage.Location = new Point(4, 24);
            TechnicalTabPage.Name = "TechnicalTabPage";
            TechnicalTabPage.Padding = new Padding(3);
            TechnicalTabPage.Size = new Size(803, 409);
            TechnicalTabPage.TabIndex = 1;
            TechnicalTabPage.Text = "Technical";
            // 
            // WindowsStartupCheckBox
            // 
            WindowsStartupCheckBox.Location = new Point(386, 182);
            WindowsStartupCheckBox.Name = "WindowsStartupCheckBox";
            WindowsStartupCheckBox.Size = new Size(411, 46);
            WindowsStartupCheckBox.TabIndex = 28;
            WindowsStartupCheckBox.Text = "Open at Windows startup";
            WindowsStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // AccelerateDataFetchCheckBox
            // 
            AccelerateDataFetchCheckBox.Location = new Point(386, 121);
            AccelerateDataFetchCheckBox.Name = "AccelerateDataFetchCheckBox";
            AccelerateDataFetchCheckBox.Size = new Size(411, 46);
            AccelerateDataFetchCheckBox.TabIndex = 27;
            AccelerateDataFetchCheckBox.Text = "Accelerate data fetch if glucose changes rapidly";
            AccelerateDataFetchCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 184);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 26;
            // 
            // ProgramSizeNumericUpDown
            // 
            ProgramSizeNumericUpDown.BackColor = Color.White;
            ProgramSizeNumericUpDown.DecimalPlaces = 1;
            ProgramSizeNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            ProgramSizeNumericUpDown.Location = new Point(184, 182);
            ProgramSizeNumericUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            ProgramSizeNumericUpDown.Minimum = new decimal(new int[] { 7, 0, 0, 65536 });
            ProgramSizeNumericUpDown.Name = "ProgramSizeNumericUpDown";
            ProgramSizeNumericUpDown.ReadOnly = true;
            ProgramSizeNumericUpDown.Size = new Size(54, 26);
            ProgramSizeNumericUpDown.TabIndex = 25;
            ProgramSizeNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ProgramSizeLabel
            // 
            ProgramSizeLabel.AutoSize = true;
            ProgramSizeLabel.Location = new Point(72, 184);
            ProgramSizeLabel.Margin = new Padding(4, 0, 4, 0);
            ProgramSizeLabel.Name = "ProgramSizeLabel";
            ProgramSizeLabel.Size = new Size(105, 20);
            ProgramSizeLabel.TabIndex = 24;
            ProgramSizeLabel.Text = "Program size:";
            // 
            // ForceAlwaysOnTopCheckBox
            // 
            ForceAlwaysOnTopCheckBox.Location = new Point(386, 64);
            ForceAlwaysOnTopCheckBox.Name = "ForceAlwaysOnTopCheckBox";
            ForceAlwaysOnTopCheckBox.Size = new Size(411, 46);
            ForceAlwaysOnTopCheckBox.TabIndex = 23;
            ForceAlwaysOnTopCheckBox.Text = "Force program always on top and allow entry into the taskbar";
            ForceAlwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            ForceAlwaysOnTopCheckBox.CheckedChanged += ForceAlwaysOnTopCheckBox_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(245, 133);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(23, 20);
            label2.TabIndex = 19;
            label2.Text = "%";
            // 
            // OpacityNumericUpDown
            // 
            OpacityNumericUpDown.Location = new Point(184, 131);
            OpacityNumericUpDown.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            OpacityNumericUpDown.Name = "OpacityNumericUpDown";
            OpacityNumericUpDown.Size = new Size(54, 26);
            OpacityNumericUpDown.TabIndex = 18;
            OpacityNumericUpDown.Value = new decimal(new int[] { 70, 0, 0, 0 });
            // 
            // OpacityLabel
            // 
            OpacityLabel.AutoSize = true;
            OpacityLabel.Location = new Point(64, 133);
            OpacityLabel.Margin = new Padding(4, 0, 4, 0);
            OpacityLabel.Name = "OpacityLabel";
            OpacityLabel.Size = new Size(113, 20);
            OpacityLabel.TabIndex = 17;
            OpacityLabel.Text = "Transparency: ";
            // 
            // DataRefreshNumericUpDown
            // 
            DataRefreshNumericUpDown.Location = new Point(184, 74);
            DataRefreshNumericUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            DataRefreshNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            DataRefreshNumericUpDown.Name = "DataRefreshNumericUpDown";
            DataRefreshNumericUpDown.Size = new Size(44, 26);
            DataRefreshNumericUpDown.TabIndex = 11;
            DataRefreshNumericUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // SecondsLabel
            // 
            SecondsLabel.AutoSize = true;
            SecondsLabel.Location = new Point(235, 76);
            SecondsLabel.Margin = new Padding(4, 0, 4, 0);
            SecondsLabel.Name = "SecondsLabel";
            SecondsLabel.Size = new Size(69, 20);
            SecondsLabel.TabIndex = 10;
            SecondsLabel.Text = "seconds";
            // 
            // TechnicalSettingsLabel
            // 
            TechnicalSettingsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TechnicalSettingsLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            TechnicalSettingsLabel.Location = new Point(7, 3);
            TechnicalSettingsLabel.Margin = new Padding(4, 0, 4, 0);
            TechnicalSettingsLabel.Name = "TechnicalSettingsLabel";
            TechnicalSettingsLabel.Size = new Size(790, 30);
            TechnicalSettingsLabel.TabIndex = 9;
            TechnicalSettingsLabel.Text = "Technical Settings";
            TechnicalSettingsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // DataRefreshLabel
            // 
            DataRefreshLabel.AutoSize = true;
            DataRefreshLabel.Location = new Point(17, 76);
            DataRefreshLabel.Margin = new Padding(4, 0, 4, 0);
            DataRefreshLabel.Name = "DataRefreshLabel";
            DataRefreshLabel.Size = new Size(160, 20);
            DataRefreshLabel.TabIndex = 7;
            DataRefreshLabel.Text = "Data refresh interval: ";
            // 
            // MainTabPage
            // 
            MainTabPage.BackColor = Color.White;
            MainTabPage.Controls.Add(BatteryPanel);
            MainTabPage.Controls.Add(ShowBatteryLabel);
            MainTabPage.Controls.Add(MaxTargetNumericUpDown);
            MainTabPage.Controls.Add(TargetGlucoseLabel);
            MainTabPage.Controls.Add(MinTargetNumericUpDown);
            MainTabPage.Controls.Add(MainSettingsLabel);
            MainTabPage.Controls.Add(NightscoutUrlLabel);
            MainTabPage.Controls.Add(NightscoutUrlTextBox);
            MainTabPage.Controls.Add(TokenTextBox);
            MainTabPage.Controls.Add(TokenLabel);
            MainTabPage.Location = new Point(4, 29);
            MainTabPage.Name = "MainTabPage";
            MainTabPage.Padding = new Padding(3);
            MainTabPage.Size = new Size(803, 404);
            MainTabPage.TabIndex = 0;
            MainTabPage.Text = "Main";
            // 
            // BatteryPanel
            // 
            BatteryPanel.BorderStyle = BorderStyle.FixedSingle;
            BatteryPanel.Controls.Add(NoneRadioButton);
            BatteryPanel.Controls.Add(BothRadioButton);
            BatteryPanel.Controls.Add(CellPhoneRadioButton);
            BatteryPanel.Controls.Add(SensorRadioButton);
            BatteryPanel.Location = new Point(175, 206);
            BatteryPanel.Name = "BatteryPanel";
            BatteryPanel.Size = new Size(200, 125);
            BatteryPanel.TabIndex = 18;
            // 
            // NoneRadioButton
            // 
            NoneRadioButton.AutoSize = true;
            NoneRadioButton.Location = new Point(3, 93);
            NoneRadioButton.Name = "NoneRadioButton";
            NoneRadioButton.Size = new Size(65, 24);
            NoneRadioButton.TabIndex = 18;
            NoneRadioButton.Text = "None";
            NoneRadioButton.UseVisualStyleBackColor = true;
            // 
            // BothRadioButton
            // 
            BothRadioButton.AutoSize = true;
            BothRadioButton.Location = new Point(3, 63);
            BothRadioButton.Name = "BothRadioButton";
            BothRadioButton.Size = new Size(61, 24);
            BothRadioButton.TabIndex = 17;
            BothRadioButton.Text = "Both";
            BothRadioButton.UseVisualStyleBackColor = true;
            // 
            // CellPhoneRadioButton
            // 
            CellPhoneRadioButton.AutoSize = true;
            CellPhoneRadioButton.Location = new Point(3, 33);
            CellPhoneRadioButton.Name = "CellPhoneRadioButton";
            CellPhoneRadioButton.Size = new Size(102, 24);
            CellPhoneRadioButton.TabIndex = 16;
            CellPhoneRadioButton.Text = "Cell phone";
            CellPhoneRadioButton.UseVisualStyleBackColor = true;
            // 
            // SensorRadioButton
            // 
            SensorRadioButton.AutoSize = true;
            SensorRadioButton.Checked = true;
            SensorRadioButton.Location = new Point(3, 3);
            SensorRadioButton.Name = "SensorRadioButton";
            SensorRadioButton.Size = new Size(78, 24);
            SensorRadioButton.TabIndex = 15;
            SensorRadioButton.TabStop = true;
            SensorRadioButton.Text = "Sensor";
            SensorRadioButton.UseVisualStyleBackColor = true;
            // 
            // ShowBatteryLabel
            // 
            ShowBatteryLabel.AutoSize = true;
            ShowBatteryLabel.Location = new Point(58, 239);
            ShowBatteryLabel.Margin = new Padding(4, 0, 4, 0);
            ShowBatteryLabel.Name = "ShowBatteryLabel";
            ShowBatteryLabel.Size = new Size(110, 20);
            ShowBatteryLabel.TabIndex = 17;
            ShowBatteryLabel.Text = "Show battery: ";
            // 
            // MaxTargetNumericUpDown
            // 
            MaxTargetNumericUpDown.Location = new Point(235, 156);
            MaxTargetNumericUpDown.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            MaxTargetNumericUpDown.Minimum = new decimal(new int[] { 101, 0, 0, 0 });
            MaxTargetNumericUpDown.Name = "MaxTargetNumericUpDown";
            MaxTargetNumericUpDown.Size = new Size(54, 26);
            MaxTargetNumericUpDown.TabIndex = 9;
            MaxTargetNumericUpDown.Value = new decimal(new int[] { 180, 0, 0, 0 });
            // 
            // TargetGlucoseLabel
            // 
            TargetGlucoseLabel.AutoSize = true;
            TargetGlucoseLabel.Location = new Point(45, 158);
            TargetGlucoseLabel.Margin = new Padding(4, 0, 4, 0);
            TargetGlucoseLabel.Name = "TargetGlucoseLabel";
            TargetGlucoseLabel.Size = new Size(122, 20);
            TargetGlucoseLabel.TabIndex = 8;
            TargetGlucoseLabel.Text = "Target Glucose:";
            // 
            // MinTargetNumericUpDown
            // 
            MinTargetNumericUpDown.Location = new Point(175, 156);
            MinTargetNumericUpDown.Minimum = new decimal(new int[] { 70, 0, 0, 0 });
            MinTargetNumericUpDown.Name = "MinTargetNumericUpDown";
            MinTargetNumericUpDown.Size = new Size(54, 26);
            MinTargetNumericUpDown.TabIndex = 7;
            MinTargetNumericUpDown.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // MainSettingsLabel
            // 
            MainSettingsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MainSettingsLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            MainSettingsLabel.Location = new Point(7, 3);
            MainSettingsLabel.Margin = new Padding(4, 0, 4, 0);
            MainSettingsLabel.Name = "MainSettingsLabel";
            MainSettingsLabel.Size = new Size(790, 30);
            MainSettingsLabel.TabIndex = 6;
            MainSettingsLabel.Text = "Main Settings";
            MainSettingsLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // NightscoutUrlLabel
            // 
            NightscoutUrlLabel.AutoSize = true;
            NightscoutUrlLabel.Location = new Point(41, 77);
            NightscoutUrlLabel.Margin = new Padding(4, 0, 4, 0);
            NightscoutUrlLabel.Name = "NightscoutUrlLabel";
            NightscoutUrlLabel.Size = new Size(126, 20);
            NightscoutUrlLabel.TabIndex = 0;
            NightscoutUrlLabel.Text = "Nightscout URL:";
            // 
            // NightscoutUrlTextBox
            // 
            NightscoutUrlTextBox.Location = new Point(175, 74);
            NightscoutUrlTextBox.Margin = new Padding(4);
            NightscoutUrlTextBox.Name = "NightscoutUrlTextBox";
            NightscoutUrlTextBox.Size = new Size(355, 26);
            NightscoutUrlTextBox.TabIndex = 1;
            // 
            // TokenTextBox
            // 
            TokenTextBox.Location = new Point(175, 108);
            TokenTextBox.Margin = new Padding(4);
            TokenTextBox.Name = "TokenTextBox";
            TokenTextBox.Size = new Size(355, 26);
            TokenTextBox.TabIndex = 3;
            // 
            // TokenLabel
            // 
            TokenLabel.AutoSize = true;
            TokenLabel.Location = new Point(13, 111);
            TokenLabel.Margin = new Padding(4, 0, 4, 0);
            TokenLabel.Name = "TokenLabel";
            TokenLabel.Size = new Size(154, 20);
            TokenLabel.TabIndex = 2;
            TokenLabel.Text = "Token (if applicable):";
            // 
            // TabsTabControl
            // 
            TabsTabControl.Controls.Add(MainTabPage);
            TabsTabControl.Controls.Add(TechnicalTabPage);
            TabsTabControl.Controls.Add(LatestReadsTabPage);
            TabsTabControl.Controls.Add(NotificationsTabPage);
            TabsTabControl.Controls.Add(LogsTabPage);
            TabsTabControl.Location = new Point(12, 12);
            TabsTabControl.Name = "TabsTabControl";
            TabsTabControl.SelectedIndex = 0;
            TabsTabControl.Size = new Size(811, 437);
            TabsTabControl.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10F);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(610, 531);
            label3.Name = "label3";
            label3.Size = new Size(209, 17);
            label3.TabIndex = 20;
            label3.Text = "Copyright (C) 2024 Rafael Assis";
            // 
            // DocumentationLabel
            // 
            DocumentationLabel.AutoSize = true;
            DocumentationLabel.Location = new Point(12, 528);
            DocumentationLabel.Name = "DocumentationLabel";
            DocumentationLabel.Size = new Size(118, 20);
            DocumentationLabel.TabIndex = 21;
            DocumentationLabel.Text = "Documentation";
            // 
            // DocLinkLabel
            // 
            DocLinkLabel.AutoSize = true;
            DocLinkLabel.Location = new Point(127, 528);
            DocLinkLabel.Name = "DocLinkLabel";
            DocLinkLabel.Size = new Size(41, 20);
            DocLinkLabel.TabIndex = 22;
            DocLinkLabel.TabStop = true;
            DocLinkLabel.Text = "here";
            DocLinkLabel.LinkClicked += DocLinkLabel_LinkClicked;
            // 
            // SettingsForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(831, 557);
            Controls.Add(SaveButton);
            Controls.Add(DocLinkLabel);
            Controls.Add(DocumentationLabel);
            Controls.Add(label3);
            Controls.Add(ViewSettingsScreenLabel);
            Controls.Add(LanguageComboBox);
            Controls.Add(LanguageLabel);
            Controls.Add(TabsTabControl);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings - Glucose Taskbar";
            FormClosing += SettingsForm_FormClosing;
            FormClosed += SettingsForm_FormClosed;
            Load += SettingsForm_Load;
            LogsTabPage.ResumeLayout(false);
            NotificationsTabPage.ResumeLayout(false);
            LatestReadsTabPage.ResumeLayout(false);
            TechnicalTabPage.ResumeLayout(false);
            TechnicalTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ProgramSizeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)OpacityNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataRefreshNumericUpDown).EndInit();
            MainTabPage.ResumeLayout(false);
            MainTabPage.PerformLayout();
            BatteryPanel.ResumeLayout(false);
            BatteryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MaxTargetNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinTargetNumericUpDown).EndInit();
            TabsTabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LanguageLabel;
        private ComboBox LanguageComboBox;
        private Button SaveButton;
        private Label ViewSettingsScreenLabel;
        private CheckBox WindowsStartupCheckBox;
        private TabPage LogsTabPage;
        private Button ClearLogsButton;
        private RichTextBox LogsRichTextBox;
        private TabPage NotificationsTabPage;
        private TabPage LatestReadsTabPage;
        private Label LastestReadsLabel;
        private TabPage TechnicalTabPage;
        private CheckBox AccelerateDataFetchCheckBox;
        private Label label1;
        private NumericUpDown ProgramSizeNumericUpDown;
        private Label ProgramSizeLabel;
        private CheckBox ForceAlwaysOnTopCheckBox;
        private Label label2;
        private NumericUpDown OpacityNumericUpDown;
        private Label OpacityLabel;
        private NumericUpDown DataRefreshNumericUpDown;
        private Label SecondsLabel;
        private Label TechnicalSettingsLabel;
        private Label DataRefreshLabel;
        private TabPage MainTabPage;
        private Panel BatteryPanel;
        internal RadioButton BothRadioButton;
        internal RadioButton CellPhoneRadioButton;
        internal RadioButton SensorRadioButton;
        private Label ShowBatteryLabel;
        private NumericUpDown MaxTargetNumericUpDown;
        private Label TargetGlucoseLabel;
        private NumericUpDown MinTargetNumericUpDown;
        private Label MainSettingsLabel;
        private Label NightscoutUrlLabel;
        private TextBox NightscoutUrlTextBox;
        private TextBox TokenTextBox;
        private Label TokenLabel;
        private TabControl TabsTabControl;
        private ScottPlot.WinForms.FormsPlot LastReadsFormsPlot;
        private Label ComingSoonLastReadsLabel;
        private Label ComingSoonNotificationsLabel;
        private Label NotificationsLabel;
        internal RadioButton NoneRadioButton;
        private Label label3;
        private Button SaveLogsButton;
        private Label DocumentationLabel;
        private LinkLabel DocLinkLabel;
        private Label LatestReadsLabel;
    }
}