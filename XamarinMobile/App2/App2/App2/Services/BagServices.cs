using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App2.dto;
using App2.Models;
using App2.Helper;

namespace App2.Services
{
    public class BagServices
    {
        public object DefaultRequestHeaders { get; set; }

        UserServices _userservice = new UserServices();
        APIServices _apiservice = new APIServices();


        //Function used to get books added to the bag by the logged in user
        public async Task<IEnumerable<BookBagModel>> GetBooksFromBagAsync(string _token)
        {
            var Booklist = new List<BookBagModel>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var json = await client.GetStringAsync(_apiservice.baseUrl+"Bag/getallbooks");
            Booklist = JsonConvert.DeserializeObject<List<BookBagModel>>(json);
            Settings.NumBagBooks = Booklist.Count;
            return await Task.FromResult(Booklist);
        }


        //Function used to remove books from book bag
        public async Task RemovefromBagAsync(int id, string _token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = client.DeleteAsync(_apiservice.baseUrl+"Bag/removebook/" + id);

        }


        //Function used to add books to bag
        public async Task<bool> AddBagAsync(string _BookAuthor, string _BookImage, string _BookTitle, int _BookId,
            int _BookQuantity,int _CategoryId, string _CategoryName, string _token)
        {
            var client = new HttpClient(new System.Net.Http.HttpClientHandler());

            var bagmodel = new AddToBagdto
            {
                BookAuthor = _BookAuthor,
                BookImage = _BookImage,
                BookTitle = _BookTitle,
                BookId = _BookId,
                BookQuantity = _BookQuantity,
                CategoryId = _CategoryId,
                CategoryName = _CategoryName,
            };

            var json = JsonConvert.SerializeObject(bagmodel);

            HttpContent content = new StringContent(json);

            var validcontent = await content.ReadAsStringAsync();

            Debug.Write(validcontent);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.PostAsync(_apiservice.baseUrl+"Bag/addtobag", content);
            var content2 = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(content2);

            return response.IsSuccessStatusCode;
        }


        //Function used to get reserved books 
        public async Task<IEnumerable<BookBagModel>> GetReservedBooksAsync(string _token)
        {
            var Booklist = new List<BookBagModel>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var json = await client.GetStringAsync(_apiservice.baseUrl+"Bag/userreservedbooks");
            Booklist = JsonConvert.DeserializeObject<List<BookBagModel>>(json);
            Settings.NumReservedBooks = Booklist.Count;
            return await Task.FromResult(Booklist);
        }


        //Function used to reserve books
        public async Task<bool> ReserveBookAsync(string _BookAuthor, string _BookImage, string _BookTitle, int _BookId,
            int _BookQuantity,int _CategoryId, string _CategoryName, string _token)
        {
            var client = new HttpClient(new System.Net.Http.HttpClientHandler());

            var bagmodel = new AddToBagdto
            {
                BookAuthor = _BookAuthor,
                BookImage = _BookImage,
                BookTitle = _BookTitle,
                BookId = _BookId,
                BookQuantity = _BookQuantity,
                CategoryId = _CategoryId,
                CategoryName = _CategoryName,
            };

            var json = JsonConvert.SerializeObject(bagmodel);

            HttpContent content = new StringContent(json);

            var validcontent = await content.ReadAsStringAsync();

            Debug.Write(validcontent);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.PostAsync(_apiservice.baseUrl+"Bag/reservebook", content);
            var content2 = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(content2);

            return response.IsSuccessStatusCode;
        }
    }
}
