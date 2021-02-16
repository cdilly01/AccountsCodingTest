using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core
{
    public enum LookupType
    {
        AccountStatus
    }

    public interface IFrontierService
    {
        Task<List<AccountModel>> GetAccountsAsync();
        List<LookUp> GetLookupList(LookupType lookupType);
    }

    //TODO: Add dependency injection as needed
    public class FrontierService : IFrontierService
    {
        public async Task<List<AccountModel>> GetAccountsAsync()
        {
            var reservationList = new List<AccountModel>();
            try
            {
                //TODO: put api endpoint into appsettings.json
                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync("https://frontiercodingtests.azurewebsites.net/api/accounts/getall");
                string apiResponse = await response.Content.ReadAsStringAsync();
                reservationList = JsonConvert.DeserializeObject<List<AccountModel>>(apiResponse);
            }
            catch (Exception ex)
            {
                //TODO: Add error logging
            }
            return reservationList;
        }

        public List<LookUp> GetLookupList(LookupType lookupType)
        {
            var lookUpList = new List<LookUp>();
            switch (lookupType)
            {
                case LookupType.AccountStatus:
                    lookUpList.Add(new LookUp { text = "Active", value = "Active" });
                    lookUpList.Add(new LookUp { text = "Inactive", value = "Inactive" });
                    lookUpList.Add(new LookUp { text = "Overdue", value = "Overdue" });
                    break;
            }

            return lookUpList;
        }
    }
}