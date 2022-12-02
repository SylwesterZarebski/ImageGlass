﻿/*
ImageGlass Project - Image viewer for Windows
Copyright (C) 2010 - 2022 DUONG DIEU PHAP
Project homepage: https://imageglass.org

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System.Runtime.InteropServices;
using Windows.Win32;

namespace ImageGlass.Base.WinApi;

public class WinColorsApi
{
    [DllImport("dwmapi.dll", EntryPoint = "#127", PreserveSig = false)]
    private static extern void DwmGetColorizationParameters(out DWM_COLORIZATION_PARAMS parameters);

    private struct DWM_COLORIZATION_PARAMS
    {
        public uint clrColor;
        public uint clrAfterGlow;
        public uint nIntensity;
        public uint clrAfterGlowBalance;
        public uint clrBlurBalance;
        public uint clrGlassReflectionIntensity;
        public bool fOpaque;
    }


    /// <summary>
    /// Gets system accent color.
    /// </summary>
    public static Color GetAccentColor(bool includeAlpha)
    {
        var temp = new DWM_COLORIZATION_PARAMS();
        DwmGetColorizationParameters(out temp);

        var bytes = BitConverter.GetBytes(temp.clrAfterGlow);
        var alpha = includeAlpha ? bytes[3] : (byte)255;
        var color = Color.FromArgb(alpha, bytes[2], bytes[1], bytes[0]);

        return color;
    }

}

