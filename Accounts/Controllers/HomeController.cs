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

        /// <summary>
        /// Index page to view results
        /// sample url: http://localhost/Accounts/home/index/0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
