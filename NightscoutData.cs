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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GlucoseTaskbar
{
    public enum Directions
    {
        DoubleUp,
        SingleUp,
        FortyFiveUp,
        Flat,
        FortyFiveDown,
        SingleDown,
        DoubleDown,
        NOT_COMPUTABLE,
        OUT_OF_RANGE,
        NONE,
    }

    internal class EntriesFields
    {
        [JsonProperty]
        public string? _id { get; set; }
        [JsonProperty]
        public string? Device { get; set; }
        [JsonProperty]
        public long Date { get; set; }
        [JsonProperty]
        public string? DateString { get; set; }
        [JsonProperty]
        public int Sgv { get; set; }
        [JsonProperty]
        public double? Delta { get; set; }
        [JsonProperty]
        public string? Direction { get; set; }
        [JsonProperty]
        public string? Type { get; set; }
        [JsonProperty]
        public double Filtered { get; set; }
        [JsonProperty]
        public double Unfiltered { get; set; }
        [JsonProperty]
        public int Rssi { get; set; }
        [JsonProperty]
        public int Noise { get; set; }
        [JsonProperty]
        public string? SysTime { get; set; }
        [JsonProperty]
        public int UtcOffset { get; set; }
        [JsonProperty]
        public long Mills { get; set; }
    }

    internal class Uploader
    {
        [JsonProperty]
        public int Battery { get; set; }
        [JsonProperty]
        public string? Type { get; set; }
        [JsonProperty]
        public int Value { get; set; }
        [JsonProperty]
        public string? Display { get; set; }
        [JsonProperty]
        public int Level { get; set; }
        [JsonProperty]
        public int? Notification { get; set; }
    }

    internal class Status
    {
        public Uploader? Uploader { get; set; }
        [JsonProperty]
        public string? CreatedAt { get; set; }
        [JsonProperty]
        public long Mills { get; set; }
        [JsonProperty]
        public string? Id { get; set; }
    }

    internal class Device
    {
        [JsonProperty]
        public string? Name { get; set; }
        [JsonProperty]
        public string? Uri { get; set; }
        public List<Status>? Statuses { get; set; }
        public Uploader? Min { get; set; }
    }

    internal class Upbat
    {
        [JsonProperty]
        public int? Level { get; set; }
        [JsonProperty]
        public string? Display { get; set; }
        [JsonProperty]
        public string? Status { get; set; }
        public Dictionary<string, Device>? Devices { get; set; }
        public Uploader? Min { get; set; }
    }

    internal class Root
    {
        public Upbat? Upbat { get; set; }
    }

    public class NightscoutDataLastReads
    {
        public string Sgv { get; set; } = "N/A";
        public string Delta { get; set; } = "N/A";
        public string Direction { get; set; } = "?";
        public long Date { get; set; }
        public string TimeDiffLastUpdate { get; set; } = "N/A";
    }

    public class NightscoutData
    {
        List<EntriesFields>? nsFieldsFull;
        readonly ResourceManager resourceManager;
        private readonly int oldDataTime = 15;

        public NightscoutData() {
            nsFieldsFull = new List<EntriesFields>();
            NsDataLastReads = new List<NightscoutDataLastReads>();
            resourceManager = new("GlucoseTaskbar.Resources", typeof(Program).Assembly);
        }
        public List<NightscoutDataLastReads> NsDataLastReads { get; set; }
        public bool OldDataGlucose { get; set; } = false;
        public int SensorBattery { get; set; } = -1;
        public int CellPhoneBattery { get; set; } = -1;
        public bool OldDataBatterySensor { get; set; } = false;
        public bool OldDataBatteryCellPhone { get; set; } = false;
        public bool GlucoseChangingQuickly {  get; set; } = false;

        //Dictionary that maps strings with spaces to enum values
        private static readonly Dictionary<string, Directions> DirectionNameMap = new()
        {
            { "DoubleUp", Directions.DoubleUp },
            { "SingleUp", Directions.SingleUp },
            { "FortyFiveUp", Directions.FortyFiveUp },
            { "Flat", Directions.Flat },
            { "FortyFiveDown", Directions.FortyFiveDown },
            { "SingleDown", Directions.SingleDown },
            { "DoubleDown", Directions.DoubleDown },
            { "NOT COMPUTABLE", Directions.NOT_COMPUTABLE },
            { "OUT OF RANGE", Directions.OUT_OF_RANGE },
            { "NONE", Directions.NONE }
        };

        //Direction symbol dictionary
        private static readonly Dictionary<Directions, string> DirectionSymbols = new()
        {
            { Directions.DoubleUp, "⇈" },
            { Directions.SingleUp, "↑" },
            { Directions.FortyFiveUp, "↗" },
            { Directions.Flat, "→" },
            { Directions.FortyFiveDown, "↘" },
            { Directions.SingleDown, "↓" },
            { Directions.DoubleDown, "⇊" },
            { Directions.NOT_COMPUTABLE, "?" },
            { Directions.OUT_OF_RANGE, "?" },
            { Directions.NONE, "?" },
        };

        private static string GetSymbolFromDirectionName(string directionName)
        {
            if (DirectionNameMap.TryGetValue(directionName, out Directions direction))
            {
                return DirectionSymbols[direction];
            }
            else
            {
                throw new ArgumentException($"Invalid Direction name: {directionName}.", nameof(directionName));
            }
        }

        public async Task<bool> RefreshGlucoseData(bool showError = false)
        {
            HttpClient httpClient = new();
            string? urlEntries = $"{Properties.Settings.Default.Url}";
            string? token = Properties.Settings.Default.Token;
            string? urlProperties = "";
            if (urlEntries.Trim() != String.Empty)
            {
                urlEntries = urlEntries.Trim();
                if (urlEntries.Substring(0, 7) != "http://" && urlEntries.Substring(0, 8) != "https://") urlEntries = $"https://{urlEntries}";
                if (urlEntries.Substring(urlEntries.Length - 1, 1) != "/") urlEntries += "/";
                urlProperties = $"{urlEntries}api/v2/properties/upbat,sage";
                urlEntries += "api/v1/entries.json?find[type]=sgv&count=11";
            }
            if (token.Trim() != String.Empty)
            {
                token = token.Trim();
                token = GetHashSha1(token);
                urlEntries += $"&secret={token}";
                urlProperties += $"?&secret={token}";
            }

            string responseEntries, responseProperties;
            bool requestSuccess = false;

            try
            {
                this.NsDataLastReads.Add(new NightscoutDataLastReads());
                responseEntries = await httpClient.GetStringAsync(urlEntries);
                Debug.WriteLine(responseEntries);
                
                responseProperties = await httpClient.GetStringAsync(urlProperties);
                Debug.WriteLine(responseProperties);

                if (!IsJson(responseEntries) || !IsJson(responseProperties))
                {
                    throw new InvalidOperationException("The content returned from the Nightscout API is not a JSON");
                }
                requestSuccess = true;
            }
            catch (HttpRequestException ex)
            {
                LogManager.Log($"HttpRequestException: {resourceManager.GetString("RefreshGlucoseDataGenericError")}");
                LogManager.Log($"Error: {ex.GetType()}: {ex.Message}");

                if (showError)
                {
                    if (ex.Message == "Response status code does not indicate success: 401 (Unauthorized).")
                        MessageBox.Show(resourceManager.GetString("RefreshGlucoseDataHttpRequestException401"), resourceManager.GetString("MessageBoxTitleError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(resourceManager.GetString("RefreshGlucoseDataGenericError"), resourceManager.GetString("MessageBoxTitleError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.NsDataLastReads[0].Sgv = "N/A";
                this.NsDataLastReads[0].Delta = "N/A";
                this.NsDataLastReads[0].Direction = "?";
                this.NsDataLastReads[0].TimeDiffLastUpdate = "N/A";
                this.CellPhoneBattery = -1;
                this.SensorBattery = -1;

                return false;
            }
            catch (Exception ex)
            {
                LogManager.Log($"{resourceManager.GetString("RefreshGlucoseDataGenericError")}");
                LogManager.Log($"Error: {ex.GetType()}: {ex.Message}");

                if (showError)
                    MessageBox.Show(resourceManager.GetString("RefreshGlucoseDataGenericError"), resourceManager.GetString("MessageBoxTitleError"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.NsDataLastReads[0].Sgv = "N/A";
                this.NsDataLastReads[0].Delta = "N/A";
                this.NsDataLastReads[0].Direction = "?";
                this.NsDataLastReads[0].TimeDiffLastUpdate = "N/A";
                this.CellPhoneBattery = -1;
                this.SensorBattery = -1;

                return false;
            }
            
            try
            {
                nsFieldsFull = JsonConvert.DeserializeObject<List<EntriesFields>>(responseEntries);

                if (nsFieldsFull != null && nsFieldsFull.Count > 0)
                {
                    NsDataLastReads.Clear();
                    for (int i = 0; i < nsFieldsFull.Count; i++)
                    {
                        this.NsDataLastReads.Add(new NightscoutDataLastReads());
                        this.NsDataLastReads[i].Sgv = nsFieldsFull[i].Sgv == 0 ? "N/A" : nsFieldsFull[i].Sgv.ToString();
                        
                        double? deltaValue = nsFieldsFull[i].Delta;
                        if (nsFieldsFull[i].Sgv == 0)
                        {
                            this.NsDataLastReads[i].Delta = "N/A";
                        }
                        else if (deltaValue.HasValue)
                        {
                            this.NsDataLastReads[i].Delta = $"{(deltaValue.Value >= 0 ? "+" : "-")}{Math.Round(Math.Abs(deltaValue.Value))}";
                        } else
                        {
                            if (i + 1 < nsFieldsFull.Count)
                            {
                                double deltaCalc = nsFieldsFull[i].Sgv - nsFieldsFull[i + 1].Sgv;
                                this.NsDataLastReads[i].Delta = $"{(deltaCalc >= 0 ? "+" : "-")}{Math.Round(Math.Abs(deltaCalc))}";
                            }
                            else
                            {
                                //Set "N/A" if there is no index to calc Delta
                                this.NsDataLastReads[i].Delta = "N/A";
                            }
                        }

                        this.NsDataLastReads[i].Direction = GetSymbolFromDirectionName(nsFieldsFull[i].Direction ?? Directions.NONE.ToString()) ?? Directions.NONE.ToString();
                        this.NsDataLastReads[i].Date = nsFieldsFull[i].Date;
                        SetTimeDiffLastUpdate(i);
                    }

                    SetGlucoseChangingQuickly();


                    Root? root = JsonConvert.DeserializeObject<Root>(responseProperties);

                    int latestPhoneBatteryValue = root?.Upbat?.Devices?
                        .SelectMany(d => d.Value?.Statuses ?? Enumerable.Empty<Status>())
                        .Where(s => s?.Uploader?.Type == "PHONE")
                        .OrderByDescending(s => s?.CreatedAt)
                        .Select(s => s?.Uploader?.Value)
                        .FirstOrDefault() ?? -1;

                    long latestPhoneBatteryCreatedAt = root?.Upbat?.Devices?
                        .SelectMany(d => d.Value?.Statuses ?? Enumerable.Empty<Status>())
                        .Where(s => s?.Uploader?.Type == "PHONE")
                        .OrderByDescending(s => s?.CreatedAt)
                        .Select(s => s?.Mills)
                        .FirstOrDefault() ?? -1;

                    int latestSensorBatteryValue = root?.Upbat?.Devices?
                        .SelectMany(d => d.Value?.Statuses ?? Enumerable.Empty<Status>())
                        .Where(s => s?.Uploader?.Type == "BRIDGE")
                        .OrderByDescending(s => s?.CreatedAt)
                        .Select(s => s?.Uploader?.Value)
                        .FirstOrDefault() ?? -1;

                    long latestSensorBatteryCreatedAt = root?.Upbat?.Devices?
                        .SelectMany(d => d.Value?.Statuses ?? Enumerable.Empty<Status>())
                        .Where(s => s?.Uploader?.Type == "BRIDGE")
                        .OrderByDescending(s => s?.CreatedAt)
                        .Select(s => s?.Mills)
                        .FirstOrDefault() ?? -1;


                    Debug.WriteLine(latestPhoneBatteryValue);
                    Debug.WriteLine(latestSensorBatteryValue);
                    this.CellPhoneBattery = latestPhoneBatteryValue;
                    this.SensorBattery = latestSensorBatteryValue;

                    long timeDiffCellPhone = (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - latestPhoneBatteryCreatedAt) / 1000 / 60;
                    long timeDiffSensor = (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - latestSensorBatteryCreatedAt) / 1000 / 60;
                    this.OldDataBatteryCellPhone = timeDiffCellPhone >= oldDataTime;
                    this.OldDataBatterySensor = timeDiffSensor >= oldDataTime;
                }
                else
                {
                    LogManager.Log("The data list is empty or the JSON was not deserialized correctly in nsFieldsFull.");
                }
            }
            catch (Exception ex)
            {
                LogManager.Log($"Error: {ex.GetType()}: {ex.Message}");
            }

            return requestSuccess;
        }

        private static bool IsJson(string content)
        {
            content = content.Trim();
            return (content.StartsWith('{') && content.EndsWith('}')) ||
                   (content.StartsWith('[') && content.EndsWith(']'));
        }

        private void SetTimeDiffLastUpdate(int index)
        {
            if (nsFieldsFull?.Count > 0 && nsFieldsFull[index].Date > 0)
            {
                long timeDiff = (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - nsFieldsFull[index].Date) / 1000 / 60;

                if (index == 0) OldDataGlucose = timeDiff >= oldDataTime;

                switch (timeDiff)
                {
                    case <= 0:
                        this.NsDataLastReads[index].TimeDiffLastUpdate = $"{resourceManager.GetString("LastUpdateNow")}";
                        break;
                    case 1:
                        this.NsDataLastReads[index].TimeDiffLastUpdate = $"{timeDiff} {resourceManager.GetString("LastUpdate1Minute")}";
                        break;
                    case >= 2:
                        this.NsDataLastReads[index].TimeDiffLastUpdate = $"{timeDiff} {resourceManager.GetString("LastUpdateMore1Minute")}";
                        break;
                }
            }
        }

        private void SetGlucoseChangingQuickly()
        {
            var directionsChangingQuickly = new HashSet<Directions> { Directions.SingleDown, Directions.DoubleDown, Directions.SingleUp, Directions.DoubleUp };
            if (Enum.TryParse(this.NsDataLastReads[0].Direction, out Directions direction))
            {
                this.GlucoseChangingQuickly = directionsChangingQuickly.Contains(direction);
            }
        }

        //Public method that updates the texts when the language is changed
        public void UpdateTextsCulture()
        {
            if (this.NsDataLastReads.Count > 0 && this.NsDataLastReads[0].TimeDiffLastUpdate != "N/A")
            {
                for (int i = 0; i < NsDataLastReads.Count; i++)
                {
                    SetTimeDiffLastUpdate(i);
                }
            }
        }

        public static String GetHashSha1(string input)
        {
            string hash = string.Concat(
                System.Security.Cryptography.SHA1.HashData(Encoding.UTF8.GetBytes(input))
                    .Select(b => b.ToString("x2"))
            );
            return hash;
        }
    }
}
