using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using QuotesApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuotesApp.PageModels
{
    public class QuoteDetailPageModel : FreshBasePageModel
    {
        public Quote Quote { get; set; }
        public Command CopyQuoteCommand { get; set; }
        public Command ShareQuoteCommand { get; set; }

        public QuoteDetailPageModel()
        {
            CopyQuoteCommand = new Command(CopyQuote);
            ShareQuoteCommand = new Command(ShareQuote);
        }
        public override void Init(object initData)
        {
            base.Init(initData);
            Quote = (Quote)initData;
        }

        private void CopyQuote()
        {
            Clipboard.SetTextAsync(Quote.Description);
        }

        private void ShareQuote()
        {
            Share.RequestAsync(Quote.Description);
        }
    }
}
