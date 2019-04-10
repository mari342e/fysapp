using Handler;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fysapp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var data = new Data();
           var exercises = data.GetExercises();
            MainPage = new MainPage();
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
