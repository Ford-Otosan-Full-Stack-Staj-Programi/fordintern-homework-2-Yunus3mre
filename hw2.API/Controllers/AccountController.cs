using hw2.Core.Models;
using hw2.Core.Services;
using hw2.Core.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hw2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IService<Account> _service;

        public AccountController(IService<Account> service)
        {
            _service = service;
           
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Account>> All()
        {
            var products = await _service.GetAllAsync();


            return products;
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<Account> Save(Account account)
        {
            try
            {
                var newAccount = await _service.AddAsync(account);
                //AddAsync metodu product aldığı için Dto'yu product'a çevirdik.

                return newAccount;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpPut]
        [Authorize]
        public async Task<string> Update(Account account)
        {
            
            try
            {
                await _service.UpdateAsync(account);
                return "işlem başarılı";
            }
            catch (Exception)
            {

                return "Bir Hata meydana geldi";
            }
            
            
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<string> Remove(int id)
        {
           

            try
            {
                var account = await _service.GetByIdAsync(id);
                await _service.RemoveAsync(account);
                return "silme işlemi başarılı";
            }
            catch (Exception)
            {

                return "Bir hata meydana geldi.";
            }
            
           
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Account> GetById(int id)
        {
            var account = await _service.GetByIdAsync(id);

            return account;
        }

    }
}
