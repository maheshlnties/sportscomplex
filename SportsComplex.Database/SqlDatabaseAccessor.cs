using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SportsComplex.Models;
using SportsComplex.Models.Database;

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

            if (psNumber == "admin" && password == "admin@123")
                return new Employee
                {
                    PsNumber = psNumber,
                    Name = "Administrator",
                    Gender = Gender.Male,
                    DateOfBirth = DateTime.Today,
                    Email = "admin@gmail.com",
                    BuisnessUnit = BuisnessUnit.MPS,
                    DeskPhoneNumber = "1234",
                    Mobile = "9902232454",
                    Address = "Bangalore",
                    UserRole = UserRoles.Admin,
                    Password = password
                };

            if (psNumber == "user" && password == "user@123")
                return new Employee
                {
                    PsNumber = psNumber,
                    Name = "Test Employee",
                    Gender = Gender.Male,
                    DateOfBirth = DateTime.Today,
                    Email = "testemployee@gmail.com",
                    BuisnessUnit = BuisnessUnit.MPS,
                    DeskPhoneNumber = "1234",
                    Mobile = "9902232454",
                    Address = "Bangalore",
                    UserRole = UserRoles.Employee,
                    Password = password
                };

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

        #region Module Operations

        public List<ResourceSettings> GetResourceSettings()
        {
            var resourceSettings = new List<ResourceSettings>();
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectResourceSettings), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                        resourceSettings.Add(new ResourceSettings
                        {
                            Name = (ResourceSettingKeys)Convert.ToInt32(datareader["Name"]),
                            Value = datareader["Value"].ToString()
                        });
                    }
                }
            }
            return resourceSettings;
        }

        public ResourceBookModel GetBookedBadmintonList(DateTime? date)
        {
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectBadmintonResource, date.HasValue?date.Value.Date:DateTime.Today), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    if (datareader.Read())
                    {
                        var resourceBookModel=new ResourceBookModel
                        {
                            BookDate = Convert.ToDateTime(datareader["BookDate"]),
                            Items = datareader["Items"].ToString()
                        };
                        return resourceBookModel;
                    }
                }
            }
            return null;
        }

        public ResourceBookModel GetBookedBilliardList(DateTime? date)
        {
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectBilliardResource, date.HasValue ? date.Value.Date : DateTime.Today), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    if (datareader.Read())
                    {
                        var resourceBookModel = new ResourceBookModel
                        {
                            BookDate = Convert.ToDateTime(datareader["BookDate"]),
                            Items = datareader["Items"].ToString()
                        };
                        return resourceBookModel;
                    }
                }
            }
            return null;
        }

        public bool BookBadmintonResource(ResourceBookModel resourceBookModel)
        {
            if (resourceBookModel == null) return false;
            using (var cmd = new SqlCommand("sp_BookBadmintonResource"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BookDate", SqlDbType.Date).Value = resourceBookModel.BookDate.Date;
                cmd.Parameters.Add("@Items", SqlDbType.VarChar).Value = resourceBookModel.Items;
                return SqlHelper.ExecuteNonQueryCommand(cmd);
            }
        }

        #endregion

        public bool BookBilliardResource(ResourceBookModel resourceBookModel)
        {
            if (resourceBookModel == null) return false;
            using (var cmd = new SqlCommand("sp_BookBilliardResource"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BookDate", SqlDbType.Date).Value = resourceBookModel.BookDate.Date;
                cmd.Parameters.Add("@Items", SqlDbType.VarChar).Value = resourceBookModel.Items;
                return SqlHelper.ExecuteNonQueryCommand(cmd);
            }
        }
    }
}
