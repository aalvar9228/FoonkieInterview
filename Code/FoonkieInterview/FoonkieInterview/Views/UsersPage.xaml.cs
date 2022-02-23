using FoonkieInterview.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoonkieInterview.Views
{
    public partial class UsersPage : ContentPage
    {
        UsersViewModel _viewModel;

        public UsersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new UsersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}