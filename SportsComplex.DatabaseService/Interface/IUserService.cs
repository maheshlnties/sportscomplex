using System.Collections.Generic;
using System.Threading.Tasks;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService.Interface
{
    public interface IUserService
    {
        Task<Employee> GetUser(string userName, string password);

        Task<bool> RegisterEmployee(Employee employee);

        bool IsUserExists(string psNumber);

        List<Image> GetGalleryImages();

        List<News> GetNews();

        List<Employee> Search(string psNumber, string name, string email);
    }
}
