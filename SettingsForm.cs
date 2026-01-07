// Glucose Taskbar - Program for glucose monitoring
// Copyright (C) 2026 Rafael Assis

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

using Microsoft.Win32;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GlucoseTaskbar
{
    public partial class SettingsForm : Form
    {
        readonly GlucoseTaskbar glucoseTaskbar;
        readonly NightscoutData nightscoutData;
        readonly CultureManager cultureManager;
        readonly ResourceManager resourceManager;
        private bool isFormLoaded = false;
        private ScottPlot.Plottables.Scatter MyScatter;
        private ScottPlot.Plottables.Crosshair MyCrosshair;

        public SettingsForm(GlucoseTaskbar glucoseTaskbar, NightscoutData nightscoutData)
        {
            this.glucoseTaskbar = glucoseTaskbar;
            this.nightscoutData = nightscoutData;
            this.cultureManager = new CultureManager(glucoseTaskbar, nightscoutData);
            resourceManager = new("GlucoseTaskbar.Resources", typeof(Program).Assembly);
            LogManager.LogEvent += LogMessage;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            InitialSetupTexts();
            InitialSetupValues();
            //FillLastReads();
            isFormLoaded = true;
        }

        private void InitialSetupTexts()
        {
            SetTextControl(this);
            SetTextControl(LanguageLabel);
            AdjustPositionLabel(LanguageLabel, LanguageComboBox);
            SetTextControl(MainTabPage);
            SetTextControl(TechnicalTabPage);
            SetTextControl(MainSettingsLabel);
            SetTextControl(NightscoutUrlLabel);
            AdjustPositionLabel(NightscoutUrlLabel, NightscoutUrlTextBox);
            SetTextControl(TokenLabel);
            AdjustPositionLabel(TokenLabel, TokenTextBox);
            SetTextControl(TargetGlucoseLabel);
            AdjustPositionLabel(TargetGlucoseLabel, MinTargetNumericUpDown);
            SetTextControl(TechnicalSettingsLabel);
            SetTextControl(DataRefreshLabel);
            AdjustPositionLabel(DataRefreshLabel, DataRefreshNumericUpDown);
            SetTextControl(SecondsLabel);
            SetTextControl(ShowBatteryLabel);
            AdjustPositionLabel(ShowBatteryLabel, BatteryPanel);
            SetTextControl(SensorRadioButton);
            SetTextControl(CellPhoneRadioButton);
            SetTextControl(BothRadioButton);
            SetTextControl(NoneRadioButton);
            SetTextControl(OpacityLabel);
            AdjustPositionLabel(OpacityLabel, OpacityNumericUpDown);
            SetTextControl(ProgramSizeLabel);
            AdjustPositionLabel(ProgramSizeLabel, ProgramSizeNumericUpDown);
            SetTextControl(ForceAlwaysOnTopCheckBox);
            SetTextControl(AccelerateDataFetchCheckBox);
            SetTextControl(WindowsStartupCheckBox);
            SetTextControl(LatestReadsTabPage);
            SetTextControl(LatestReadsLabel);
            SetTextControl(ComingSoonLastReadsLabel);
            SetTextControl(NotificationsTabPage);
            SetTextControl(NotificationsLabel);
            SetTextControl(ComingSoonNotificationsLabel);
            SetTextControl(SaveLogsButton);
            SetTextControl(ClearLogsButton);
            SetTextControl(ViewSettingsScreenLabel);
            SetTextControl(SaveButton);
            SetTextControl(DocumentationLabel);
            SetTextControl(DocLinkLabel);
            AdjustPositionControl(DocumentationLabel, DocLinkLabel, -4);
        }

        public void LogMessage(string message)
        {
            if (LogsRichTextBox.Text.Length != 0) LogsRichTextBox.AppendText("\n\n");
            LogsRichTextBox.AppendText(message);
            LogsRichTextBox.ScrollToCaret();
        }

        private void InitialSetupValues()
        {
            LanguageComboBox.Text = Properties.Settings.Default.Language;
            NightscoutUrlTextBox.Text = Properties.Settings.Default.Url;
            TokenTextBox.Text = Properties.Settings.Default.Token;
            MinTargetNumericUpDown.Value = Properties.Settings.Default.MinTarget;
            MaxTargetNumericUpDown.Value = Properties.Settings.Default.MaxTarget;

            string radioButtonBatteryName = Properties.Settings.Default.ShowBattery ?? SensorRadioButton.Name;
            RadioButton radioButtonBattery = BatteryPanel.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Name == radioButtonBatteryName) ?? SensorRadioButton;
            radioButtonBattery.Checked = true;

            DataRefreshNumericUpDown.Value = Properties.Settings.Default.DataRefreshInterval;
            OpacityNumericUpDown.Value = Properties.Settings.Default.Opacity;
            ProgramSizeNumericUpDown.Value = Properties.Settings.Default.ProgramSize;
            ForceAlwaysOnTopCheckBox.Checked = Properties.Settings.Default.ForceAlwaysInFront;
            AccelerateDataFetchCheckBox.Checked = Properties.Settings.Default.SpeedUpDataFetching;
            WindowsStartupCheckBox.Checked = IsInStartup();
        }

        //Coming soon
        private void FillLastReads()
        {
            LastReadsFormsPlot.Reset();
            int[] glucoseValues = new int[nightscoutData.NsDataLastReads.Count];
            int[] timeDiff = new int[nightscoutData.NsDataLastReads.Count];

            for (int i = 0; i < glucoseValues.Length; i++)
            {
                glucoseValues[i] = int.Parse(nightscoutData.NsDataLastReads[i].Sgv);
                timeDiff[i] = (int)((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - nightscoutData.NsDataLastReads[i].Date) / 1000 / 60);
            }
            Array.Reverse(timeDiff);
            Array.Reverse(glucoseValues);

            int[] dataX = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] dataY = { 50, 200 };

            int glucoseMaxRange = glucoseValues.Max() + 40 > 200 ? glucoseValues.Max() + 40 : 200;
            int timeMinRange = timeDiff.Min() - 2 >= 0 ? timeDiff.Min() - 2 : 0;
            MyScatter = LastReadsFormsPlot.Plot.Add.Scatter(timeDiff, glucoseValues);
            MyScatter.LineWidth = 2;
            MyScatter.Smooth = true;
            MyScatter.MarkerSize = 7;

            LastReadsFormsPlot.Plot.Axes.Bottom.Label.Text = "Tempo (em minutos)";
            LastReadsFormsPlot.Plot.Axes.Left.Label.Text = "Glicemia (em mg/dl)";

            LastReadsFormsPlot.Plot.Axes.SetLimitsX(timeDiff.Max() + 2, timeMinRange);
            LastReadsFormsPlot.Plot.Axes.SetLimitsY(50, glucoseMaxRange);

            var hl1 = LastReadsFormsPlot.Plot.Add.HorizontalLine((int)Properties.Settings.Default.MinTarget);
            hl1.LineWidth = 2;
            hl1.Color = Colors.Green;
            hl1.LinePattern = LinePattern.DenselyDashed;

            var hl2 = LastReadsFormsPlot.Plot.Add.HorizontalLine((int)Properties.Settings.Default.MaxTarget);
            hl2.LineWidth = 2;
            hl2.Color = Colors.Green;
            hl2.LinePattern = LinePattern.DenselyDashed;

            MyCrosshair = LastReadsFormsPlot.Plot.Add.Crosshair(0, 0);
            MyCrosshair.IsVisible = false;
            MyCrosshair.MarkerShape = MarkerShape.OpenCircle;
            MyCrosshair.MarkerSize = 15;

            LastReadsFormsPlot.Refresh();

            //LastReadsRichTextBox.Text = "";
            //foreach (NightscoutDataLastReads nsDataLastReads in nightscoutData.NsDataLastReads)
            //{
            //    if (int.Parse(nsDataLastReads.Sgv) >= Properties.Settings.Default.MinTarget && int.Parse(nsDataLastReads.Sgv) <= Properties.Settings.Default.MaxTarget)
            //    {
            //        LastReadsRichTextBox.SelectionColor = Color.Green;
            //    }
            //    else
            //    {
            //        LastReadsRichTextBox.SelectionColor = Color.Yellow;
            //    }
            //    LastReadsRichTextBox.AppendText($"{nsDataLastReads.Sgv} {nsDataLastReads.Direction}");
            //    LastReadsRichTextBox.SelectionColor = Color.Red;
            //    LastReadsRichTextBox.AppendText($"  {nsDataLastReads.Delta}");
            //    LastReadsRichTextBox.SelectionColor = SystemColors.ButtonFace;
            //    LastReadsRichTextBox.AppendText($"  ({nsDataLastReads.TimeDiffLastUpdate})\n");
            //}
        }

        //Sets the label text according to the system language
        private void SetTextControl(Control control)
        {
            control.Text = resourceManager.GetString(control.Name);
        }

        //Adjusts the label position according to the control position (ex.: Text Box)
        private static void AdjustPositionLabel(System.Windows.Forms.Label label, Control control, int offset = 0)
        {
            int textWidth = TextRenderer.MeasureText(label.Text, label.Font).Width;
            label.Left = control.Left - textWidth + offset;
            label.Width = textWidth;
        }

        private static void AdjustPositionControl(Control firstControl, Control secondControl, int offset = 0)
        {
            secondControl.Left = firstControl.Right + offset;
            secondControl.Top = firstControl.Top;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            Properties.Settings.Default.Language = LanguageComboBox.Text;
            Properties.Settings.Default.Url = NightscoutUrlTextBox.Text;
            Properties.Settings.Default.Token = TokenTextBox.Text;
            Properties.Settings.Default.MinTarget = MinTargetNumericUpDown.Value;
            Properties.Settings.Default.MaxTarget = MaxTargetNumericUpDown.Value;
            Properties.Settings.Default.ShowBattery = GetRadioButtonBatteryChecked()?.Name;
            Properties.Settings.Default.DataRefreshInterval = DataRefreshNumericUpDown.Value;
            Properties.Settings.Default.Opacity = OpacityNumericUpDown.Value;
            Properties.Settings.Default.ProgramSize = ProgramSizeNumericUpDown.Value;
            Properties.Settings.Default.ForceAlwaysInFront = ForceAlwaysOnTopCheckBox.Checked;
            Properties.Settings.Default.SpeedUpDataFetching = AccelerateDataFetchCheckBox.Checked;

            try
            {
                MutexManager.Acquire();
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{resourceManager.GetString("MessageBoxSaveSettingsErrorMessage")}: {ex.Message}", resourceManager.GetString("MessageBoxTitleError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Log($"Error: {ex.GetType()}: {ex.Message}");
            }
            finally
            {
                MutexManager.Release();
            }

            AddToStartup(WindowsStartupCheckBox.Checked);

            glucoseTaskbar.SetOpacity();
            glucoseTaskbar.SetProgramSize();
            glucoseTaskbar.FixPosition();
            glucoseTaskbar.SetForceAlwaysInFrontTimer();

            if (await glucoseTaskbar.RefreshGlucoseData(true))
                this.Close();

            this.Enabled = true;
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cultureManager.UpdateCulture(LanguageComboBox.Text);
            InitialSetupTexts();
            //FillLastReads();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cultureManager.UpdateCulture(Properties.Settings.Default.Language); //Returning the culture to the value saved in the config (adjusts the culture if the new one is not saved) 
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Checking if any data has not been saved
            if (Properties.Settings.Default.Language != LanguageComboBox.Text ||
                Properties.Settings.Default.Url != NightscoutUrlTextBox.Text ||
                Properties.Settings.Default.Token != TokenTextBox.Text ||
                Properties.Settings.Default.MinTarget != MinTargetNumericUpDown.Value ||
                Properties.Settings.Default.MaxTarget != MaxTargetNumericUpDown.Value ||
                Properties.Settings.Default.ShowBattery != GetRadioButtonBatteryChecked()?.Name ||
                Properties.Settings.Default.DataRefreshInterval != DataRefreshNumericUpDown.Value ||
                Properties.Settings.Default.Opacity != OpacityNumericUpDown.Value ||
                Properties.Settings.Default.ProgramSize != ProgramSizeNumericUpDown.Value ||
                Properties.Settings.Default.ForceAlwaysInFront != ForceAlwaysOnTopCheckBox.Checked ||
                Properties.Settings.Default.SpeedUpDataFetching != AccelerateDataFetchCheckBox.Checked ||
                WindowsStartupCheckBox.Checked != IsInStartup())
            {
                DialogResult result = MessageBox.Show(resourceManager.GetString("MessageBoxDiscardMessage"), resourceManager.GetString("MessageBoxTitleWarning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private RadioButton? GetRadioButtonBatteryChecked()
        {
            IEnumerable<RadioButton> radioButtonsBattery = BatteryPanel.Controls.OfType<RadioButton>();
            foreach (var radioButton in radioButtonsBattery)
            {
                if (radioButton.Checked)
                {
                    return radioButton;
                }
            };
            return null;
        }

        private void ForceAlwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isFormLoaded && ForceAlwaysOnTopCheckBox.Checked)
            {
                MessageBox.Show(resourceManager.GetString("MessageBoxForceAlwaysInFrontMessage"), resourceManager.GetString("MessageBoxTitleInformation"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveLogsButton_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            string dateHour = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            saveFileDialog.FileName = $"log_{dateHour}.txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, LogsRichTextBox.Text);
            }
        }

        private void ClearLogsButton_Click(object sender, EventArgs e)
        {
            LogsRichTextBox.Clear();
        }

        public static void AddToStartup(bool enable)
        {
            string appName = "Glucose Taskbar";
            string exePath = Application.ExecutablePath;
            string value = $"\"{exePath}\"";

            using RegistryKey? rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk != null)
            {
                if (enable)
                {
                    rk.SetValue(appName, value);
                }
                else
                {
                    rk.DeleteValue(appName, false);
                }
            }
        }

        public static bool IsInStartup()
        {
            string appName = "Glucose Taskbar";
            string exePath = Application.ExecutablePath;

            using RegistryKey? rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk != null)
            {
                return rk.GetValue(appName) is string registryValue && registryValue.Equals($"\"{exePath}\"", StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        private void LastReadsFormsPlot_MouseMove(object sender, MouseEventArgs e)
        {
            // determine where the mouse is and get the nearest point
            Pixel mousePixel = new(e.Location.X, e.Location.Y);
            Coordinates mouseLocation = LastReadsFormsPlot.Plot.GetCoordinates(mousePixel);
            DataPoint nearest = MyScatter.Data.GetNearest(mouseLocation, LastReadsFormsPlot.Plot.LastRender);

            // place the crosshair over the highlighted point
            if (nearest.IsReal)
            {
                MyCrosshair.IsVisible = true;
                MyCrosshair.Position = nearest.Coordinates;
                LastReadsFormsPlot.Refresh();
                Text = $"Selected Index={nearest.Index}, X={nearest.X:0.##}, Y={nearest.Y:0.##}";
            }

            // hide the crosshair when no point is selected
            if (!nearest.IsReal && MyCrosshair.IsVisible)
            {
                MyCrosshair.IsVisible = false;
                LastReadsFormsPlot.Refresh();
                Text = $"No point selected";
            }
        }

        private void DocLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/RafaelBomfim128/GlucoseTaskbar";

            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{resourceManager.GetString("OpenLinkDocError")}: {ex.Message}", resourceManager.GetString("MessageBoxTitleError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogManager.Log($"Error: {ex.GetType()}: {ex.Message}");
            }
        }
    }
}