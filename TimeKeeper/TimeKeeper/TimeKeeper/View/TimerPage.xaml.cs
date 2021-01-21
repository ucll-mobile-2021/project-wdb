using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeKeeper.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeKeeper.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        Countdown countdown;

        public TimerPage()
        {
            countdown = new Countdown();
            InitializeComponent();

            BindingContext = countdown;
        }

        private void IncreaseHour(object sender, EventArgs e)
        {

            countdown.Hours = 1;
        }

        private void DecreaseHour(object sender, EventArgs e)
        {
            countdown.Hours = -1;
        }

        private void IncreaseMinute(object sender, EventArgs e)
        {
            countdown.Minutes = 1;
        }

        private void DecreaseMinute(object sender, EventArgs e)
        {
            countdown.Minutes = -1;
        }

        private void IncreaseSeconds(object sender, EventArgs e)
        {
            countdown.Seconds = 1;
        }

        private void DecreaseSeconds(object sender, EventArgs e)
        {
            countdown.Seconds = -1;
        }

        private void StartCountdown(object sender, EventArgs e)
        {
            countdown.Start();
        }

        private void ResetCountdown(object sender, EventArgs e)
        {
            countdown.Reset();
        }

        private void StopCountdown(object sender, EventArgs e)
        {
            countdown.Stop();
        }
    }
}