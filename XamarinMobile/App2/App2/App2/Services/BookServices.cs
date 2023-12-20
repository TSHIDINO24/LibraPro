using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services
{   public class BookServices
    {
        public object DefaultRequestHeaders { get; set; }

        private APIServices _apiservice = new APIServices();

        //Function used to get all registered books from the database
        public async Task<IEnumerable<BookModel>> GetBooksAsync()
        {
            List<BookModel> Booklist = new List<BookModel>();
            HttpClient client = new HttpClient();

            string url = _apiservice.baseUrl+"Book/allbooks";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string Content = response.Content.ReadAsStringAsync().Result;
                 Booklist = JsonConvert.DeserializeObject<List<BookModel>>(Content);
            }
            return await Task.FromResult(Booklist);
        }



        //Function used to get Books by category id from the database
        public async Task<IEnumerable<BookModel>> GetBookByCategorysync(int id)
        {
            var Booklist = new List<BookModel>();
            HttpClient client = new HttpClient();
            string url = _apiservice.baseUrl+$"Book/getbooksbycategory?Id={id}";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync("");

            var content2 = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(content2);

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Booklist = JsonConvert.DeserializeObject<List<BookModel>>(content);
            }
            return await Task.FromResult(Booklist);
        }



        //Function used to get all registered Categories from the database
        public async Task<IEnumerable<CategoryModel>> GetCategoryAsync()
        {
            var CategoryList = new List<CategoryModel>();
            HttpClient client = new HttpClient();
            String url = _apiservice.baseUrl+"Category/getallcategories";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage responsemessage = await client.GetAsync("");
           
            if (responsemessage.IsSuccessStatusCode)
            {
                string Content = responsemessage.Content.ReadAsStringAsync().Result;
                CategoryList = JsonConvert.DeserializeObject<List<CategoryModel>>(Content);
            }

            return await Task.FromResult(CategoryList);

        }
    }
}
