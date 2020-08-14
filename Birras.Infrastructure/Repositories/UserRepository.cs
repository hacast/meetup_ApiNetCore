using Birras.Core.Entities;
using Birras.Core.Interfaces;
using Birras.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly BirrasContext _context;
        public UserRepository(BirrasContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
            var users = await _context.Usuario.ToListAsync();

            await Task.Delay(10);
            return users;
        }

        public async Task<Usuario> GetUser(string nombre)
        {
            var user = await _context.Usuario.FirstOrDefaultAsync(x => x.Nombre == nombre);

            await Task.Delay(10);
            return user;
        }

        public async Task<Usuario> GetUserByCredentials(UserLogin userLogin)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.Nombre == userLogin.User && x.Password == userLogin.Password);
        }
    }
}
