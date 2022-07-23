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

namespace ImageGlass.Base;


/// <summary>
/// Defines user action chain
/// </summary>
public class UserAction
{
    /// <summary>
    /// Executable action, its value can be:
    /// <list type="bullet">
    ///   <item>
    ///   Name of a menu item of <c>MnuMain</c> in <c>FrmMain.cs</c>.
    ///   For example: <c>MnuPrint</c>
    ///   </item>
    ///   <item>
    ///   Name of <c>IG_</c> methods defined in <c>FrmMain.IGMethods.cs</c>.
    ///   For example: <c>IG_Print</c>
    ///   </item>
    ///   <item>
    ///   Path of executable file / command.
    ///   For example: <c>cmd.exe</c>
    ///   </item>
    /// </list>
    /// </summary>
    public string Executable { get; set; } = string.Empty;

    
    /// <summary>
    /// Argument to pass to the <see cref="Executable"/>.
    /// </summary>
    public object Argument { get; set; } = string.Empty;

    
    /// <summary>
    /// Next action to execute after running <see cref="Executable"/>.
    /// </summary>
    public UserAction? NextAction { get; set; } = null;


    /// <summary>
    /// Initialize the empty <see cref="UserAction"/> instance.
    /// </summary>
    public UserAction() { }


    /// <summary>
    /// Initialize the <see cref="UserAction"/> instance.
    /// </summary>
    public UserAction(string executable = "", string arguments = "", UserAction? nextAction = null)
    {
        Executable = executable.Trim();
        Argument = arguments.Trim();
        NextAction = nextAction;
    }
    
}
