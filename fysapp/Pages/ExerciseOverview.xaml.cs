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
		public ExerciseOverview ()
		{
            var data = new Data();
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            listExerciseOverview.ItemsSource = data.GetExercises();
        }
	}
}