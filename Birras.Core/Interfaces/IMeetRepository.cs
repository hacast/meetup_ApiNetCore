using Birras.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Core.Interfaces
{
    public interface IMeetRepository
    {
        Task<IEnumerable<Reunion>> GetMeets();

        Task<Reunion> GetMeet(int id);

        Task<Reunion> InsertMeet(Reunion meet);

        Task<bool> UpdateMeet(Reunion meet);

        Task<bool> DeleteMeet(int id);

        Task<IEnumerable<Reunion>> GetMeetsByCreatorUser(int idUsuarioCreador);

    }
}
