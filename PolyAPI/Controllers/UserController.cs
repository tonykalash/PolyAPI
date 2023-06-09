﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolyAPI.Commons.DTO;
using PolyAPI.Interface.User;

namespace PolyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _Iuser;
        public UserController(IUser Iuser)
        {
            _Iuser = Iuser;
        }


        [HttpGet]
       public async Task<ActionResult<List<UserDTO>>> Get(int idUser) 
        {
            return await Task.FromResult(_Iuser.GetUserById(idUser));
        }     
    }
}
