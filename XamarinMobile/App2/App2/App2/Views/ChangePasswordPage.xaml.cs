using App2.Helper;
using App2.ViewModels;
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
    public partial class ChangePasswordPage : ContentPage
    {
        BagViewModel _bagviewmodel;
        public ChangePasswordPage()
        {
            InitializeComponent();
            this.BindingContext = _bagviewmodel = new BagViewModel();
        
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Settings.NumReservedBooks <= 0)
            {
                NoReservedBooks.IsVisible = true;
            }
            _bagviewmodel.OnAppearing();

        }

        private void ChangePassword_Clicked(object sender, EventArgs e)
        {

        }
    }
}