using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using App2.Helper;
using Newtonsoft.Json.Linq;

namespace App2.Services
{
    public class BorrowedServices
    {
        BagServices _bagservice = new BagServices();
        APIServices _apIServices = new APIServices();
        public object DefaultRequestHeaders { get; set; }


        //Function used to check-out books
        public async Task<bool> Checkoutbooks(string token)
        {
            var client = new HttpClient();
            //var Booklist = new List<BookBagModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var inbooks = _bagservice.GetBooksFromBagAsync(token);
            var json = await client.GetStringAsync(_apIServices.baseUrl+"Bag/getallbooks");
           // Booklist = JsonConvert.DeserializeObject<List<BookBagModel>>(json);
            HttpContent content = new StringContent(json);
            //int BooksInBag = Booklist.Count;
            //if (BooksInBag > 0)
            //{
               
            var response = await client.PostAsync(_apIServices.baseUrl+"Borrow/borrowbook", content);
            var cont = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var Booklist = JsonConvert.DeserializeObject<BorrowedModel>(cont);
                
                Debug.WriteLine(Booklist);
                Settings.BorrowCode = Booklist.BorrowCode;
              
            }
               
            //}


            return response.IsSuccessStatusCode;
        }


        //Function used to get books added to the bag by the logged in user
        public async Task<IEnumerable<BorrowedModel>> GetborrowedbooksAsync(string _token)
        {
            var Booklist = new List<BorrowedModel>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var json = await client.GetStringAsync(_apIServices.baseUrl+"Borrow/userborrowedbooks");
            Booklist = JsonConvert.DeserializeObject<List<BorrowedModel>>(json);
           Settings.NumBorrowedBooks = Booklist.Count;
            return await Task.FromResult(Booklist);
        }

    }
}
