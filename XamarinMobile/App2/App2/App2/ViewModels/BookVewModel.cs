using App2.Helper;
using App2.Models;
using App2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class BookVewModel : BaseCatViewModel
    {
        //Command to load all books
        public Command LoadAllBookCommand { get; }

        //Command to load book by categories
        public Command LoadBookCommand { get; }

        //Command for Book selected
        //private DelegateCommand itemselectedcommand;
        //public DelegateCommand SelectedBookCommand => itemselectedcommand
        //   ?? (itemselectedcommand);


        BookServices _bookservice = new BookServices();

        public ObservableCollection<BookModel> BooklistByCat { get; }

        public BookVewModel()
        {
            BooklistByCat = new ObservableCollection<BookModel>();
            LoadAllBookCommand = new Command(async () => await LoadBooksCommand());
            LoadBookCommand = new Command(async () => await BookByCategory());

            Books = GetBooks();

        }

        public void OnAppearing()
        {
            IsBusy = true;
        }


        //Function used to load books
        private async Task LoadBooksCommand()
        {
            IsBusy = true;
            try
            {
                BooklistByCat.Clear();
                //var booklist = await _apiservice.GetBookByCategorysync(3);
                var booklist = await _bookservice.GetBooksAsync();
                foreach (var book in booklist)
                {                   
                    BooklistByCat.Add(book);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task BookByCategory()
        {
            IsBusy = true;
            try
            {
                BooklistByCat.Clear();
                var catId = Settings.categoId;

                var booklist = await _bookservice.GetBookByCategorysync(catId);
                //var booklist = await _apiservice.GetBooksAsync();
                foreach (var book in booklist)
                {
                    BooklistByCat.Add(book);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


        private BookModel _book;

        public BookModel SelectedBook
        {
            get { return _book; }
            set { _book = value; }
        }

        private ObservableCollection<BookBagModel> _Books;

        public ObservableCollection<BookBagModel> Books
        {
            get { return _Books; }
            set { _Books = value; }

        }

        public ObservableCollection<BookBagModel> GetBooks()
        {
            return new ObservableCollection<BookBagModel>
            {
                new BookBagModel {BookTitle = "Tshidino", BookDescription = "Venda", BookAuthor = "Mulaudzi", BookImage = "HappyE.jpg" },
                new BookBagModel {BookTitle = "Hungwani", BookDescription = "Tsonga", BookAuthor = "Khalanga", BookImage = "LosingM.jpg"},
                new BookBagModel {BookTitle = "Thutlwa", BookDescription = "Tswana", BookAuthor = "Tlhopi", BookImage = "JohnR.jpg" },
                new BookBagModel {BookTitle = "Moloto", BookDescription = "Pedi", BookAuthor = "Sekhukhune", BookImage = "Rockstar.jpg"},
            };
        }
    }
}
