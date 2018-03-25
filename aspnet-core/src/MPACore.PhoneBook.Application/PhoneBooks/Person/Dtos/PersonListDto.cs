using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MPACore.PhoneBook.PhoneBooks.Person.Dtos
{
    [AutoMapFrom(typeof(Persons.Person))]
    public class PersonListDto:FullAuditedEntityDto
    {
        /// <summary>
        /// 姓名
        /// </summary>
     
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
     
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
       
        public string Address { get; set; }
    }
}