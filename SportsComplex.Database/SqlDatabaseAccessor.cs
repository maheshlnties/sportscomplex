using System;
using System.Data;
using System.Data.SqlClient;
using SportsComplex.Models;
namespace SportsComplex.Database
{
    public class SqlDatabaseAccessor
    {
        #region UserService Operations

        public bool RegisterUser(Employee employee)
        {
            if (employee == null) return false;

            using (var cmd = new SqlCommand("sp_InsertEmployee"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PsNumber", SqlDbType.VarChar).Value = employee.PsNumber;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = employee.Name;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = employee.Gender;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = employee.DateOfBirth.Date;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
                cmd.Parameters.Add("@BuisnessUnit", SqlDbType.Int).Value = employee.BuisnessUnit;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = employee.Address;
                cmd.Parameters.Add("@DeskPhoneNumber", SqlDbType.VarChar).Value = employee.DeskPhoneNumber;
                cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = employee.Mobile;
                cmd.Parameters.Add("@UserRole", SqlDbType.Int).Value = employee.UserRole;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = employee.Password;
                return SqlHelper.ExecuteNonQueryCommand(cmd);
            }
        }

        public Employee GetUser(string psNumber, string password)
        {
            Employee employee=null;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectEmployees, psNumber, password), conn))
                {
                    var datareader=cmd.ExecuteReader();
                    if (datareader.Read())
                    {
                        employee = new Employee
                        {
                            PsNumber = datareader["PsNumber"].ToString(),
                            Name = datareader["Name"].ToString(),
                            Gender = (Gender) Convert.ToInt32(datareader["Gender"]),
                            DateOfBirth = Convert.ToDateTime(datareader["DateOfBirth"]),
                            Email = datareader["Email"].ToString(),
                            BuisnessUnit = (BuisnessUnit) Convert.ToInt32(datareader["BuisnessUnit"]),
                            DeskPhoneNumber = datareader["DeskPhoneNumber"].ToString(),
                            Mobile = datareader["Mobile"].ToString(),
                            Address = datareader["Address"].ToString(),
                            UserRole = (UserRoles) Convert.ToInt32(datareader["UserRole"]),
                            Password = datareader["Password"].ToString()
                        };
                    }
                }
            }
           
            return employee;
        }

        #endregion
    }
}
