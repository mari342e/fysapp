using Handler.Handlers;
using Handler.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class AfterTraining : ContentPage
    {
        bool sideEffectsAnswered = false;
        bool tiredAnswered = false;
        bool sideEffects = false;
        bool tired = false;
        Training selectedTraining = null;
        Session selectedSession = null;

        public AfterTraining(Session session, Training training = null)
        {
            selectedSession = session;
            selectedTraining = training;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            if (training != null)
            {
                slider.Value = training.PainsAfter;
                if (training.TakenPainkillerAfter)
                {
                    HasSideEffects(new object(), new EventArgs());
                }
                else
                {
                    NotHasSideEffects(new object(), new EventArgs());
                }
                TypePainkiller.Text = training.TypePainkillerAfter;
                TypePainkiller.Text = training.AmountPainkillerAfter;
                if (training.ExhaustedAfter)
                {
                    Tired(new object(), new EventArgs());
                }
                else
                {
                    NotTired(new object(), new EventArgs());
                }
                EntryComments.Text = training.Comments;
                if (selectedSession.ExerciseList.Count == training.TrainingExercises.Count)
                {
                    SaveButton.IsVisible = true;
                }
            }

        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void HasSideEffects(object sender, EventArgs e)
        {
            sideEffects = true;
            sideEffectsAnswered = true;
            SideEffectsFurtherQuestions.IsVisible = true;
            YesSideEffects.BackgroundColor = Color.FromHex("#b95b5b");
            NoSideEffects.BackgroundColor = Color.Transparent;
            YesSideEffectsLabel.TextColor = Color.White;
            NoSideEffectsLabel.TextColor = Color.FromHex("#707070");
        }

        private void NotHasSideEffects(object sender, EventArgs e)
        {
            sideEffects = false;
            sideEffectsAnswered = true;
            SideEffectsFurtherQuestions.IsVisible = false;
            NoSideEffects.BackgroundColor = Color.FromHex("#b95b5b");
            YesSideEffects.BackgroundColor = Color.Transparent;
            NoSideEffectsLabel.TextColor = Color.White;
            YesSideEffectsLabel.TextColor = Color.FromHex("#707070");
        }

        private void Tired(object sender, EventArgs e)
        {
            tired = true;
            tiredAnswered = true;
            YesTired.BackgroundColor = Color.FromHex("#b95b5b");
            NoTired.BackgroundColor = Color.Transparent;
            YesTiredLabel.TextColor = Color.White;
            NoTiredLabel.TextColor = Color.FromHex("#707070");
        }
        private void NotTired(object sender, EventArgs e)
        {
            tired = false;
            tiredAnswered = true;
            NoTired.BackgroundColor = Color.FromHex("#b95b5b");
            YesTired.BackgroundColor = Color.Transparent;
            NoTiredLabel.TextColor = Color.White;
            YesTiredLabel.TextColor = Color.FromHex("#707070");
        }

        private async void SaveAfterTraining(object sender, EventArgs e)
        {
            if (sideEffectsAnswered && tiredAnswered)
            {
                var training = new Training(selectedTraining);
                training.PainsAfter = Convert.ToInt32(slider.Value);
                training.TakenPainkillerAfter = sideEffects;
                training.TypePainkillerAfter = TypePainkiller.Text;
                training.AmountPainkillerAfter = TypePainkiller.Text;
                training.ExhaustedAfter = tired;
                training.Comments = EntryComments.Text;
                training.Completed = true;

                var trainingHandler = new TrainingHandler();
                await trainingHandler.UpdateTraining(training);

                await LoginInfo.SetLoginInfo(LoginInfo.LoggedInUser._id);
                await Navigation.PopAsync();

            }
            else
            {
                MissingInfoLabel.IsVisible = true;
            }
        }
    }
}
