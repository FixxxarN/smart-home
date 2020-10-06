using smart_home_backend.Dtos;
using System.Threading.Tasks;

namespace smart_home_backend.Repositories
{
    public interface IPersonRepository
    {
        Task<bool> Create(PersonDto person);
    }
}