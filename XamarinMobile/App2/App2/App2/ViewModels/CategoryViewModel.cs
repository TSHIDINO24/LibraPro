using App2.Models;
using App2.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class CategoryViewModel : BaseCatViewModel
    {
        BookServices _categoryservice = new BookServices();
        public Command LoadCatCommand { get; }
        //public string CategoryName { get; set; }
       
        public ObservableCollection<CategoryModel> Categorylist { get; }
        public CategoryViewModel() 
        { 
          Categorylist = new ObservableCollection<CategoryModel>();
          LoadCatCommand = new Command(async () => await LoadCategoryCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }


        private async Task LoadCategoryCommand()
        {
          IsBusy = true;
            try
            {
                Categorylist.Clear();
                var catlist = await _categoryservice.GetCategoryAsync();
                foreach (var cat in catlist)
                {
                    Categorylist.Add(cat);
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

        //public class CategoryVModel

        //{
        //     public List<CategoryViewModel> Get()
        //     {
        //       List<CategoryViewModel> list = new List<CategoryViewModel>();
        //       list.Add(new CategoryViewModel { CategoryName = "Software Engineering" });
        //       list.Add(new CategoryViewModel { CategoryName = "Data Structure" });
        //       list.Add(new CategoryViewModel { CategoryName = "Search Engine Optimization" });
        //       list.Add(new CategoryViewModel { CategoryName = "Android Programming " });
        //       list.Add(new CategoryViewModel { CategoryName = "Internet of Things " });
        //       list.Add(new CategoryViewModel { CategoryName = "Computer Organization " });
        //       list.Add(new CategoryViewModel { CategoryName = "Data Mining" });
        //       list.Add(new CategoryViewModel { CategoryName = "Relational Database Management System" });
        //       list.Add(new CategoryViewModel { CategoryName = "Data Structure using C" });
        //       list.Add(new CategoryViewModel { CategoryName = "Data Structure using C" });
        //       list.Add(new CategoryViewModel { CategoryName = "Data Structure using C" });
        //       return list;
        //     }
        //
}
