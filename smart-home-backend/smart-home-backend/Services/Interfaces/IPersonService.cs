using smart_home_backend.Dtos;

namespace smart_home_backend.Services
{
    public interface IPersonService
    {
        void SendPersonData(PersonDto person);
    }
}