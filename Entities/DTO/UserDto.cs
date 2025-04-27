using Core.Entitites;

namespace Entities.DTO
{
    public class UserDto : IDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
