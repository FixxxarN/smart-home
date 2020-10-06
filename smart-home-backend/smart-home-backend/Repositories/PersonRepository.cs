using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using smart_home_backend.Datasource.Context;
using smart_home_backend.Datasource.Models;
using smart_home_backend.Dtos;
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
        public PersonRepository(IMapper mapper, smart_home_backend_context context, ILogger<PersonRepository> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Create(PersonDto person)
        {
            try
            {
                var p = await _context.Person.FirstOrDefaultAsync(p => p.Name == person.Name);
                if(p == null)
                {
                    var personEntity = _mapper.Map<PersonEntity>(person);
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
