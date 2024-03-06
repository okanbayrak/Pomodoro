using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pomodoro.Pages {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PomodoroPage : BasePage {
        private DispatcherTimer _timer;
        private TimeSpan _time;
        public PomodoroPage() {
            InitializeComponent();
            SetupCountdown(new TimeSpan(0, Context.PomodoroLength, 0));
        }

        private void SetupCountdown(TimeSpan time) {
            _time = time;
            _timer = new DispatcherTimer() {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, object e) {
            if (_time == TimeSpan.Zero) {
                _timer.Stop();
                Context.PomodoroCount++;
                var isLongBreak = Context.PomodoroCount % 4 == 0;
                Frame.Navigate(typeof(BreakPage), isLongBreak);
            }
            else {
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                Countdown.Text = _time.ToString("c");
            }
        }
    }
}
