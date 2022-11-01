using Microsoft.AspNetCore.Mvc;
using UIWeb.Shared.SharedModels;

namespace UIWeb.Server.Controllers;

[ApiController]
[Route("/authorize/")]
public class AuthorizeController : ServerControllerBase {
    private const string ValidLogin = "login";
    private const string ValidPassword = "possword1111";

    [HttpPost("login")]
    public string? Authorize(UserLogin user) {
        if (user.Login == ValidLogin && user.Password == ValidPassword) return user.Login;
    
        return null;
    }

    [HttpGet("validateToken")]
    public bool ValidateToken([FromQuery] string token) {
        return token == ValidLogin;
    }
}