using System;
using System.Threading.Tasks;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Common.Tools;
using UndoAssessment.Domain.Navigation;
using UndoAssessment.Domain.Navigation.Attributes;
using UndoAssessment.Service.Contract.Storage;

namespace UndoAssessment.ViewModels
{
    [ViewModelRegistration(NavigationTag = NavigationTags.NewItem)]
    public class NewItemViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IDataStore<Item> _dataStore;
        
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public AsyncCommand SaveCommand { get; }
        
        public AsyncCommand CancelCommand { get; }
        
        public NewItemViewModel(INavigationService navigationService, IDataStore<Item> dataStore)
        {
            _navigationService = navigationService;
            _dataStore = dataStore;
            SaveCommand = new AsyncCommand(OnSave, ValidateSave);
            CancelCommand = new AsyncCommand(OnCancel);
            PropertyChanged += 
                (_, __) => SaveCommand.RaiseExecuteChanged(_);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_text)
                && !String.IsNullOrWhiteSpace(_description);
        }

        private Task OnCancel()
        {
            return _navigationService.NavigateBackAsync();
        }

        private async Task OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };
            
            await _dataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await _navigationService.NavigateBackAsync();
        }
    }
}

