using Handler;
using Handler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fysapp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDescription : ContentPage
    {
        Exercise selectedExercise = null;
        Training selectedTraining = null;

        public ExerciseDescription(Exercise exercise, Training training = null, bool trainingExerciseBool = false)
        {

            selectedExercise = exercise;
            BindingContext = exercise;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            TrainingExercise trainingExercise = null;

            if (training != null)
            {
                selectedTraining = training;
                trainingExercise = training.TrainingExercises.Find(i => i.ExerciseID == exercise.ApiExerciseID);
                if (trainingExercise != null)
                {
                    //var tap = new TapGestureRecognizer();
                    //var command = new Command<Training>(ResultTrainingExercise);
                    //tap.Command = command;
                    //tap.CommandParameter = training;
                    //ResultButton.GestureRecognizers.Add(tap);
                    //ResultButton.Pressed += ResultTrainingExercise;
                    ResultButton.IsVisible = true;

                }
                else if (trainingExerciseBool && trainingExercise == null)
                {
                    //var tap = new TapGestureRecognizer();
                    //var command = new Command<Training>(ResultTrainingExercise);
                    //tap.Command = command;
                    //tap.CommandParameter = training;
                    //ResultButton.GestureRecognizers.Add(tap);
                    //FinishedButton.Pressed += ResultFinishedExercise;
                    FinishedButton.IsVisible = true;
                }
            }

            //Skjuler timer og start hvis ikke aktiv øvelse
            Training.IsVisible = trainingExerciseBool;
            Label label = new Label { Text = exercise.Description, TextColor = Color.FromHex("#707070") };
            Description.Children.Add(label);

            Timer.Text = "00:00:00";
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        bool timerStarted = false;
        Timer myTimer = new Timer();


        private async void ResultTrainingExercise(object sender, EventArgs e)
        {
            var afterExercisePage = new AfterExercise(selectedExercise, selectedTraining);
            await Navigation.PushAsync(afterExercisePage);
        }
        private async void ResultFinishExercise(object sender, EventArgs e)
        {
            var time = Timer.Text;
            var afterExercisePage = new AfterExercise(selectedExercise, selectedTraining, time);
            await Navigation.PushAsync(afterExercisePage);
        }

        private void UpdateTraining(object sender, EventArgs e)
        {
            myTimer.Elapsed += new ElapsedEventHandler(SetTimer);
            myTimer.Interval = 30;
            if (!timerStarted)
            {
                myTimer.Start();
                timerStarted = true;
                UpdateTrainingImage.Source = "Square.png";
            }
            else
            {
                myTimer.Stop();
                timerStarted = false;
                UpdateTrainingImage.Source = "Play.png";
            }
        }

        private void SetTimer(Object source, EventArgs e)
        {
            DateTime time = DateTime.ParseExact(Timer.Text, "mm:ss:ff", null);
            var newTime = time.AddMilliseconds(30);
            var timerText = String.Format("{0:mm:ss:ff}", newTime);
            Device.BeginInvokeOnMainThread(() =>
            Timer.Text = timerText
            );
        }
    }
}