using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WonderlandAnimal.Models;


namespace WonderlandAnimal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        [HttpGet, Route("accounts/{accountId}")]
        public Account Get(int accountId)
        {
            Account account = new Account();
            account.accountId = accountId;
            account.login = "Nikites";
            account.password = "qwerty";
            return account;
        }
    }
}
