using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Application.UserServices;
using News.Application.UserServices.Dtos;
using News.Core.Enums;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using News.Application.NewServices;
using News.Application.NewServices.Dtos;
using System.Linq;
using News.Application.Helper;
using News.Application.SettingServices;
using News.Application.SettingServices.Dtos;
using News.Core.Entities;
using News.Application.ViewModels;
using News.Common;

namespace News.Web.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly IUserService _service;
        private readonly ISettingService _settingService;
        private readonly INewService _newService;

        public AdminController(
            IUserService service,
            ISettingService settingService,
            INewService newService)
        {
            _service = service;
            _settingService = settingService;
            _newService = newService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth(LoginModel request)
        {
            var user = await _service.Authenticate(request);
            if (user == null)
            {
                request.Message = "Sai tên đăng nhập hoặc mật khẩu.";
                return View(request);
            }

            var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("Name",user.Name)
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
            {
                IsPersistent = true
            });

            return RedirectToAction("Setting", "Admin");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            var file = Request.Form.Files.FirstOrDefault();
            if(file != null)
            {
                var data = await FileHelper.ToUploadAsync(file, "news", file.FileName);
                return Json(data);
            }

            return default;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> News(int? page = 1, int? pageSize = 10)
        {
            ViewBag.Page = page;
            var data = await _newService.GetPagingAsync(page, pageSize);
            return View(data);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> CreateNews()
        {
            var categories = await _newService.GetCategoriesAsync();
            return View(categories);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateNews(NewDto request)
        {
            await _newService.CreateAsync(request);

            return RedirectToAction("News");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> EditNews(Guid id)
        {
            var categories = await _newService.GetCategoriesAsync();
            var entity = await _newService.GetById(id);
            var model = new EditNewViewModel()
            {
                Id = entity.Id,
                Categories = categories,
                CategoryId = entity.CategoryId,
                Content = entity.Content,
                Image = entity.Image,
                Title = entity.Title,
                Category = string.Empty,
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> EditNews(NewDto dto)
        {
            await _newService.UpdateAsync(dto);

            return RedirectToAction("News");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Setting()
        {
            var models = await _settingService.GetAllAsync();
            var model = new SettingViewModel()
            {
                Header = models.FirstOrDefault(x => x.Section.Equals(EnumSection.Header)),
                Summary = models.FirstOrDefault(x => x.Section.Equals(EnumSection.Summary)),
                Footer = models.FirstOrDefault(x => x.Section.Equals(EnumSection.Footer))
            };
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> UpdateSetting([FromBody] SettingDto dto)
        {
            await _settingService.UpdateAsync(dto);
            return Json(true);
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<JsonResult> Delete(Guid id)
        {
            await _newService.DeleteAsync(id);

            return Json(true);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var data = (await _newService.GetCategoriesAsync()).ToList();

            return View(data);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<JsonResult> GetById(Guid id)
        {
            var data = await _newService.GetCategoryById(id);

            return Json(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> CreateCategory([FromBody] CategoryDto model)
        {
            await _newService.CreateCategoryAsync(model);
            return Json(true);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> UpdateCategory([FromBody] CategoryDto model)
        {
            await _newService.UpdateCategory(model);
            return Json(true);
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<JsonResult> DeleteCategory(Guid id)
        {
            await _newService.DeleteCategoryAsync(id);

            return Json(true);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<JsonResult> SetHome(Guid id)
        {
            await _newService.SetHomeAsync(id);
            return Json(true);
        }
    }
}
