using FreshMvvm;
using QuotesApp.Interfaces;
using QuotesApp.PageModels;
using QuotesApp.Pages;
using QuotesApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IRestService, RestServices>();

            var mainPage = FreshPageModelResolver.ResolvePageModel<CategoryPageModel>();
            var navigationContainer = new FreshNavigationContainer(mainPage);
            MainPage = navigationContainer;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
