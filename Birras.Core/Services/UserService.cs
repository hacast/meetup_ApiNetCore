using Birras.Core.Entities;
using Birras.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Birras.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMeetRepository _meetRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        public UserService(IUserRepository userRepository, IMeetRepository meetRepository,
            IAttendanceRepository attendanceRepository)
        {
            this._userRepository = userRepository;
            this._meetRepository = meetRepository;
            this._attendanceRepository = attendanceRepository;
        }

        public async Task<Usuario> GetUser(string nombre)
        {
            return await _userRepository.GetUser(nombre);
        }

        public async Task<Usuario> GetUserByCredentials(UserLogin userLogin)
        {
            return await _userRepository.GetUserByCredentials(userLogin);
        }

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<IEnumerable<Usuario>> GetUserToInvite(int idReunion)
        {
            var attendances = await _attendanceRepository.GetAttendancesByMeet(idReunion);

            var users = await _userRepository.GetUsers();

            var userToInvite = new List<Usuario>();

            foreach (var item1 in users)
            {
                if (attendances.Count(x => x.IdUsuario.Equals(item1.IdUsuario)) == 0)
                    userToInvite.Add(item1);

            }

            return userToInvite;
        }
    }
}
