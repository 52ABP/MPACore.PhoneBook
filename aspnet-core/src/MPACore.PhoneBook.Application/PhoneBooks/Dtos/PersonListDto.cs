using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.Persons;

namespace MPACore.PhoneBook.PhoneBooks.Dtos
{
    [AutoMapFrom(typeof(Person))]
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