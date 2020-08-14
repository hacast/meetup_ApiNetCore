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
    public class MeetController : ControllerBase
    {

        private readonly IMeetService _meetService;
        private readonly IMapper _mapper;
        
        public MeetController(IMeetService meetService, IMapper mapper)
        {
            this._meetService = meetService;
            this._mapper = mapper;
            
        }

        /// <summary>
        /// Obtiene todas las reuniones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMeets()
        {
            var meets = await _meetService.GetMeets();
            var meetsDTO = _mapper.Map<IEnumerable<MeetDTO>>(meets);
            var apiResponse = new ApiResponse<IEnumerable<MeetDTO>>(meetsDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Obtienes las reuniones por Usuario Creador
        /// </summary>
        /// <param name="idUsuarioCreador"></param>
        /// <returns></returns>
        [HttpGet("bycreator/{idUsuarioCreador}")]
        public async Task<IActionResult> GetMeetsByCreator(int idUsuarioCreador)
        {
            // comment test from
            var meets = await _meetService.GetMeetsByCreatorUser(idUsuarioCreador);
            var meetsDTO = _mapper.Map<IEnumerable<MeetDTO>>(meets);
            var apiResponse = new ApiResponse<IEnumerable<MeetDTO>>(meetsDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Obtiene la reunion por Id Reunion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeet(int id)
        {
            var meet = await _meetService.GetMeet(id);
            var meetDTO = _mapper.Map<MeetDTO>(meet);
            var apiResponse = new ApiResponse<MeetDTO>(meetDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Crear una nueva reunion
        /// </summary>
        /// <param name="meetDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMeet(MeetDTO meetDTO)
        {
            var meet = _mapper.Map<Reunion>(meetDTO);
            await _meetService.InsertMeet(meet);
            meetDTO = _mapper.Map<MeetDTO>(meet);
            var apiResponse = new ApiResponse<MeetDTO>(meetDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Actualiza una reunion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="meetDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, MeetDTO meetDTO)
        {
            var meet = _mapper.Map<Reunion>(meetDTO);
            meet.Id = id;
            await _meetService.UpdateMeet(meet);
            meetDTO = _mapper.Map<MeetDTO>(meet);
            var apiResponse = new ApiResponse<MeetDTO>(meetDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Borra una reunion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _meetService.DeleteMeet(id);
            var apiResponse = new ApiResponse<bool>(result);
            return Ok(apiResponse);
        }
    }
}
