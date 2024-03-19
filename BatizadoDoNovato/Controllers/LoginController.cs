using BatizadoDoNovato.Context;
using BatizadoDoNovato.Entities;
using BatizadoDoNovato.Models;
using BatizadoDoNovato.Repositories;
using BatizadoDoNovato.Services;
using Microsoft.AspNetCore.Mvc;

namespace BatizadoDoNovato.Controllers;
[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public LoginController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("novo-login")]
    public ActionResult<LoginViewModel> Authenticate([FromBody] Login model)
    {
        LoginViewModel loginViewModel = new LoginViewModel();   
        try
        {
            loginViewModel.Login = new LoginRepository().Get(model);

            if(loginViewModel.Login == null)
                return NotFound("Usuário não encontrado.");

            loginViewModel.Token = new TokenGenerator().Generate();
            loginViewModel.Login.Senha = string.Empty;
        }
        catch (Exception)
        {
            throw;
        }

        return loginViewModel;
    }
}
