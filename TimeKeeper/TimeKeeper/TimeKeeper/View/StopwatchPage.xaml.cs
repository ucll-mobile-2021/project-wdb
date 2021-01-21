using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeKeeper.Model;

namespace TimeKeeper.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopwatchPage : ContentPage
    {
        Stopwatch timer;

        public StopwatchPage()
        {
            InitializeComponent();
            timer = new Stopwatch();

            timeLabel.BindingContext = timer;

        }
        private void OnStartClicked(object sender, EventArgs args)
        {
            timer.Start();
        }

        private void OnResetClicked(object sender, EventArgs args)
        {
            timer.Reset();
        }

        private void OnStopClicked(object sender, EventArgs args)
        {
            timer.Stop();
        }
    }
}