using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class Home : ContentPage
    {
        private static ISettings AppSettings => CrossSettings.Current;
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

           
            if (AppSettings.GetValueOrDefault("VisitedFrontpage", string.Empty) == "")
            {
                AppSettings.AddOrUpdateValue("VisitedFrontpage", "1");
            }
            else {
                ImportantInfo.IsVisible = false;
            }
        }

        async void ReadMore(object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new GeneralInfo());
        }

        async void GoToTrainingLog(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TrainingLog());
        }

        async void GoToExercises(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseOverview());
        }
    }
}
