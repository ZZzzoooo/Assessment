using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UndoAssessment.Models;
using Xamarin.Essentials;

namespace UndoAssessment.Services
{
    public class UserReopsitory
    {
        private const string UserKey = nameof(UserKey);
        public User ReadUser()
        {
            var data = Preferences.Get(UserKey, string.Empty);

            if(string.IsNullOrEmpty(data))
            {
                return new User { Name = string.Empty, Age = -1 };
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<User>(data);
        }

        public void WriteUser(User user)
        {
            if(user == null)
            {
                Preferences.Remove(UserKey);
            }

            Preferences.Set(UserKey, Newtonsoft.Json.JsonConvert.SerializeObject(user));
        }
    }
}
