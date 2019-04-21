using System;
using System.Collections.Generic;
using Handler;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class TrainingSession : ContentPage
    {
        public TrainingSession()
        {
            var data = new Data();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            listExerciseOverview.ItemsSource = data.GetExercises();
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
