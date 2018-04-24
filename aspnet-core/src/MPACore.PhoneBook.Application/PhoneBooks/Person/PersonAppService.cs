using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBooks.Person.Dtos;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MPACore.PhoneBook.PhoneBooks.Person
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {

        private readonly IRepository<Persons.Person> _personRepository;
        

        public PersonAppService(IRepository<Persons.Person> personRepository)
        {
            _personRepository = personRepository;
        }


     

        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input)
        {



            if (input.PersonEditDto.Id.HasValue)
            {

                await UpdatePersonAsync(input.PersonEditDto);


            }
            else
            {
                await CreatePersonAsync(input.PersonEditDto);
            }


             
        }

        public async Task DeletePersonAsync(EntityDto input)
        {

    var entity=      await  _personRepository.GetAsync(input.Id);

            if (entity==null)
            {
                throw new UserFriendlyException("该联系人已经消失在数据库中，无法二次删除");
            }

            await _personRepository.DeleteAsync(input.Id);
        }

        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
      var query=      _personRepository.GetAllIncluding(a=>a.PhoneNumbers);

            var personCount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var dtos = persons.MapTo<List<PersonListDto>>();

            return  new PagedResultDto<PersonListDto>(personCount,dtos);


 
        }


        public async Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
    var person=   await       _personRepository.GetAllIncluding(a=>a.PhoneNumbers).FirstOrDefaultAsync(a=>a.Id== input.Id.Value);

        return      person.MapTo<PersonListDto>();

        }



        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);
            

            await _personRepository.UpdateAsync(input.MapTo(entity));


        }

        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            var entity = input.MapTo<Persons.Person>();

        



       await     _personRepository.InsertAsync(entity);

        }

       

        public async Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input)
        {
            var output = new GetPersonForEditOutput();

            PersonEditDto personEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAllIncluding(a => a.PhoneNumbers).FirstOrDefaultAsync(a=>a.Id== input.Id.Value);
                personEditDto = entity.MapTo<PersonEditDto>();
            }
            else
            {
                personEditDto = new PersonEditDto();
            }

            output.Person = personEditDto;
            return output;
        }
    }
}