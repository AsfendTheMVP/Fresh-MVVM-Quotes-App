using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FreshMvvm;
using QuotesApp.Interfaces;
using QuotesApp.Models;

namespace QuotesApp.PageModels
{
    public class QuotesListPageModel : FreshBasePageModel
    {
        public Category Category;
        public ObservableCollection<Quote> Quotes { get; set; }
        private IRestService _restService;

        public QuotesListPageModel(IRestService restService)
        {
            _restService = restService;
            Quotes = new ObservableCollection<Quote>();
        }

        private bool isBusy = true;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

        public override async void Init(object initData)
        {
            base.Init(initData);
            Category = (Category)initData;
            var quotes = await _restService.GetQuotes(Category.Title);
            foreach (var quote in quotes)
            {
                Quotes.Add(quote);
            }
            IsBusy = false;
        }

        private Quote selectedQuote;

        public Quote SelectedQuote
        {
            get { return null; }
            set
            {
                selectedQuote = value;
                if (selectedQuote != null)
                {
                    CoreMethods.PushPageModel<QuoteDetailPageModel>(selectedQuote);
                    RaisePropertyChanged();
                }
            }
        }

    }
}
