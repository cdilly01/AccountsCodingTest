using Core;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Accounts.Controllers
{
    [Route("Home")]
    [DisplayName("Account List")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IFrontierService FrontierService { get; set; }

        public HomeController(ILogger<HomeController> logger, IFrontierService frontierService)
        {
            _logger = logger;
            FrontierService = frontierService;
        }

        [Route("Index/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var vm = new AccountsViewModel();
            var apiData = await FrontierService.GetAccountsAsync();
            vm.AccountsModel = new AccountsModel { Accounts = apiData };
            vm.StatusList = FrontierService.GetLookupList(LookupType.AccountStatus);
            return View("Index", vm);
        }
    }
}
