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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlucoseTaskbar
{
    internal class ControlPropertiesManager
    {
        private class ControlProperties
        {
            public Size Size { get; set; }
            public Font? Font { get; set; }
            public Point Location { get; set; }
        }

        private readonly Dictionary<Control, ControlProperties> originalProperties = new Dictionary<Control, ControlProperties>();
        private readonly Control mainForm;

        public ControlPropertiesManager(Control mainForm)
        {
            this.mainForm = mainForm;
        }

        public void StoreOriginalProperties(Control parentControl)
        {
            originalProperties[parentControl] = new ControlProperties
            {
                Size = parentControl.Size,
                Font = parentControl.Font,
                Location = parentControl.Location
            };

            StoreOriginalPropertiesRecursive(parentControl);
        }

        private void StoreOriginalPropertiesRecursive(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                originalProperties[control] = new ControlProperties
                {
                    Size = control.Size,
                    Font = control.Font,
                    Location = control.Location
                };
                StoreOriginalPropertiesRecursive(control);
            }
        }
        public void RestoreOriginalProperties()
        {
            foreach (KeyValuePair<Control, ControlProperties> pair in originalProperties)
            {
                Control control = pair.Key;
                ControlProperties originalProps = pair.Value;
                control.Size = originalProps.Size;
                control.Font = originalProps.Font;

                if (control != mainForm)
                {
                    control.Location = originalProps.Location;
                }
            }
        }
    }
}
