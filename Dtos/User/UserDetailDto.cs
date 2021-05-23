using System.Collections.Generic;
namespace CoreAPIAndEfCore.Dtos
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CharacterGetDto> Characters { get; set; }
        public IEnumerable<string> Weapons { get; set; }
    }
}