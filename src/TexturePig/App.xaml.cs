// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.
global using WPFUI;
global using WPFUI.Common;
global using WPFUI.Controls;
global using WPFUI.Theme;
global using System.Windows;

namespace TexturePig
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            WPFUI.Theme.Manager.SetSystemTheme();
            //WPFUI.Theme.Manager.SetSystemAccent();
        }
    }
}
