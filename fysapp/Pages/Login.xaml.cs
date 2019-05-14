using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using Handler.Handlers;
using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class Login : ContentPage
    {
        private static ISettings AppSettings => CrossSettings.Current;
        public Login(bool wrongId = false)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            if (wrongId == true) {
                WrongID.IsVisible = true;
            }
        }

        async void GoToHomePage(object sender, System.EventArgs e)
        {
            var text = LoginID.Text;
            UserHandler userHandler = new UserHandler();
            var user = await userHandler.GetUserByAssignedID(text);
            if (user != null)
            {
                AppSettings.AddOrUpdateValue("UserID", user._id);
                await LoginInfo.SetLoginInfo(user._id);
                await Navigation.PushAsync(new Home());
            }
            else {
                await Navigation.PushAsync(new Login(true));
            }
        }
    }
}