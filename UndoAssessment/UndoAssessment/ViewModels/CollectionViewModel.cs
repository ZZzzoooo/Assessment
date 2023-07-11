using UndoAssessment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UndoAssessment.ViewModels
{
    public abstract class CollectionViewModel<T> : BaseViewModel
        where T : IEntity
    {
        public ObservableCollection<T> Items { get; }

        public Command AddItemCommand { get; }
        public Command LoadItemsCommand { get; }
        public Command<T> ItemTapped { get; }

        protected abstract Task<IEnumerable<T>> LoadDataStore();
        protected abstract void OnAddItem(object obj);
        protected abstract void OnItemSelected(T item);

        public CollectionViewModel()
        {
            Items = new ObservableCollection<T>();
            AddItemCommand = new Command(OnAddItem);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ItemTapped = new Command<T>(OnItemSelected);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var items = await LoadDataStore();

                items.ForEach(x => Items.Add(x));
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

        private IEntity _selectedItem;
        public IEntity SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected((T)value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
    }
}
