using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesListPage : ContentPage
    {
        public QuotesListPage()
        {
            InitializeComponent();
        }
    }
}