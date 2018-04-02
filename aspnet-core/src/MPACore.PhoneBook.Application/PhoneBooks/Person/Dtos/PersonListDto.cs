using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

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


        /// <summary>
        /// 电话号码
        /// </summary>
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}