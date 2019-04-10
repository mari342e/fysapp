using System;
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
    }
}
