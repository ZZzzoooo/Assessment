using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain;
using UndoAssessment.Domain.Navigation.Attributes;
using UndoAssessment.Service.Contract.Storage;

namespace UndoAssessment.ViewModels
{
    [ViewModelRegistration(NavigationTag = NavigationTags.ItemDetails)]
    public class ItemDetailViewModel : BaseViewModel, INavigated
    {
        public IDataStore<Item> DataStore { get; }
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId { get; set; }

        public ItemDetailViewModel(IDataStore<Item> dataStore)
        {
            DataStore = dataStore;
        }

        public async Task NavigatedAsync(NavigationData data)
        {
            try
            {
                var itemId = (string)data.Parameters["ItemId"];
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}

