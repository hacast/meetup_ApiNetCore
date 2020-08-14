using Birras.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario> GetUser(string nombre);
        Task<IEnumerable<Usuario>> GetUsers();

        Task<Usuario> GetUserByCredentials(UserLogin userLogin);
    }
}