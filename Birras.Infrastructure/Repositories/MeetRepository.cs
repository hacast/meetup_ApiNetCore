using Birras.Core.Entities;
using Birras.Core.Interfaces;
using Birras.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Birras.Infrastructure.Repositories
{
    public class MeetRepository : IMeetRepository
    {
        private readonly BirrasContext _context;
        public MeetRepository(BirrasContext context)
        {
            this._context = context;
        }
        
        public async Task<IEnumerable<Reunion>> GetMeets()
        {
            var meets = await _context.Reunion.ToListAsync();

            await Task.Delay(10);
            return meets;
        }

        public async Task<IEnumerable<Reunion>> GetMeetsByCreatorUser(int idUsuarioCreador)
        {
            var meets = await _context.Reunion.Where(x => x.IdUsuarioCreador == idUsuarioCreador).ToListAsync();

            await Task.Delay(10);
            return meets;
        }

        public async Task<Reunion> GetMeet(int id)
        {
            var meets = await _context.Reunion.FirstOrDefaultAsync(x => x.Id == id);

            await Task.Delay(10);
            return meets;
        }

        public async Task<Reunion> InsertMeet(Reunion meet)
        {
            var response = _context.Reunion.Add(meet);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<bool> UpdateMeet(Reunion meet)
        {
            var currentReunion = await GetMeet(meet.Id);
            currentReunion.FechaReunion = meet.FechaReunion;
            currentReunion.Temperatura = meet.Temperatura;
            currentReunion.Birras = meet.Birras;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteMeet(int id)
        {
            var currentReunion = await GetMeet(id);
            _context.Reunion.RemoveRange(currentReunion);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }


    }
}
