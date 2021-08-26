using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRExampleProject.Domain;
using SignalRExampleProject.Domain.Entitties;

namespace SignalRExampleProject.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignalRDbContext _dbContext;

        public ChatHub(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, SignalRDbContext dbContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public async Task SendMessage(string receiverUserId, string message)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var sender = await _userManager.FindByIdAsync(userId);
            var receiver = await _userManager.FindByIdAsync(receiverUserId);

            _dbContext.PrivateMessages.Add(new PrivateMessage
            {
                ReceiverId = receiver.Id,
                SenderId = sender.Id,
                Text = message
            });
            await _dbContext.SaveChangesAsync();
            await Clients.User(receiver.Id).SendAsync("ReceiveMessage", sender.UserName, message);
        }

        public async Task GetOldMessages()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var messages = await _dbContext.PrivateMessages.Where(x => x.ReceiverId == userId).ToListAsync();

            foreach (var x in messages)
            {
                var sender = x.SenderId == userId ? "You" : (await _userManager.FindByIdAsync(x.SenderId)).UserName;
                await Clients.User(userId).SendAsync("ReceiveOldMessages", sender, x.Text);
            }

        }
    }
}
