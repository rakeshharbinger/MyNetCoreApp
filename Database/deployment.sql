USE [NetCoreDB]
GO
/****** Object:  Table [dbo].[ApplicationUser]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Add_User]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[sp_Add_User] 
	-- Add the parameters for the stored procedure here
	@FirstName VARCHAR(100), 
	@LastName VARCHAR (100),
	@Email VARCHAR (100),
	@Password VARCHAR (100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
   SET NOCOUNT ON;
   IF NOT EXISTS (Select 1 from ApplicationUser where Email = @Email)
   BEGIN
	   INSERT INTO ApplicationUser (FirstName, LastName, Email, PASSWORD)
	   VALUES (@FirstName, @LastName, @Email, @Password)
   END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create   PROCEDURE [dbo].[sp_DeleteUser] 
	-- Add the parameters for the stored procedure here
	@UserId Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
   SET NOCOUNT ON;
   IF EXISTS (Select 1 from ApplicationUser where UserId = @UserId)
   BEGIN
	   Delete ApplicationUser Where UserId=@UserId
   END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Edit_User]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create   PROCEDURE [dbo].[sp_Edit_User] 
	-- Add the parameters for the stored procedure here
	@UserId Int,
	@FirstName VARCHAR(100), 
	@LastName VARCHAR (100),
	@Email VARCHAR (100),
	@Password VARCHAR (100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
   SET NOCOUNT ON;
   IF EXISTS (Select 1 from ApplicationUser where UserId = @UserId)
   BEGIN
	   Update ApplicationUser
	   SET FirstName = @FirstName, 
	   LastName = @LastName,
	   Email = @Email,
	   Password = @Password
	   Where UserId=@UserId
   END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUser]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROCEDURE [dbo].[sp_GetUser] 
	@UserId varchar(100)
AS
BEGIN
	
	SET NOCOUNT ON;
	Select UserId, FirstName, LastName, Email, Password from ApplicationUser where UserId = @UserId;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUsers]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUsers] 
AS
BEGIN
	Select UserId, FirstName, LastName, Email from ApplicationUser
END
GO
/****** Object:  StoredProcedure [dbo].[sp_IsUserExist]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_IsUserExist] 
	@Email varchar(100)
AS
BEGIN
	
	SET NOCOUNT ON;
	IF Exists (select 1 from ApplicationUser where Email = @Email)
	BEGIN
	select 1
	END
	ELSE
	BEGIN
	select 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ValidateUser]    Script Date: 12-07-2021 15:35:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ValidateUser] 
	@Email varchar(100),
	@Password varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT * from ApplicationUser where Email= @Email and Password = @Password
END
GO
