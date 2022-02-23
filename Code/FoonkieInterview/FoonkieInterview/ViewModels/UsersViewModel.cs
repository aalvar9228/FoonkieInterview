using FoonkieInterview.Database.Contracts.Providers;
using FoonkieInterview.Database.Entities;
using FoonkieInterview.Models;
using FoonkieInterview.Repository.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoonkieInterview.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private User _userItem;
        private bool _canExecuteRefresh;
        private int _currentPage = 0;
        private int? _totalPages = null;
        private bool _showLoadMoreButton;

        private readonly IUserRepository _userRepository;
        private readonly IUserProvider _userProvider;

        public ObservableCollection<User> Users { get; }
        public Command RefreshUserListCommand { get; }
        public Command LoadMoreCommand { get; }
        public Command AddUserCommand { get; }
        public Command<User> UserTapped { get; }

        public UsersViewModel()
        {
            _userRepository = DependencyService.Get<IUserRepository>();
            _userProvider = DependencyService.Get<IUserProvider>();

            Title = "Lista de usuarios";

            Users = new ObservableCollection<User>();

            RefreshUserListCommand = new Command(async () => await LoadStoredUsers(), CanExecuteRefreshUserList());
            LoadMoreCommand = new Command(async () => await LoadMoreUsers());
            UserTapped = new Command<User>(OnItemSelected);
            AddUserCommand = new Command(OnAddItem);
        }

        private Func<bool> CanExecuteRefreshUserList()
        {
            return new Func<bool>(() => _canExecuteRefresh);
        }

        protected override void IsBusyChanged()
        {
            base.IsBusyChanged();

            RefreshUserListCommand?.ChangeCanExecute();
            UserTapped?.ChangeCanExecute();
            AddUserCommand?.ChangeCanExecute();
        }

        public async Task LoadMoreUsers()
        {
            _canExecuteRefresh = false;
            IsBusy = true;

            try
            {
                if (!_totalPages.HasValue || _totalPages > _currentPage)
                {
                    var userResponse = await _userRepository.GetUserListAsync(++_currentPage);
                    if (userResponse.Success)
                    {
                        await _userProvider.SaveItemCollectionAsync(Mapper.Map<List<UserEntity>>(userResponse.Data.Data));
                        _totalPages = userResponse.Data.TotalPages;
                    }
                }

                await LoadStoredUsers();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _canExecuteRefresh = true;
                IsBusy = false;
            }
        }

        private async Task LoadStoredUsers()
        {
            _canExecuteRefresh = false;
            IsBusy = true;

            try
            {
                Users.Clear();
                var userResponse = await _userProvider.GetItemsAsync();
                if (userResponse?.Any() ?? false)
                {
                    foreach(var user in userResponse)
                    {
                        Users.Add(Mapper.Map<User>(user));
                    }
                }

                ShowLoadMoreButton = !(_totalPages.HasValue && _totalPages == _currentPage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _canExecuteRefresh = true;
                IsBusy = false;
            }
        }
        public async void OnAppearing()
        {
            IsBusy = true;
            SelectedUser = null;

            await LoadStoredUsers();
        }

        public User SelectedUser
        {
            get => _userItem;
            set
            {
                SetProperty(ref _userItem, value);
                OnItemSelected(value);
            }
        }

        public bool ShowLoadMoreButton
        {
            get => _showLoadMoreButton;
            set
            {
                SetProperty(ref _showLoadMoreButton, value);
            }
        }

        private async void OnAddItem(object obj)
        {
            _canExecuteRefresh = false;
            IsBusy = true;
            
            try
            {
                await _userProvider.SaveItemCollectionAsync(Mapper.Map<List<UserEntity>>(Users.ToList()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _canExecuteRefresh = true;
                IsBusy = false;
            }
        }

        private async void OnItemSelected(User item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
