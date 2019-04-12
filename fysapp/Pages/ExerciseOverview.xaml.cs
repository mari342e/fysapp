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
            var exerciseDescriptionPage = new ExerciseDescription();

            var exercise = listExerciseOverview.SelectedItem;            
            exerciseDescriptionPage.BindingContext = exercise;
            await Navigation.PushAsync(exerciseDescriptionPage);

            //Dette er nødvendigt for at skjule selected baggrundsfarve.
            //this.listExerciseOverview.selec.Clear();
            
        }
    }
}