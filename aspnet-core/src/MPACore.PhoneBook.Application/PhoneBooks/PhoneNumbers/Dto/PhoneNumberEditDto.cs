using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace MPACore.PhoneBook.PhoneBooks.PhoneNumbers.Dto
{
    [AutoMapTo(typeof(PhoneNumber))]

    public class PhoneNumberEditDto
    {

        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(PhoneBookConsts.MaxPhoneNumberLength)]
        public string Number { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType Type { get; set; }
 


         
    }
}