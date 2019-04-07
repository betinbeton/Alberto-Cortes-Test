

/****** Object:  StoredProcedure [dbo].[TG_insertUser]    ******/

IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'TG_insertUser')
BEGIN
    DROP PROCEDURE dbo.TG_insertUser
END

GO

-- =============================================
-- Author:		<ALberto Cortes, >
-- Create date: <2019-04-06>
-- Description:	<Insert a new user>
-- Params:		<@Name = name of the user>
--				<@LastName = last name of the user>
--				<@Email = email of the user>
--				<@Password = password of the user>
-- =============================================
create PROCEDURE [dbo].[TG_insertUser]
	@Name varchar(100),
	@LastName varchar(100),
	@Email varchar(100),
	@Password varchar(100)


AS
BEGIN
	
	SET NOCOUNT ON;
		Begin Try


		insert into TG_User
		(
			[Name],
			LastName,
			Email,
			[Password],
			Active
		)
		values
		(
			 @Name,
			 @LastName,
			 @Email,
			 @Password,
			 1
		)
		--We get the last inserted id	
		declare @result varchar(100)
		set @result=@@Identity
		 --Return the last inserted id
		select @result as Message

		End Try
			Begin Catch
			  declare @error int, @message varchar(4000), @xstate int;
				select @error = ERROR_NUMBER(),
						 @message = ERROR_MESSAGE()
				 raiserror ('TG_insertUser : %d: %s', 16, 1, @error, @message) ;
		End Catch


END

GO

/****** Object:  StoredProcedure [dbo].[TG_insertUser]    ******/

/****** Object:  StoredProcedure [dbo].[TG_deleteUserLogic]    ******/

IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'TG_deleteUserLogic')
BEGIN
    DROP PROCEDURE dbo.TG_deleteUserLogic
END

GO

-- =============================================
-- Author:		<ALberto Cortes, >
-- Create date: <2019-04-06>
-- Description:	<This is a logic delete>
-- Params:		<@UserId = User id is a Identity>
-- =============================================
create PROCEDURE [dbo].[TG_deleteUserLogic]
	@UserId int



AS
BEGIN
	
	SET NOCOUNT ON;
		Begin Try


		update TG_User
			set Active =0
		where
			TG_User_id =@UserId

		End Try
			Begin Catch
			  declare @error int, @message varchar(4000), @xstate int;
				select @error = ERROR_NUMBER(),
						 @message = ERROR_MESSAGE()
				 raiserror ('TG_deleteUserLogic : %d: %s', 16, 1, @error, @message) ;
		End Catch


END

GO

/****** Object:  StoredProcedure [dbo].[TG_deleteUserLogic]    ******/

/****** Object:  StoredProcedure [dbo].[TG_deleteUser]    ******/

IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'TG_deleteUser')
BEGIN
    DROP PROCEDURE dbo.TG_deleteUser
END

GO

-- =============================================
-- Author:		<ALberto Cortes, >
-- Create date: <2019-04-06>
-- Description:	<This is a physical delete>
-- Params:		<@UserId = User id is a Identity>
-- =============================================
create PROCEDURE [dbo].[TG_deleteUser]
	@UserId int


AS
BEGIN
	
	SET NOCOUNT ON;
		Begin Try

		delete from TG_User 
		where TG_User_Id =@UserId

		End Try
			Begin Catch
			  declare @error int, @message varchar(4000), @xstate int;
				select @error = ERROR_NUMBER(),
						 @message = ERROR_MESSAGE()
				 raiserror ('TG_deleteUser : %d: %s', 16, 1, @error, @message) ;
		End Catch


END

GO

/****** Object:  StoredProcedure [dbo].[TG_deleteUser]    ******/



/****** Object:  StoredProcedure [dbo].[TG_updateUser]    ******/

IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'TG_updateUser')
BEGIN
    DROP PROCEDURE dbo.TG_updateUser
END

GO

-- =============================================
-- Author:		<ALberto Cortes, >
-- Create date: <2019-04-06>
-- Description:	<Update user infor>
-- Params:		<@UserId = User id is a Identity>
--				<@Name = name of the user>
--				<@LastName = last name of the user>
--				<@Email = email of the user>
--				<@Password = password of the user>
-- =============================================
create PROCEDURE [dbo].[TG_updateUser]
	@UserId int,
	@Name varchar(100),
	@LastName varchar(100),
	@Email varchar(100),
	@Password varchar(100)


AS
BEGIN
	
	SET NOCOUNT ON;
		Begin Try


		update TG_User
		set
			[Name] = @Name,
			LastName = @LastName,
			Email = @Email ,
			[Password] = @Password
		where
			TG_User_Id = @UserId
			
	

		End Try
			Begin Catch
			  declare @error int, @message varchar(4000), @xstate int;
				select @error = ERROR_NUMBER(),
						 @message = ERROR_MESSAGE()
				 raiserror ('TG_updateUser : %d: %s', 16, 1, @error, @message) ;
		End Catch


END

GO

/****** Object:  StoredProcedure [dbo].[TG_updateUser]    ******/


/****** Object:  StoredProcedure [dbo].[TG_selectAllUsers]    ******/

IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'TG_selectAllUsers')
BEGIN
    DROP PROCEDURE dbo.TG_selectAllUsers
END

GO

-- =============================================
-- Author:		<ALberto Cortes, >
-- Create date: <2019-04-06>
-- Description:	<get all the users from the table>
-- =============================================
create PROCEDURE [dbo].[TG_selectAllUsers]

AS
BEGIN
	
	SET NOCOUNT ON;
		Begin Try


		select 
			TG_User_Id as userId,
			[Name] as name,
			LastName as lastName,
			Email as email ,
			[Password] as password,
			Active as active
		from 
			TG_User with(nolock)
		


		End Try
			Begin Catch
			  declare @error int, @message varchar(4000), @xstate int;
				select @error = ERROR_NUMBER(),
						 @message = ERROR_MESSAGE()
				 raiserror ('TG_selectAllUsers: %d: %s', 16, 1, @error, @message) ;
		End Catch


END

GO

/****** Object:  StoredProcedure [dbo].[TG_selectAllUsers]    ******/


/****** Object:  StoredProcedure [dbo].[TG_selectUser]    ******/

IF EXISTS(SELECT 1 FROM sys.procedures 
          WHERE Name = 'TG_selectUser')
BEGIN
    DROP PROCEDURE dbo.TG_selectUser
END

GO

-- =============================================
-- Author:		<ALberto Cortes, >
-- Create date: <2019-04-06>
-- Description:	<get user info>
-- Params:		<@UserId = User id is a Identity>
-- =============================================
create PROCEDURE [dbo].[TG_selectUser]
	@UserId int
AS
BEGIN
	
	SET NOCOUNT ON;
		Begin Try


		select 
			TG_User_Id as userId,
			[Name] as name,
			LastName as lastName,
			Email as email ,
			[Password] as password,
			Active as active
		from 
			TG_User with(nolock)
		where 
			TG_User_Id = @UserId


		End Try
			Begin Catch
			  declare @error int, @message varchar(4000), @xstate int;
				select @error = ERROR_NUMBER(),
						 @message = ERROR_MESSAGE()
				 raiserror ('TG_selectAllUsers: %d: %s', 16, 1, @error, @message) ;
		End Catch


END

GO

/****** Object:  StoredProcedure [dbo].[TG_selectAllUsers]    ******/