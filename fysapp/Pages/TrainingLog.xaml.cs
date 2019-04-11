using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class TrainingLog : ContentPage
    {
        public TrainingLog()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoToTrainingSession(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TrainingSession());
        }
    }
}
