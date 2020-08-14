using AutoMapper;
using Birras.Api.Responses;
using Birras.Core.DTOs;
using Birras.Core.Entities;
using Birras.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birras.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceService _attendanceService;
        private readonly IUserService _userService;
        private readonly IMeetService _meetService;
        public AttendanceController(IMapper mapper, IAttendanceService attendanceService, IUserService userService,
            IMeetService meetService)
        {
            this._mapper = mapper;
            this._attendanceService = attendanceService;
            this._userService = userService;
            this._meetService = meetService;
        }

        /// <summary>
        /// Obtiene las invitaciones por usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceByUser(int id)
        {
            var att = await _attendanceService.GetAttendancesByUser(id);
            var attDTO = _mapper.Map<IEnumerable<AttendanceDTO>>(att);
            var users = await _userService.GetUsers();
            var meets = await _meetService.GetMeets();

            foreach (var item1 in attDTO)
            {
                foreach (var item2 in meets)
                {
                    if (item1.IdReunion == item2.Id)
                    {
                        item1.IdUsuarioCreador = item2.IdUsuarioCreador;
                        item1.FechaReunion = item2.FechaReunion;
                        item1.Temperatura = item2.Temperatura;
                        foreach (var item3 in users)
                        {
                            if (item1.IdUsuarioCreador == item3.IdUsuario)
                            {
                                item1.DescripcionUsuarioCreador = item3.Nombre;
                            }
                        }
                    }
                }
            }

            var apiResponse = new ApiResponse<IEnumerable<AttendanceDTO>>(attDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Obtiene las invitaciones aceptadas por usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("acepted/{id}")]
        public async Task<IActionResult> GetAttendancesAcepted(int id)
        {
            var att = await _attendanceService.GetAttendancesAceptedByUser(id);
            var attDTO = _mapper.Map<IEnumerable<AttendanceDTO>>(att);
            var users = await _userService.GetUsers();
            var meets = await _meetService.GetMeets();

            foreach (var item1 in attDTO)
            {
                foreach (var item2 in meets)
                {
                    if (item1.IdReunion == item2.Id)
                    {
                        item1.IdUsuarioCreador = item2.IdUsuarioCreador;
                        item1.FechaReunion = item2.FechaReunion;
                        item1.Temperatura = item2.Temperatura;
                        foreach (var item3 in users)
                        {
                            if (item1.IdUsuarioCreador == item3.IdUsuario)
                            {
                                item1.DescripcionUsuarioCreador = item3.Nombre;
                            }
                        }
                    }
                }
            }

            var apiResponse = new ApiResponse<IEnumerable<AttendanceDTO>>(attDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Obtiene las invitaciones declinadas por usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("declined/{id}")]
        public async Task<IActionResult> GetAttendancesDeclined(int id)
        {
            var att = await _attendanceService.GetAttendancesDeclinedByUser(id);
            var attDTO = _mapper.Map<IEnumerable<AttendanceDTO>>(att);
            var users = await _userService.GetUsers();
            var meets = await _meetService.GetMeets();

            foreach (var item1 in attDTO)
            {
                foreach (var item2 in meets)
                {
                    if (item1.IdReunion == item2.Id)
                    {
                        item1.IdUsuarioCreador = item2.IdUsuarioCreador;
                        item1.FechaReunion = item2.FechaReunion;
                        item1.Temperatura = item2.Temperatura;
                        foreach (var item3 in users)
                        {
                            if (item1.IdUsuarioCreador == item3.IdUsuario)
                            {
                                item1.DescripcionUsuarioCreador = item3.Nombre;
                            }
                        }
                    }
                }
            }

            var apiResponse = new ApiResponse<IEnumerable<AttendanceDTO>>(attDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Obtiene las invitaciones con CheckIn por usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("checkouts/{id}")]
        public async Task<IActionResult> GetAttendancesChecked(int id)
        {
            var att = await _attendanceService.GetAttendancesCheckedByUser(id);
            var attDTO = _mapper.Map<IEnumerable<AttendanceDTO>>(att);
            var users = await _userService.GetUsers();
            var meets = await _meetService.GetMeets();

            foreach (var item1 in attDTO)
            {
                foreach (var item2 in meets)
                {
                    if (item1.IdReunion == item2.Id)
                    {
                        item1.IdUsuarioCreador = item2.IdUsuarioCreador;
                        item1.FechaReunion = item2.FechaReunion;
                        item1.Temperatura = item2.Temperatura;
                        foreach (var item3 in users)
                        {
                            if (item1.IdUsuarioCreador == item3.IdUsuario)
                            {
                                item1.DescripcionUsuarioCreador = item3.Nombre;
                            }
                        }
                    }
                }
            }

            var apiResponse = new ApiResponse<IEnumerable<AttendanceDTO>>(attDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Crear una invitacion para un usuario
        /// </summary>
        /// <param name="attDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAttendance(AttendanceDTO attDTO)
        {
            var att = _mapper.Map<Asistencia>(attDTO);
            await _attendanceService.InsertAttendance(att);
            attDTO = _mapper.Map<AttendanceDTO>(att);
            var apiResponse = new ApiResponse<AttendanceDTO>(attDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Actualiza una invitacion por usuario
        /// </summary>
        /// <param name="attDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(AttendanceDTO attDTO)
        {
            var att = _mapper.Map<Asistencia>(attDTO);
            await _attendanceService.UpdateAttendance(att);
            var cantaccepted = await _attendanceService.GetConfirmsByMeet(att.IdReunion);
            await _meetService.CalculateBeersForAcepted(att.IdReunion, cantaccepted);
            attDTO = _mapper.Map<AttendanceDTO>(att);
            var apiResponse = new ApiResponse<AttendanceDTO>(attDTO);
            return Ok(apiResponse);
        }


        /// <summary>
        /// Obtiene las invitaciones aceptadas por Reunion
        /// </summary>
        /// <param name="idReunion"></param>
        /// <returns></returns>
        [HttpGet("acepted/bymeet/{idReunion}")]
        public async Task<IActionResult> GetAttendancesAceptedByMeet(int idReunion)
        {
            var att = await _attendanceService.GetAcceptedByMeet(idReunion);
            var attDTO = _mapper.Map<IEnumerable<AttendanceDTO>>(att);
            var users = await _userService.GetUsers();

            foreach (var item1 in attDTO)
            {

                foreach (var item2 in users)
                {
                    if (item1.IdUsuario == item2.IdUsuario)
                        item1.DescripcionIdUsuario = item2.Nombre;
                }
            }

            var apiResponse = new ApiResponse<IEnumerable<AttendanceDTO>>(attDTO);
            return Ok(apiResponse);
        }

    }
}
