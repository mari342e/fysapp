using System;
using System.Collections.Generic;
using Handler.Handlers;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class TrainingLog : ContentPage
    {
        public TrainingLog()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            SessionHandler sessionHandler = new SessionHandler();
            //sessionHandler.GetGroupSessions()
        }

        async void GoToTrainingSession(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TrainingSession());
        }
    }
}
