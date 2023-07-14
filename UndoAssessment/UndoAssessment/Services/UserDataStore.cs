using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services;

public class UserDataStore : IDataStore<User>
{
	readonly List<User> _items;

	public UserDataStore()
	{
		_items = new List<User>();
	}

	public async Task<bool> AddItemAsync(User item)
	{
		_items.Add(item);

		return await Task.FromResult(true);
	}

	public Task<bool> UpdateItemAsync(User item)
	{
		throw new System.NotImplementedException();
	}

	public Task<bool> DeleteItemAsync(string id)
	{
		throw new System.NotImplementedException();
	}

	public Task<User> GetItemAsync(string id)
	{
		var item = _items.FirstOrDefault((i) => i.Id == id);
		return Task.FromResult(item);
	}

	public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
	{
		throw new System.NotImplementedException();
	}
}