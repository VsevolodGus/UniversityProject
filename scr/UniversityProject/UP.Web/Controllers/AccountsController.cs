using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UP.BLL;
using UP.Web.Helpers;

namespace UP.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IUserBLL _userBLL;

    public class LoginModel
    {
        public string Login { get; init; }

        public string Password { get; init; }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<bool> SingInAsync([FromBody] LoginModel model)
    {
        var user = await _userBLL.SignInAsync(model.Login, model.Password, HttpContext.RequestAborted);

        await new AuthenticationHelper().SingInAsync();

        return true;
    }
}



