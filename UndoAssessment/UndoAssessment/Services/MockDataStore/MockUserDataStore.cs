using System;
using System.Collections.Generic;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public class MockUserDataStore : MockDataStore<User>
    {
        public MockUserDataStore()
        {
            Items = new List<User>()
            {
                new User { Id = Guid.NewGuid().ToString(), Name = "Andrii", Age = 32 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Smitt", Age = 30 },
                new User { Id = Guid.NewGuid().ToString(), Name = "Boris", Age = 55 }
            };
        }
    }
}
