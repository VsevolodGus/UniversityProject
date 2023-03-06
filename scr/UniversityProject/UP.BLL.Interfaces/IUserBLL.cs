using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UP.Domain;

namespace UP.BLL;
public interface IUserBLL
{
    Task<User> SignInAsync(string login, string password, CancellationToken cancellationToken);
}
