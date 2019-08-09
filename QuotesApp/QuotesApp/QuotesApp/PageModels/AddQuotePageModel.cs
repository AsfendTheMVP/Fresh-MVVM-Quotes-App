using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FreshMvvm;
using QuotesApp.Interfaces;
using QuotesApp.Models;
using Xamarin.Forms;

namespace QuotesApp.PageModels
{
    public class AddQuotePageModel : FreshBasePageModel
    {
        private IRestService _restService;
        public Command SaveCommand { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public AddQuotePageModel(IRestService restService)
        {
            _restService = restService;
            SaveCommand = new Command(SaveQuote);
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            Categories = (ObservableCollection<Category>)initData;
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private Category salectedCategory;
        public Category SelectedCategory
        {
            get { return salectedCategory; }
            set { salectedCategory = value; }
        }


        private async void SaveQuote()
        {
            var quote = new Quote()
            {
                Title = Title,
                Author = Author,
                Description = Description,
                CreatedAt = DateTime.Now,
                Category = SelectedCategory.Title
            };

            var result = await _restService.PostQuote(quote);
            if (result)
            {
                await CoreMethods.DisplayAlert("Hi", "Your record has been added successfully...", "Alright");
            }
            else
            {
                await CoreMethods.DisplayAlert("Oops", "Something went wrong", "Alright");
            }
        }
    }
}
