using System;
using System.Collections.Generic;
using Handler;
using Handler.Models;
using Handler.Handlers;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace fysapp.Pages
{
    public partial class TrainingSession : ContentPage
    {
        Training selectedTraining = null;
        Session selectedSession = new Session();
        public TrainingSession(Session session, Training training = null)
        {
            if (selectedTraining != null)
            {
                selectedTraining = LoginInfo.AllTrainings.Find(i => i._id == selectedTraining._id);
                beforeTrainingBox.Children.Add(PositiveFrame());
                if (selectedTraining.Completed == true)
                {
                    afterTrainingBox.Children.Add(PositiveFrame());
                }
            }
            foreach (var item in selectedSession.ExerciseIDs)
            {
                foreach (var exercise in LoginInfo.AllExercises)
                {
                    if (exercise.ApiExerciseID == item)
                    {
                        exerciseList.Children.Add(ExerciseStackLayout(exercise, selectedTraining));
                    }
                }
            }

            selectedSession = session;
            selectedTraining = training;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //async private void ExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var selectedExercise = listExerciseOverview.SelectedItem;
        //    var exercise = (Exercise)selectedExercise;
        //    var exerciseDescriptionPage = new ExerciseDescription(exercise, true);

        //    await Navigation.PushAsync(exerciseDescriptionPage);
        //}
        private async void goToTrainingExercise(Exercise exercise = null)
        {
            var startable = false;
            if (selectedSession.UserStartDate < DateTime.Now && selectedSession.UserEndDate > DateTime.Now && selectedTraining != null)
            {

                var training = selectedTraining.TrainingExercises.Find(i => i.ExerciseID == exercise.ApiExerciseID);
                if (training == null)
                {
                    startable = true;
                }
            }
            var exerciseDescriptionPage = new ExerciseDescription(exercise, selectedTraining, startable);
            await Navigation.PushAsync(exerciseDescriptionPage);
        }

        async void GoToBeforeTraining(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BeforeTraining(selectedTraining, selectedSession));
        }

        async void GoToAfterTraining(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AfterTraining(selectedSession, selectedTraining));
        }

        private StackLayout ExerciseStackLayout(Exercise exercise, Training training = null)
        {

            Grid grid = new Grid();
            grid.ColumnSpacing = 10;
            grid.RowSpacing = 5;
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();

            row1.Height = 35;
            row2.Height = 50;
            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);
            ColumnDefinition column1 = new ColumnDefinition();
            ColumnDefinition column2 = new ColumnDefinition();
            column1.Width = 90;
            column2.Width = new GridLength(1.0, GridUnitType.Star);
            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);

            //Image
            var image = new Image();
            image.Source = exercise.ImageLinks[0];
            image.Aspect = Aspect.AspectFill;
            Grid.SetRowSpan(image, 2);
            Grid.SetRow(image, 0);
            Grid.SetColumn(image, 0);
            grid.Children.Add(image);

            //Label øvelse
            var label = new Label();
            label.Style = Application.Current.Resources["h2"] as Style;
            label.Text = "Øvelse " + exercise.ExerciseID.ToString();
            Grid.SetRow(label, 0);
            Grid.SetColumn(label, 1);
            grid.Children.Add(label);

            //Label øvelses navn
            var label2 = new Label();
            label2.Style = Application.Current.Resources["basicListFrameBodyText"] as Style;
            label2.Text = exercise.Title;
            Grid.SetRow(label2, 1);
            Grid.SetColumn(label2, 1);
            grid.Children.Add(label2);

            //Frame
            Frame frame = new Frame();
            frame.Style = Application.Current.Resources["basicListFrame"] as Style;
            frame.HeightRequest = 90;
            var command = new Command<Exercise>(goToTrainingExercise);
            var tap = new TapGestureRecognizer();
            tap.Command = command;
            tap.CommandParameter = exercise;
            frame.GestureRecognizers.Add(tap);
            frame.Content = grid;

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(frame);

            if (training != null && training.TrainingExercises != null)
            {
                TrainingExercise trainingExercise = training.TrainingExercises.Find(i => i.ExerciseID == exercise.ApiExerciseID);
                if (trainingExercise != null)
                {
                    var icon = PositiveFrame();
                    stackLayout.Children.Add(icon);
                }
            }
            return stackLayout;
        }
        private Frame PositiveFrame()
        {
            var frame = new Frame();
            var image = new Image();
            frame.Style = Application.Current.Resources["checkmark"] as Style;
            frame.Margin = new Thickness(0, -25, 0, 0);
            image.Source = "Checkmark";
            image.Style = Application.Current.Resources["checkmarkIcon"] as Style;
            frame.Content = image;
            return frame;
        }
        private Frame NegativeFrame()
        {
            var frame = new Frame();
            var image = new Image();
            frame.Style = Application.Current.Resources["cross"] as Style;
            frame.Margin = new Thickness(0, -25, 0, 0);
            image.Source = "Cross";
            image.Style = Application.Current.Resources["crossIcon"] as Style;
            frame.Content = image;
            return frame;
        }
    }
}
