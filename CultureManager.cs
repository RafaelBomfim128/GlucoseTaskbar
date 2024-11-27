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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlucoseTaskbar
{
    internal class CultureManager
    {
        readonly NightscoutData nsData;
        readonly GlucoseTaskbar? glucoseTaskbar;

        public CultureManager()
        {
            nsData = new NightscoutData();
        }

        public CultureManager(GlucoseTaskbar? glucoseTaskbar, NightscoutData nsData)
        {
            this.nsData = nsData;
            this.glucoseTaskbar = glucoseTaskbar;
        }
        //Sets the culture according to the machine default or value passed in the parameter
        public static void SetCulture(string? languageSetting = null)
        {
            languageSetting ??= Properties.Settings.Default.Language;
            string? cultureInfoName;
            if (languageSetting == "English (US)")
                cultureInfoName = "en-US";
            else if (languageSetting == "Português (Brasil)")
                cultureInfoName = "pt-BR";
            else cultureInfoName = null;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfoName != null ? new CultureInfo(cultureInfoName) : null;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfoName != null ? new CultureInfo(cultureInfoName) : null;
        }

        public void UpdateCulture(string? languageSetting)
        {
            CultureManager.SetCulture(languageSetting);
            nsData.UpdateTextsCulture();
            glucoseTaskbar?.UpdateTextsCulture();
        }
    }
}
