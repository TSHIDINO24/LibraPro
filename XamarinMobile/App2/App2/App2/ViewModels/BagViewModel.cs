using App2.Helper;
using App2.Models;
using App2.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModels
{
    public class BagViewModel : BaseViewModel
    {
        //Command to load books
        public AsyncCommand LoadBookCommand { get; }
        public AsyncCommand LoadReservedBookCommand { get; }

        BagServices _bagservice = new BagServices();

        public ObservableRangeCollection<BookBagModel> Booklist { get; set; }

        public AsyncCommand<BookBagModel> RemoveCommand { get; }

        public BagViewModel()
        {
            Booklist = new ObservableRangeCollection<BookBagModel>();
            LoadBookCommand = new AsyncCommand(async () => await LoadBooksCommand());
            //RemoveCommand = new AsyncCommand(async () => await RemoveBookCommand(Booklist));
            RemoveCommand = new AsyncCommand<BookBagModel>(RemoveBookCommand);

            LoadReservedBookCommand = new AsyncCommand(async () => await LoadReserveBooksCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        //Command function used to load books in the book bag page
        private async Task LoadBooksCommand()
        {
            IsBusy = true;
            try
            {
                var token = Settings.token;
                Booklist.Clear();
                var _booklist = await _bagservice.GetBooksFromBagAsync(token);
                foreach (var book in _booklist)
                {
                    Booklist.Add(book);
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

        //Command function used to load books in the book bag page
        private async Task LoadReserveBooksCommand()
        {
            IsBusy = true;
            try
            {
                var token = Settings.token;
                Booklist.Clear();
                var _booklist = await _bagservice.GetReservedBooksAsync(token);
                foreach (var book in _booklist)
                {
                    Booklist.Add(book);
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


        //Command function used to remove books from book bag page
        private async Task RemoveBookCommand(BookBagModel book)
        {
            var token = Settings.token;
            await _bagservice.RemovefromBagAsync(book.BagId, token);
        }

        private async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(1000);

            Booklist.Clear();

            var token = Settings.token;
            var newbooklist = await _bagservice.GetBooksFromBagAsync(token);


        }
    }
}
