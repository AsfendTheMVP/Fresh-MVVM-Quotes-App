using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; }
    }
}
