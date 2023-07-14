using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UndoAssessment.Contracts;
using UndoAssessment.Models;
using UndoAssessment.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels;

public class CreateUserViewModel : BaseViewModel
{
	private readonly IDataStore<User> _userDataStore;
	private readonly ILogger<CreateUserViewModel> _logger;
	private string _name;
	private string _age;
	
	public bool IsValid => !string.IsNullOrWhiteSpace(_name)
	                        && !string.IsNullOrWhiteSpace(_age)
	                        && int.TryParse(_age, out var age)
	                        && age > 0;

	public AsyncCommand CreateUserCommand { get; }
	public AsyncCommand CancelCommand { get; }

	public string Name
	{
		get => _name;
		set => SetProperty(ref _name, value);
	}

	public string Age
	{
		get => _age;
		set => SetProperty(ref _age, value);
	}

	public CreateUserViewModel(IDataStore<User> userDataStore, ILogger<CreateUserViewModel> logger)
	{
		_userDataStore = userDataStore;
		_logger = logger;
		CreateUserCommand = new AsyncCommand(CreateUser);
		CancelCommand = new AsyncCommand(GoBackAsync);
	}

	public async Task CreateUser()
	{
		if (!IsValid)
		{
			await Shell.Current.DisplayAlert("Status", "Validation Failed", "Ok");
			return;
		}

		var user = new User
		{
			Id = Guid.NewGuid().ToString(),
			Name = _name,
			Age = int.Parse(_age)
		};

		await _userDataStore.AddItemAsync(user);
		
		_logger.LogInformation("User {Id} was created", user.Id);

		MessagingCenter.Send<CreateUserViewModel, string>(this, Messaging.ID_CHANGED_MESSAGE, user.Id);

		await GoBackAsync();
	}
}