using FoonkieInterview.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FoonkieInterview.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}