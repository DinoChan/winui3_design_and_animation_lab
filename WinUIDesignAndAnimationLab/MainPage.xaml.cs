using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDesignAndAnimationLab
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationHelper navigationHelper;

        // We track the last visual state we set to avoid redundant GoToState calls
        // (these cause flickering on 8.1 apps running on Win10).
        private enum VisualState { Unknown, Big, Small, Tiny };
        private VisualState currentVisualState = VisualState.Unknown;

        public MainPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var example = (ExampleDefinition)e.ClickedItem;
            this.Frame.Navigate(typeof(ExamplePage), example);
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    this.navigationHelper.OnNavigatedTo(e);
        //}

        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    this.navigationHelper.OnNavigatedFrom(e);
        //}

    }
}
