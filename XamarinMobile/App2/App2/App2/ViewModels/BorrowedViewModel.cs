using App2.Helper;
using App2.Models;
using App2.Services;
using MvvmHelpers.Commands;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModels
{
    public class BorrowedViewModel : BaseViewModel
    {
        //Command to load books
        public AsyncCommand LoadBookCommand { get; }


        BorrowedServices _borrowedservice = new BorrowedServices();

        public ObservableRangeCollection<BorrowedModel> Booklist { get; set; }


        public BorrowedViewModel()
        {
            Booklist = new ObservableRangeCollection<BorrowedModel>();
            LoadBookCommand = new AsyncCommand(async () => await LoadBooksCommand());
        }


        public void OnAppearing()
        {
            IsBusy = true;
        }


        //Command function used to load borrowed books in the book history page
        private async Task LoadBooksCommand()
        {
            IsBusy = true;
            try
            {
                var token = Settings.token;
                Booklist.Clear();
                var _booklist = await _borrowedservice.GetborrowedbooksAsync(token);
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
    }
}
