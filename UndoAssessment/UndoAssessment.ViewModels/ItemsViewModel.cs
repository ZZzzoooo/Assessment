using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Common.Tools;
using UndoAssessment.Domain;
using UndoAssessment.Domain.Navigation.Attributes;
using UndoAssessment.Service.Contract.Storage;

namespace UndoAssessment.ViewModels
{
    [ViewModelRegistration(NavigationTag = NavigationTags.ItemsPage)]
    public class ItemsViewModel : BaseViewModel, INavigated
    {
        private readonly INavigationService _navigationService;
        private readonly IDataStore<Item> _dataStore;
        
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public ICommand LoadItemsCommand { get; }
        public ICommand AddItemCommand { get;  }
        public AsyncCommand<Item> ItemTapped { get; }

        public ItemsViewModel(
            IDataStore<Item> dataStore,
            INavigationService navigationService)
        {
            _navigationService = navigationService;
            _dataStore = dataStore;
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new AsyncCommand(ExecuteLoadItemsCommand);
            ItemTapped = new AsyncCommand<Item>(OnItemSelected);
            AddItemCommand = new AsyncCommand(OnAddItem);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _dataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Task NavigatedAsync(NavigationData data)
        {
            IsBusy = true;
            SelectedItem = null;
            return Task.CompletedTask;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private Task OnAddItem(object obj)
        {
            return _navigationService.NavigateAsync(NavigationTags.NewItem);
        }

        private Task OnItemSelected(Item item)
        {
            if (item == null)
                return Task.CompletedTask;

            return _navigationService.NavigateAsync(NavigationTags.ItemDetails,
                new KeyValuePair<string, object>("ItemId", item.Id));
        }
    }
}
