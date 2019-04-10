using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace fysapp
{
    public partial class FrontPage : ContentPage
    {
        public FrontPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
