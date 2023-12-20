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
    public partial class ViewBookPage : ContentPage
    {
        private BagServices _bagservice = new BagServices();
        public int SelectedBookID { get; set; }
        public string SelectedBookTitle { get; set; } = null;
        public string SelectedBookAuthor { get; set; } = null;
        public string SelectedBookImage { get; set; } = null;
        public int SelectedBookQuantity { get; set; }

        public int SelectedCategoryId { get; set; }

        public string SelectedCategoryName { get; set; } = null;

        public ViewBookPage(int _BookId, string _BookTitle, string _BookAuthor, string _BookImage, string _BookDescription, int _BookQuantity, string _BookStatus,string _isbn,string _CategoryName,int _CategoryId)
        {
            InitializeComponent();
            BookTitle.Text = _BookTitle;
            BookAuthor.Text = _BookAuthor;
            BookDescription.Text = _BookDescription;

            BookQuantity.Text = Convert.ToString(_BookQuantity);
            if(_BookQuantity <= 0)
            {
                BookStatus.Text = "Not Available";
                ReserveBtn.IsVisible = true;
            }
            else
            {
                BookStatus.Text = _BookStatus;
            }
            
            ISBN.Text = _isbn;
            Category.Text = _CategoryName;

            BookImage.Source = new UriImageSource()
            {
                Uri = new Uri(_BookImage)
            };

            SelectedBookAuthor = _BookAuthor;
            SelectedBookImage = _BookImage;
            SelectedBookTitle = _BookTitle;
            SelectedBookID = _BookId;
            SelectedBookQuantity = _BookQuantity;
            SelectedCategoryId = _CategoryId;
            SelectedCategoryName = _CategoryName;
        }

        private async void AddToBag_Clicked(object sender, EventArgs e)
        {
            if (SelectedBookQuantity > 0)
            {
                var token = Settings.token;
                bool addbook = await _bagservice.AddBagAsync(SelectedBookAuthor, SelectedBookImage, SelectedBookTitle, SelectedBookID,
                               SelectedBookQuantity,SelectedCategoryId, SelectedCategoryName, token);

                if (addbook == true)
                {
                    await DisplayAlert("", "Book added to Bag", "ok");
                }
                else
                {
                    await DisplayAlert("", "Book already added to Bag", "ok");
                }
            }
            else
            {
                await DisplayAlert("", "Book is not available", "ok");
            }
        }

        private async void Reserve_Clicked(object sender, EventArgs e)
        {
            if(SelectedBookQuantity <= 0)
            {
                var token = Settings.token;
                bool addbook = await _bagservice.ReserveBookAsync(SelectedBookAuthor, SelectedBookImage, SelectedBookTitle, SelectedBookID,
                               SelectedBookQuantity,SelectedCategoryId,SelectedCategoryName, token);

                if (addbook == true)
                {
                    await DisplayAlert("", "Book reserved successfully", "ok");
                }
                else
                {
                    await DisplayAlert("", "Book already reserved", "ok");
                }
               
            }
            else
            {
                await DisplayAlert("", "Book is available you can add to bag", "ok");
            }
        }
    }
}