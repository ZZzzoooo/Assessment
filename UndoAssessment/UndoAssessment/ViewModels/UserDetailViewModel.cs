using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class UserDetailViewModel : BaseViewModel
    {
        private string _userId;
        private string _name;
        private uint _age;
        public string Id { get; set; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public uint Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public string UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                LoadUserId(value);
            }
        }

        public async void LoadUserId(string itemId)
        {
            try
            {
                var item = await UserDataStore.GetItemAsync(itemId);

                Id = item.Id;
                Name = item.Name;
                Age = item.Age;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load User");
            }
        }
    }
}
