using Birras.Core.Entities;
using Birras.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Core.Services
{
    public class MeetService : IMeetService
    {

        private readonly IMeetRepository _meetRepository;
        private readonly IWeatherService _weatherService;
        private readonly IAttendanceService _attendanceService;
        public MeetService(IMeetRepository meetRepository, IWeatherService weatherService
            , IAttendanceService attendanceService)
        {
            this._meetRepository = meetRepository;
            this._weatherService = weatherService;
            this._attendanceService = attendanceService;
        }

        public async Task<Reunion> GetMeet(int id)
        {
            return await _meetRepository.GetMeet(id);
        }

        public async Task<IEnumerable<Reunion>> GetMeets()
        {
            return  await _meetRepository.GetMeets();
        }

        public async Task<IEnumerable<Reunion>> GetMeetsByCreatorUser(int idUsuarioCreador)
        {
            return await _meetRepository.GetMeetsByCreatorUser(idUsuarioCreador);
        }

        public async Task InsertMeet(Reunion meet)
        {
            meet.Temperatura = _weatherService.GetWeatherByDay(meet.FechaReunion);

            meet = await _meetRepository.InsertMeet(meet);

            await _attendanceService.InsertAttendance(new Asistencia() { Aceptada = "Aceptada", IdReunion = meet.Id, IdUsuario = meet.IdUsuarioCreador });


            //return await _meetRepository.InsertMeet(meet);
        }

        public async Task<bool> UpdateMeet(Reunion meet)
        {
            return await _meetRepository.UpdateMeet(meet);
        }

        public async Task<bool> DeleteMeet(int id)
        {
            return await _meetRepository.DeleteMeet(id);
        }

        public async Task CalculateBeersForAcepted(int idReunion, int accepted)
        {
            var meet = await GetMeet(idReunion);

            decimal cantbeers;

            if (meet.Temperatura >= 20 && meet.Temperatura <= 24)
            {
                cantbeers = accepted * 1;
            }
            else if (meet.Temperatura < 20)
            {
                cantbeers = accepted * decimal.Parse("0,75");
            }
            else 
            {
                cantbeers = accepted * 2;
            }

            cantbeers = setPack(Convert.ToInt32(cantbeers), 6);

            meet.Birras = int.Parse(cantbeers.ToString());

            await UpdateMeet(meet);
        }

        public int setPack(int x, int n)
        {
            do
            {
                if (x % n == 0 && x >= 6)
                    break;
                else
                    x++;
            } while (x % n != 0 || x <= 6);
            return x;
        }

    }
}
