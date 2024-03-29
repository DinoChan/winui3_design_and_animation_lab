﻿using System;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace WinUIDesignAndAnimationLab.Demos.GalaxyShuttles;

public sealed partial class GalaxyShuttleControl : UserControl
{
    public GalaxyShuttleControl()
    {
        InitializeComponent();
        Loaded += GalaxyShettleControl_Loaded;
    }

    public TimeSpan Delay { get; set; }

    private async void GalaxyShettleControl_Loaded(object sender, RoutedEventArgs e)
    {
        await Task.Delay(Delay);
        Move.Begin();
        Fade.Begin();
    }
}