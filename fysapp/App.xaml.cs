using fysapp.Pages;
using Handler.Handlers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Threading.Tasks;

namespace fysapp
{
    public partial class App : Application
    {
        private static ISettings AppSettings => CrossSettings.Current;
        public App()
        {
            InitializeComponent();
            var text = AppSettings.GetValueOrDefault("UserID", string.Empty);

            if (text != null && text != "")
            {               
                MainPage = new NavigationPage(new LoadingPage());
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }


        }


        protected override void OnStart()
        {
            // Handle when your app starts
           
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
