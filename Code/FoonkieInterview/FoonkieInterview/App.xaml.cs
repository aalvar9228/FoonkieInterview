using AutoMapper;
using FoonkieInterview.Common.Contracts.Providers;
using FoonkieInterview.Database.Contracts.Providers;
using FoonkieInterview.Database.Providers;
using FoonkieInterview.Mappers;
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
            #region Mappers

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AppProfile());
            });

            DependencyService.RegisterSingleton(config.CreateMapper());

            #endregion

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
