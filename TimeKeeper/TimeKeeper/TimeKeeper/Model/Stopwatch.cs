using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Timers;

namespace TimeKeeper.Model
{
    public class Stopwatch : INotifyPropertyChanged
    {
        private Timer timer;
        private DateTime time;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Time 
        {
            get { return time; }
            private set 
            { 
                time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StopwatchTime"));
            }
        }
        public string StopwatchTime { get { return Time.Hour.ToString("D2") + ":" + Time.Minute.ToString("D2") + ":" + Time.Second.ToString("D2"); } }

        public Stopwatch()
        {
            timer = new Timer();
            Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);

            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.AutoReset = true;
        }

        ~Stopwatch()
        {
            timer.Close();
        }

        public void Start()
        {
            if(!timer.Enabled)
            {
                timer.Start();
            }
        }

        public void Reset()
        {
            Stop();
            Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);
        }

        public void Stop()
        {
            if(timer.Enabled) timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Time = Time.AddSeconds(1);
        }
    }
}
