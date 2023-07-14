using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.CommunityToolkit.ObjectModel;

namespace UndoAssessment.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		private Item _selectedItem;
		private readonly IDataStore<Item> _dataStore;

		public ObservableCollection<Item> Items { get; }
		public AsyncCommand LoadItemsCommand { get; }
		public Command AddItemCommand { get; }
		public Command<Item> ItemTapped { get; }

		public ItemsViewModel(IDataStore<Item> dataStore)
		{
			_dataStore = dataStore;
			Title = "Browse";
			Items = new ObservableCollection<Item>();
			LoadItemsCommand = new AsyncCommand(ExecuteLoadItemsCommand);

			ItemTapped = new Command<Item>(OnItemSelected);

			AddItemCommand = new Command(OnAddItem);
		}

		async Task ExecuteLoadItemsCommand()
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

		public void OnAppearing()
		{
			IsBusy = true;
			SelectedItem = null;
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

		private async void OnAddItem(object obj)
		{
			await Shell.Current.GoToAsync(nameof(NewItemPage));
		}

		async void OnItemSelected(Item item)
		{
			if (item == null)
				return;

			// This will push the ItemDetailPage onto the navigation stack
			await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
		}
	}
}