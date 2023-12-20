using App2.dto;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App2.Helper;


namespace App2.Services
{
    public class UserServices
    {
        public object DefaultRequestHeaders { get; set; }

        public APIServices apiservice = new APIServices();

        //Function used to register users
        public async Task<bool> RegisterAsync(string _username, string _surname, string _idnumber, string _email, string _phone, string _address, string _password)
        {

            var client = new HttpClient(new System.Net.Http.HttpClientHandler());

            var model = new Userregisterdto
            {
                Username = _username,
                UserSurname = _surname,
                UserIDNumber = _idnumber,
                UserEmail = _email,
                UserAddress = _address,
                UserPhone = _phone,
                UserPassword = _password
            };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(apiservice.baseUrl+"User/userregister", content);
            var content2 = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(content2);
            return response.IsSuccessStatusCode;
        }


        //Function used to login the users
        public async Task<bool> LoginAsync(string _email, string _password)
        {

            var client = new HttpClient(new System.Net.Http.HttpClientHandler());

            var model = new UserLogindto
            {
                UserEmail = _email,
                UserPassword = _password
            };

            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(apiservice.baseUrl +"User/userlogin", content);
            var cont = await response.Content.ReadAsStringAsync();
            if(response.IsSuccessStatusCode == true)
            {
                JObject jwtd = JsonConvert.DeserializeObject<JObject>(cont);
                var token = jwtd.Value<string>("token");
                Debug.WriteLine(token);
                Settings.token = token;
            }
            return response.IsSuccessStatusCode;
        }


        //Function used to get user by ID 
        public async Task<string> getuser(int id)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("https://differentpurpleshed41.conveyor.cloud/api/User/userby/" + id);

            Debug.WriteLine(json);

            return json;
        }
    }
}
