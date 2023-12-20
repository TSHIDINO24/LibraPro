using App2.Helper;
using App2.Models;
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
    public partial class CategoryPage : ContentPage
    {
        public readonly CategoryViewModel _categoryviewmodel;
        private readonly BookVewModel _bookviewmodel;
        private BookServices bookservices = new BookServices();
        public CategoryPage()
        {
            InitializeComponent();
            this.BindingContext = _categoryviewmodel = new CategoryViewModel();
            //CategoryList.ItemsSource = new CategoryVModel().Get();
            
        }

        private async void CategoryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            var mycat = e.Item as CategoryModel;
            Settings.categoId = mycat.CategoryId;

            await Navigation.PushAsync(new BooksPage());
          
   
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _categoryviewmodel.OnAppearing();
        }
    }
}