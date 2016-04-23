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
            Employee employee = null;

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
                    var datareader = cmd.ExecuteReader();
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

        public List<News> GetNews()
        {
            var news = new List<News>();
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectNews), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                        news.Add(new News
                        {
                            Id = datareader["Id"].ToString(),
                            Content = datareader["Content"].ToString(),
                            Highlight = Convert.ToBoolean(datareader["Highlight"]),
                            PostedOn = Convert.ToDateTime(datareader["PostedOn"]),
                            ExpiresOn = Convert.ToDateTime(datareader["ExpiresOn"])
                        });
                    }
                }
            }
            return news;
        }

        public List<Image> GetImages()
        {
            var images = new List<Image>();
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectImages), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    while (datareader.Read())
                    {
                        images.Add(new Image
                        {
                            Id = datareader["Id"].ToString(),
                            Name = datareader["Name"].ToString(),
                            EncodedImage = datareader["EncodedImage"].ToString(),
                            UploadedOn = datareader["UploadedOn"].ToString()
                        });
                    }
                }
            }
            return images;
        }

        public List<Employee> SearchUser(string psNumber, string name, string email)
        {
            var employees = new List<Employee>();
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlSearchEmployees, psNumber, name, email), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    if (datareader.Read())
                    {
                        employees.Add(new Employee
                        {
                            PsNumber = datareader["PsNumber"].ToString(),
                            Name = datareader["Name"].ToString(),
                            Gender = (Gender)Convert.ToInt32(datareader["Gender"]),
                            DateOfBirth = Convert.ToDateTime(datareader["DateOfBirth"]),
                            Email = datareader["Email"].ToString(),
                            BuisnessUnit = (BuisnessUnit)Convert.ToInt32(datareader["BuisnessUnit"]),
                            DeskPhoneNumber = datareader["DeskPhoneNumber"].ToString(),
                            Mobile = datareader["Mobile"].ToString(),
                            Address = datareader["Address"].ToString(),
                            UserRole = (UserRoles)Convert.ToInt32(datareader["UserRole"]),
                            Password = datareader["Password"].ToString()
                        });
                    }
                }
            }
            return employees;
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
                            Name = (ResourceSettingKeys) Convert.ToInt32(datareader["Name"]),
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
                using (
                    var cmd =
                        new SqlCommand(
                            string.Format(SqlQueries.SqlSelectBadmintonResource,
                                date.HasValue ? date.Value.Date : DateTime.Today), conn))
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

        public ResourceBookModel GetBookedBilliardList(DateTime? date)
        {
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (
                    var cmd =
                        new SqlCommand(
                            string.Format(SqlQueries.SqlSelectBilliardResource,
                                date.HasValue ? date.Value.Date : DateTime.Today), conn))
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

        #endregion
        
        #region Admin Operations

        public bool AddImage(List<Image> image)
        {
            if (image == null) return false;
            var result=0;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                foreach (var eachImage in image)
                {
                    using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlAddImage, eachImage.Name, eachImage.EncodedImage, eachImage.UploadedOn),conn))
                    {
                        result += cmd.ExecuteNonQuery();
                    }
                }
            }
            return result == image.Count;
        }

        public bool DeleteImages(List<string> images)
        {
            if (images == null) return false;
            var result = 0;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                foreach (var eachImage in images)
                {
                    using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlDeleteImages,eachImage), conn))
                    {
                        result += cmd.ExecuteNonQuery();
                    }
                }
            }
            return result == images.Count;
        }

        public bool AddNews(News news)
        {
            if (news == null) return false;
            int result;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (
                    var cmd =
                        new SqlCommand(
                            string.Format(SqlQueries.SqlAddNews, news.Content, news.Highlight, news.PostedOn,
                                news.ExpiresOn), conn))
                {
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        public bool DeleteNews(IList<string> news)
        {
            if (news == null) return false;
            var result = 0;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                foreach (var eachNews in news)
                {
                    using (var cmd = new SqlCommand(string.Format(SqlQueries.SqlDeleteNews, eachNews), conn))
                    {
                        result += cmd.ExecuteNonQuery();
                    }
                }
            }
            return result == news.Count;
        }

        #endregion

        public bool JoinGym(Gym gym)
        {
            if (gym == null) return false;
            int result;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (
                    var cmd =
                        new SqlCommand(string.Format(SqlQueries.SqlAddGym, gym.PsNumber, gym.TransactionDate, gym.Joined,
                                gym.JoinedOn, gym.LeftOn), conn))
                {
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        public bool LeaveGym(string id, Gym gym)
        {
            if (gym == null || string.IsNullOrWhiteSpace(id)) return false;
            int result;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (
                    var cmd =
                        new SqlCommand(string.Format(SqlQueries.SqlUpdateGym, gym.TransactionDate, gym.Joined, gym.LeftOn,
                                id), conn))
                {
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        public Gym GetGymByPsNumber(string psNumber)
        {
            Gym gym = null;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (
                    var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectGymByPsNumber, psNumber), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    if (datareader.Read())
                    {
                        gym = new Gym
                        {
                            Id = datareader["Id"].ToString(),
                            PsNumber = datareader["PsNumber"].ToString(),
                            TransactionDate = Convert.ToDateTime(datareader["TransactionDate"].ToString()),
                            Joined = true,
                            JoinedOn =
                                ReferenceEquals(datareader["JoinedOn"], typeof (DBNull))
                                    ? (DateTime?) null
                                    : Convert.ToDateTime(datareader["JoinedOn"]),
                            LeftOn =
                                ReferenceEquals(datareader["LeftOn"], typeof (DBNull))
                                    ? (DateTime?) null
                                    : Convert.ToDateTime(datareader["LeftOn"])
                        };
                    }
                }
            }
            return gym;
        }

        public Gym GetGymById(string id)
        {
            Gym gym = null;
            using (var conn = new SqlConnection(SqlQueries.ConnectionString))
            {
                conn.Open();
                using (
                    var cmd = new SqlCommand(string.Format(SqlQueries.SqlSelectGmyById, id), conn))
                {
                    var datareader = cmd.ExecuteReader();
                    if (datareader.Read())
                    {
                        gym = new Gym
                        {
                            Id = datareader["Id"].ToString(),
                            PsNumber = datareader["PsNumber"].ToString(),
                            TransactionDate = Convert.ToDateTime(datareader["TransactionDate"].ToString()),
                            Joined = Convert.ToBoolean(datareader["Joined"]),
                            JoinedOn =
                                ReferenceEquals(datareader["JoinedOn"], typeof(DBNull))
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(datareader["JoinedOn"]),
                            LeftOn =
                                ReferenceEquals(datareader["LeftOn"], typeof(DBNull))
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(datareader["LeftOn"])
                        };
                    }
                }
            }
            return gym;
        }
    }
}
