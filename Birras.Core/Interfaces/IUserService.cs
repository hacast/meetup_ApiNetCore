using Birras.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Core.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> GetUser(string nombre);
        Task<IEnumerable<Usuario>> GetUsers();

        Task<IEnumerable<Usuario>> GetUserToInvite(int idReunion);

        Task<Usuario> GetUserByCredentials(UserLogin userLogin);

    }
}
