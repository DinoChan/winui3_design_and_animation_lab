﻿using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDesignAndAnimationLab
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private VisualState currentVisualState = VisualState.Unknown;
        private NavigationHelper navigationHelper;

        public MainPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
        }

        // We track the last visual state we set to avoid redundant GoToState calls
        // (these cause flickering on 8.1 apps running on Win10).
        private enum VisualState
        { Unknown, Big, Small, Tiny };

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var example = (ExampleDefinition)e.ClickedItem;
            this.Frame.Navigate(typeof(ExamplePage), example);
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