using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace Pomodoro.Pages {
    public sealed partial class BreakPage : BasePage {
        private DispatcherTimer _timer;
        private TimeSpan _time;

        public BreakPage() {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            if (e.Parameter is bool isLongBreak) {
                var breakLength = isLongBreak ? Context.LongBreakLength : Context.ShortBreakLength;
                SetupCountdown(new TimeSpan(0, breakLength, 0));
            }
        }

        private void SetupCountdown(TimeSpan time) {
            _time = time;
            _timer = new DispatcherTimer {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, object e) {
            if (_time == TimeSpan.Zero) {
                _timer.Stop();
                Frame.Navigate(typeof(PomodoroPage));
            }
            else {
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                Countdown.Text = _time.ToString("c");
            }
        }
    }
}
