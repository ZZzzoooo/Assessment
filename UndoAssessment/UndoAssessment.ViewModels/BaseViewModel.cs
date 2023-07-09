using UndoAssessment.Common.Models;
using UndoAssessment.Domain;
using UndoAssessment.Service.Contract.Storage;

namespace UndoAssessment.ViewModels
{
    public class BaseViewModel : ViewModelAbstract
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

