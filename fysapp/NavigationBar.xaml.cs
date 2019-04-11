using System;
using System.Collections.Generic;
using fysapp.Pages;
using Xamarin.Forms;

namespace fysapp
{
    public partial class NavigationBar : ContentView
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        async void GoToHomePage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FrontPage());
        }

        async void GoToTrainingLog(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TrainingLog());
        }

        async void GoToExerciseOverview(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseOverview());
        }

        async void GoToMorePage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MorePage());
        }
    }
}
