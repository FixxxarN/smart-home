using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using smart_home_backend.Dtos;
using smart_home_backend.Repositories;

namespace smart_home_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonRepository _personRepository;

        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
        }

        [HttpPost]
        public IActionResult Post(string name)
        {
            _personRepository.GetPersonAndSendPersonData(name);
            if (_personRepository.Create(name).Result)
                return StatusCode(200);
            else
                return StatusCode(500);
        }
    }
}
