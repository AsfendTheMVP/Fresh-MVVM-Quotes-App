using Newtonsoft.Json;
using QuotesApp.Interfaces;
using QuotesApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuotesApp.Services
{
    public class RestServices : IRestService
    {
        public async Task<List<Category>> GetCategories()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://brainyquote.azurewebsites.net/api/Categories");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        public async Task<List<Quote>> GetQuotes(string category)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://brainyquote.azurewebsites.net/api/Quotes?category=" + category);
            return JsonConvert.DeserializeObject<List<Quote>>(response);
        }

        public async Task<bool> PostQuote(Quote quote)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(quote);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://brainyquote.azurewebsites.net/api/Quotes", content);
            return response.IsSuccessStatusCode;
        }
    }
}
