using Handler;
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
    public partial class ExerciseDescription : ContentPage
    {
        public ExerciseDescription()
        {            
            InitializeComponent();
            //var page = this;
            //var ele = page.BindingContext;
            //Exercise exercise = ele as Exercise;
            ////Exercise ele = Exercise(BindingContext);
            //var descriptionTexts = exercise.Description;
            //foreach (var item in descriptionTexts)
            //{
            //    Label label = new Label { Text = item, TextColor = Color.FromHex("#707070") };
            //    Description.Children.Add(label);
            //}
        }
    }
}