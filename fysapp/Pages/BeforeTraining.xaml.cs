using Handler.Handlers;
using Handler.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class BeforeTraining : ContentPage
    {

        bool painkillersAnswered = false;
        bool sideEffectsAnswered = false;
        bool physiotherapistAnswered = false;
        bool hasPhysiotherapist = false;
        bool takenPainkillers = false;
        bool hasSideEffects = false;

        Training selectedTraining = null;
        Session selectedSession = null;
        public BeforeTraining(Training training = null, Session session = null)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            selectedSession = session;

            //Fills before training information
            if (training != null) {
                selectedTraining = training;
                if (training.TrainingFysioToday)
                {
                    HasPhysiotherapist(new object(), new EventArgs());
                }
                else {
                    NotHasPhysiotherapist(new object(), new EventArgs());
                }
                slider.Value = training.PainsBefore;
                if (training.TakenPainkillerBefore)
                {
                    TakenPainkillers(new object(), new EventArgs());
                    EntryTypePainkiller.Text = training.TypePainkillerBefore;
                    EntryAmountPainkiller.Text = training.AmountPainkillerBefore;
                }
                else
                {
                    NotTakenPainkillers(new object(), new EventArgs());
                }
                if (training.SideEffectsBefore)
                {
                    HasSideEffects(new object(), new EventArgs());
                    EntrySideEffectsFurtherQuestions.Text = training.SideEffectsDescriptionBefore;
                }
                else
                {
                    NotHasSideEffects(new object(), new EventArgs());
                }
            }

        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void HasPhysiotherapist(object sender, EventArgs e)
        {
            hasPhysiotherapist = true;
            physiotherapistAnswered = true;
            YesPhysiotherapist.BackgroundColor = Color.FromHex("#b95b5b");
            NoPhysiotherapist.BackgroundColor = Color.Transparent;
            YesPhysiotherapistLabel.TextColor = Color.White;
            NoPhysiotherapistLabel.TextColor = Color.FromHex("#707070");
        }

        private void NotHasPhysiotherapist(object sender, EventArgs e)
        {
            hasPhysiotherapist = false;
            physiotherapistAnswered = true;
            NoPhysiotherapist.BackgroundColor = Color.FromHex("#b95b5b");
            YesPhysiotherapist.BackgroundColor = Color.Transparent;
            NoPhysiotherapistLabel.TextColor = Color.White;
            YesPhysiotherapistLabel.TextColor = Color.FromHex("#707070");
        }

        private void TakenPainkillers(object sender, EventArgs e)
        {
            takenPainkillers = true;
            painkillersAnswered = true;
            PainKillersFurtherQuestions.IsVisible = true;
            YesPainkillers.BackgroundColor = Color.FromHex("#b95b5b");
            NoPainkillers.BackgroundColor = Color.Transparent;
            YesPainkillersLabel.TextColor = Color.White;
            NoPainkillersLabel.TextColor = Color.FromHex("#707070");
        }

        private void NotTakenPainkillers(object sender, EventArgs e)
        {
            takenPainkillers = false;
            painkillersAnswered = true;
            PainKillersFurtherQuestions.IsVisible = false;
            NoPainkillers.BackgroundColor = Color.FromHex("#b95b5b");
            YesPainkillers.BackgroundColor = Color.Transparent;
            NoPainkillersLabel.TextColor = Color.White;
            YesPainkillersLabel.TextColor = Color.FromHex("#707070");
        }

        private void HasSideEffects(object sender, EventArgs e)
        {
            hasSideEffects = true;
            sideEffectsAnswered = true;
            SideEffectsFurtherQuestions.IsVisible = true;
            YesSideEffects.BackgroundColor = Color.FromHex("#b95b5b");
            NoSideEffects.BackgroundColor = Color.Transparent;
            YesSideEffectsLabel.TextColor = Color.White;
            NoSideEffectsLabel.TextColor = Color.FromHex("#707070");
        }

        private void NotHasSideEffects(object sender, EventArgs e)
        {
            hasSideEffects = false;
            sideEffectsAnswered = true;
            SideEffectsFurtherQuestions.IsVisible = false;
            NoSideEffects.BackgroundColor = Color.FromHex("#b95b5b");
            YesSideEffects.BackgroundColor = Color.Transparent;
            NoSideEffectsLabel.TextColor = Color.White;
            YesSideEffectsLabel.TextColor = Color.FromHex("#707070");
        }

        private async void SaveBeforeTraining(object sender, EventArgs e)
        {
            if (sideEffectsAnswered && painkillersAnswered && physiotherapistAnswered)
            {
                TrainingHandler trainingHandler = new TrainingHandler();
                if (selectedTraining == null) {    
                    Training training = new Training();
                    training.TrainingFysioToday = hasPhysiotherapist;
                    training.PainsBefore = slider.Value;
                    training.TakenPainkillerBefore = takenPainkillers;
                    training.TypePainkillerBefore = EntryTypePainkiller.Text;
                    training.AmountPainkillerBefore = EntryAmountPainkiller.Text;                   
                    training.SideEffectsBefore = hasSideEffects;
                    training.SideEffectsDescriptionBefore = EntrySideEffectsFurtherQuestions.Text;
                    training.UserID = LoginInfo.LoggedInUser._id;
                    training.SessionID = selectedSession._id;
                    training.TrainingExercises = new List<TrainingExercise>();
                    training.Date = DateTime.Today;
                    await trainingHandler.CreateTraining(training);
                }
               else 
                {
                    Training training = new Training(selectedTraining);
                    training.TrainingFysioToday = hasPhysiotherapist;
                    training.PainsBefore = slider.Value;
                    training.TakenPainkillerBefore = takenPainkillers;
                    training.TypePainkillerBefore = EntryTypePainkiller.Text;
                    training.AmountPainkillerBefore = EntryAmountPainkiller.Text;
                    training.SideEffectsBefore = hasSideEffects;
                    training.SideEffectsDescriptionBefore = EntrySideEffectsFurtherQuestions.Text;
                    
                    await trainingHandler.UpdateTraining(training);
                }
                await LoginInfo.SetLoginInfo(LoginInfo.LoggedInUser._id);
                await Navigation.PopAsync();          
            }
            else {
                MissingInfoLabel.IsVisible = true;
            }
        }
    }
}
