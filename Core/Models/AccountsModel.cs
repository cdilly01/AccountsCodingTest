using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public enum AccountStatuses
    {
        Active,
        Inactive,
        Overdue
    }

    public class AccountsModel
    {
        public IEnumerable<AccountModel> Accounts { get; set; }
        public IEnumerable<AccountModel> ActiveAccounts => Accounts.Where(a => a.Status == AccountStatuses.Active.ToString());
        public IEnumerable<AccountModel> InactiveAccounts => Accounts.Where(a => a.Status == AccountStatuses.Inactive.ToString());
        public IEnumerable<AccountModel> OverdueAccounts => Accounts.Where(a => a.Status == AccountStatuses.Overdue.ToString());
    }

    public class AccountModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName => $"{LastName}, {FirstName}";
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? AmountDue { get; set; }
        public DateTimeOffset? PaymentDueDate { get; set; }
        public int? AccountStatusId { get; set; }
        public string Status => Enum.TryParse(AccountStatusId.ToString(), out AccountStatuses result) ? result.ToString() : string.Empty;
    }
}
