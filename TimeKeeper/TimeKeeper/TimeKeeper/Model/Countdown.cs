using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Timers;

namespace TimeKeeper.Model
{
    public class Countdown : INotifyPropertyChanged
    {
        private Timer timer;

        public event PropertyChangedEventHandler PropertyChanged;

        DateTime Time;

        public int Hours
        {
            get { return Time.Hour; } 
            set 
            { 
                Time = Time.AddHours(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hours"));
            }
        }

        public int Minutes
        {
            get { return Time.Minute; }
            set
            {
                Time = Time.AddMinutes(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Minutes"));
            }
        }
        public int Seconds
        {
            get { return Time.Second; }
            set
            {
                Time = Time.AddSeconds(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Seconds"));
            }
        }

        public Countdown()
        {
            Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);

            timer = new Timer();

            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.AutoReset = true;
        }

        ~Countdown()
        {
            timer.Close();
        }

        public void Start()
        {
            if (!timer.Enabled)
            {
                timer.Start();
            }
        }

        public void Reset()
        {
            Stop();
            Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0);

            Update();
        }

        public void Stop()
        {
            if (timer.Enabled) timer.Stop();
        }
        private void Update()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hours"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Minutes"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Seconds"));
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Hours == 0 && Minutes == 0 && Seconds == 0)
            {
                Stop();
            }
            else
            {
                Seconds = -1;

                Update();
            }
        }
    }
}
