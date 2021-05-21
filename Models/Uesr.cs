using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CoreAPIAndEfCore.Models
{
    public class Uesr
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public IEnumerable<Character> Characters { get; set; }
    }
}