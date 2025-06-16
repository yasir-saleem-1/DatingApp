using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

 [Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository userRepository ) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var user = await userRepository.GetMembersAsync();
        return Ok(user);
    }

    // [HttpGet("{id:int}")]
    // public async Task<ActionResult<AppUser>> GetUser(int id)
    // {
    //     var user = await userRepository.GetUserByIdAsync(id);

    //     if (user == null)
    //     {
    //         return NotFound();
    //     }

    //     return Ok(user);
    // }
    
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetMemberAsync(username);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }
}



