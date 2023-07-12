using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public class MockUsersDataStore : IDataStore<User>
    {
        readonly List<User> users;

        public MockUsersDataStore()
        {
            users = new List<User>()
            {
                new User { Id = Guid.NewGuid().ToString(), Name = "First user", Age = 20 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Second user", Age = 25 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Third user", Age = 30 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Fourth user", Age = 35 },
            };
        }

        public async Task<bool> AddItemAsync(User item)
        {
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            var oldItem = users.Where((User arg) => arg.Id == item.Id).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = users.Where((User arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }
    }
}
