using FoonkieInterview.Common.Contracts.Providers;
using FoonkieInterview.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoonkieInterview.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        private readonly IEmailProvider _emailProvider;

        public ICommand GetInTouchCommand { get; }
        public ICommand ShowUsersCommand { get; }

        public StartupViewModel()
        {
            Title = "Sup man!";

            _emailProvider = DependencyService.Get<IEmailProvider>();

            GetInTouchCommand = new Command(async () => await PerformGetInTouch());
            ShowUsersCommand = new Command(async () => await Shell.Current.GoToAsync($"{nameof(UsersPage)}"));
        }

        private async Task PerformGetInTouch()
        {
            var subject = "I want a quote";
            var body = "I need you to build an application";

            await _emailProvider.SendEmail(subject, body);
        }
    }
}
