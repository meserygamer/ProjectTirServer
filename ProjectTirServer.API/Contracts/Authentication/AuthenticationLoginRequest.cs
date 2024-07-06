using System.ComponentModel.DataAnnotations;

namespace ProjectTirServer.API.Contracts.Authentication
{
    public class AuthenticationLoginRequest
    {
        [Required] public string Login { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }
}
