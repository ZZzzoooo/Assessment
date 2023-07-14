using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UndoAssessment.Contracts;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels;

public class AssessmentViewModel : BaseViewModel
{
	private readonly AssessmentService _service;
	private readonly IDataStore<User> _userDataStore;
	private readonly ILogger<AssessmentViewModel> _logger;
	private string _createdProfileId = "";

	bool _isUserPanelVisible = false;

	public bool IsUserPanelVisible
	{
		get => _isUserPanelVisible;
		set => SetProperty(ref _isUserPanelVisible, value);
	}

	private string _name;
	private string _age;

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

	public AsyncCommand SuccessCommand { get; }
	public AsyncCommand FailCommand { get; }

	public AsyncCommand NavigateToCreateUserPageCommand { get; }

	public AssessmentViewModel(AssessmentService assessmentService, IDataStore<User> userDataStore,
		ILogger<AssessmentViewModel> logger)
	{
		_service = assessmentService;
		_userDataStore = userDataStore;
		_logger = logger;
		SuccessCommand = new AsyncCommand(OnSuccessCommand);
		FailCommand = new AsyncCommand(OnFailCommand);
		NavigateToCreateUserPageCommand = new AsyncCommand(OnNavigateToCreateUserPageCommand);

		MessagingCenter.Subscribe<CreateUserViewModel, string>(this, Messaging.ID_CHANGED_MESSAGE,
			(model, s) => { _createdProfileId = s; });
	}

	public async Task LoadUser()
	{
		var user = await _userDataStore.GetItemAsync(_createdProfileId);

		if (user is null)
		{
			IsUserPanelVisible = false;
			return;
		}

		Name = user.Name;
		Age = user.Age.ToString();

		IsUserPanelVisible = true;
	}

	private async Task OnSuccessCommand()
	{
		try
		{
			var result = await _service.GetSuccessResponseAsync();
			await Shell.Current.DisplayAlert("Success", result.Message, "Ok");
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}

	private async Task OnFailCommand()
	{
		var result = await _service.GetFailResponseAsync();
		await Shell.Current.DisplayAlert("Failure", result.Message, "Ok");
	}

	private async Task OnNavigateToCreateUserPageCommand()
	{
		_logger.LogInformation("Navigating to {Page}", nameof(CreateUserPage));
		await Shell.Current.GoToAsync(nameof(CreateUserPage));
	}
}