using AutoMapper;
using Birras.Core.DTOs;
using Birras.Core.Entities;

namespace Birras.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Reunion, MeetDTO>();
            CreateMap<MeetDTO, Reunion>();
            CreateMap<Usuario, UserDTO>();
            CreateMap<UserDTO, Usuario>();
            CreateMap<Asistencia, AttendanceDTO>();
            CreateMap<AttendanceDTO, Asistencia>();
        }
    }
}
