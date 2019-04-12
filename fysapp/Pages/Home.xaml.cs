﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void GoToSurvey(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Pages.Accordion());
        }
    }
}
