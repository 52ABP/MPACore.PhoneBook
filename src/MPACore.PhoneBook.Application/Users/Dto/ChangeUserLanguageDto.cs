using System.ComponentModel.DataAnnotations;

namespace MPACore.PhoneBook.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}