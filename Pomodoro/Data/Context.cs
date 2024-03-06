using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pomodoro.Data {
    public class Context : INotifyPropertyChanged {
        public int PomodoroLength { get; set; } = 25;
        public int ShortBreakLength { get; set; } = 5;
        public int LongBreakLength { get; set; } = 30;

        private string _startTime = "-";
        public string StartTime {
            get => _startTime;
            set {
                _startTime = value;
                OnPropertyChanged();
            }
        }

        private int pomodoroCount;

        public int PomodoroCount {
            get => pomodoroCount;
            set {
                pomodoroCount = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
