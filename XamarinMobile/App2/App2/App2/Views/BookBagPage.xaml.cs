using App2.Helper;
using App2.Services;
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
    public partial class BookBagPage : ContentPage
    {
        private BagServices _bagservice = new BagServices();
        private BorrowedServices _borrowservice = new BorrowedServices();
        public readonly BagViewModel _bagviewmodel;
        public BookBagPage()
        {
            InitializeComponent();
            this.BindingContext = _bagviewmodel = new BagViewModel();
            NumBooks.Text = Convert.ToString(Settings.NumBagBooks + "Books");
            if (Settings.NumBagBooks <= 0)
            {
                BookInBag.IsVisible = true;
            }
            _bagviewmodel.OnAppearing();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
           
           
        }

        //Borrow book button functionality
        private async void Borrow_Clicked(object sender, EventArgs e)
        {
            var token = Settings.token;
           
            bool checkoutbooks = await _borrowservice.Checkoutbooks(token);
            var BorrowCode = Settings.BorrowCode;

            if (checkoutbooks == true)
            {
                await DisplayAlert("", "Please present the Borrow code to the librarian:"+ BorrowCode, "ok");
                await Navigation.PushAsync(new BookHistoryPage());
            }
            else
            {
                await DisplayAlert("", "Please return borrowed books first", "ok");
            }
        }

      
    }
}