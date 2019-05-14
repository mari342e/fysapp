using Handler.Handlers;
using Handler.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class AfterExercise : ContentPage
    {
        TrainingExercise selectedTrainingExercise = null;
        Training selectedTraining = null;
        Exercise selectedExercise = null;


        public AfterExercise(Exercise exercise, Training training, string time = null)
        {
            selectedTraining = training;
            selectedExercise = exercise;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            selectedTrainingExercise = training.TrainingExercises.Find(i => i.ExerciseID == exercise.ApiExerciseID);

            if (time != null)
            {
                EntryTime.Text = time;
            }
            else if (selectedTrainingExercise != null) {
                EntryTime.Text = selectedTrainingExercise.time.ToString("mm:ss:ff");
            }
            if (selectedTrainingExercise != null)
            {
                EntryRepetitions1.Text = selectedTrainingExercise.set1Repetitions.ToString();
                EntryRepetitions2.Text = selectedTrainingExercise.set2Repetitions.ToString();
                EntryRepetitions3.Text = selectedTrainingExercise.set3Repetitions.ToString();
                EntryWeights1.Text = selectedTrainingExercise.set1Weights.ToString();
                EntryWeights2.Text = selectedTrainingExercise.set2Weights.ToString();
                EntryWeights3.Text = selectedTrainingExercise.set3Weights.ToString();
            }
            

        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            if (selectedTrainingExercise != null)
            {
                var trainingExercise = new TrainingExercise(
                    selectedTrainingExercise.ExerciseID,
                    DateTime.ParseExact(EntryTime.Text, "mm:ss:ff", CultureInfo.InvariantCulture),
                    int.Parse(EntryRepetitions1.Text),
                    int.Parse(EntryRepetitions2.Text),
                    int.Parse(EntryRepetitions3.Text),
                    Double.Parse(EntryWeights1.Text),
                    Double.Parse(EntryWeights2.Text),
                    Double.Parse(EntryWeights3.Text)
                    );

                selectedTraining.TrainingExercises.Remove(selectedTrainingExercise);
                selectedTraining.TrainingExercises.Add(trainingExercise);
                var trainingHandler = new TrainingHandler();

                await trainingHandler.UpdateTraining(selectedTraining);
                await LoginInfo.SetLoginInfo(LoginInfo.LoggedInUser._id);
                await Navigation.PopAsync();
                await Navigation.PopAsync();

            }
            else if (EntryRepetitions1.Text != null && EntryRepetitions2.Text != null && EntryRepetitions3.Text != null && EntryWeights1.Text != null && EntryWeights2.Text != null && EntryWeights3.Text != null)
            {
                var trainingExercise = new TrainingExercise(
                   selectedExercise.ApiExerciseID,
                   DateTime.ParseExact(EntryTime.Text, "mm:ss:ff", CultureInfo.InvariantCulture),
                   int.Parse(EntryRepetitions1.Text),
                   int.Parse(EntryRepetitions2.Text),
                   int.Parse(EntryRepetitions3.Text),
                   Double.Parse(EntryWeights1.Text),
                   Double.Parse(EntryWeights2.Text),
                   Double.Parse(EntryWeights3.Text)
                   );
                var trainingHandler = new TrainingHandler();

                selectedTraining.TrainingExercises.Add(trainingExercise);

                await trainingHandler.UpdateTraining(selectedTraining);
                await LoginInfo.SetLoginInfo(LoginInfo.LoggedInUser._id);
                await Navigation.PopAsync();
                await Navigation.PopAsync();

            }
            else {
                MissingInfoLabel.IsVisible = true;
            }
        }
    }
}
