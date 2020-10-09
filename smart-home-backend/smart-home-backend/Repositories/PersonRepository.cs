using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using smart_home_backend.Datasource.Context;
using smart_home_backend.Datasource.Models;
using smart_home_backend.Dtos;
using smart_home_backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_home_backend.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;
        private readonly smart_home_backend_context _context;
        private readonly ILogger<PersonRepository> _logger;
        private readonly IPersonService _personService;
        public PersonRepository(IMapper mapper, smart_home_backend_context context, ILogger<PersonRepository> logger, IPersonService personService)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
            _personService = personService;
        }

        public async Task<bool> GetPersonAndSendPersonData(string name)
        {
            try
            {
                var person = await _context.Person.FirstOrDefaultAsync(p => p.Name == name);

                if(person != null)
                {
                    _personService.SendPersonData(_mapper.Map<PersonDto>(person));
                    return true;
                }
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e.Message);
                return false;
            }
            return false;
        }

        public async Task<bool> Create(string name)
        {
            try
            {
                var p = await _context.Person.FirstOrDefaultAsync(p => p.Name == name);
                if(p == null)
                {
                    var personEntity = new PersonEntity() { Name = name };
                    personEntity.Id = Guid.NewGuid();
                    await _context.Person.AddAsync(personEntity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e.Message);
                return false;
            }
            return true;
        }
    }
}
