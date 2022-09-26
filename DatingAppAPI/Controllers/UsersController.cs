using AutoMapper;
using DatingAppAPI.Data;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppAPI.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        //private readonly DataContext _context;
        private readonly IUserReporsitory _userReporsitory;
        private readonly IMapper _mapper;

        public UsersController(IUserReporsitory userReporsitory,IMapper mapper)
        {
            //_context = context;
            _userReporsitory = userReporsitory;
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            //get the notes from Database
            //return Ok(await _context.Users.ToListAsync());
            // return await _context.Users.ToListAsync();  
            /*var users = await _userReporsitory.GetUsersAsync();
            return Ok(users);*/
            /* var users = await _userReporsitory.GetUsersAsync();
             var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
             return Ok(usersToReturn);*/

            //using automapperr

            var users = await _userReporsitory.GetMembersAsync();
            return Ok(users);
        }
/*        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //get the notes from Database
            //return Ok(await _context.Users.ToListAsync());
            // return await _context.Users.ToListAsync();  
            var users= await _userReporsitory.GetUsersAsync();
            return Ok(users);
        }*/
        //api/user/2
      
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            /*var user= await _userReporsitory.GetUserByUsernameAsync(username);
            return _mapper.Map<MemberDto>(user);*/
            //return await _userReporsitory.GetUserByUsernameAsync(username);

            // using NEW AUTOMAPPER TECHNOLOGY BY PROJECTING MEMBER DTO BY providing configuration builder
           //we dont need to map inside our controller
            return await _userReporsitory.GetMemberAsync(username);
        }


    }
}
