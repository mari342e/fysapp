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

        public BeforeTraining()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void HasPhysiotherapist(object sender, EventArgs e)
        {
            physiotherapistAnswered = true;
            YesPhysiotherapist.BackgroundColor = Color.FromHex("#b95b5b");
            NoPhysiotherapist.BackgroundColor = Color.Transparent;
            YesPhysiotherapistLabel.TextColor = Color.White;
            NoPhysiotherapistLabel.TextColor = Color.FromHex("#707070");
        }

        private void NotHasPhysiotherapist(object sender, EventArgs e)
        {
            physiotherapistAnswered = true;
            NoPhysiotherapist.BackgroundColor = Color.FromHex("#b95b5b");
            YesPhysiotherapist.BackgroundColor = Color.Transparent;
            NoPhysiotherapistLabel.TextColor = Color.White;
            YesPhysiotherapistLabel.TextColor = Color.FromHex("#707070");
        }

        private void TakenPainkillers(object sender, EventArgs e)
        {
            painkillersAnswered = true;
            PainKillersFurtherQuestions.IsVisible = true;
            YesPainkillers.BackgroundColor = Color.FromHex("#b95b5b");
            NoPainkillers.BackgroundColor = Color.Transparent;
            YesPainkillersLabel.TextColor = Color.White;
            NoPainkillersLabel.TextColor = Color.FromHex("#707070");
        }

        private void NotTakenPainkillers(object sender, EventArgs e)
        {
            painkillersAnswered = true;
            PainKillersFurtherQuestions.IsVisible = false;
            NoPainkillers.BackgroundColor = Color.FromHex("#b95b5b");
            YesPainkillers.BackgroundColor = Color.Transparent;
            NoPainkillersLabel.TextColor = Color.White;
            YesPainkillersLabel.TextColor = Color.FromHex("#707070");
        }

        private void HasSideEffects(object sender, EventArgs e)
        {
            sideEffectsAnswered = true;
            SideEffectsFurtherQuestions.IsVisible = true;
            YesSideEffects.BackgroundColor = Color.FromHex("#b95b5b");
            NoSideEffects.BackgroundColor = Color.Transparent;
            YesSideEffectsLabel.TextColor = Color.White;
            NoSideEffectsLabel.TextColor = Color.FromHex("#707070");
        }

        private void NotHasSideEffects(object sender, EventArgs e)
        {
            sideEffectsAnswered = true;

            SideEffectsFurtherQuestions.IsVisible = false;
            NoSideEffects.BackgroundColor = Color.FromHex("#b95b5b");
            YesSideEffects.BackgroundColor = Color.Transparent;
            NoSideEffectsLabel.TextColor = Color.White;
            YesSideEffectsLabel.TextColor = Color.FromHex("#707070");
        }

        private void SaveBeforeTraining(object sender, EventArgs e)
        {
            if (sideEffectsAnswered && painkillersAnswered && physiotherapistAnswered)
            {
                GoBack(new object(), new EventArgs());
            }
            else {
                MissingInfoLabel.IsVisible = true;
            }
        }
    }
}
