using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MPACore.PhoneBook.Web.Views
{
    public abstract class PhoneBookRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PhoneBookRazorPage()
        {
            LocalizationSourceName = PhoneBookConsts.LocalizationSourceName;
        }
    }
}
