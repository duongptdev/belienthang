using News.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using News.Application.UserServices.Dtos;
using News.Application.UserServices;
using System.Text;
using News.Core.Enums;
using Org.BouncyCastle.Asn1.Ocsp;
using News.Core.Contants;
using News.Common;
using News.Application.NewServices;
using News.Application.ViewModels;
using News.Application.SettingServices;

namespace News.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _service;
        private readonly INewService _newService;
        private readonly ISettingService _settingService;

        public HomeController(
            ILogger<HomeController> logger,
            IUserService service,
            INewService newService,
            ISettingService settingService
            )
        {
            _logger = logger;
            _service = service;
            _newService = newService;
            _settingService = settingService;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var host = Request.Host.Value;
            var data = (await _newService.GetTopNews()).ToList();

            data[0].Selector = "show active";
            var settings = (await _settingService.GetAllAsync()).ToList();

            var homeNew = await _newService.GetHomeNewsAsync();

            var model = new HomeViewModel()
            {
                Categories = null,
                CategoryNews = data,
                Settings = settings,
                HomeNew = homeNew
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll(int? page = 1, int? pageSize = 5, Guid? categoryId = null)
        {
            var news = await _newService.GetPagingAsync(page, pageSize, categoryId);
            var categories = await _newService.GetCategoriesAsync();
            var model = new NewsViewModel()
            {
                Categories = categories,
                News = news
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var data = await _newService.GetById(id);
            var categories = await _newService.GetCategoriesAsync();
            return View(new DetailViewModel()
            {
                Categories = categories,
                News = data
            });
        }
    }
}
