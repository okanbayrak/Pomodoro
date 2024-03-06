using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pomodoro.Pages {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : BasePage {
        public MainPage() {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e) {
            Context.StartTime = DateTime.Now.ToShortTimeString();
            Frame.Navigate(typeof(PomodoroPage));
        }
    }
}
