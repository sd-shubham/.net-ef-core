using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.MapperConfig;

namespace CoreAPIAndEfCore.Models
{
    public class User : IMapFrom<UserCreateDto>
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public string Role { get; set; }
    }
}