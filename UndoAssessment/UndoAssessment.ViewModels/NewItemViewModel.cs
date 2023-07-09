using System;
using System.Threading.Tasks;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Tools;

namespace UndoAssessment.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
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

        
        public NewItemViewModel()
        {
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

        private async Task OnCancel()
        {
            // This will pop the current page off the navigation stack
            return Shell.Current.GoToAsync("..");
        }

        private async Task OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };
            
            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

