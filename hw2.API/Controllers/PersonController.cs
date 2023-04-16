using AutoMapper;
using hw2.Core.Dtos;
using hw2.Core.Models;
using hw2.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace hw2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Person> _service;

        public PersonController(IService<Person> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<PersonDto>> All()
        {
            var claimsList = User.Claims;
            var result = claimsList.Where(x => x.Type == "AccountId").FirstOrDefault();
            List<Person> filtered = new List<Person>();
            var persons = await _service.GetAllAsync();
            foreach (var person in persons)
            {
                if (person.AccountId==int.Parse(result.Value))
                {
                    filtered.Add(person);
                }
            }
            var productsDtos = _mapper.Map<List<PersonDto>>(filtered.ToList());


            return productsDtos;
        }
        [HttpPost]
        [Authorize]
        public async Task<PersonDto> Save(PersonDto person)
        {
            var claimsList = User.Claims;
            var result = claimsList.Where(x => x.Type == "AccountId").FirstOrDefault();
           var newPerson= _mapper.Map<Person>(person);

            newPerson.AccountId = int.Parse(result.Value);
            var newperson = await _service.AddAsync(newPerson);
            //AddAsync metodu product aldığı için Dto'yu product'a çevirdik.

            var returnPersonDto=_mapper.Map<PersonDto>(newPerson);

            return returnPersonDto;
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<string> Update([FromBody]PersonDto personDto,int id)
        {
            

            try
            {
                var getPerson = await GetById(id);

                var claimsList = User.Claims;
                var result = claimsList.Where(x => x.Type == "AccountId").FirstOrDefault();
                var person = _mapper.Map<Person>(personDto);
                person.AccountId = int.Parse(result.Value);

                if (getPerson.AccountId == int.Parse(result.Value))
                {
                    await _service.UpdateAsync(person);
                    return "işlem başarılı";
                }
                else
                {
                    throw new Exception();
                }
               
                
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
               
                var person = await GetById(id);

                var claimsList = User.Claims;
                var result = claimsList.Where(x => x.Type == "AccountId").FirstOrDefault();

                if (person.AccountId ==int.Parse(result.Value))
                {
                    await _service.RemoveAsync(person);
                    return "silme işlemi başarılı";
                }
                else
                {
                    throw new Exception();
                }

                
            }
            catch (Exception)
            {

                return "Bir hata meydana geldi.";
            }


        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<dynamic> GetById(int id)
        {

            try
            {
                

                var claimsList = User.Claims;
                var result = claimsList.Where(x => x.Type == "AccountId").FirstOrDefault();
                var getPerson = await _service.GetByIdAsync(id);
                if (getPerson != null && getPerson.AccountId==int.Parse(result.Value))
                {

                    return getPerson;
                }
                else
                {
                    throw new Exception();
                }

                
            }
            catch (Exception)
            {

                return "Bir hata meydana geldi";
            }
            
        }

    }
}
