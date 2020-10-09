using smart_home_backend.Dtos;
using System.Threading.Tasks;

namespace smart_home_backend.Repositories
{
    public interface IPersonRepository
    {
        Task<bool> GetPersonAndSendPersonData(string name);
        Task<bool> Create(string name);
    }
}