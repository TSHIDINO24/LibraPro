using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalDetailsPage : ContentPage
    {
        public PersonalDetailsPage()
        {
            InitializeComponent();
        }

        private void Update_Clicked(object sender, EventArgs e)
        {

        }
    }
}