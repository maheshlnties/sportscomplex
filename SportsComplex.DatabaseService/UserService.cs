using System;
using System.Threading.Tasks;
using SportsComplex.Database;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService
{
    public class UserService : IUserService
    {
        private readonly SqlDatabaseAccessor _databaseAccessor;
        public UserService()
        {
            _databaseAccessor=new SqlDatabaseAccessor();
        }

        public async Task<Employee> GetUser(string userName, string password)
        {
            return await Task.Run(() => _databaseAccessor.GetUser(userName, password)).ConfigureAwait(false);
        }

        public async Task<bool> RegisterEmployee(Employee employee)
        {
            return await Task.Run(() => _databaseAccessor.RegisterUser(employee)).ConfigureAwait(false);
        }
    }
}
