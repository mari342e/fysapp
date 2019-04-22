using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class AfterTraining : ContentPage
    {
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
    }
}
