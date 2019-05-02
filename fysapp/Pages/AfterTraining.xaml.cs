using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class AfterTraining : ContentPage
    {
        bool sideEffectsAnswered = false;
        bool tiredAnswered = false;
        public AfterTraining()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            displayNr.Text = String.Format("{0}", value);
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
        private void Tired(object sender, EventArgs e)
        {
            tiredAnswered = true;
            YesTired.BackgroundColor = Color.FromHex("#b95b5b");
            NoTired.BackgroundColor = Color.Transparent;
            YesTiredLabel.TextColor = Color.White;
            NoTiredLabel.TextColor = Color.FromHex("#707070");
        }
        private void NotTired(object sender, EventArgs e)
        {
            tiredAnswered = true;            
            NoTired.BackgroundColor = Color.FromHex("#b95b5b");
            YesTired.BackgroundColor = Color.Transparent;
            NoTiredLabel.TextColor = Color.White;
            YesTiredLabel.TextColor = Color.FromHex("#707070");
        }
        private void SaveAfterTraining(object sender, EventArgs e)
        {
            if (sideEffectsAnswered && tiredAnswered)
            {
                GoBack(new object(), new EventArgs());
            }
            else
            {
                MissingInfoLabel.IsVisible = true;
            }
        }
    }
}
