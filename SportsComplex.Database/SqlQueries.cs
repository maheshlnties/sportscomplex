﻿using System.Configuration;
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

        public const string SqlBookBadmintonResource = @"CREATE PROCEDURE [dbo].[sp_BookBadmintonResource]  
  @BookDate date  
   ,@Items nvarchar(MAX) 
AS   
BEGIN   
declare @rows as int
Select @rows = count(*) From dbo.BadmintonResource Where BookDate=@BookDate

IF @rows = 0
BEGIN  
	insert into dbo.BadmintonResource(BookDate, Items)  
	values(@BookDate, @Items) 
END

ELSE

BEGIN    
	UPDATE [SportsComplex].[dbo].[BadmintonResource]
	SET [BookDate] = @BookDate
		  ,[Items] = @Items
	WHERE BookDate=@BookDate
END
    
END  
GO";


        public const string SqlBookBilliardResource = @"CREATE PROCEDURE [dbo].[sp_BookBilliardResource]  
  @BookDate date  
   ,@Items nvarchar(MAX) 
AS   
BEGIN   
declare @rows as int
Select @rows = count(*) From dbo.BilliardResource Where BookDate=@BookDate

IF @rows = 0
BEGIN  
	insert into dbo.BilliardResource(BookDate, Items)  
	values(@BookDate, @Items) 
END

ELSE

BEGIN    
	UPDATE [SportsComplex].[dbo].BilliardResource
	SET [BookDate] = @BookDate
		  ,[Items] = @Items
	WHERE BookDate=@BookDate
END
    
END  
";
        #endregion

        #region Queries

        public const string SqlSelectEmployees = "SELECT * FROM [SportsComplex].[dbo].[Employees] WHERE PsNumber = '{0}' AND [Password] = '{1}'";

        public const string SqlSelectResourceSettings = "SELECT * FROM [SportsComplex].[dbo].[ResourceSettings]";

        public const string SqlSelectBadmintonResource = "SELECT * FROM [SportsComplex].[dbo].[BadmintonResource] WHERE BookDate = '{0}'";

        public const string SqlSelectBilliardResource = "SELECT * FROM [SportsComplex].[dbo].[BilliardResource] WHERE BookDate = '{0}'";

        #endregion
    }
}
