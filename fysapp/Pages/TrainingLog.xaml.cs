using System;
using System.Collections.Generic;
using Handler.Handlers;
using Handler.Models;
using Xamarin.Forms;

namespace fysapp.Pages
{
    public partial class TrainingLog : ContentPage
    {

        DateTime dateWeek = new DateTime();
        Session selectedSession = new Session();
        public TrainingLog(DateTime? date = null)
        {
            dateWeek = date ?? DateTime.Now;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var session = GetSessionByDate(dateWeek);
            selectedSession = session;

            //Skjuler tilbage og giver den korrekt uge nr.
            if (session.UserSelectedWeekNo == 1)
            {
                FormerWeek.IsVisible = false;
            }
            else
            {
                FormerWeekText.Text = "uge " + (session.UserSelectedWeekNo - 1).ToString();
            }
            if (GetSessionByDate(dateWeek.AddDays(7), true) == null)
            {
                FutureWeek.IsVisible = false;
            }
            else
            {
                FutureWeekText.Text = "uge " + (session.UserSelectedWeekNo + 1).ToString();
            }
            CurrentWeekText.Text = "Du er igang med uge " + session.UserSelectedWeekNo.ToString();

            var trainings = GetTrainingsByDate(dateWeek);
           
            var command = new Command<Training>(GoToTrainingSession);
            trainingPas1Tap.Command = command;
            trainingPas2Tap.Command = command;
            trainingPas3Tap.Command = command;
            if (trainings.Count > 0) {
               
                trainingPas1Tap.CommandParameter = trainings[0];
                if (trainings[0].Completed)
                {
                    //Is completed
                    var frame = PositiveFrame();

                    trainingPas1.Children.Add(frame);
                }
                else
                {
                    var frame = NegativeFrame();

                    trainingPas1.Children.Add(frame);
                    //Is started but not completed
                }
            }
            if (trainings.Count > 1) {             
                trainingPas2Tap.CommandParameter = trainings[1];
                if (trainings[1].Completed)
                {
                    //Is completed
                    var frame = PositiveFrame();

                    trainingPas2.Children.Add(frame);
                }
                else
                {
                    var frame = NegativeFrame();

                    trainingPas2.Children.Add(frame);
                    //Is started but not completed
                }
            }
            if (trainings.Count > 2)
            {               
                trainingPas3Tap.CommandParameter = trainings[2];
                if (trainings[2].Completed)
                {
                    //Is completed
                    var frame = PositiveFrame();

                    trainingPas3.Children.Add(frame);
                }
                else
                {
                    var frame = NegativeFrame();

                    trainingPas3.Children.Add(frame);
                    //Is started but not completed
                }
            }
            else
            {
                //No trainings completed
            }



           
        }

        async void GoToTrainingSession(Training training = null)
        {
           
            await Navigation.PushAsync(new TrainingSession(selectedSession, training));
        }
        async void NextWeek(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TrainingLog(dateWeek.AddDays(7)));
        }
        async void LastWeek(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TrainingLog(dateWeek.AddDays(-7)));
        }
        private Session GetSessionByDate(DateTime? date, bool checkIfDateAvailable = false)
        {

            var session = LoginInfo.UserSessions.Find(i => i.UserStartDate <= date && i.UserEndDate >= date);
            if (session != null && !checkIfDateAvailable)
            {
                if (session.UserWeekNo.Count > 1)
                {
                    for (int i = 0; i < session.UserWeekNo.Count; i++)
                    {
                        if (session.UserStartDate < date && date < session.UserStartDate.AddDays((i + 1) * 7))
                        {
                            session.UserSelectedWeekNo = session.UserWeekNo[i];
                            i = 100;
                        }
                    }
                }
                else {
                    session.UserSelectedWeekNo = session.UserWeekNo[0];
                }
            }

            return session;
        }
        private Frame PositiveFrame() {
            var frame = new Frame();
            var image = new Image();
            frame.Style = Application.Current.Resources["checkmark"] as Style;     
            image.Source = "Checkmark";
            image.Style = Application.Current.Resources["checkmarkIcon"] as Style;
            frame.Content = image;
            return frame;
        }
        private Frame NegativeFrame()
        {
            var frame = new Frame();
            var image = new Image();
            frame.Style = Application.Current.Resources["cross"] as Style;
            image.Source = "Cross";
            image.Style = Application.Current.Resources["crossIcon"] as Style;
            frame.Content = image;
            return frame;
        }
        private List<Training> GetTrainingsByDate(DateTime date) {

            var dayOfWeek = (int)date.DayOfWeek;
            if (dayOfWeek == 0)
            {
                dayOfWeek = 7;
            }
            var fromDate = date.Date.AddDays(-dayOfWeek +1);
            var toDate = fromDate.AddDays(7);
            var trainings = LoginInfo.AllTrainings.FindAll(i => i.Date > fromDate & i.Date < toDate);

            return trainings;
        }
    }
    public class TrainingEventArgs : EventArgs {
        public Training Training {get; set;}
    }
}
