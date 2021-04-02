using Core.Entities;

namespace Entities.DTOs
{
    //giriş yapmak isteyen kullanıcının entitysi
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
