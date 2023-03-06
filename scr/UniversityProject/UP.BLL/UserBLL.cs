using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP.Domain;

namespace UP.BLL;
internal class UserBLL : IUserBLL
{
    private readonly List<User> _users = new List<User>
    {
        new User { ID = Guid.NewGuid(), Login="admin@gmail.com", Password="12345"},
        new User { ID = Guid.NewGuid(), Login="qwerty@gmail.com", Password="55555" }
    };


    public async Task<User> SignInAsync(string login, string password, CancellationToken cancellationToken)
    {
        return _users.FirstOrDefault(c => c.Login.Equals(login) && c.Password.Equals(password));
    }
}
