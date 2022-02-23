using FoonkieInterview.ViewModels;
using Xamarin.Forms;

namespace FoonkieInterview.Views
{
    public partial class StartupPage : ContentPage
    {
        StartupViewModel _viewModel;

        public StartupPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new StartupViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}