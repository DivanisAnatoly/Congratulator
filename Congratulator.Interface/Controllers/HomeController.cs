using Congratulator.Interface.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Congratulator.Interface.ViewModels;
using Congratulator.Services;

namespace Congratulator.Interface.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRecordService _recordService;

        public HomeController(ILogger<HomeController> logger, IPersonRecordService recordService)
        {
            _recordService = recordService;
        }


        public IActionResult Index()
        {
            HomePageViewModel homePageVM = new HomePageViewModel();
            homePageVM.BirthdayPeople = _recordService.GetBirthdayPeople();
            homePageVM.BirthdayPeopleSoon = _recordService.GetSoonBirthdayPeople();

            return View(homePageVM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
