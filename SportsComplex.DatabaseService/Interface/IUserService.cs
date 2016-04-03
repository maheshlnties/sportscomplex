using System.Collections.Generic;
using System.Threading.Tasks;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService.Interface
{
    public interface IUserService
    {
        Task<Employee> GetUser(string userName, string password);

        Task<bool> RegisterEmployee(Employee employee);

        List<Image> GetGalleryImages();
    }
}
