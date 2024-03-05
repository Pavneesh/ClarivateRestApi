using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarivateRestApi.Models
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
    public class UserService : IUserService
    {

        private List<User> _users = new List<User>
        {
        new User { Username = "Test", Password = "1234" }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users);
        }
    }
}

