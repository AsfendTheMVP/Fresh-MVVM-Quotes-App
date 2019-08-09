using QuotesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuotesApp.Interfaces
{
    public interface IRestService
    {
        Task<List<Category>> GetCategories();
        Task<List<Quote>> GetQuotes(string category);
        Task<bool> PostQuote(Quote quote);
    }
}
