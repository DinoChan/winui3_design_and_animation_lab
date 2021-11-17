using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace WinUIDesignAndAnimationLab.Demos.GalaxyShuttles
{
    public sealed partial class GalaxyShuttleControl : UserControl
    {
        public GalaxyShuttleControl()
        {
            this.InitializeComponent();
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
}
