using Microsoft.UI.Xaml;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUIDesignAndAnimationLab
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            rootFrame.Loaded += RootFrame_Loaded;
            CurrentWindow = this;
        }

        public static MainWindow CurrentWindow { get; set; }

        private void RootFrame_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                rootFrame.Navigate(typeof(MainPage));
            }
            catch (Exception ex)
            {
            }
        }
    }
}