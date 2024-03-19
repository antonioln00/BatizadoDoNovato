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
    public ActionResult<UserViewModel> Authenticate([FromBody] Login model)
    {
        UserViewModel userViewModel = new UserViewModel();   
        try
        {
            userViewModel.Login = new LoginRepository().Get(model);

            if(userViewModel.Login == null)
                return NotFound("Usuário não encontrado.");

            userViewModel.Token = new TokenGenerator().Generate();
            userViewModel.Login.Senha = string.Empty;
        }
        catch (Exception)
        {
            throw;
        }

        return userViewModel;
    }
}
