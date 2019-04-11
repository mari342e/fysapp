using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class MorePage : ContentPage
    {
        public MorePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoToAbout(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Pages.AboutPage());
        }

        async void GoToGeneralInfo(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Pages.GeneralInfo());
        }
    }
}
