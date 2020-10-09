using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using smart_home_backend.Dtos;
using smart_home_backend.Hubs.Interfaces;
using smart_home_backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_home_backend.Hubs
{
    public class SmartHomeHub : Hub<ISmartHomeHub>
    {
        private readonly ILogger<SmartHomeHub> _logger;
        public SmartHomeHub(ILogger<SmartHomeHub> logger)
        {
            _logger = logger;
        }

        public async Task SendPersonData(PersonDto data)
        {
            await Clients.All.SendPersonData(data);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
