using fysapp.Pages;
using Handler.Handlers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace fysapp
{
    public partial class App : Application
    {
        private static ISettings AppSettings => CrossSettings.Current;
        public App()
        {
            InitializeComponent();
           var data = new SessionHandler();
            var exercises = data.GetAllSessions();
            

            var text = AppSettings.GetValueOrDefault("LoginID", string.Empty);           

            if (text != null && text != "")
            {

                UserHandler userHandler = new UserHandler();
                var user = userHandler.GetUserByID(text);

                if (user != null)
                {
                    MainPage = new NavigationPage(new Home());
                }
                else {
                    MainPage = new NavigationPage(new Login());
                }
            }
            else {
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
