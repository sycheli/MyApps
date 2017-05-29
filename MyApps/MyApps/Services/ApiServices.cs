using MyApps.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyApps.Services
{
    public class ApiServices
    {
        public async Task RegisterUserAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            };
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://10.0.3.2:51868/api/Account/Register", content);

        }
        public async Task LoginUserAsync(string email, string password)
        {
            var client = new HttpClient();
            var KeyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",email),
                new KeyValuePair<string, string>("passowrd",password),
                new KeyValuePair<string, string>("grant_type","password")
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://10.0.3.2:51868/Token");
            request.Content = new FormUrlEncodedContent(KeyValues);
            var response = await client.SendAsync(request);
        }
    }
}
