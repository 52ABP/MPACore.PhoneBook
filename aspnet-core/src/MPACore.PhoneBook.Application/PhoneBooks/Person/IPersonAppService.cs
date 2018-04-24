using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MPACore.PhoneBook.PhoneBooks.Person.Dtos;

namespace MPACore.PhoneBook.PhoneBooks.Person
{
    public interface IPersonAppService: IApplicationService
    {

        /// <summary>
        /// 获取联系人的相关信息,支持分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input);

        /// <summary>
        /// 根据ID获取相关联系人的信息
        /// </summary>
        /// <returns></returns>
        Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input);

       
            /// <summary>
            /// 新增或者更改联系人信息
            /// </summary>
            /// <returns></returns>
        Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonInput input);

        /// <summary>
        /// 删除联系人信息
        /// </summary>
        /// <returns></returns>
        Task DeletePersonAsync(EntityDto input);
        /// <summary>
        /// 通过Id获取联系人信息进行编辑或修改 
        /// </summary>
        Task<GetPersonForEditOutput> GetPersonForEditAsync(NullableIdDto<int> input);


    }
}