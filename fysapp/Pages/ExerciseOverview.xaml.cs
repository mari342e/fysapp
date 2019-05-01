using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handler;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fysapp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExerciseOverview : ContentPage
	{
        Data data = new Data();

        public ExerciseOverview ()
		{
            
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            listExerciseOverview.ItemsSource = data.GetExercises();
            
        }

        private async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedExercise = listExerciseOverview.SelectedItem;
            var exercise = (Exercise)selectedExercise;
            var exerciseDescriptionPage = new ExerciseDescription(exercise);                  
           
            await Navigation.PushAsync(exerciseDescriptionPage);

            //Dette er nødvendigt for at skjule selected baggrundsfarve.
            //this.listExerciseOverview.selec.Clear();
            
        }

        async void GoBack(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}