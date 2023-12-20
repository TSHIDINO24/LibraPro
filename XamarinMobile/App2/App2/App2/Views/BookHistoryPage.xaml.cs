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
	public partial class BookHistoryPage : ContentPage
	{
        private BorrowedViewModel _borrowedviewmodel = new BorrowedViewModel();
        public BookHistoryPage ()
		{
			InitializeComponent ();
            this.BindingContext = _borrowedviewmodel = new BorrowedViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(Settings.NumBorrowedBooks <= 0)
            {
                NoBorrowedBooks.IsVisible = true;
            }
            _borrowedviewmodel.OnAppearing();
        }
    }
}