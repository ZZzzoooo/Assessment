using System;
using System.Threading.Tasks;

namespace UndoAssessment.Services.Servers
{
	public interface IServer
	{
		Task GetSuccessAsync();
		Task GetFailureAsync();
	}
}

