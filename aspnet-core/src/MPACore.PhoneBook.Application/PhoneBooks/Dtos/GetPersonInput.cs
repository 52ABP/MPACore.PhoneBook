using System;
using Abp;
using Abp.Runtime.Validation;
using MPACore.PhoneBook.Dto;

namespace MPACore.PhoneBook.PhoneBooks.Dtos
{
    public class GetPersonInput:PagedAndSortedInputDto,IShouldNormalize
    {

        public string FilterText { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}