using FoonkieInterview.Common.Contracts.Providers;
using FoonkieInterview.Database.Contracts.Providers;
using FoonkieInterview.Database.Providers;
using FoonkieInterview.Providers;
using FoonkieInterview.Repository.Contracts.Repositories;
using FoonkieInterview.Repository.Repositories;
using FoonkieInterview.Services;
using Xamarin.Forms;

namespace FoonkieInterview
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetDependencies();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void SetDependencies()
        {
            DependencyService.Register<MockDataStore>();

            #region Repositories

            DependencyService.Register<IUserRepository, UserRepository>();

            #endregion

            #region Providers

            DependencyService.Register<IUserProvider, UserProvider>();
            DependencyService.Register<IEmailProvider, EmailProvider>();

            #endregion
        }
    }
}
