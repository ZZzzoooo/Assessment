using System.Collections.Generic;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class ItemsViewModel : CollectionViewModel<Item>
    {
        public ItemsViewModel()
        {
            Title = "Browse";
        }

        protected override async Task<IEnumerable<Item>> LoadDataStore()
        {
            return await ItemsDataStore.GetItemsAsync(true);
        }

        protected override async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        protected override async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
