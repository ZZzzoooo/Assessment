using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class UserDataViewModel : BaseViewModel
    {
        private string age;
        public string Age { get => age; set => SetProperty(ref age, value); }

        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        public Command SaveCommand { get; }


        private UserReopsitory repository;

        public UserDataViewModel()
        {
            Title = "User";

            repository = DependencyService.Resolve<UserReopsitory>();

            var user = repository.ReadUser();

            Age = user.Age == -1 ? string.Empty : user.Age.ToString();
            Name = user.Name;

            SaveCommand = new Command(OnSave);
        }

        private void OnSave(object obj)
        {
            int newAge = -1;

            if(int.TryParse(age, out int parsedAge)) 
            {
                newAge = parsedAge;
            }

            repository.WriteUser(new Models.User { Name = Name, Age = newAge });

            Shell.Current.SendBackButtonPressed();
        }
    }
}
