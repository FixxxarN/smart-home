using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using smart_home_backend.Dtos;
using smart_home_backend.Hubs;
using smart_home_backend.Hubs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_home_backend.Services
{
    public class PersonService : IPersonService
    {
        private readonly ILogger _logger;
        private readonly IHubContext<SmartHomeHub, ISmartHomeHub> _hubContext;
        public PersonService(ILogger<PersonService> logger, IHubContext<SmartHomeHub, ISmartHomeHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public void SendPersonData(PersonDto person)
        {
            try
            {
                _hubContext.Clients.All.SendPersonData(person);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
