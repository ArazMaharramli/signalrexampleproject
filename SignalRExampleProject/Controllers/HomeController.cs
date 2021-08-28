using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
            var users = await _signalRDbContext.Users.Where(x => x.Id != HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync();
            var model = new IndexViewModel
            {
                Users = users.Select(x => (x.Id, x.UserName)).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChatAsync([FromQuery] string user)
        {
            var receiver = await _signalRDbContext.Users.FindAsync(user);
            if (receiver is not null)
            {
                var model = new ChatViewModel
                {
                    ReceiverId = receiver.Id,
                    ReceiverName = receiver.UserName
                };
                return View(model);
            }
            return BadRequest();
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
