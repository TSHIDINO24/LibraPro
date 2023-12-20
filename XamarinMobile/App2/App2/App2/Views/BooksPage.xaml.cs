using System;
using App2.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Models;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksPage : ContentPage
    {
        public readonly BookVewModel _bookviewmodel;
        public BooksPage()
        {
            InitializeComponent();
            this.BindingContext = _bookviewmodel = new BookVewModel();
            //BindingContext = new BookVewModel();
        }


        //Functionality for searching books
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as BookVewModel;

            BookList.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
    
                BookList.ItemsSource = _container.BooklistByCat;
                //BookNotFound.IsVisible = true;
           
            }         
            else
                BookList.ItemsSource = _container.BooklistByCat.Where(i => i.BookTitle.Contains(e.NewTextValue));
                

            BookList.EndRefresh();
        }

    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _bookviewmodel.OnAppearing();
        }

        private async void BookList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var mybook = e.Item as BookModel;
            await Navigation.PushAsync(new ViewBookPage(mybook.BookId, mybook.BookTitle, mybook.BookAuthor, mybook.BookImage, mybook.BookDescription, mybook.BookQuantity, mybook.BookStatus, mybook.Isbn, mybook.CategoryName, mybook.CategoryID));
        }

        private void Bag_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BookBagPage());
        }
    }
}