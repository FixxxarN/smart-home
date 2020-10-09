using smart_home_backend.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_home_backend.Hubs.Interfaces
{
    public interface ISmartHomeHub
    {
        Task SendPersonData(PersonDto data);
    }
}
