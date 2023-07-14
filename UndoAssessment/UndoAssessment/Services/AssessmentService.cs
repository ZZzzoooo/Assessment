using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UndoAssessment.Configuration;
using UndoAssessment.Contracts;

namespace UndoAssessment.Services;

public class AssessmentService
{
	private readonly HttpClient _httpClient;
	private readonly ILogger<AssessmentService> _logger;
	private readonly AssessmentConfiguration _assessmentConfiguration;

	private const string DATE_TIME_FORMAT = "dd.MM.yyyy HH:mm:ss";

	public AssessmentService(HttpClient httpClient, IOptions<AssessmentConfiguration> assessmentConfiguration,
		ILogger<AssessmentService> logger)
	{
		_httpClient = httpClient;
		_logger = logger;
		_assessmentConfiguration = assessmentConfiguration.Value;

		_httpClient.BaseAddress = new Uri(_assessmentConfiguration.BaseAddress);
	}

	public async Task<SuccessResponse> GetSuccessResponseAsync()
	{
		try
		{
			var json = await _httpClient.GetStringAsync(_assessmentConfiguration.Success);
			var response = JsonConvert.DeserializeObject<SuccessResponse>(json,
				new IsoDateTimeConverter { DateTimeFormat = DATE_TIME_FORMAT });
			return response;
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Failed with message: {Message}", exception.Message);
		}

		return null;
	}

	public async Task<FailResponse> GetFailResponseAsync()
	{
		try
		{
			var httpResponse = await _httpClient.GetAsync(_assessmentConfiguration.Fail);
			var json = await httpResponse.Content.ReadAsStringAsync();
			var response = JsonConvert.DeserializeObject<FailResponse>(json,
				new IsoDateTimeConverter { DateTimeFormat = DATE_TIME_FORMAT });
			return response;
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Failed with message: {Message}", exception.Message);
		}

		return null;
	}
}