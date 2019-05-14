using Handler.Handlers;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fysapp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        private static ISettings AppSettings => CrossSettings.Current;
        public LoadingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            var x = loadFromApi();
            base.OnAppearing();
        }

        private async Task<string> loadFromApi()
        {
            var text = AppSettings.GetValueOrDefault("UserID", string.Empty);

            var text2 = await LoginInfo.SetLoginInfo(text);
            await Navigation.PushAsync(new Home());
            return "done";
        }
    }
}