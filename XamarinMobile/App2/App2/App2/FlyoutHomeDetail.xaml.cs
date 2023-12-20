using App2.Models;
using App2.ViewModels;
using App2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutHomeDetail : ContentPage
    {

        public ObservableCollection<BookModel> BooklistByCat { get; }
        private readonly BookVewModel _bookviewmodel;
        public FlyoutHomeDetail()
        {
            InitializeComponent();

            BooklistByCat = new ObservableCollection<BookModel>();
            this.BindingContext = _bookviewmodel = new BookVewModel();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as BookVewModel;

            //BookList.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                BookList.ItemsSource = _container.BooklistByCat;
                //BookNotFound.IsVisible = true;
            }
              
            else
                BookList.ItemsSource = _container.BooklistByCat.Where(i => i.BookTitle.Contains(e.NewTextValue));

            //BookList.EndRefresh();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _bookviewmodel.OnAppearing();
        }

        private void Bag_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BookBagPage());
        }
    }
}