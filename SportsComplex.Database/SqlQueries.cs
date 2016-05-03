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

        public const string SqlSelectEmployeesByPsNumber = "SELECT * FROM [SportsComplex].[dbo].[Employees] WHERE PsNumber = '{0}'";

        public const string SqlSearchEmployees = "SELECT * FROM [SportsComplex].[dbo].[Employees] WHERE PsNumber LIKE '%{0}%' OR Name LIKE '%{1}%' OR Email LIKE '%{2}%'";

        public const string SqlSelectResourceSettings = "SELECT * FROM [SportsComplex].[dbo].[ResourceSettings]";

        //public const string SqlSelectBadmintonResource = "SELECT * FROM [SportsComplex].[dbo].[BadmintonResource] WHERE BookDate = '{0}'";

        public const string SqlSelectBadmintonResource = "SELECT * FROM [SportsComplex].[dbo].[BadmintonResource] WHERE BookDate = convert(date , '{0}' , 105)";

        //public const string SqlSelectBilliardResource = "SELECT * FROM [SportsComplex].[dbo].[BilliardResource] WHERE BookDate = '{0}'";

        public const string SqlSelectBilliardResource = "SELECT * FROM [SportsComplex].[dbo].[BilliardResource] WHERE BookDate = convert(date , '{0}' , 105)";

        //public const string SqlAddImage = "INSERT INTO [SportsComplex].[dbo].[Gallery] ([Name],[EncodedImage],[UploadedOn]) VALUES('{0}','{1}','{2}')";

        public const string SqlAddImage = "INSERT INTO [SportsComplex].[dbo].[Gallery] ([Name],[EncodedImage],[UploadedOn]) VALUES('{0}','{1}',convert(date , '{2}' , 105))";

        public const string SqlDeleteImages = "DELETE FROM [SportsComplex].[dbo].[Gallery] Where Id = '{0}'";

        public const string SqlSelectImages = "SELECT * FROM [SportsComplex].[dbo].[Gallery]";

        //public const string SqlAddNews = "INSERT INTO [SportsComplex].[dbo].[News] ([Content],[Highlight],[PostedOn],[ExpiresOn]) VALUES('{0}','{1}','{2}','{3}')";

        public const string SqlAddNews = "INSERT INTO [SportsComplex].[dbo].[News] ([Content],[Highlight],[PostedOn],[ExpiresOn]) VALUES('{0}','{1}',convert(date , '{2}' , 105),convert(date , '{3}' , 105))";

        public const string SqlDeleteNews = "DELETE FROM [SportsComplex].[dbo].[News] Where Id = '{0}'";

        public const string SqlSelectNews = "SELECT * FROM [SportsComplex].[dbo].[News]";

        public const string SqlAddGym = "INSERT INTO [SportsComplex].[dbo].[Gym] ([PsNumber],[TransactionDate],[Joined],[JoinedOn],[LeftOn]) VALUES('{0}',convert(date , '{1}' , 105),'{2}',convert(date , '{3}' , 105),convert(date , '{4}' , 105))";

        //public const string SqlAddGym = "INSERT INTO [SportsComplex].[dbo].[Gym] ([PsNumber],[TransactionDate],[Joined],[JoinedOn],[LeftOn]) VALUES('{0}','{1}','{2}','{3}','{4}')";

        public const string SqlUpdateGym = "UPDATE [SportsComplex].[dbo].[Gym] SET [TransactionDate] = convert(date , '{0}' , 105),[Joined] = '{1}',[LeftOn] = convert(date , '{2}' , 105) WHERE Id='{3}'";

        //public const string SqlUpdateGym = "UPDATE [SportsComplex].[dbo].[Gym] SET [TransactionDate] = '{0}',[Joined] = '{1}',[LeftOn] = '{2}' WHERE Id='{3}'";

        public const string SqlSelectGymByPsNumber = "SELECT * FROM [SportsComplex].[dbo].[Gym] Where Joined = 1 AND PsNumber='{0}'";

        public const string SqlSelectGmyById = "SELECT * FROM [SportsComplex].[dbo].[Gym] Where Id ='{0}'";

        public const string SqlAddTournment = "INSERT INTO [SportsComplex].[dbo].[Tournment] ([Name],[Fees],[CreatedDate],[TournmentDate],[LastDate],[IsDeleted]) VALUES('{0}','{1}',convert(date , '{2}' , 105),convert(date , '{3}' , 105),convert(date , '{4}' , 105), '{5}')";

        //public const string SqlAddTournment = "INSERT INTO [SportsComplex].[dbo].[Tournment] ([Name],[Fees],[CreatedDate],[TournmentDate],[LastDate],[IsDeleted]) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')";

        public const string SqlDeleteTournment = "DELETE FROM [SportsComplex].[dbo].[Tournment] Where Id = '{0}'";

        public const string SqlUpdateTournmentForDelete = "UPDATE [SportsComplex].[dbo].[Tournment] SET [IsDeleted] = '{0}' Where Id = '{1}'";

        public const string SqlSelectTournment = "SELECT * FROM [SportsComplex].[dbo].[Tournment]";

        //public const string SqlBookTournment = "INSERT INTO [SportsComplex].[dbo].[TournmentBooking] ([TournmentId],[PsNumber],[TransactionDate]) VALUES('{0}','{1}','{2}')";

        public const string SqlBookTournment = "INSERT INTO [SportsComplex].[dbo].[TournmentBooking] ([TournmentId],[PsNumber],[TransactionDate]) VALUES('{0}','{1}','convert(date , '{2}' , 105)')";

        public const string SqlSelectTournmentBookingByPsNumber = "SELECT * FROM [SportsComplex].[dbo].[TournmentBooking] Where PsNumber='{0}'";

        public const string SqlSelectBadmintonCharge = "SELECT * FROM [SportsComplex].[dbo].[BadmintonResource] Where MONTH([BOOKDATE])='{0}' AND YEAR([BOOKDATE])='{1}'";

        public const string SqlSelectBilliardsCharge = "SELECT * FROM [SportsComplex].[dbo].[BilliardResource] Where MONTH([BOOKDATE])='{0}' AND YEAR([BOOKDATE])='{1}'";

        public const string SqlSelectGymChargeEmployee = "SELECT * FROM [SportsComplex].[dbo].[Gym] Where MONTH([TransactionDate])='{0}' AND YEAR([TransactionDate])='{1}' AND PsNumber='{2}'";
        
        public const string SqlSelectTournmentChargeEmployee = "SELECT T.Name, T.Fees, B.TransactionDate FROM [SportsComplex].[dbo].[TournmentBooking] as B INNER JOIN [SportsComplex].[dbo].[Tournment] as T ON B.TournmentId = T.Id Where MONTH(B.TransactionDate)='{0}' AND YEAR(B.TransactionDate)='{1}' AND PsNumber='{2}'";
        
        public const string SqlSelectGymChargeAdmin = "SELECT G.Joined, G.JoinedOn,G.LeftOn, G.TransactionDate, E.Name, E.PsNumber FROM [SportsComplex].[dbo].[Gym] as G INNER JOIN [SportsComplex].[dbo].[Employees] as E ON G.PsNumber = E.PsNumber Where MONTH(G.TransactionDate)='{0}' AND YEAR(G.TransactionDate)='{1}'";
        
        public const string SqlSelectTournmentChargeAdmin = "SELECT T.Name as TName, T.Fees, B.TransactionDate, E.Name as EName,E.PsNumber FROM [SportsComplex].[dbo].[TournmentBooking] as B INNER JOIN [SportsComplex].[dbo].[Tournment] as T ON B.TournmentId = T.Id INNER JOIN [SportsComplex].[dbo].[Employees] as E ON B.PsNumber = E.PsNumber Where MONTH(B.TransactionDate)='{0}' AND YEAR(B.TransactionDate)='{1}'";
        
        #endregion
    }
}
