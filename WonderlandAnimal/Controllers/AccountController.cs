using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WonderlandAnimal.Database.Repository;
using WonderlandAnimal.Models;
using WonderlandAnimal.MongoDB;
using WonderlandAnimal.Services;


namespace WonderlandAnimal.Controllers
{
    // [Route("[controller]")]
    [ApiController]
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _accountRepository;
        
        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("accounts/{id}")] //  Route("accounts/{id}")
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest(401);
            }
            
            if (id is > 0)
            { 
                var account = await _accountRepository.GetAsync(id.Value);
               // var account2 = await _accountRepository.GetByEmailAsync("Email");

               if (account != null)
               {
                   AccountLogin accountLogin = new AccountLogin()
                   {
                       Id = id.Value,
                       Email = account.Email,
                       FirstName = account.FirstName,
                       LastName = account.LastName
                   }; 
                   
                   return Ok(accountLogin);
               }
               return NotFound();
            }
            else
            {
                return BadRequest(400);
            }
        }
        
        [HttpGet("accounts/search")]
        public async Task<IActionResult> Get(String? firstName, String lastName, String email, int from, int size)
        {
            if (firstName == null || lastName == null || email == null)
            {
                return Ok();
            }
           
            if (from < 0 && size <= 0)
            {
                return BadRequest(400); 
            }
          //  var account = await _accountRepository.GetAsync(1);
            return Ok( );
        }


        [HttpPost("registration/")]
        public async Task<IActionResult> Post(String firstName, String lastname, String email, String password)
        {
            if ((firstName == null || firstName.Trim() == "") || (lastname == null || lastname.Trim() == "") ||
                (email == null || email.Trim() == "" || ValidateEmail.IsValidEmail(email)) || (password == null || password.Trim() == ""))
            {

                if (IsEmailExistsDb(email))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                    //return BadRequest(409);
                }
                
                Account newAccount = new Account();
                newAccount.FirstName = firstName;
                newAccount.LastName = lastname;
                newAccount.Email = email;
                newAccount.Password = password;

                await _accountRepository.AddAsync(newAccount);
                return CreatedAtAction(nameof(Get), newAccount); // 201
            }

            return BadRequest(400);
        }


        bool IsEmailExistsDb(String email)
        {
            var accounts = _accountRepository.GetListAsync();
            foreach (var account in accounts)
            {
                if (email == account.Email)
                {
                    return true;
                }
            }
            return false;
        }


        [HttpPut("accounts/{id}")]
        public async Task<IActionResult> Put(int? id, String firstName, String lastname, String email, String password)
        {
            Account newAccount = new Account();
            newAccount.FirstName = firstName;
            newAccount.LastName = lastname;
            newAccount.Email = email;
            newAccount.Password = password;
        
            AccountLogin accountLogin = new AccountLogin()
            {
                Id = id.Value,
                Email = email,
                FirstName = firstName,
                LastName = lastname
            }; 
            
            _accountRepository.UpdateAsync(newAccount);
            return Ok(accountLogin);
        }
        
        [HttpDelete("accounts/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            _accountRepository.DeleteAsync(await _accountRepository.GetAsync(id.Value));
            return Ok();
        }
    }
}
