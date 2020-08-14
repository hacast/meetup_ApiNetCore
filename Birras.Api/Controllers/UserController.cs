using AutoMapper;
using Birras.Api.Responses;
using Birras.Core.DTOs;
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
    public class UserController : ControllerBase
    {


        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            var apiResponse = new ApiResponse<IEnumerable<UserDTO>>(usersDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Obtiene el usuario por Nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        [HttpGet("{nombre}")]
        public async Task<IActionResult> GetUserByName(string nombre)
        {
            var user = await _userService.GetUser(nombre);
            var userDTO = _mapper.Map<UserDTO>(user);
            var apiResponse = new ApiResponse<UserDTO>(userDTO);
            return Ok(apiResponse);
        }

        /// <summary>
        /// Obtiene los usuarios disponibles a invitar
        /// </summary>
        /// <param name="idReunion"></param>
        /// <returns></returns>
        [HttpGet("toinvite/{idReunion}")]
        public async Task<IActionResult> GetUserToInvite(int idReunion)
        {
            var users = await _userService.GetUserToInvite(idReunion);
            //var users = await _userService.GetUsers();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            var apiResponse = new ApiResponse<IEnumerable<UserDTO>>(usersDTO);
            return Ok(apiResponse);
        }

    }
}
