﻿using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class MorePage : ContentPage
    {
        private static ISettings AppSettings =>
   CrossSettings.Current;
        public MorePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoToAbout(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        async void GoToGeneralInfo(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GeneralInfo());
        }

        async void LogOut(object sender, EventArgs e)
        {

            AppSettings.AddOrUpdateValue("LoginID","");
            await Navigation.PushAsync(new Login());
        }
    }
}
