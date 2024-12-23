// Glucose Taskbar - Program for glucose monitoring
// Copyright (C) 2024 Rafael Assis

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.

using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Resources;
using System.Windows.Forms;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace GlucoseTaskbar
{
    public partial class GlucoseTaskbar : Form
    {
        readonly ResourceManager resourceManager;
        readonly static ResourceManager prm = Properties.Resources.ResourceManager;
        readonly NightscoutData nsData;
        readonly SettingsForm settingsForm;
        readonly ControlPropertiesManager controlPropertiesManager;
        readonly PictureBox SensorBatteryPictureBox;
        readonly PictureBox CellPhoneBatteryPictureBox;
        readonly Label SettingsOpenLabel;
        Size originalFormSize;

        //Importing native Windows functions to allow draggin the Form
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public GlucoseTaskbar()
        {
            InitializeComponent();
            resourceManager = new("GlucoseTaskbar.Resources", typeof(Program).Assembly);
            nsData = new NightscoutData();
            settingsForm = new(this, nsData);
            SetOpacity();
            CultureManager.SetCulture();
            AttachMouseDownEventToControls(this);
            float dpiScale = DeviceDpi / 96f;
            SensorBatteryPictureBox = new PictureBox()
            {
                Size = new Size(
                    (int)(19 * dpiScale),
                    (int)(36 * dpiScale)
                ),
                Location = new Point(
                    (int)(110 * dpiScale),
                    (int)(0 * dpiScale)
                ),
                Image = Properties.Resources.battery_no_signal,
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            CellPhoneBatteryPictureBox = new PictureBox()
            {
                Size = new Size(
                    (int)(19 * dpiScale),
                    (int)(36* dpiScale)
                ),
                Location = new Point(
                    (int)(110 * dpiScale),
                    (int)(0 * dpiScale)
                ),
                Image = Properties.Resources.battery_no_signal,
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            SettingsOpenLabel = new Label()
            {
                Text = resourceManager.GetString("SettingsOpenLabel"),
                Font = new System.Drawing.Font("Arial", 14),
                ForeColor = Color.White,
                AutoSize = true,
                Visible = false
            };
            SettingsOpenLabel.BringToFront();
            this.Controls.Add(SettingsOpenLabel);
            SettingsOpenLabel.Location = new Point((this.ClientSize.Width - SettingsOpenLabel.Width) / 2, (this.ClientSize.Height - SettingsOpenLabel.Height) / 2);
            AttachMouseDownEventToControls(SensorBatteryPictureBox);
            AttachMouseDownEventToControls(CellPhoneBatteryPictureBox);
            AttachMouseDownEventToControls(SettingsOpenLabel);
            SetTooltipsTexts();
            SetContextMenuTexts();
            controlPropertiesManager = new ControlPropertiesManager(this);
            controlPropertiesManager.StoreOriginalProperties(this);
            controlPropertiesManager.StoreOriginalProperties(SensorBatteryPictureBox);
            controlPropertiesManager.StoreOriginalProperties(CellPhoneBatteryPictureBox);
            controlPropertiesManager.StoreOriginalProperties(SettingsOpenLabel);
            SetProgramSize();
            LockPositionToolStripMenuItem.Checked = Properties.Settings.Default.LockPosition;
        }

        private async void GlucoseTaskbar_LoadAsync(object sender, EventArgs e)
        {
            SetFormPosition();
            SetDataFetchInterval();
            if (Properties.Settings.Default.Url.Trim() == String.Empty)
            {
                OpenSettingsForm(); //Open settings if url is not defined
            }
            else
            {
                await RefreshGlucoseData(true);
                DataFetchTimer.Start();
            }
            this.TopLevel = true;
            this.TopMost = true;
            this.BringToFront();
            SetForceAlwaysInFrontTimer();
        }

        private void SetContextMenuTexts()
        {
            SettingsToolStripMenuItem.Text = resourceManager.GetString("SettingsToolStripMenuItem");
            RefreshDataToolStripMenuItem.Text = resourceManager.GetString("RefreshDataToolStripMenuItem");
            LockPositionToolStripMenuItem.Text = resourceManager.GetString("LockPositionToolStripMenuItem");
            MoveToToolStripMenuItem.Text = resourceManager.GetString("MoveToToolStripMenuItem");
            BottomLeftCornerToolStripMenuItem.Text = resourceManager.GetString("BottomLeftCornerToolStripMenuItem");
            CenterScreenToolStripMenuItem.Text = resourceManager.GetString("CenterScreenToolStripMenuItem");
            BottomRightCornerToolStripMenuItem.Text = resourceManager.GetString("BottomRightCornerToolStripMenuItem");
            SaveCustomPositionToolStripMenuItem.Text = resourceManager.GetString("SaveCustomPositionToolStripMenuItem");
            RestoreCustomPositionToolStripMenuItem.Text = resourceManager.GetString("RestoreCustomPositionToolStripMenuItem");
            ExitToolStripMenuItem.Text = resourceManager.GetString("ExitToolStripMenuItem");
        }

        private void SetTooltipsTexts()
        {
            TipsToolTip.SetToolTip(GlucoseValueLabel, resourceManager.GetString("GlucoseValueLabelTip"));
            TipsToolTip.SetToolTip(DeltaLabel, resourceManager.GetString("DeltaLabelTip"));
            TipsToolTip.SetToolTip(LastUpdateLabel, resourceManager.GetString("LastUpdateLabelTip"));
            TipsToolTip.SetToolTip(SensorBatteryPictureBox, resourceManager.GetString("SensorBatteryPictureBoxTip") + $": {nsData.SensorBattery}%");
            TipsToolTip.SetToolTip(CellPhoneBatteryPictureBox, resourceManager.GetString("CellPhoneBatteryPictureBoxTip") + $": {nsData.CellPhoneBattery}%");
        }

        public async Task<bool> RefreshGlucoseData(bool showError = false)
        {
            bool success = await nsData.RefreshGlucoseData(showError);
            FillData();
            return success;
        }

        private void FillData()
        {
            GlucoseValueLabel.Text = $"{nsData.NsDataLastReads[0].Sgv} {nsData.NsDataLastReads[0].Direction}";
            int sgv;
            decimal minTarget, maxTarget;
            bool oldData = nsData.OldDataGlucose;
            SetDataFetchInterval();

            try
            {
                sgv = int.Parse(nsData.NsDataLastReads[0].Sgv);
                minTarget = Properties.Settings.Default.MinTarget;
                maxTarget = Properties.Settings.Default.MaxTarget;

                if (sgv < minTarget || sgv > maxTarget || oldData) //if off target or old, set yellow color
                {
                    GlucoseValueLabel.ForeColor = Color.Yellow;
                }
                else
                {
                    GlucoseValueLabel.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.GetType()}: {ex.Message}");
                GlucoseValueLabel.ForeColor = Color.Yellow;
            }

            DeltaLabel.Text = nsData.NsDataLastReads[0].Delta;
            LastUpdateLabel.Text = nsData.NsDataLastReads[0].TimeDiffLastUpdate;

            FillBattery();

            if (oldData)
            {
                GlucoseValueLabel.Font = new System.Drawing.Font(GlucoseValueLabel.Font, GlucoseValueLabel.Font.Style | FontStyle.Strikeout);
                DeltaLabel.Font = new System.Drawing.Font(DeltaLabel.Font, DeltaLabel.Font.Style | FontStyle.Strikeout);
            }
            else
            {
                GlucoseValueLabel.Font = new System.Drawing.Font(GlucoseValueLabel.Font, GlucoseValueLabel.Font.Style & ~FontStyle.Strikeout);
                DeltaLabel.Font = new System.Drawing.Font(DeltaLabel.Font, DeltaLabel.Font.Style & ~FontStyle.Strikeout);
            }

            TipsToolTip.SetToolTip(SensorBatteryPictureBox, resourceManager.GetString("SensorBatteryPictureBoxTip") + $": {nsData.SensorBattery}%");
            TipsToolTip.SetToolTip(CellPhoneBatteryPictureBox, resourceManager.GetString("CellPhoneBatteryPictureBoxTip") + $": {nsData.CellPhoneBattery}%");
        }


        private void FillBattery()
        {
            float dpiScale = DeviceDpi / 96f;
            decimal scale = Properties.Settings.Default.ProgramSize;

            static void SetBatteryValue(PictureBox pctBattery, int value, bool oldData)
            {
                string suffix = oldData ? "_old_data" : "";
                pctBattery.Image = value switch
                {
                    0 or 1 => Properties.Resources.battery_0,
                    >= 2 and < 20 => (System.Drawing.Image)(prm.GetObject($"battery_1{suffix}") ?? Properties.Resources.battery_no_signal),
                    >= 20 and < 40 => (System.Drawing.Image)(prm.GetObject($"battery_2{suffix}") ?? Properties.Resources.battery_no_signal),
                    >= 40 and < 60 => (System.Drawing.Image)(prm.GetObject($"battery_3{suffix}") ?? Properties.Resources.battery_no_signal),
                    >= 60 and < 80 => (System.Drawing.Image)(prm.GetObject($"battery_4{suffix}") ?? Properties.Resources.battery_no_signal),
                    >= 80 and <= 100 => (System.Drawing.Image)(prm.GetObject($"battery_5{suffix}") ?? Properties.Resources.battery_no_signal),
                    _ => Properties.Resources.battery_no_signal,
                };
            }

            SetBatteryValue(SensorBatteryPictureBox, nsData.SensorBattery, nsData.OldDataBatterySensor);
            SetBatteryValue(CellPhoneBatteryPictureBox, nsData.CellPhoneBattery, nsData.OldDataBatteryCellPhone);

            string battery = Properties.Settings.Default.ShowBattery;
            if (battery == settingsForm.SensorRadioButton.Name)
            {
                this.Size = originalFormSize;
                this.Controls.Remove(CellPhoneBatteryPictureBox);
                this.Controls.Add(SensorBatteryPictureBox);
            }
            else if (battery == settingsForm.CellPhoneRadioButton.Name)
            {
                this.Size = originalFormSize;
                this.Controls.Remove(SensorBatteryPictureBox);
                CellPhoneBatteryPictureBox.Location = new Point(SensorBatteryPictureBox.Location.X, SensorBatteryPictureBox.Location.Y);
                this.Controls.Add(CellPhoneBatteryPictureBox);
            }
            else if (battery == settingsForm.BothRadioButton.Name)
            {
                this.Size = new Size(originalFormSize.Width + CellPhoneBatteryPictureBox.Width + (int)(2 * scale), originalFormSize.Height);
                CellPhoneBatteryPictureBox.Location = new Point(
                    (int)(SensorBatteryPictureBox.Location.X + (20 * dpiScale * (float)scale)),
                    (int)(SensorBatteryPictureBox.Location.Y * scale)
                );
                this.Controls.Add(SensorBatteryPictureBox);
                this.Controls.Add(CellPhoneBatteryPictureBox);
            }
            else if (battery == settingsForm.NoneRadioButton.Name)
            {
                this.Controls.Remove(SensorBatteryPictureBox);
                this.Controls.Remove(CellPhoneBatteryPictureBox);
                this.Size = new Size(originalFormSize.Width - SensorBatteryPictureBox.Width, originalFormSize.Height);
            }

            FixPosition();
        }

        private void OpenSettingsForm()
        {
            if (settingsForm.Visible)
            {
                settingsForm.BringToFront();
                return;
            }
            DataFetchTimer.Stop();
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
            SettingsOpenLabel.Location = new Point((this.ClientSize.Width - SettingsOpenLabel.Width) / 2, (this.ClientSize.Height - SettingsOpenLabel.Height) / 2);
            SettingsOpenLabel.Visible = true;
            settingsForm.ShowDialog();
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
            }
            SettingsOpenLabel.Visible = false;
            SetDataFetchInterval();
            DataFetchTimer.Start();
        }

        //Scale function
        public void SetProgramSize()
        {
            controlPropertiesManager.RestoreOriginalProperties();
            decimal scale = Properties.Settings.Default.ProgramSize;
            Width = (int)(Width * scale);
            Height = (int)(Height * scale);

            foreach (Control control in Controls)
            {
                int originalX = control.Location.X;
                int originalY = control.Location.Y;

                control.Width = (int)(control.Width * scale);
                control.Height = (int)(control.Height * scale);

                control.Location = new Point((int)(originalX * scale), (int)(originalY * scale));

                control.Font = new System.Drawing.Font(control.Font.FontFamily, control.Font.Size * (float)scale, control.Font.Style);

                control.PerformLayout();
            }

            if (!this.Controls.Contains(SensorBatteryPictureBox))
            {
                SensorBatteryPictureBox.Width = (int)(SensorBatteryPictureBox.Width * scale);
                SensorBatteryPictureBox.Height = (int)(SensorBatteryPictureBox.Height * scale);
                int originalBatterySensorX = SensorBatteryPictureBox.Location.X;
                int originalBatterySensorY = SensorBatteryPictureBox.Location.Y;
                SensorBatteryPictureBox.Location = new Point((int)(originalBatterySensorX * scale), (int)(originalBatterySensorY * scale));
            }

            if (!this.Controls.Contains(CellPhoneBatteryPictureBox))
            {
                CellPhoneBatteryPictureBox.Width = (int)(CellPhoneBatteryPictureBox.Width * scale);
                CellPhoneBatteryPictureBox.Height = (int)(CellPhoneBatteryPictureBox.Height * scale);
                int originalBatteryCellPhoneX = CellPhoneBatteryPictureBox.Location.X;
                int originalBatteryCellPhoneY = CellPhoneBatteryPictureBox.Location.Y;
                CellPhoneBatteryPictureBox.Location = new Point((int)(originalBatteryCellPhoneX * scale), (int)(originalBatteryCellPhoneY * scale));
            }

            originalFormSize = this.Size;
        }

        //Public method that updates the texts when the language is changed
        public void UpdateTextsCulture()
        {
            if (nsData.NsDataLastReads.Count > 0)
                LastUpdateLabel.Text = nsData.NsDataLastReads[0].TimeDiffLastUpdate;
            SettingsOpenLabel.Text = resourceManager.GetString("SettingsOpenLabel");
            SetTooltipsTexts();
            SetContextMenuTexts();
        }

        public void SetOpacity()
        {
            this.Opacity = (double)Properties.Settings.Default.Opacity / 100;
        }

        public void SetForceAlwaysInFrontTimer()
        {
            ForceAlwaysInFrontTimer.Enabled = Properties.Settings.Default.ForceAlwaysInFront;
        }

        //Set the form position. If the position is not defined, set the form above the time and date
        private void SetFormPosition()
        {
            string formXPosition = Properties.Settings.Default.FormXPosition;
            string formYPosition = Properties.Settings.Default.FormYPosition;

            if (string.IsNullOrWhiteSpace(formXPosition) || string.IsNullOrWhiteSpace(formYPosition))
            {
                Rectangle? workingArea = Screen.PrimaryScreen?.WorkingArea;

                if (workingArea != null)
                {
                    int xPosition = workingArea.Value.Right - this.Width;
                    int yPosition = workingArea.Value.Bottom - this.Height;
                    this.Location = new Point(xPosition, yPosition);
                }
            }
            else
            {
                this.Location = new Point(int.Parse(formXPosition), int.Parse(formYPosition));
            }
        }

        public void FixPosition()
        {
            //Checking if the Form is off screen
            Screen screen = Screen.FromControl(this);

            //If ForceAlwaysInFrontCheckBox, limit = after taskbar. Else limit = before taskbar
            Rectangle limitArea = Properties.Settings.Default.ForceAlwaysInFront ? screen.Bounds : screen.WorkingArea;

            //Fix of X position
            if (this.Left < limitArea.Left)
            {
                this.Left = limitArea.Left;
            }
            else if (this.Right > limitArea.Right)
            {
                this.Left = limitArea.Right - this.Width;
            }

            //Fix of Y position
            if (this.Top < limitArea.Top)
            {
                this.Top = limitArea.Top;
            }
            else if (this.Bottom > limitArea.Bottom)
            {
                this.Top = limitArea.Bottom - this.Height;
            }
        }

        //Including MouseDown event on all form controls
        private void AttachMouseDownEventToControls(Control control)
        {
            control.MouseDown += (sender, e) =>
            {
                if (sender != null)
                    GlucoseTaskbar_MouseDown(sender, e);
            };

            foreach (Control childControl in control.Controls)
            {
                AttachMouseDownEventToControls(childControl);
            }
        }

        private void GlucoseTaskbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !Properties.Settings.Default.LockPosition) //Move the form
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            if (e.Button == MouseButtons.Right)
            {
                MenuContextMenuStrip.Show(this, e.Location);
            }
        }

        private void GlucoseTaskbar_LocationChanged(object sender, EventArgs e)
        {
            SavePositionTimer.Stop();
            SavePositionTimer.Start();
        }

        //Timer to prevent multiple unnecessary saves
        private void SavePositionTimer_Tick(object sender, EventArgs e)
        {
            SavePositionTimer.Stop();
            Debug.WriteLine($"X:{this.Location.X} Y:{this.Location.Y}");
            Properties.Settings.Default.FormXPosition = this.Location.X.ToString();
            Properties.Settings.Default.FormYPosition = this.Location.Y.ToString();
            Properties.Settings.Default.Save();
            FixPosition();
        }

        private void SetDataFetchInterval()
        {
            if (Properties.Settings.Default.SpeedUpDataFetching && nsData.GlucoseChangingQuickly)
                DataFetchTimer.Interval = 10000;
            else
                DataFetchTimer.Interval = (int)Properties.Settings.Default.DataRefreshInterval * 1000;
        }

        private async void DataFetchTimer_Tick(object sender, EventArgs e)
        {
            await RefreshGlucoseData();
        }

        private void ForceAlwaysInFrontTimer_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void LockPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LockPosition = LockPositionToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void BottomLeftCornerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.FromControl(this);
            int xPosition = screen.WorkingArea.Left;
            int yPosition = screen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(xPosition, yPosition);
        }

        private void CenterScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.FromControl(this);
            int xPosition = (screen.WorkingArea.Left + screen.WorkingArea.Right) / 2 - this.Width / 2;
            int yPosition = (screen.WorkingArea.Top + screen.WorkingArea.Bottom) / 2 - this.Height / 2;
            this.Location = new Point(xPosition, yPosition);
        }

        private void BottomRightCornerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Screen screen = Screen.FromControl(this);
            int xPosition = screen.WorkingArea.Right - this.Width;
            int yPosition = screen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(xPosition, yPosition);
        }

        private void SaveCustomPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CustomPosition != Point.Empty)
            {
                DialogResult result = MessageBox.Show(resourceManager.GetString("MessageBoxSaveCustomPositionOverwriteMessage"), resourceManager.GetString("MessageBoxTitleWarning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;
            }
            Properties.Settings.Default.CustomPosition = this.Location;
            Properties.Settings.Default.Save();
        }

        private void RestoreCustomPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CustomPosition != Point.Empty)
            {
                this.Location = Properties.Settings.Default.CustomPosition;
            }
            else
            {
                MessageBox.Show(resourceManager.GetString("MessageBoxRestoreCustomPositionErrorMessage"), resourceManager.GetString("MessageBoxTitleError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RefreshDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await RefreshGlucoseData(true);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}