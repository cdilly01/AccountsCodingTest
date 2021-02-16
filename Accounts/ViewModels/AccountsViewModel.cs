using Core.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class AccountsViewModel : BaseViewModel
    {
        public AccountsViewModel()
            : base()
        {
        }

        public AccountsModel AccountsModel { get; set; }
        public string ReturnUrl { get; set; }
        public List<LookUp> StatusList { get; set; }
    }
}
