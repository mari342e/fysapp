﻿using System;
using System.Collections.Generic;
using Handler;
using Handler.Handlers;
using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class TrainingSession : ContentPage
    {
        public TrainingSession()
        {
            var data = new ExerciseHandler();
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            listExerciseOverview.ItemsSource = LoginInfo.AllTrainings;
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

        async void GoToBeforeTraining(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BeforeTraining());
        }

        async void GoToAfterTraining(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AfterTraining());
        }
    }
}
