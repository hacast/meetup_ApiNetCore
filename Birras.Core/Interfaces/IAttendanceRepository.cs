using Birras.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Core.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Asistencia>> GetAttendancesByUser(int IdUsuario);

        Task<IEnumerable<Asistencia>> GetAttendancesByMeet(int IdReunion);

        Task<IEnumerable<Asistencia>> GetAttendancesAceptedByUser(int IdUsuario);

        Task<IEnumerable<Asistencia>> GetAttendancesDeclinedByUser(int IdUsuario);

        Task<IEnumerable<Asistencia>> GetAttendancesCheckedByUser(int IdUsuario);

        Task<Asistencia> GetAttendanceById(int Id);

        Task InsertAttendance(Asistencia asistencia);

        Task<bool> UpdateAttendance(Asistencia asistencia);

        Task<int> GetConfirmsByMeet(int IdReunion);

        Task<IEnumerable<Asistencia>> GetAcceptedByMeet(int IdReunion);
    }
}
