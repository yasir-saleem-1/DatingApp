using System;
using System.Security.Cryptography;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController] 
[Route("api/[controller]")]
public class AccountController(DataContext context , ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
         if (await UserExists(registerDto.Username)) return BadRequest("Username already exists");
        return Ok();
        // using var hmac = new HMACSHA512();
        
        // var user = new AppUser
        // {
        //     FirstName = registerDto.Username.ToLower(),
        //     PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerDto.Password)),
        //     PasswordSalt = hmac.Key
        // };
        // context.Users.Add(user);
        // await context.SaveChangesAsync();

        // return new UserDto
        // {
        //     Username = user.FirstName,
        //     Token = tokenService.CreateToken(user)
        // }; 
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await context.Users.SingleOrDefaultAsync(x => x.FirstName == loginDto.Username.ToLower());
        if (user == null) return Unauthorized("Invalid username");

        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginDto.Password));
        
        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        }

        return new UserDto
        {
            Username = user.FirstName,
            Token = tokenService.CreateToken(user)
        };
    }
    private async Task<bool> UserExists(string username)
    {
        return await context.Users.AnyAsync(x => x.FirstName.ToLower() == username.ToLower());
    }
}
