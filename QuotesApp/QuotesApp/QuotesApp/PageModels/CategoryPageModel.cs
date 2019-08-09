using FreshMvvm;
using QuotesApp.Interfaces;
using QuotesApp.Models;
using QuotesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace QuotesApp.PageModels
{
    public class CategoryPageModel : FreshBasePageModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        private IRestService _restService;
        public Command AddQuoteCommand { get; set; }    
        public CategoryPageModel(IRestService restService)
        {
            _restService = restService;
            Categories = new ObservableCollection<Category>();
            LoadCategories();
            AddQuoteCommand = new Command(AddQuote);
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


        private void AddQuote()
        {
            CoreMethods.PushPageModel<AddQuotePageModel>(Categories);
        }

        private async void LoadCategories()
        {
            var categories = await _restService.GetCategories();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
            IsBusy = false;
        }

        private Category selectedCategory;

        public Category SelectedCategory
        {
            get { return null; }
            set
            {
                selectedCategory = value;
                if (selectedCategory != null)
                {
                    CoreMethods.PushPageModel<QuotesListPageModel>(selectedCategory);
                    RaisePropertyChanged();
                }
            }
        }

    }
}
