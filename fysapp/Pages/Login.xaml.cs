using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoToHomePage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Home());
        }
    }
}
