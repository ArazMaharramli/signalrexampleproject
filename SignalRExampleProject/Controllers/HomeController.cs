using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SignalRExampleProject.Domain;
using SignalRExampleProject.Domain.Entitties;
using SignalRExampleProject.Models;
using SignalRExampleProject.ViewModels;

namespace SignalRExampleProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignalRDbContext _signalRDbContext;

        public HomeController(ILogger<HomeController> logger, SignalRDbContext signalRDbContext)
        {
            _logger = logger;
            _signalRDbContext = signalRDbContext;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var users = await _signalRDbContext.Users.ToListAsync();
            var model = new ChatViewModel
            {
                Users = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(users, nameof(ApplicationUser.Id), nameof(ApplicationUser.UserName))
            };
            return View(model);
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
