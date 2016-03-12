using System.Configuration;
namespace SportsComplex.Database
{
    public class SqlQueries
    {

        #region Properties

        public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        }

        #endregion

        #region StoredProcedures

        public const string SqlInsertEmployee = @"CREATE PROCEDURE [dbo].[sp_InsertEmployee]
  @PsNumber nvarchar(50),
  @Name nvarchar(50)
  ,@Gender int
  ,@DateOfBirth date
   ,@Email nvarchar(MAX)
    ,@BuisnessUnit int
     ,@Address nvarchar(MAX)
     ,@DeskPhoneNumber nvarchar(50)
      ,@Mobile nvarchar(50)
       ,@UserRole int
,@Password nvarchar(50)
AS 
BEGIN 
insert into dbo.Employees(PsNumber, Name, Gender, DateOfBirth, Email, BuisnessUnit, [Address], DeskPhoneNumber, Mobile, UserRole, [Password])
values(@PsNumber, @Name, @Gender, @DateOfBirth, @Email, @BuisnessUnit, @Address, @DeskPhoneNumber, @Mobile, @UserRole, @Password)
END";


        #endregion

        #region Queries

        public const string SqlSelectEmployees = "SELECT * FROM [SportsComplex].[dbo].[Employees] WHERE PsNumber = '{0}' AND [Password] = '{1}'";

        #endregion
    }
}
