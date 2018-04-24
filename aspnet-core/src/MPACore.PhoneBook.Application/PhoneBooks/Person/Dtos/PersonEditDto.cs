using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MPACore.PhoneBook.PhoneBooks.NumberDto;
using MPACore.PhoneBook.PhoneBooks.Persons;
using MPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace MPACore.PhoneBook.PhoneBooks.Person.Dtos
{
    [AutoMapTo(typeof(Persons.Person))]
    public class PersonEditDto
    {

        public int? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        [MaxLength(80)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; }


        /// <summary>
        /// 电话号码
        /// </summary>
        public List<PhoneNumberEditDto> PhoneNumbers { get; set; }

    }
}