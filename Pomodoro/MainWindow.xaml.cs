using Microsoft.UI.Xaml;
using Pomodoro.Data;
using Pomodoro.Pages;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pomodoro {
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window {
        private Context Context => App.Context;
        public MainWindow() {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(MainPage));
        }
    }
}
