using Birras.Core.Entities;
using Birras.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Core.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;
        //private readonly IMeetService _meetService;
        public AttendanceService(IAttendanceRepository repository)//, IMeetService meetService)
        {
            this._repository = repository;
            //this._meetService = meetService;
        }
        
        public async Task<Asistencia> GetAttendanceById(int id)
        {
            return await _repository.GetAttendanceById(id);
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesByUser(int IdUsuario)
        {
            return await _repository.GetAttendancesByUser(IdUsuario);
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesAceptedByUser(int IdUsuario)
        {
            return await _repository.GetAttendancesAceptedByUser(IdUsuario);
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesDeclinedByUser(int IdUsuario)
        {
            return await _repository.GetAttendancesDeclinedByUser(IdUsuario);
        }
        public async Task<IEnumerable<Asistencia>> GetAttendancesCheckedByUser(int IdUsuario)
        {
            return await _repository.GetAttendancesCheckedByUser(IdUsuario);
        }

        public async Task InsertAttendance(Asistencia asistencia)
        {
            await _repository.InsertAttendance(asistencia);
        }

        public async Task<bool> UpdateAttendance(Asistencia asistencia)
        {
            var result = await _repository.UpdateAttendance(asistencia);

            //var accepted = await _repository.GetConfirmsByAttendance(asistencia.IdAsistencia);

            //await _meetService.CalculateBeersForAcepted(asistencia.IdReunion, accepted);

            return result;
        }

        public async Task<int> GetConfirmsByMeet(int IdReunion)
        {
            return await _repository.GetConfirmsByMeet(IdReunion);
        }

        public async Task<IEnumerable<Asistencia>> GetAcceptedByMeet(int IdReunion)
        {
            return await _repository.GetAcceptedByMeet(IdReunion);
        }
    }
}
