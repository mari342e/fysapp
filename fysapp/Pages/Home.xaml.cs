using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoToTrainingLog(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Pages.TrainingLog());
        }

        async void GoToExercises(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ExerciseOverview());
        }
    }
}
