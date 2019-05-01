using Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fysapp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDescription : ContentPage
    {
        
        public ExerciseDescription(Exercise exercise, bool trainingExercise = false, string timerText = "00:00:00")
        {           

            BindingContext = exercise;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            //Skjuler timer og start hvis ikke aktiv øvelse
            Training.IsVisible = trainingExercise;

            var descriptionTexts = exercise.Description;
            foreach (var item in descriptionTexts)
            {
                Label label = new Label { Text = item, TextColor = Color.FromHex("#707070") };
                Description.Children.Add(label);
            }
            Timer.Text = timerText;
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        bool timerStarted = false;
        Timer myTimer = new Timer();

        private void UpdateTraining(object sender, EventArgs e)
        {            
            myTimer.Elapsed += new ElapsedEventHandler(SetTimer);
            myTimer.Interval = 30;
            if (!timerStarted)
            {                
                myTimer.Start();
                timerStarted = true;
                UpdateTrainingImage.Source = "Square.png";
            }
            else 
            {
                myTimer.Stop();
                timerStarted = false;
                UpdateTrainingImage.Source = "Play.png";
            }       
        }
        
        private void SetTimer(Object source, EventArgs e) 
        {
            DateTime time = DateTime.ParseExact(Timer.Text, "mm:ss:ff", null);
            var newTime = time.AddMilliseconds(30);
            var timerText = String.Format("{0:mm:ss:ff}", newTime); 
            Device.BeginInvokeOnMainThread(() =>
            Timer.Text = timerText
            );  
        }
    }
}