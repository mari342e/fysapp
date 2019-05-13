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
        public TrainingLog(DateTime? date = null)
        {
            dateWeek = date ?? DateTime.Now;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var session = GetSessionByDate(dateWeek);


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

            //var trainings = GetTrainingsByDate(dateWeek);
            //int i = 0;

            //if (trainings[0] != null)
            //    if (trainings[0].TakenPainkillerAfter != null)
            //    {
            //        //Is completed
                    

            //    }
            //    else {
            //        //Is started but not completed
            //    }
            //else {
            //    //Is not completed
            //}



            //this.Resources["NavigationBackButtonNormalStyle"] as Style;
        }

        async void GoToTrainingSession(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TrainingSession());
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

        private List<Training> GetTrainingsByDate(DateTime date) {

            var dayOfWeek = (int)date.DayOfWeek;
            if (dayOfWeek == 0)
            {
                dayOfWeek = 7;
            }
            var fromDate = date.AddDays(-dayOfWeek);
            var toDate = fromDate.AddDays(7);
            var trainings = LoginInfo.AllTrainings.FindAll(i => i.Date > fromDate & i.Date < toDate);

            return trainings;
        }
    }
}
