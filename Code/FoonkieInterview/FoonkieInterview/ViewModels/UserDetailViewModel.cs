using FoonkieInterview.Database.Contracts.Providers;
using FoonkieInterview.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace FoonkieInterview.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class UserDetailViewModel : BaseViewModel
    {
        private readonly IUserProvider _userProvider;

        private User _user;
        private int _itemId;

        public UserDetailViewModel()
        {
            _userProvider = DependencyService.Get<IUserProvider>();
        }

        public User User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await _userProvider.GetItemAsync(itemId);
                User = Mapper.Map<User>(item);
                Title = $"User: {User.FullName}";
            }
            catch (Exception)
            {
                Debug.WriteLine($"Failed to Load USer with Id: {itemId}");
            }
        }
    }
}
