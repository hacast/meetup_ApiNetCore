using Birras.Core.Entities;
using Birras.Core.Interfaces;
using Birras.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birras.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly BirrasContext _context;

        public AttendanceRepository(BirrasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesByUser(int IdUsuario)
        {
            var atts = await _context.Asistencia.Where(x => x.IdUsuario == IdUsuario && x.Aceptada == null && x.Cumplida == null).ToListAsync();

            await Task.Delay(10);
            return atts;
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesByMeet(int IdReunion)
        {
            var atts = await _context.Asistencia.Where(x => x.IdReunion == IdReunion).ToListAsync();

            await Task.Delay(10);
            return atts;
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesAceptedByUser(int IdUsuario)
        {
            var atts = await _context.Asistencia.Where(x => x.IdUsuario == IdUsuario && x.Aceptada == "Aceptada" && (x.Cumplida == null ||
            x.Cumplida == "")).ToListAsync();

            await Task.Delay(10);
            return atts;
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesDeclinedByUser(int IdUsuario)
        {
            var atts = await _context.Asistencia.Where(x => x.IdUsuario == IdUsuario && x.Aceptada == "Declinada" && (x.Cumplida == null ||
            x.Cumplida == "")).ToListAsync();

            await Task.Delay(10);
            return atts;
        }

        public async Task<IEnumerable<Asistencia>> GetAttendancesCheckedByUser(int IdUsuario)
        {
            var atts = await _context.Asistencia.Where(x => x.IdUsuario == IdUsuario && x.Aceptada == "Aceptada" && x.Cumplida == "Si").ToListAsync();

            await Task.Delay(10);
            return atts;
        }

        public async Task<Asistencia> GetAttendanceById(int id)
        {
            var att = await _context.Asistencia.FirstOrDefaultAsync(x => x.IdAsistencia == id);

            await Task.Delay(10);
            return att;
        }

        public async Task InsertAttendance(Asistencia asistencia)
        {
            _context.Asistencia.Add(asistencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAttendance(Asistencia asistencia)
        {
            var currentAtt = await GetAttendanceById(asistencia.IdAsistencia);
            currentAtt.Aceptada = asistencia.Aceptada;
            currentAtt.Cumplida = asistencia.Cumplida;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<int> GetConfirmsByMeet(int IdReunion)
        {
            var atts = await _context.Asistencia.Where(x=>x.IdReunion == IdReunion && x.Aceptada == "Aceptada").ToListAsync();

            await Task.Delay(10);
            return atts.Count;
        }

        public async Task<IEnumerable<Asistencia>> GetAcceptedByMeet(int IdReunion)
        {
            var atts = await _context.Asistencia.Where(x => x.IdReunion == IdReunion && x.Aceptada == "Aceptada").ToListAsync();

            await Task.Delay(10);
            return atts;
        }

    }
}
