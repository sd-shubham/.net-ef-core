using System.Threading.Tasks;
using CoreAPIAndEfCore.Data;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Models;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace CoreAPIAndEfCore.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly IConfiguration _config;

        public AuthService(DataContext dataContext, IMapper mapper, IConfiguration config)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
            _config = config;

        }

        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            var user = await dataContext.Users.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(userLoginDto.Name.ToLower()));
            if (user is null) throw new InvalidOperationException("user doesn't exists");
            if (!IsPasswordValid(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                throw new InvalidOperationException("Invalid Password");
            return GenerateToken(user);
        }

        public async Task<int> Register(UserCreateDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Password) && string.IsNullOrEmpty(userDto.Name)) throw new ArgumentException("password required");
            if (await UserExists(userDto.Name)) throw new InvalidOperationException($"{userDto.Name} already Exists");
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = mapper.Map<Uesr>(userDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UserExists(string userNmae)
        {
            return await dataContext.Users.AnyAsync(x => x.Name.ToLower() == userNmae.ToLower());
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordsalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordsalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        private bool IsPasswordValid(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != passwordHash[i]) return false;
            }
            return true;
        }
        private string GenerateToken(Uesr uesr)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,uesr.Id.ToString()),
                new Claim(ClaimTypes.Name,uesr.Name)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value)
            );
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}