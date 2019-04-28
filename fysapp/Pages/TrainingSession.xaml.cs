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

        async private void ExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedExercise = listExerciseOverview.SelectedItem;
            var exercise = (Exercise)selectedExercise;
            var exerciseDescriptionPage = new ExerciseDescription(exercise, true);

            await Navigation.PushAsync(exerciseDescriptionPage);
        }
    }
}
