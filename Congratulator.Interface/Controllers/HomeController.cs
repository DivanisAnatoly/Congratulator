using Congratulator.Infrastructure.DBAccess;
using Congratulator.Domain.Entities;
using Congratulator.Interface.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Congratulator.Interface.ViewModels;
using Congratulator.Services;

namespace Congratulator.Interface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonRecordService _recordService;

        public HomeController(ILogger<HomeController> logger, IPersonRecordService recordService)
        {
            _logger = logger;
            _recordService = recordService;
        }


        public IActionResult Index()
        {
            HomePageViewModel homePageVM = new HomePageViewModel();
            homePageVM.BirthdayPeople = _recordService.GetBirthdayPeople();
            homePageVM.BirthdayPeopleSoon = _recordService.GetSoonBirthdayPeople();

            return View(homePageVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
