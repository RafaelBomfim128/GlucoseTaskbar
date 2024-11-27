﻿// Glucose Taskbar - Program for glucose monitoring
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
using System.Threading;

public static class MutexManager
{
    private static readonly Mutex configMutex = new Mutex(false, "Global\\GlucoseTaskbarConfigMutex");

    public static void Acquire()
    {
        configMutex.WaitOne();
    }

    public static void Release()
    {
        configMutex.ReleaseMutex();
    }
}
