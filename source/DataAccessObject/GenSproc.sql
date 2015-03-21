
/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AWBuildVersionDeleteByAWBuildVersionID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AWBuildVersionDeleteByAWBuildVersionID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AWBuildVersionDeleteByAWBuildVersionID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE AWBuildVersionDeleteByAWBuildVersionID 
     @SystemInformationID tinyint

AS 
     SET NOCOUNT ON;

 DELETE FROM AWBuildVersion 
WHERE SystemInformationID = @SystemInformationID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AWBuildVersionSelectByAWBuildVersionID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AWBuildVersionSelectByAWBuildVersionID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AWBuildVersionSelectByAWBuildVersionID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE AWBuildVersionSelectByAWBuildVersionID 
     @SystemInformationID tinyint

AS 
 SET NOCOUNT ON;
SELECT * FROM AWBuildVersion 
WHERE SystemInformationID = @SystemInformationID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     AWBuildVersionInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AWBuildVersionInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AWBuildVersionInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE AWBuildVersionInsert
            
           @Database Version nvarchar
         , @VersionDate datetime
         , @ModifiedDate datetime
        ,@SystemInformationID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO AWBuildVersion 
         (
             Database Version
         , VersionDate
         , ModifiedDate

         ) VALUES (
             @Database Version
         , @VersionDate
         , @ModifiedDate
         
        )
        SELECT @SystemInformationID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AWBuildVersionUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'AWBuildVersionUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  AWBuildVersionUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE AWBuildVersionUpdate
            @SystemInformationID tinyint
         , @Database Version nvarchar
         , @VersionDate datetime
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE AWBuildVersion SET
             Database Version = @Database Version
          , VersionDate = @VersionDate
          , ModifiedDate = @ModifiedDate
      WHERE SystemInformationID = @SystemInformationID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DatabaseLogDeleteByDatabaseLogID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DatabaseLogDeleteByDatabaseLogID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DatabaseLogDeleteByDatabaseLogID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE DatabaseLogDeleteByDatabaseLogID 
     @DatabaseLogID int

AS 
     SET NOCOUNT ON;

 DELETE FROM DatabaseLog 
WHERE DatabaseLogID = @DatabaseLogID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DatabaseLogSelectByDatabaseLogID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DatabaseLogSelectByDatabaseLogID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DatabaseLogSelectByDatabaseLogID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE DatabaseLogSelectByDatabaseLogID 
     @DatabaseLogID int

AS 
 SET NOCOUNT ON;
SELECT * FROM DatabaseLog 
WHERE DatabaseLogID = @DatabaseLogID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     DatabaseLogInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DatabaseLogInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DatabaseLogInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE DatabaseLogInsert
            
           @PostTime datetime
         , @DatabaseUser sysname
         , @Event sysname
         , @Schema sysname
         , @Object sysname
         , @TSQL nvarchar
         , @XmlEvent 
        ,@DatabaseLogID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO DatabaseLog 
         (
             PostTime
         , DatabaseUser
         , Event
         , Schema
         , Object
         , TSQL
         , XmlEvent

         ) VALUES (
             @PostTime
         , @DatabaseUser
         , @Event
         , @Schema
         , @Object
         , @TSQL
         , @XmlEvent
         
        )
        SELECT @DatabaseLogID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DatabaseLogUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'DatabaseLogUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  DatabaseLogUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE DatabaseLogUpdate
            @DatabaseLogID int
         , @PostTime datetime
         , @DatabaseUser sysname
         , @Event sysname
         , @Schema sysname
         , @Object sysname
         , @TSQL nvarchar
         , @XmlEvent 
    
         AS 
         SET NOCOUNT ON
         UPDATE DatabaseLog SET
             PostTime = @PostTime
          , DatabaseUser = @DatabaseUser
          , Event = @Event
          , Schema = @Schema
          , Object = @Object
          , TSQL = @TSQL
          , XmlEvent = @XmlEvent
      WHERE DatabaseLogID = @DatabaseLogID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ErrorLogDeleteByErrorLogID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ErrorLogDeleteByErrorLogID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ErrorLogDeleteByErrorLogID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ErrorLogDeleteByErrorLogID 
     @ErrorLogID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ErrorLog 
WHERE ErrorLogID = @ErrorLogID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ErrorLogSelectByErrorLogID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ErrorLogSelectByErrorLogID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ErrorLogSelectByErrorLogID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ErrorLogSelectByErrorLogID 
     @ErrorLogID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ErrorLog 
WHERE ErrorLogID = @ErrorLogID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ErrorLogInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ErrorLogInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ErrorLogInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ErrorLogInsert
            
           @ErrorTime datetime
         , @UserName sysname
         , @ErrorNumber int
         , @ErrorSeverity int
         , @ErrorState int
         , @ErrorProcedure nvarchar
         , @ErrorLine int
         , @ErrorMessage nvarchar
        ,@ErrorLogID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ErrorLog 
         (
             ErrorTime
         , UserName
         , ErrorNumber
         , ErrorSeverity
         , ErrorState
         , ErrorProcedure
         , ErrorLine
         , ErrorMessage

         ) VALUES (
             @ErrorTime
         , @UserName
         , @ErrorNumber
         , @ErrorSeverity
         , @ErrorState
         , @ErrorProcedure
         , @ErrorLine
         , @ErrorMessage
         
        )
        SELECT @ErrorLogID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ErrorLogUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ErrorLogUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ErrorLogUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ErrorLogUpdate
            @ErrorLogID int
         , @ErrorTime datetime
         , @UserName sysname
         , @ErrorNumber int
         , @ErrorSeverity int
         , @ErrorState int
         , @ErrorProcedure nvarchar
         , @ErrorLine int
         , @ErrorMessage nvarchar
    
         AS 
         SET NOCOUNT ON
         UPDATE ErrorLog SET
             ErrorTime = @ErrorTime
          , UserName = @UserName
          , ErrorNumber = @ErrorNumber
          , ErrorSeverity = @ErrorSeverity
          , ErrorState = @ErrorState
          , ErrorProcedure = @ErrorProcedure
          , ErrorLine = @ErrorLine
          , ErrorMessage = @ErrorMessage
      WHERE ErrorLogID = @ErrorLogID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DepartmentDeleteByDepartmentID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DepartmentDeleteByDepartmentID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DepartmentDeleteByDepartmentID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE DepartmentDeleteByDepartmentID 
     @DepartmentID smallint

AS 
     SET NOCOUNT ON;

 DELETE FROM Department 
WHERE DepartmentID = @DepartmentID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DepartmentSelectByDepartmentID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DepartmentSelectByDepartmentID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DepartmentSelectByDepartmentID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE DepartmentSelectByDepartmentID 
     @DepartmentID smallint

AS 
 SET NOCOUNT ON;
SELECT * FROM Department 
WHERE DepartmentID = @DepartmentID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     DepartmentInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DepartmentInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DepartmentInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE DepartmentInsert
            
           @Name Name
         , @GroupName Name
         , @ModifiedDate datetime
        ,@DepartmentID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Department 
         (
             Name
         , GroupName
         , ModifiedDate

         ) VALUES (
             @Name
         , @GroupName
         , @ModifiedDate
         
        )
        SELECT @DepartmentID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DepartmentUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'DepartmentUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  DepartmentUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE DepartmentUpdate
            @DepartmentID smallint
         , @Name Name
         , @GroupName Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Department SET
             Name = @Name
          , GroupName = @GroupName
          , ModifiedDate = @ModifiedDate
      WHERE DepartmentID = @DepartmentID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeDeleteByEmployeeID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeDeleteByEmployeeID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeDeleteByEmployeeID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeeDeleteByEmployeeID 
     @EmployeeID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Employee 
WHERE EmployeeID = @EmployeeID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeSelectByEmployeeID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeSelectByEmployeeID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeSelectByEmployeeID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeeSelectByEmployeeID 
     @EmployeeID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Employee 
WHERE EmployeeID = @EmployeeID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     EmployeeInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE EmployeeInsert
            
           @NationalIDNumber nvarchar
         , @ContactID int
         , @LoginID nvarchar
         , @ManagerID int
         , @Title nvarchar
         , @BirthDate datetime
         , @MaritalStatus nchar
         , @Gender nchar
         , @HireDate datetime
         , @SalariedFlag Flag
         , @VacationHours smallint
         , @SickLeaveHours smallint
         , @CurrentFlag Flag
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@EmployeeID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Employee 
         (
             NationalIDNumber
         , ContactID
         , LoginID
         , ManagerID
         , Title
         , BirthDate
         , MaritalStatus
         , Gender
         , HireDate
         , SalariedFlag
         , VacationHours
         , SickLeaveHours
         , CurrentFlag
         , rowguid
         , ModifiedDate

         ) VALUES (
             @NationalIDNumber
         , @ContactID
         , @LoginID
         , @ManagerID
         , @Title
         , @BirthDate
         , @MaritalStatus
         , @Gender
         , @HireDate
         , @SalariedFlag
         , @VacationHours
         , @SickLeaveHours
         , @CurrentFlag
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @EmployeeID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'EmployeeUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  EmployeeUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE EmployeeUpdate
            @EmployeeID int
         , @NationalIDNumber nvarchar
         , @ContactID int
         , @LoginID nvarchar
         , @ManagerID int
         , @Title nvarchar
         , @BirthDate datetime
         , @MaritalStatus nchar
         , @Gender nchar
         , @HireDate datetime
         , @SalariedFlag Flag
         , @VacationHours smallint
         , @SickLeaveHours smallint
         , @CurrentFlag Flag
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Employee SET
             NationalIDNumber = @NationalIDNumber
          , ContactID = @ContactID
          , LoginID = @LoginID
          , ManagerID = @ManagerID
          , Title = @Title
          , BirthDate = @BirthDate
          , MaritalStatus = @MaritalStatus
          , Gender = @Gender
          , HireDate = @HireDate
          , SalariedFlag = @SalariedFlag
          , VacationHours = @VacationHours
          , SickLeaveHours = @SickLeaveHours
          , CurrentFlag = @CurrentFlag
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE EmployeeID = @EmployeeID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeAddressDeleteByEmployeeAddressID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeAddressDeleteByEmployeeAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeAddressDeleteByEmployeeAddressID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeeAddressDeleteByEmployeeAddressID 
     @EmployeeID int,
     @AddressID int

AS 
     SET NOCOUNT ON;

 DELETE FROM EmployeeAddress 
WHERE EmployeeID = @EmployeeID
 AND AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeAddressSelectByEmployeeAddressID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeAddressSelectByEmployeeAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeAddressSelectByEmployeeAddressID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeeAddressSelectByEmployeeAddressID 
     @EmployeeID int,
     @AddressID int

AS 
 SET NOCOUNT ON;
SELECT * FROM EmployeeAddress 
WHERE EmployeeID = @EmployeeID
 AND AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     EmployeeAddressInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeAddressInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeAddressInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE EmployeeAddressInsert
               @EmployeeID int
         , @AddressID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO EmployeeAddress 
         (
             EmployeeID
         , AddressID
         , rowguid
         , ModifiedDate

         ) VALUES (
             @EmployeeID
         , @AddressID
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeAddressUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'EmployeeAddressUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  EmployeeAddressUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE EmployeeAddressUpdate
            @EmployeeID int
         , @AddressID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE EmployeeAddress SET
             rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE EmployeeID = @EmployeeID , AddressID = @AddressID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeDepartmentHistoryDeleteByEmployeeDepartmentHistoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeDepartmentHistoryDeleteByEmployeeDepartmentHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeDepartmentHistoryDeleteByEmployeeDepartmentHistoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeeDepartmentHistoryDeleteByEmployeeDepartmentHistoryID 
     @EmployeeID int,
     @DepartmentID smallint,
     @ShiftID tinyint,
     @StartDate datetime

AS 
     SET NOCOUNT ON;

 DELETE FROM EmployeeDepartmentHistory 
WHERE EmployeeID = @EmployeeID
 AND DepartmentID = @DepartmentID
 AND ShiftID = @ShiftID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeDepartmentHistorySelectByEmployeeDepartmentHistoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeDepartmentHistorySelectByEmployeeDepartmentHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeDepartmentHistorySelectByEmployeeDepartmentHistoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeeDepartmentHistorySelectByEmployeeDepartmentHistoryID 
     @EmployeeID int,
     @DepartmentID smallint,
     @ShiftID tinyint,
     @StartDate datetime

AS 
 SET NOCOUNT ON;
SELECT * FROM EmployeeDepartmentHistory 
WHERE EmployeeID = @EmployeeID
 AND DepartmentID = @DepartmentID
 AND ShiftID = @ShiftID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     EmployeeDepartmentHistoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeeDepartmentHistoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeeDepartmentHistoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE EmployeeDepartmentHistoryInsert
               @EmployeeID int
         , @DepartmentID smallint
         , @ShiftID tinyint
         , @StartDate datetime
         , @EndDate datetime
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO EmployeeDepartmentHistory 
         (
             EmployeeID
         , DepartmentID
         , ShiftID
         , StartDate
         , EndDate
         , ModifiedDate

         ) VALUES (
             @EmployeeID
         , @DepartmentID
         , @ShiftID
         , @StartDate
         , @EndDate
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeeDepartmentHistoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'EmployeeDepartmentHistoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  EmployeeDepartmentHistoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE EmployeeDepartmentHistoryUpdate
            @EmployeeID int
         , @DepartmentID smallint
         , @ShiftID tinyint
         , @StartDate datetime
         , @EndDate datetime
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE EmployeeDepartmentHistory SET
             EndDate = @EndDate
          , ModifiedDate = @ModifiedDate
      WHERE EmployeeID = @EmployeeID , DepartmentID = @DepartmentID , ShiftID = @ShiftID , StartDate = @StartDate 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeePayHistoryDeleteByEmployeePayHistoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeePayHistoryDeleteByEmployeePayHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeePayHistoryDeleteByEmployeePayHistoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeePayHistoryDeleteByEmployeePayHistoryID 
     @EmployeeID int,
     @RateChangeDate datetime

AS 
     SET NOCOUNT ON;

 DELETE FROM EmployeePayHistory 
WHERE EmployeeID = @EmployeeID
 AND RateChangeDate = @RateChangeDate

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeePayHistorySelectByEmployeePayHistoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeePayHistorySelectByEmployeePayHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeePayHistorySelectByEmployeePayHistoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE EmployeePayHistorySelectByEmployeePayHistoryID 
     @EmployeeID int,
     @RateChangeDate datetime

AS 
 SET NOCOUNT ON;
SELECT * FROM EmployeePayHistory 
WHERE EmployeeID = @EmployeeID
 AND RateChangeDate = @RateChangeDate

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     EmployeePayHistoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'EmployeePayHistoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  EmployeePayHistoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE EmployeePayHistoryInsert
               @EmployeeID int
         , @RateChangeDate datetime
         , @Rate money
         , @PayFrequency tinyint
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO EmployeePayHistory 
         (
             EmployeeID
         , RateChangeDate
         , Rate
         , PayFrequency
         , ModifiedDate

         ) VALUES (
             @EmployeeID
         , @RateChangeDate
         , @Rate
         , @PayFrequency
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     EmployeePayHistoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'EmployeePayHistoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  EmployeePayHistoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE EmployeePayHistoryUpdate
            @EmployeeID int
         , @RateChangeDate datetime
         , @Rate money
         , @PayFrequency tinyint
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE EmployeePayHistory SET
             Rate = @Rate
          , PayFrequency = @PayFrequency
          , ModifiedDate = @ModifiedDate
      WHERE EmployeeID = @EmployeeID , RateChangeDate = @RateChangeDate 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     JobCandidateDeleteByJobCandidateID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'JobCandidateDeleteByJobCandidateID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  JobCandidateDeleteByJobCandidateID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE JobCandidateDeleteByJobCandidateID 
     @JobCandidateID int

AS 
     SET NOCOUNT ON;

 DELETE FROM JobCandidate 
WHERE JobCandidateID = @JobCandidateID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     JobCandidateSelectByJobCandidateID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'JobCandidateSelectByJobCandidateID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  JobCandidateSelectByJobCandidateID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE JobCandidateSelectByJobCandidateID 
     @JobCandidateID int

AS 
 SET NOCOUNT ON;
SELECT * FROM JobCandidate 
WHERE JobCandidateID = @JobCandidateID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     JobCandidateInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'JobCandidateInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  JobCandidateInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE JobCandidateInsert
            
           @EmployeeID int
         , @Resume HRResumeSchemaCollection
         , @ModifiedDate datetime
        ,@JobCandidateID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO JobCandidate 
         (
             EmployeeID
         , Resume
         , ModifiedDate

         ) VALUES (
             @EmployeeID
         , @Resume
         , @ModifiedDate
         
        )
        SELECT @JobCandidateID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     JobCandidateUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'JobCandidateUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  JobCandidateUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE JobCandidateUpdate
            @JobCandidateID int
         , @EmployeeID int
         , @Resume HRResumeSchemaCollection
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE JobCandidate SET
             EmployeeID = @EmployeeID
          , Resume = @Resume
          , ModifiedDate = @ModifiedDate
      WHERE JobCandidateID = @JobCandidateID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShiftDeleteByShiftID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShiftDeleteByShiftID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShiftDeleteByShiftID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ShiftDeleteByShiftID 
     @ShiftID tinyint

AS 
     SET NOCOUNT ON;

 DELETE FROM Shift 
WHERE ShiftID = @ShiftID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShiftSelectByShiftID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShiftSelectByShiftID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShiftSelectByShiftID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ShiftSelectByShiftID 
     @ShiftID tinyint

AS 
 SET NOCOUNT ON;
SELECT * FROM Shift 
WHERE ShiftID = @ShiftID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ShiftInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShiftInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShiftInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ShiftInsert
            
           @Name Name
         , @StartTime datetime
         , @EndTime datetime
         , @ModifiedDate datetime
        ,@ShiftID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Shift 
         (
             Name
         , StartTime
         , EndTime
         , ModifiedDate

         ) VALUES (
             @Name
         , @StartTime
         , @EndTime
         , @ModifiedDate
         
        )
        SELECT @ShiftID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShiftUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ShiftUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ShiftUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ShiftUpdate
            @ShiftID tinyint
         , @Name Name
         , @StartTime datetime
         , @EndTime datetime
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Shift SET
             Name = @Name
          , StartTime = @StartTime
          , EndTime = @EndTime
          , ModifiedDate = @ModifiedDate
      WHERE ShiftID = @ShiftID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AddressDeleteByAddressID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AddressDeleteByAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AddressDeleteByAddressID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE AddressDeleteByAddressID 
     @AddressID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Address 
WHERE AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AddressSelectByAddressID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AddressSelectByAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AddressSelectByAddressID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE AddressSelectByAddressID 
     @AddressID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Address 
WHERE AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     AddressInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AddressInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AddressInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE AddressInsert
            
           @AddressLine1 nvarchar
         , @AddressLine2 nvarchar
         , @City nvarchar
         , @StateProvinceID int
         , @PostalCode nvarchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@AddressID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Address 
         (
             AddressLine1
         , AddressLine2
         , City
         , StateProvinceID
         , PostalCode
         , rowguid
         , ModifiedDate

         ) VALUES (
             @AddressLine1
         , @AddressLine2
         , @City
         , @StateProvinceID
         , @PostalCode
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @AddressID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AddressUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'AddressUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  AddressUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE AddressUpdate
            @AddressID int
         , @AddressLine1 nvarchar
         , @AddressLine2 nvarchar
         , @City nvarchar
         , @StateProvinceID int
         , @PostalCode nvarchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Address SET
             AddressLine1 = @AddressLine1
          , AddressLine2 = @AddressLine2
          , City = @City
          , StateProvinceID = @StateProvinceID
          , PostalCode = @PostalCode
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE AddressID = @AddressID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AddressTypeDeleteByAddressTypeID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AddressTypeDeleteByAddressTypeID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AddressTypeDeleteByAddressTypeID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE AddressTypeDeleteByAddressTypeID 
     @AddressTypeID int

AS 
     SET NOCOUNT ON;

 DELETE FROM AddressType 
WHERE AddressTypeID = @AddressTypeID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AddressTypeSelectByAddressTypeID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AddressTypeSelectByAddressTypeID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AddressTypeSelectByAddressTypeID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE AddressTypeSelectByAddressTypeID 
     @AddressTypeID int

AS 
 SET NOCOUNT ON;
SELECT * FROM AddressType 
WHERE AddressTypeID = @AddressTypeID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     AddressTypeInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'AddressTypeInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  AddressTypeInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE AddressTypeInsert
            
           @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@AddressTypeID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO AddressType 
         (
             Name
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Name
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @AddressTypeID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     AddressTypeUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'AddressTypeUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  AddressTypeUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE AddressTypeUpdate
            @AddressTypeID int
         , @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE AddressType SET
             Name = @Name
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE AddressTypeID = @AddressTypeID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactDeleteByContactID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactDeleteByContactID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactDeleteByContactID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ContactDeleteByContactID 
     @ContactID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Contact 
WHERE ContactID = @ContactID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactSelectByContactID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactSelectByContactID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactSelectByContactID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ContactSelectByContactID 
     @ContactID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Contact 
WHERE ContactID = @ContactID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ContactInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ContactInsert
            
           @NameStyle NameStyle
         , @Title nvarchar
         , @FirstName Name
         , @MiddleName Name
         , @LastName Name
         , @Suffix nvarchar
         , @EmailAddress nvarchar
         , @EmailPromotion int
         , @Phone Phone
         , @PasswordHash varchar(128)
         , @PasswordSalt varchar(10)
         , @AdditionalContactInfo AdditionalContactInfoSchemaCollection
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ContactID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Contact 
         (
             NameStyle
         , Title
         , FirstName
         , MiddleName
         , LastName
         , Suffix
         , EmailAddress
         , EmailPromotion
         , Phone
         , PasswordHash
         , PasswordSalt
         , AdditionalContactInfo
         , rowguid
         , ModifiedDate

         ) VALUES (
             @NameStyle
         , @Title
         , @FirstName
         , @MiddleName
         , @LastName
         , @Suffix
         , @EmailAddress
         , @EmailPromotion
         , @Phone
         , @PasswordHash
         , @PasswordSalt
         , @AdditionalContactInfo
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ContactID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ContactUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ContactUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ContactUpdate
            @ContactID int
         , @NameStyle NameStyle
         , @Title nvarchar
         , @FirstName Name
         , @MiddleName Name
         , @LastName Name
         , @Suffix nvarchar
         , @EmailAddress nvarchar
         , @EmailPromotion int
         , @Phone Phone
         , @PasswordHash varchar(128)
         , @PasswordSalt varchar(10)
         , @AdditionalContactInfo AdditionalContactInfoSchemaCollection
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Contact SET
             NameStyle = @NameStyle
          , Title = @Title
          , FirstName = @FirstName
          , MiddleName = @MiddleName
          , LastName = @LastName
          , Suffix = @Suffix
          , EmailAddress = @EmailAddress
          , EmailPromotion = @EmailPromotion
          , Phone = @Phone
          , PasswordHash = @PasswordHash
          , PasswordSalt = @PasswordSalt
          , AdditionalContactInfo = @AdditionalContactInfo
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ContactID = @ContactID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactTypeDeleteByContactTypeID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactTypeDeleteByContactTypeID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactTypeDeleteByContactTypeID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ContactTypeDeleteByContactTypeID 
     @ContactTypeID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ContactType 
WHERE ContactTypeID = @ContactTypeID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactTypeSelectByContactTypeID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactTypeSelectByContactTypeID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactTypeSelectByContactTypeID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ContactTypeSelectByContactTypeID 
     @ContactTypeID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ContactType 
WHERE ContactTypeID = @ContactTypeID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ContactTypeInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactTypeInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactTypeInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ContactTypeInsert
            
           @Name Name
         , @ModifiedDate datetime
        ,@ContactTypeID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ContactType 
         (
             Name
         , ModifiedDate

         ) VALUES (
             @Name
         , @ModifiedDate
         
        )
        SELECT @ContactTypeID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactTypeUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ContactTypeUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ContactTypeUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ContactTypeUpdate
            @ContactTypeID int
         , @Name Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ContactType SET
             Name = @Name
          , ModifiedDate = @ModifiedDate
      WHERE ContactTypeID = @ContactTypeID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CountryRegionDeleteByCountryRegionID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CountryRegionDeleteByCountryRegionID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CountryRegionDeleteByCountryRegionID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CountryRegionDeleteByCountryRegionID 
     @CountryRegionCode nvarchar

AS 
     SET NOCOUNT ON;

 DELETE FROM CountryRegion 
WHERE CountryRegionCode = @CountryRegionCode

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CountryRegionSelectByCountryRegionID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CountryRegionSelectByCountryRegionID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CountryRegionSelectByCountryRegionID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CountryRegionSelectByCountryRegionID 
     @CountryRegionCode nvarchar

AS 
 SET NOCOUNT ON;
SELECT * FROM CountryRegion 
WHERE CountryRegionCode = @CountryRegionCode

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CountryRegionInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CountryRegionInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CountryRegionInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CountryRegionInsert
               @CountryRegionCode nvarchar
         , @Name Name
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO CountryRegion 
         (
             CountryRegionCode
         , Name
         , ModifiedDate

         ) VALUES (
             @CountryRegionCode
         , @Name
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CountryRegionUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CountryRegionUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CountryRegionUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CountryRegionUpdate
            @CountryRegionCode nvarchar
         , @Name Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE CountryRegion SET
             Name = @Name
          , ModifiedDate = @ModifiedDate
      WHERE CountryRegionCode = @CountryRegionCode 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StateProvinceDeleteByStateProvinceID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StateProvinceDeleteByStateProvinceID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StateProvinceDeleteByStateProvinceID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE StateProvinceDeleteByStateProvinceID 
     @StateProvinceID int

AS 
     SET NOCOUNT ON;

 DELETE FROM StateProvince 
WHERE StateProvinceID = @StateProvinceID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StateProvinceSelectByStateProvinceID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StateProvinceSelectByStateProvinceID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StateProvinceSelectByStateProvinceID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE StateProvinceSelectByStateProvinceID 
     @StateProvinceID int

AS 
 SET NOCOUNT ON;
SELECT * FROM StateProvince 
WHERE StateProvinceID = @StateProvinceID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     StateProvinceInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StateProvinceInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StateProvinceInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE StateProvinceInsert
            
           @StateProvinceCode nchar
         , @CountryRegionCode nvarchar
         , @IsOnlyStateProvinceFlag Flag
         , @Name Name
         , @TerritoryID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@StateProvinceID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO StateProvince 
         (
             StateProvinceCode
         , CountryRegionCode
         , IsOnlyStateProvinceFlag
         , Name
         , TerritoryID
         , rowguid
         , ModifiedDate

         ) VALUES (
             @StateProvinceCode
         , @CountryRegionCode
         , @IsOnlyStateProvinceFlag
         , @Name
         , @TerritoryID
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @StateProvinceID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StateProvinceUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'StateProvinceUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  StateProvinceUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE StateProvinceUpdate
            @StateProvinceID int
         , @StateProvinceCode nchar
         , @CountryRegionCode nvarchar
         , @IsOnlyStateProvinceFlag Flag
         , @Name Name
         , @TerritoryID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE StateProvince SET
             StateProvinceCode = @StateProvinceCode
          , CountryRegionCode = @CountryRegionCode
          , IsOnlyStateProvinceFlag = @IsOnlyStateProvinceFlag
          , Name = @Name
          , TerritoryID = @TerritoryID
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE StateProvinceID = @StateProvinceID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     BillOfMaterialsDeleteByBillOfMaterialsID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'BillOfMaterialsDeleteByBillOfMaterialsID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  BillOfMaterialsDeleteByBillOfMaterialsID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE BillOfMaterialsDeleteByBillOfMaterialsID 
     @BillOfMaterialsID int

AS 
     SET NOCOUNT ON;

 DELETE FROM BillOfMaterials 
WHERE BillOfMaterialsID = @BillOfMaterialsID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     BillOfMaterialsSelectByBillOfMaterialsID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'BillOfMaterialsSelectByBillOfMaterialsID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  BillOfMaterialsSelectByBillOfMaterialsID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE BillOfMaterialsSelectByBillOfMaterialsID 
     @BillOfMaterialsID int

AS 
 SET NOCOUNT ON;
SELECT * FROM BillOfMaterials 
WHERE BillOfMaterialsID = @BillOfMaterialsID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     BillOfMaterialsInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'BillOfMaterialsInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  BillOfMaterialsInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE BillOfMaterialsInsert
            
           @ProductAssemblyID int
         , @ComponentID int
         , @StartDate datetime
         , @EndDate datetime
         , @UnitMeasureCode nchar
         , @BOMLevel smallint
         , @PerAssemblyQty decimal
         , @ModifiedDate datetime
        ,@BillOfMaterialsID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO BillOfMaterials 
         (
             ProductAssemblyID
         , ComponentID
         , StartDate
         , EndDate
         , UnitMeasureCode
         , BOMLevel
         , PerAssemblyQty
         , ModifiedDate

         ) VALUES (
             @ProductAssemblyID
         , @ComponentID
         , @StartDate
         , @EndDate
         , @UnitMeasureCode
         , @BOMLevel
         , @PerAssemblyQty
         , @ModifiedDate
         
        )
        SELECT @BillOfMaterialsID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     BillOfMaterialsUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'BillOfMaterialsUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  BillOfMaterialsUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE BillOfMaterialsUpdate
            @BillOfMaterialsID int
         , @ProductAssemblyID int
         , @ComponentID int
         , @StartDate datetime
         , @EndDate datetime
         , @UnitMeasureCode nchar
         , @BOMLevel smallint
         , @PerAssemblyQty decimal
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE BillOfMaterials SET
             ProductAssemblyID = @ProductAssemblyID
          , ComponentID = @ComponentID
          , StartDate = @StartDate
          , EndDate = @EndDate
          , UnitMeasureCode = @UnitMeasureCode
          , BOMLevel = @BOMLevel
          , PerAssemblyQty = @PerAssemblyQty
          , ModifiedDate = @ModifiedDate
      WHERE BillOfMaterialsID = @BillOfMaterialsID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CultureDeleteByCultureID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CultureDeleteByCultureID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CultureDeleteByCultureID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CultureDeleteByCultureID 
     @CultureID nchar

AS 
     SET NOCOUNT ON;

 DELETE FROM Culture 
WHERE CultureID = @CultureID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CultureSelectByCultureID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CultureSelectByCultureID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CultureSelectByCultureID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CultureSelectByCultureID 
     @CultureID nchar

AS 
 SET NOCOUNT ON;
SELECT * FROM Culture 
WHERE CultureID = @CultureID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CultureInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CultureInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CultureInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CultureInsert
               @CultureID nchar
         , @Name Name
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Culture 
         (
             CultureID
         , Name
         , ModifiedDate

         ) VALUES (
             @CultureID
         , @Name
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CultureUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CultureUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CultureUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CultureUpdate
            @CultureID nchar
         , @Name Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Culture SET
             Name = @Name
          , ModifiedDate = @ModifiedDate
      WHERE CultureID = @CultureID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DocumentDeleteByDocumentID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DocumentDeleteByDocumentID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DocumentDeleteByDocumentID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE DocumentDeleteByDocumentID 
     @DocumentID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Document 
WHERE DocumentID = @DocumentID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DocumentSelectByDocumentID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DocumentSelectByDocumentID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DocumentSelectByDocumentID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE DocumentSelectByDocumentID 
     @DocumentID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Document 
WHERE DocumentID = @DocumentID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     DocumentInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'DocumentInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  DocumentInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE DocumentInsert
            
           @Title nvarchar
         , @FileName nvarchar
         , @FileExtension nvarchar
         , @Revision nchar
         , @ChangeNumber int
         , @Status tinyint
         , @DocumentSummary nvarchar
         , @Document varbinary
         , @ModifiedDate datetime
        ,@DocumentID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Document 
         (
             Title
         , FileName
         , FileExtension
         , Revision
         , ChangeNumber
         , Status
         , DocumentSummary
         , Document
         , ModifiedDate

         ) VALUES (
             @Title
         , @FileName
         , @FileExtension
         , @Revision
         , @ChangeNumber
         , @Status
         , @DocumentSummary
         , @Document
         , @ModifiedDate
         
        )
        SELECT @DocumentID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     DocumentUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'DocumentUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  DocumentUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE DocumentUpdate
            @DocumentID int
         , @Title nvarchar
         , @FileName nvarchar
         , @FileExtension nvarchar
         , @Revision nchar
         , @ChangeNumber int
         , @Status tinyint
         , @DocumentSummary nvarchar
         , @Document varbinary
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Document SET
             Title = @Title
          , FileName = @FileName
          , FileExtension = @FileExtension
          , Revision = @Revision
          , ChangeNumber = @ChangeNumber
          , Status = @Status
          , DocumentSummary = @DocumentSummary
          , Document = @Document
          , ModifiedDate = @ModifiedDate
      WHERE DocumentID = @DocumentID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     IllustrationDeleteByIllustrationID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'IllustrationDeleteByIllustrationID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  IllustrationDeleteByIllustrationID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE IllustrationDeleteByIllustrationID 
     @IllustrationID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Illustration 
WHERE IllustrationID = @IllustrationID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     IllustrationSelectByIllustrationID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'IllustrationSelectByIllustrationID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  IllustrationSelectByIllustrationID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE IllustrationSelectByIllustrationID 
     @IllustrationID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Illustration 
WHERE IllustrationID = @IllustrationID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     IllustrationInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'IllustrationInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  IllustrationInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE IllustrationInsert
            
           @Diagram 
         , @ModifiedDate datetime
        ,@IllustrationID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Illustration 
         (
             Diagram
         , ModifiedDate

         ) VALUES (
             @Diagram
         , @ModifiedDate
         
        )
        SELECT @IllustrationID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     IllustrationUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'IllustrationUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  IllustrationUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE IllustrationUpdate
            @IllustrationID int
         , @Diagram 
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Illustration SET
             Diagram = @Diagram
          , ModifiedDate = @ModifiedDate
      WHERE IllustrationID = @IllustrationID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     LocationDeleteByLocationID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'LocationDeleteByLocationID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  LocationDeleteByLocationID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE LocationDeleteByLocationID 
     @LocationID smallint

AS 
     SET NOCOUNT ON;

 DELETE FROM Location 
WHERE LocationID = @LocationID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     LocationSelectByLocationID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'LocationSelectByLocationID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  LocationSelectByLocationID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE LocationSelectByLocationID 
     @LocationID smallint

AS 
 SET NOCOUNT ON;
SELECT * FROM Location 
WHERE LocationID = @LocationID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     LocationInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'LocationInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  LocationInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE LocationInsert
            
           @Name Name
         , @CostRate smallmoney
         , @Availability decimal
         , @ModifiedDate datetime
        ,@LocationID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Location 
         (
             Name
         , CostRate
         , Availability
         , ModifiedDate

         ) VALUES (
             @Name
         , @CostRate
         , @Availability
         , @ModifiedDate
         
        )
        SELECT @LocationID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     LocationUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'LocationUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  LocationUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE LocationUpdate
            @LocationID smallint
         , @Name Name
         , @CostRate smallmoney
         , @Availability decimal
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Location SET
             Name = @Name
          , CostRate = @CostRate
          , Availability = @Availability
          , ModifiedDate = @ModifiedDate
      WHERE LocationID = @LocationID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductDeleteByProductID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductDeleteByProductID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductDeleteByProductID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductDeleteByProductID 
     @ProductID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Product 
WHERE ProductID = @ProductID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductSelectByProductID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductSelectByProductID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductSelectByProductID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductSelectByProductID 
     @ProductID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Product 
WHERE ProductID = @ProductID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductInsert
            
           @Name Name
         , @ProductNumber nvarchar
         , @MakeFlag Flag
         , @FinishedGoodsFlag Flag
         , @Color nvarchar
         , @SafetyStockLevel smallint
         , @ReorderPoint smallint
         , @StandardCost money
         , @ListPrice money
         , @Size nvarchar
         , @SizeUnitMeasureCode nchar
         , @WeightUnitMeasureCode nchar
         , @Weight decimal
         , @DaysToManufacture int
         , @ProductLine nchar
         , @Class nchar
         , @Style nchar
         , @ProductSubcategoryID int
         , @ProductModelID int
         , @SellStartDate datetime
         , @SellEndDate datetime
         , @DiscontinuedDate datetime
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ProductID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Product 
         (
             Name
         , ProductNumber
         , MakeFlag
         , FinishedGoodsFlag
         , Color
         , SafetyStockLevel
         , ReorderPoint
         , StandardCost
         , ListPrice
         , Size
         , SizeUnitMeasureCode
         , WeightUnitMeasureCode
         , Weight
         , DaysToManufacture
         , ProductLine
         , Class
         , Style
         , ProductSubcategoryID
         , ProductModelID
         , SellStartDate
         , SellEndDate
         , DiscontinuedDate
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Name
         , @ProductNumber
         , @MakeFlag
         , @FinishedGoodsFlag
         , @Color
         , @SafetyStockLevel
         , @ReorderPoint
         , @StandardCost
         , @ListPrice
         , @Size
         , @SizeUnitMeasureCode
         , @WeightUnitMeasureCode
         , @Weight
         , @DaysToManufacture
         , @ProductLine
         , @Class
         , @Style
         , @ProductSubcategoryID
         , @ProductModelID
         , @SellStartDate
         , @SellEndDate
         , @DiscontinuedDate
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ProductID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductUpdate
            @ProductID int
         , @Name Name
         , @ProductNumber nvarchar
         , @MakeFlag Flag
         , @FinishedGoodsFlag Flag
         , @Color nvarchar
         , @SafetyStockLevel smallint
         , @ReorderPoint smallint
         , @StandardCost money
         , @ListPrice money
         , @Size nvarchar
         , @SizeUnitMeasureCode nchar
         , @WeightUnitMeasureCode nchar
         , @Weight decimal
         , @DaysToManufacture int
         , @ProductLine nchar
         , @Class nchar
         , @Style nchar
         , @ProductSubcategoryID int
         , @ProductModelID int
         , @SellStartDate datetime
         , @SellEndDate datetime
         , @DiscontinuedDate datetime
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Product SET
             Name = @Name
          , ProductNumber = @ProductNumber
          , MakeFlag = @MakeFlag
          , FinishedGoodsFlag = @FinishedGoodsFlag
          , Color = @Color
          , SafetyStockLevel = @SafetyStockLevel
          , ReorderPoint = @ReorderPoint
          , StandardCost = @StandardCost
          , ListPrice = @ListPrice
          , Size = @Size
          , SizeUnitMeasureCode = @SizeUnitMeasureCode
          , WeightUnitMeasureCode = @WeightUnitMeasureCode
          , Weight = @Weight
          , DaysToManufacture = @DaysToManufacture
          , ProductLine = @ProductLine
          , Class = @Class
          , Style = @Style
          , ProductSubcategoryID = @ProductSubcategoryID
          , ProductModelID = @ProductModelID
          , SellStartDate = @SellStartDate
          , SellEndDate = @SellEndDate
          , DiscontinuedDate = @DiscontinuedDate
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ProductID = @ProductID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductCategoryDeleteByProductCategoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductCategoryDeleteByProductCategoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductCategoryDeleteByProductCategoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductCategoryDeleteByProductCategoryID 
     @ProductCategoryID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductCategory 
WHERE ProductCategoryID = @ProductCategoryID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductCategorySelectByProductCategoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductCategorySelectByProductCategoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductCategorySelectByProductCategoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductCategorySelectByProductCategoryID 
     @ProductCategoryID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductCategory 
WHERE ProductCategoryID = @ProductCategoryID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductCategoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductCategoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductCategoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductCategoryInsert
            
           @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ProductCategoryID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductCategory 
         (
             Name
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Name
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ProductCategoryID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductCategoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductCategoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductCategoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductCategoryUpdate
            @ProductCategoryID int
         , @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductCategory SET
             Name = @Name
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ProductCategoryID = @ProductCategoryID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductCostHistoryDeleteByProductCostHistoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductCostHistoryDeleteByProductCostHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductCostHistoryDeleteByProductCostHistoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductCostHistoryDeleteByProductCostHistoryID 
     @ProductID int,
     @StartDate datetime

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductCostHistory 
WHERE ProductID = @ProductID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductCostHistorySelectByProductCostHistoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductCostHistorySelectByProductCostHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductCostHistorySelectByProductCostHistoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductCostHistorySelectByProductCostHistoryID 
     @ProductID int,
     @StartDate datetime

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductCostHistory 
WHERE ProductID = @ProductID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductCostHistoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductCostHistoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductCostHistoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductCostHistoryInsert
               @ProductID int
         , @StartDate datetime
         , @EndDate datetime
         , @StandardCost money
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductCostHistory 
         (
             ProductID
         , StartDate
         , EndDate
         , StandardCost
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @StartDate
         , @EndDate
         , @StandardCost
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductCostHistoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductCostHistoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductCostHistoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductCostHistoryUpdate
            @ProductID int
         , @StartDate datetime
         , @EndDate datetime
         , @StandardCost money
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductCostHistory SET
             EndDate = @EndDate
          , StandardCost = @StandardCost
          , ModifiedDate = @ModifiedDate
      WHERE ProductID = @ProductID , StartDate = @StartDate 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductDescriptionDeleteByProductDescriptionID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductDescriptionDeleteByProductDescriptionID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductDescriptionDeleteByProductDescriptionID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductDescriptionDeleteByProductDescriptionID 
     @ProductDescriptionID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductDescription 
WHERE ProductDescriptionID = @ProductDescriptionID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductDescriptionSelectByProductDescriptionID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductDescriptionSelectByProductDescriptionID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductDescriptionSelectByProductDescriptionID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductDescriptionSelectByProductDescriptionID 
     @ProductDescriptionID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductDescription 
WHERE ProductDescriptionID = @ProductDescriptionID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductDescriptionInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductDescriptionInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductDescriptionInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductDescriptionInsert
            
           @Description nvarchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ProductDescriptionID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductDescription 
         (
             Description
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Description
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ProductDescriptionID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductDescriptionUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductDescriptionUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductDescriptionUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductDescriptionUpdate
            @ProductDescriptionID int
         , @Description nvarchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductDescription SET
             Description = @Description
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ProductDescriptionID = @ProductDescriptionID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductDocumentDeleteByProductDocumentID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductDocumentDeleteByProductDocumentID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductDocumentDeleteByProductDocumentID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductDocumentDeleteByProductDocumentID 
     @ProductID int,
     @DocumentID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductDocument 
WHERE ProductID = @ProductID
 AND DocumentID = @DocumentID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductDocumentSelectByProductDocumentID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductDocumentSelectByProductDocumentID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductDocumentSelectByProductDocumentID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductDocumentSelectByProductDocumentID 
     @ProductID int,
     @DocumentID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductDocument 
WHERE ProductID = @ProductID
 AND DocumentID = @DocumentID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductDocumentInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductDocumentInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductDocumentInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductDocumentInsert
               @ProductID int
         , @DocumentID int
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductDocument 
         (
             ProductID
         , DocumentID
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @DocumentID
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductDocumentUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductDocumentUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductDocumentUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductDocumentUpdate
            @ProductID int
         , @DocumentID int
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductDocument SET
             ModifiedDate = @ModifiedDate
      WHERE ProductID = @ProductID , DocumentID = @DocumentID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductInventoryDeleteByProductInventoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductInventoryDeleteByProductInventoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductInventoryDeleteByProductInventoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductInventoryDeleteByProductInventoryID 
     @ProductID int,
     @LocationID smallint

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductInventory 
WHERE ProductID = @ProductID
 AND LocationID = @LocationID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductInventorySelectByProductInventoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductInventorySelectByProductInventoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductInventorySelectByProductInventoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductInventorySelectByProductInventoryID 
     @ProductID int,
     @LocationID smallint

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductInventory 
WHERE ProductID = @ProductID
 AND LocationID = @LocationID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductInventoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductInventoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductInventoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductInventoryInsert
               @ProductID int
         , @LocationID smallint
         , @Shelf nvarchar
         , @Bin tinyint
         , @Quantity smallint
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductInventory 
         (
             ProductID
         , LocationID
         , Shelf
         , Bin
         , Quantity
         , rowguid
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @LocationID
         , @Shelf
         , @Bin
         , @Quantity
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductInventoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductInventoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductInventoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductInventoryUpdate
            @ProductID int
         , @LocationID smallint
         , @Shelf nvarchar
         , @Bin tinyint
         , @Quantity smallint
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductInventory SET
             Shelf = @Shelf
          , Bin = @Bin
          , Quantity = @Quantity
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ProductID = @ProductID , LocationID = @LocationID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductListPriceHistoryDeleteByProductListPriceHistoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductListPriceHistoryDeleteByProductListPriceHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductListPriceHistoryDeleteByProductListPriceHistoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductListPriceHistoryDeleteByProductListPriceHistoryID 
     @ProductID int,
     @StartDate datetime

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductListPriceHistory 
WHERE ProductID = @ProductID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductListPriceHistorySelectByProductListPriceHistoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductListPriceHistorySelectByProductListPriceHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductListPriceHistorySelectByProductListPriceHistoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductListPriceHistorySelectByProductListPriceHistoryID 
     @ProductID int,
     @StartDate datetime

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductListPriceHistory 
WHERE ProductID = @ProductID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductListPriceHistoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductListPriceHistoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductListPriceHistoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductListPriceHistoryInsert
               @ProductID int
         , @StartDate datetime
         , @EndDate datetime
         , @ListPrice money
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductListPriceHistory 
         (
             ProductID
         , StartDate
         , EndDate
         , ListPrice
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @StartDate
         , @EndDate
         , @ListPrice
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductListPriceHistoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductListPriceHistoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductListPriceHistoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductListPriceHistoryUpdate
            @ProductID int
         , @StartDate datetime
         , @EndDate datetime
         , @ListPrice money
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductListPriceHistory SET
             EndDate = @EndDate
          , ListPrice = @ListPrice
          , ModifiedDate = @ModifiedDate
      WHERE ProductID = @ProductID , StartDate = @StartDate 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelDeleteByProductModelID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelDeleteByProductModelID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelDeleteByProductModelID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductModelDeleteByProductModelID 
     @ProductModelID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductModel 
WHERE ProductModelID = @ProductModelID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelSelectByProductModelID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelSelectByProductModelID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelSelectByProductModelID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductModelSelectByProductModelID 
     @ProductModelID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductModel 
WHERE ProductModelID = @ProductModelID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductModelInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductModelInsert
            
           @Name Name
         , @CatalogDescription ProductDescriptionSchemaCollection
         , @Instructions ManuInstructionsSchemaCollection
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ProductModelID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductModel 
         (
             Name
         , CatalogDescription
         , Instructions
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Name
         , @CatalogDescription
         , @Instructions
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ProductModelID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductModelUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductModelUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductModelUpdate
            @ProductModelID int
         , @Name Name
         , @CatalogDescription ProductDescriptionSchemaCollection
         , @Instructions ManuInstructionsSchemaCollection
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductModel SET
             Name = @Name
          , CatalogDescription = @CatalogDescription
          , Instructions = @Instructions
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ProductModelID = @ProductModelID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelIllustrationDeleteByProductModelIllustrationID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelIllustrationDeleteByProductModelIllustrationID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelIllustrationDeleteByProductModelIllustrationID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductModelIllustrationDeleteByProductModelIllustrationID 
     @ProductModelID int,
     @IllustrationID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductModelIllustration 
WHERE ProductModelID = @ProductModelID
 AND IllustrationID = @IllustrationID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelIllustrationSelectByProductModelIllustrationID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelIllustrationSelectByProductModelIllustrationID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelIllustrationSelectByProductModelIllustrationID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductModelIllustrationSelectByProductModelIllustrationID 
     @ProductModelID int,
     @IllustrationID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductModelIllustration 
WHERE ProductModelID = @ProductModelID
 AND IllustrationID = @IllustrationID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductModelIllustrationInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelIllustrationInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelIllustrationInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductModelIllustrationInsert
               @ProductModelID int
         , @IllustrationID int
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductModelIllustration 
         (
             ProductModelID
         , IllustrationID
         , ModifiedDate

         ) VALUES (
             @ProductModelID
         , @IllustrationID
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelIllustrationUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductModelIllustrationUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductModelIllustrationUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductModelIllustrationUpdate
            @ProductModelID int
         , @IllustrationID int
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductModelIllustration SET
             ModifiedDate = @ModifiedDate
      WHERE ProductModelID = @ProductModelID , IllustrationID = @IllustrationID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelProductDescriptionCultureDeleteByProductModelProductDescriptionCultureID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelProductDescriptionCultureDeleteByProductModelProductDescriptionCultureID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelProductDescriptionCultureDeleteByProductModelProductDescriptionCultureID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductModelProductDescriptionCultureDeleteByProductModelProductDescriptionCultureID 
     @ProductModelID int,
     @ProductDescriptionID int,
     @CultureID nchar

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductModelProductDescriptionCulture 
WHERE ProductModelID = @ProductModelID
 AND ProductDescriptionID = @ProductDescriptionID
 AND CultureID = @CultureID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelProductDescriptionCultureSelectByProductModelProductDescriptionCultureID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelProductDescriptionCultureSelectByProductModelProductDescriptionCultureID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelProductDescriptionCultureSelectByProductModelProductDescriptionCultureID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductModelProductDescriptionCultureSelectByProductModelProductDescriptionCultureID 
     @ProductModelID int,
     @ProductDescriptionID int,
     @CultureID nchar

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductModelProductDescriptionCulture 
WHERE ProductModelID = @ProductModelID
 AND ProductDescriptionID = @ProductDescriptionID
 AND CultureID = @CultureID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductModelProductDescriptionCultureInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductModelProductDescriptionCultureInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductModelProductDescriptionCultureInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductModelProductDescriptionCultureInsert
               @ProductModelID int
         , @ProductDescriptionID int
         , @CultureID nchar
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductModelProductDescriptionCulture 
         (
             ProductModelID
         , ProductDescriptionID
         , CultureID
         , ModifiedDate

         ) VALUES (
             @ProductModelID
         , @ProductDescriptionID
         , @CultureID
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductModelProductDescriptionCultureUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductModelProductDescriptionCultureUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductModelProductDescriptionCultureUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductModelProductDescriptionCultureUpdate
            @ProductModelID int
         , @ProductDescriptionID int
         , @CultureID nchar
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductModelProductDescriptionCulture SET
             ModifiedDate = @ModifiedDate
      WHERE ProductModelID = @ProductModelID , ProductDescriptionID = @ProductDescriptionID , CultureID = @CultureID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductPhotoDeleteByProductPhotoID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductPhotoDeleteByProductPhotoID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductPhotoDeleteByProductPhotoID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductPhotoDeleteByProductPhotoID 
     @ProductPhotoID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductPhoto 
WHERE ProductPhotoID = @ProductPhotoID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductPhotoSelectByProductPhotoID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductPhotoSelectByProductPhotoID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductPhotoSelectByProductPhotoID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductPhotoSelectByProductPhotoID 
     @ProductPhotoID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductPhoto 
WHERE ProductPhotoID = @ProductPhotoID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductPhotoInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductPhotoInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductPhotoInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductPhotoInsert
            
           @ThumbNailPhoto varbinary
         , @ThumbnailPhotoFileName nvarchar
         , @LargePhoto varbinary
         , @LargePhotoFileName nvarchar
         , @ModifiedDate datetime
        ,@ProductPhotoID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductPhoto 
         (
             ThumbNailPhoto
         , ThumbnailPhotoFileName
         , LargePhoto
         , LargePhotoFileName
         , ModifiedDate

         ) VALUES (
             @ThumbNailPhoto
         , @ThumbnailPhotoFileName
         , @LargePhoto
         , @LargePhotoFileName
         , @ModifiedDate
         
        )
        SELECT @ProductPhotoID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductPhotoUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductPhotoUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductPhotoUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductPhotoUpdate
            @ProductPhotoID int
         , @ThumbNailPhoto varbinary
         , @ThumbnailPhotoFileName nvarchar
         , @LargePhoto varbinary
         , @LargePhotoFileName nvarchar
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductPhoto SET
             ThumbNailPhoto = @ThumbNailPhoto
          , ThumbnailPhotoFileName = @ThumbnailPhotoFileName
          , LargePhoto = @LargePhoto
          , LargePhotoFileName = @LargePhotoFileName
          , ModifiedDate = @ModifiedDate
      WHERE ProductPhotoID = @ProductPhotoID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductProductPhotoDeleteByProductProductPhotoID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductProductPhotoDeleteByProductProductPhotoID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductProductPhotoDeleteByProductProductPhotoID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductProductPhotoDeleteByProductProductPhotoID 
     @ProductID int,
     @ProductPhotoID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductProductPhoto 
WHERE ProductID = @ProductID
 AND ProductPhotoID = @ProductPhotoID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductProductPhotoSelectByProductProductPhotoID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductProductPhotoSelectByProductProductPhotoID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductProductPhotoSelectByProductProductPhotoID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductProductPhotoSelectByProductProductPhotoID 
     @ProductID int,
     @ProductPhotoID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductProductPhoto 
WHERE ProductID = @ProductID
 AND ProductPhotoID = @ProductPhotoID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductProductPhotoInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductProductPhotoInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductProductPhotoInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductProductPhotoInsert
               @ProductID int
         , @ProductPhotoID int
         , @Primary Flag
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductProductPhoto 
         (
             ProductID
         , ProductPhotoID
         , Primary
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @ProductPhotoID
         , @Primary
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductProductPhotoUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductProductPhotoUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductProductPhotoUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductProductPhotoUpdate
            @ProductID int
         , @ProductPhotoID int
         , @Primary Flag
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductProductPhoto SET
             Primary = @Primary
          , ModifiedDate = @ModifiedDate
      WHERE ProductID = @ProductID , ProductPhotoID = @ProductPhotoID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductReviewDeleteByProductReviewID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductReviewDeleteByProductReviewID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductReviewDeleteByProductReviewID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductReviewDeleteByProductReviewID 
     @ProductReviewID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductReview 
WHERE ProductReviewID = @ProductReviewID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductReviewSelectByProductReviewID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductReviewSelectByProductReviewID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductReviewSelectByProductReviewID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductReviewSelectByProductReviewID 
     @ProductReviewID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductReview 
WHERE ProductReviewID = @ProductReviewID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductReviewInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductReviewInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductReviewInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductReviewInsert
            
           @ProductID int
         , @ReviewerName Name
         , @ReviewDate datetime
         , @EmailAddress nvarchar
         , @Rating int
         , @Comments nvarchar
         , @ModifiedDate datetime
        ,@ProductReviewID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductReview 
         (
             ProductID
         , ReviewerName
         , ReviewDate
         , EmailAddress
         , Rating
         , Comments
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @ReviewerName
         , @ReviewDate
         , @EmailAddress
         , @Rating
         , @Comments
         , @ModifiedDate
         
        )
        SELECT @ProductReviewID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductReviewUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductReviewUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductReviewUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductReviewUpdate
            @ProductReviewID int
         , @ProductID int
         , @ReviewerName Name
         , @ReviewDate datetime
         , @EmailAddress nvarchar
         , @Rating int
         , @Comments nvarchar
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductReview SET
             ProductID = @ProductID
          , ReviewerName = @ReviewerName
          , ReviewDate = @ReviewDate
          , EmailAddress = @EmailAddress
          , Rating = @Rating
          , Comments = @Comments
          , ModifiedDate = @ModifiedDate
      WHERE ProductReviewID = @ProductReviewID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductSubcategoryDeleteByProductSubcategoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductSubcategoryDeleteByProductSubcategoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductSubcategoryDeleteByProductSubcategoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductSubcategoryDeleteByProductSubcategoryID 
     @ProductSubcategoryID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductSubcategory 
WHERE ProductSubcategoryID = @ProductSubcategoryID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductSubcategorySelectByProductSubcategoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductSubcategorySelectByProductSubcategoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductSubcategorySelectByProductSubcategoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductSubcategorySelectByProductSubcategoryID 
     @ProductSubcategoryID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductSubcategory 
WHERE ProductSubcategoryID = @ProductSubcategoryID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductSubcategoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductSubcategoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductSubcategoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductSubcategoryInsert
            
           @ProductCategoryID int
         , @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ProductSubcategoryID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductSubcategory 
         (
             ProductCategoryID
         , Name
         , rowguid
         , ModifiedDate

         ) VALUES (
             @ProductCategoryID
         , @Name
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ProductSubcategoryID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductSubcategoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductSubcategoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductSubcategoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductSubcategoryUpdate
            @ProductSubcategoryID int
         , @ProductCategoryID int
         , @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductSubcategory SET
             ProductCategoryID = @ProductCategoryID
          , Name = @Name
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ProductSubcategoryID = @ProductSubcategoryID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ScrapReasonDeleteByScrapReasonID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ScrapReasonDeleteByScrapReasonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ScrapReasonDeleteByScrapReasonID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ScrapReasonDeleteByScrapReasonID 
     @ScrapReasonID smallint

AS 
     SET NOCOUNT ON;

 DELETE FROM ScrapReason 
WHERE ScrapReasonID = @ScrapReasonID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ScrapReasonSelectByScrapReasonID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ScrapReasonSelectByScrapReasonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ScrapReasonSelectByScrapReasonID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ScrapReasonSelectByScrapReasonID 
     @ScrapReasonID smallint

AS 
 SET NOCOUNT ON;
SELECT * FROM ScrapReason 
WHERE ScrapReasonID = @ScrapReasonID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ScrapReasonInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ScrapReasonInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ScrapReasonInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ScrapReasonInsert
            
           @Name Name
         , @ModifiedDate datetime
        ,@ScrapReasonID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ScrapReason 
         (
             Name
         , ModifiedDate

         ) VALUES (
             @Name
         , @ModifiedDate
         
        )
        SELECT @ScrapReasonID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ScrapReasonUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ScrapReasonUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ScrapReasonUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ScrapReasonUpdate
            @ScrapReasonID smallint
         , @Name Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ScrapReason SET
             Name = @Name
          , ModifiedDate = @ModifiedDate
      WHERE ScrapReasonID = @ScrapReasonID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     TransactionHistoryDeleteByTransactionHistoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'TransactionHistoryDeleteByTransactionHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  TransactionHistoryDeleteByTransactionHistoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE TransactionHistoryDeleteByTransactionHistoryID 
     @TransactionID int

AS 
     SET NOCOUNT ON;

 DELETE FROM TransactionHistory 
WHERE TransactionID = @TransactionID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     TransactionHistorySelectByTransactionHistoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'TransactionHistorySelectByTransactionHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  TransactionHistorySelectByTransactionHistoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE TransactionHistorySelectByTransactionHistoryID 
     @TransactionID int

AS 
 SET NOCOUNT ON;
SELECT * FROM TransactionHistory 
WHERE TransactionID = @TransactionID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     TransactionHistoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'TransactionHistoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  TransactionHistoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE TransactionHistoryInsert
            
           @ProductID int
         , @ReferenceOrderID int
         , @ReferenceOrderLineID int
         , @TransactionDate datetime
         , @TransactionType nchar
         , @Quantity int
         , @ActualCost money
         , @ModifiedDate datetime
        ,@TransactionID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO TransactionHistory 
         (
             ProductID
         , ReferenceOrderID
         , ReferenceOrderLineID
         , TransactionDate
         , TransactionType
         , Quantity
         , ActualCost
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @ReferenceOrderID
         , @ReferenceOrderLineID
         , @TransactionDate
         , @TransactionType
         , @Quantity
         , @ActualCost
         , @ModifiedDate
         
        )
        SELECT @TransactionID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     TransactionHistoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'TransactionHistoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  TransactionHistoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE TransactionHistoryUpdate
            @TransactionID int
         , @ProductID int
         , @ReferenceOrderID int
         , @ReferenceOrderLineID int
         , @TransactionDate datetime
         , @TransactionType nchar
         , @Quantity int
         , @ActualCost money
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE TransactionHistory SET
             ProductID = @ProductID
          , ReferenceOrderID = @ReferenceOrderID
          , ReferenceOrderLineID = @ReferenceOrderLineID
          , TransactionDate = @TransactionDate
          , TransactionType = @TransactionType
          , Quantity = @Quantity
          , ActualCost = @ActualCost
          , ModifiedDate = @ModifiedDate
      WHERE TransactionID = @TransactionID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     TransactionHistoryArchiveDeleteByTransactionHistoryArchiveID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'TransactionHistoryArchiveDeleteByTransactionHistoryArchiveID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  TransactionHistoryArchiveDeleteByTransactionHistoryArchiveID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE TransactionHistoryArchiveDeleteByTransactionHistoryArchiveID 
     @TransactionID int

AS 
     SET NOCOUNT ON;

 DELETE FROM TransactionHistoryArchive 
WHERE TransactionID = @TransactionID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     TransactionHistoryArchiveSelectByTransactionHistoryArchiveID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'TransactionHistoryArchiveSelectByTransactionHistoryArchiveID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  TransactionHistoryArchiveSelectByTransactionHistoryArchiveID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE TransactionHistoryArchiveSelectByTransactionHistoryArchiveID 
     @TransactionID int

AS 
 SET NOCOUNT ON;
SELECT * FROM TransactionHistoryArchive 
WHERE TransactionID = @TransactionID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     TransactionHistoryArchiveInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'TransactionHistoryArchiveInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  TransactionHistoryArchiveInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE TransactionHistoryArchiveInsert
               @TransactionID int
         , @ProductID int
         , @ReferenceOrderID int
         , @ReferenceOrderLineID int
         , @TransactionDate datetime
         , @TransactionType nchar
         , @Quantity int
         , @ActualCost money
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO TransactionHistoryArchive 
         (
             TransactionID
         , ProductID
         , ReferenceOrderID
         , ReferenceOrderLineID
         , TransactionDate
         , TransactionType
         , Quantity
         , ActualCost
         , ModifiedDate

         ) VALUES (
             @TransactionID
         , @ProductID
         , @ReferenceOrderID
         , @ReferenceOrderLineID
         , @TransactionDate
         , @TransactionType
         , @Quantity
         , @ActualCost
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     TransactionHistoryArchiveUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'TransactionHistoryArchiveUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  TransactionHistoryArchiveUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE TransactionHistoryArchiveUpdate
            @TransactionID int
         , @ProductID int
         , @ReferenceOrderID int
         , @ReferenceOrderLineID int
         , @TransactionDate datetime
         , @TransactionType nchar
         , @Quantity int
         , @ActualCost money
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE TransactionHistoryArchive SET
             ProductID = @ProductID
          , ReferenceOrderID = @ReferenceOrderID
          , ReferenceOrderLineID = @ReferenceOrderLineID
          , TransactionDate = @TransactionDate
          , TransactionType = @TransactionType
          , Quantity = @Quantity
          , ActualCost = @ActualCost
          , ModifiedDate = @ModifiedDate
      WHERE TransactionID = @TransactionID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     UnitMeasureDeleteByUnitMeasureID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'UnitMeasureDeleteByUnitMeasureID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  UnitMeasureDeleteByUnitMeasureID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE UnitMeasureDeleteByUnitMeasureID 
     @UnitMeasureCode nchar

AS 
     SET NOCOUNT ON;

 DELETE FROM UnitMeasure 
WHERE UnitMeasureCode = @UnitMeasureCode

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     UnitMeasureSelectByUnitMeasureID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'UnitMeasureSelectByUnitMeasureID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  UnitMeasureSelectByUnitMeasureID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE UnitMeasureSelectByUnitMeasureID 
     @UnitMeasureCode nchar

AS 
 SET NOCOUNT ON;
SELECT * FROM UnitMeasure 
WHERE UnitMeasureCode = @UnitMeasureCode

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     UnitMeasureInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'UnitMeasureInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  UnitMeasureInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE UnitMeasureInsert
               @UnitMeasureCode nchar
         , @Name Name
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO UnitMeasure 
         (
             UnitMeasureCode
         , Name
         , ModifiedDate

         ) VALUES (
             @UnitMeasureCode
         , @Name
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     UnitMeasureUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'UnitMeasureUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  UnitMeasureUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE UnitMeasureUpdate
            @UnitMeasureCode nchar
         , @Name Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE UnitMeasure SET
             Name = @Name
          , ModifiedDate = @ModifiedDate
      WHERE UnitMeasureCode = @UnitMeasureCode 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     WorkOrderDeleteByWorkOrderID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'WorkOrderDeleteByWorkOrderID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  WorkOrderDeleteByWorkOrderID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE WorkOrderDeleteByWorkOrderID 
     @WorkOrderID int

AS 
     SET NOCOUNT ON;

 DELETE FROM WorkOrder 
WHERE WorkOrderID = @WorkOrderID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     WorkOrderSelectByWorkOrderID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'WorkOrderSelectByWorkOrderID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  WorkOrderSelectByWorkOrderID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE WorkOrderSelectByWorkOrderID 
     @WorkOrderID int

AS 
 SET NOCOUNT ON;
SELECT * FROM WorkOrder 
WHERE WorkOrderID = @WorkOrderID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     WorkOrderInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'WorkOrderInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  WorkOrderInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE WorkOrderInsert
            
           @ProductID int
         , @OrderQty int
         , @StockedQty int
         , @ScrappedQty smallint
         , @StartDate datetime
         , @EndDate datetime
         , @DueDate datetime
         , @ScrapReasonID smallint
         , @ModifiedDate datetime
        ,@WorkOrderID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO WorkOrder 
         (
             ProductID
         , OrderQty
         , StockedQty
         , ScrappedQty
         , StartDate
         , EndDate
         , DueDate
         , ScrapReasonID
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @OrderQty
         , @StockedQty
         , @ScrappedQty
         , @StartDate
         , @EndDate
         , @DueDate
         , @ScrapReasonID
         , @ModifiedDate
         
        )
        SELECT @WorkOrderID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     WorkOrderUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'WorkOrderUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  WorkOrderUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE WorkOrderUpdate
            @WorkOrderID int
         , @ProductID int
         , @OrderQty int
         , @StockedQty int
         , @ScrappedQty smallint
         , @StartDate datetime
         , @EndDate datetime
         , @DueDate datetime
         , @ScrapReasonID smallint
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE WorkOrder SET
             ProductID = @ProductID
          , OrderQty = @OrderQty
          , StockedQty = @StockedQty
          , ScrappedQty = @ScrappedQty
          , StartDate = @StartDate
          , EndDate = @EndDate
          , DueDate = @DueDate
          , ScrapReasonID = @ScrapReasonID
          , ModifiedDate = @ModifiedDate
      WHERE WorkOrderID = @WorkOrderID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     WorkOrderRoutingDeleteByWorkOrderRoutingID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'WorkOrderRoutingDeleteByWorkOrderRoutingID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  WorkOrderRoutingDeleteByWorkOrderRoutingID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE WorkOrderRoutingDeleteByWorkOrderRoutingID 
     @WorkOrderID int,
     @ProductID int,
     @OperationSequence smallint

AS 
     SET NOCOUNT ON;

 DELETE FROM WorkOrderRouting 
WHERE WorkOrderID = @WorkOrderID
 AND ProductID = @ProductID
 AND OperationSequence = @OperationSequence

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     WorkOrderRoutingSelectByWorkOrderRoutingID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'WorkOrderRoutingSelectByWorkOrderRoutingID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  WorkOrderRoutingSelectByWorkOrderRoutingID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE WorkOrderRoutingSelectByWorkOrderRoutingID 
     @WorkOrderID int,
     @ProductID int,
     @OperationSequence smallint

AS 
 SET NOCOUNT ON;
SELECT * FROM WorkOrderRouting 
WHERE WorkOrderID = @WorkOrderID
 AND ProductID = @ProductID
 AND OperationSequence = @OperationSequence

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     WorkOrderRoutingInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'WorkOrderRoutingInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  WorkOrderRoutingInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE WorkOrderRoutingInsert
               @WorkOrderID int
         , @ProductID int
         , @OperationSequence smallint
         , @LocationID smallint
         , @ScheduledStartDate datetime
         , @ScheduledEndDate datetime
         , @ActualStartDate datetime
         , @ActualEndDate datetime
         , @ActualResourceHrs decimal
         , @PlannedCost money
         , @ActualCost money
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO WorkOrderRouting 
         (
             WorkOrderID
         , ProductID
         , OperationSequence
         , LocationID
         , ScheduledStartDate
         , ScheduledEndDate
         , ActualStartDate
         , ActualEndDate
         , ActualResourceHrs
         , PlannedCost
         , ActualCost
         , ModifiedDate

         ) VALUES (
             @WorkOrderID
         , @ProductID
         , @OperationSequence
         , @LocationID
         , @ScheduledStartDate
         , @ScheduledEndDate
         , @ActualStartDate
         , @ActualEndDate
         , @ActualResourceHrs
         , @PlannedCost
         , @ActualCost
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     WorkOrderRoutingUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'WorkOrderRoutingUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  WorkOrderRoutingUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE WorkOrderRoutingUpdate
            @WorkOrderID int
         , @ProductID int
         , @OperationSequence smallint
         , @LocationID smallint
         , @ScheduledStartDate datetime
         , @ScheduledEndDate datetime
         , @ActualStartDate datetime
         , @ActualEndDate datetime
         , @ActualResourceHrs decimal
         , @PlannedCost money
         , @ActualCost money
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE WorkOrderRouting SET
             LocationID = @LocationID
          , ScheduledStartDate = @ScheduledStartDate
          , ScheduledEndDate = @ScheduledEndDate
          , ActualStartDate = @ActualStartDate
          , ActualEndDate = @ActualEndDate
          , ActualResourceHrs = @ActualResourceHrs
          , PlannedCost = @PlannedCost
          , ActualCost = @ActualCost
          , ModifiedDate = @ModifiedDate
      WHERE WorkOrderID = @WorkOrderID , ProductID = @ProductID , OperationSequence = @OperationSequence 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductVendorDeleteByProductVendorID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductVendorDeleteByProductVendorID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductVendorDeleteByProductVendorID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductVendorDeleteByProductVendorID 
     @ProductID int,
     @VendorID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ProductVendor 
WHERE ProductID = @ProductID
 AND VendorID = @VendorID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductVendorSelectByProductVendorID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductVendorSelectByProductVendorID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductVendorSelectByProductVendorID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ProductVendorSelectByProductVendorID 
     @ProductID int,
     @VendorID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ProductVendor 
WHERE ProductID = @ProductID
 AND VendorID = @VendorID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ProductVendorInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ProductVendorInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ProductVendorInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ProductVendorInsert
               @ProductID int
         , @VendorID int
         , @AverageLeadTime int
         , @StandardPrice money
         , @LastReceiptCost money
         , @LastReceiptDate datetime
         , @MinOrderQty int
         , @MaxOrderQty int
         , @OnOrderQty int
         , @UnitMeasureCode nchar
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ProductVendor 
         (
             ProductID
         , VendorID
         , AverageLeadTime
         , StandardPrice
         , LastReceiptCost
         , LastReceiptDate
         , MinOrderQty
         , MaxOrderQty
         , OnOrderQty
         , UnitMeasureCode
         , ModifiedDate

         ) VALUES (
             @ProductID
         , @VendorID
         , @AverageLeadTime
         , @StandardPrice
         , @LastReceiptCost
         , @LastReceiptDate
         , @MinOrderQty
         , @MaxOrderQty
         , @OnOrderQty
         , @UnitMeasureCode
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ProductVendorUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ProductVendorUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ProductVendorUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ProductVendorUpdate
            @ProductID int
         , @VendorID int
         , @AverageLeadTime int
         , @StandardPrice money
         , @LastReceiptCost money
         , @LastReceiptDate datetime
         , @MinOrderQty int
         , @MaxOrderQty int
         , @OnOrderQty int
         , @UnitMeasureCode nchar
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ProductVendor SET
             AverageLeadTime = @AverageLeadTime
          , StandardPrice = @StandardPrice
          , LastReceiptCost = @LastReceiptCost
          , LastReceiptDate = @LastReceiptDate
          , MinOrderQty = @MinOrderQty
          , MaxOrderQty = @MaxOrderQty
          , OnOrderQty = @OnOrderQty
          , UnitMeasureCode = @UnitMeasureCode
          , ModifiedDate = @ModifiedDate
      WHERE ProductID = @ProductID , VendorID = @VendorID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     PurchaseOrderDetailDeleteByPurchaseOrderDetailID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'PurchaseOrderDetailDeleteByPurchaseOrderDetailID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  PurchaseOrderDetailDeleteByPurchaseOrderDetailID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE PurchaseOrderDetailDeleteByPurchaseOrderDetailID 
     @PurchaseOrderID int,
     @PurchaseOrderDetailID int

AS 
     SET NOCOUNT ON;

 DELETE FROM PurchaseOrderDetail 
WHERE PurchaseOrderID = @PurchaseOrderID
 AND PurchaseOrderDetailID = @PurchaseOrderDetailID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     PurchaseOrderDetailSelectByPurchaseOrderDetailID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'PurchaseOrderDetailSelectByPurchaseOrderDetailID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  PurchaseOrderDetailSelectByPurchaseOrderDetailID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE PurchaseOrderDetailSelectByPurchaseOrderDetailID 
     @PurchaseOrderID int,
     @PurchaseOrderDetailID int

AS 
 SET NOCOUNT ON;
SELECT * FROM PurchaseOrderDetail 
WHERE PurchaseOrderID = @PurchaseOrderID
 AND PurchaseOrderDetailID = @PurchaseOrderDetailID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     PurchaseOrderDetailInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'PurchaseOrderDetailInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  PurchaseOrderDetailInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE PurchaseOrderDetailInsert
               @PurchaseOrderID int

         , @DueDate datetime
         , @OrderQty smallint
         , @ProductID int
         , @UnitPrice money
         , @LineTotal money
         , @ReceivedQty decimal
         , @RejectedQty decimal
         , @StockedQty decimal
         , @ModifiedDate datetime
        ,@PurchaseOrderDetailID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO PurchaseOrderDetail 
         (
             PurchaseOrderID
         , DueDate
         , OrderQty
         , ProductID
         , UnitPrice
         , LineTotal
         , ReceivedQty
         , RejectedQty
         , StockedQty
         , ModifiedDate

         ) VALUES (
             @PurchaseOrderID
         , @DueDate
         , @OrderQty
         , @ProductID
         , @UnitPrice
         , @LineTotal
         , @ReceivedQty
         , @RejectedQty
         , @StockedQty
         , @ModifiedDate
         
        )
        SELECT @PurchaseOrderDetailID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     PurchaseOrderDetailUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'PurchaseOrderDetailUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  PurchaseOrderDetailUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE PurchaseOrderDetailUpdate
            @PurchaseOrderID int
         , @PurchaseOrderDetailID int
         , @DueDate datetime
         , @OrderQty smallint
         , @ProductID int
         , @UnitPrice money
         , @LineTotal money
         , @ReceivedQty decimal
         , @RejectedQty decimal
         , @StockedQty decimal
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE PurchaseOrderDetail SET
             DueDate = @DueDate
          , OrderQty = @OrderQty
          , ProductID = @ProductID
          , UnitPrice = @UnitPrice
          , LineTotal = @LineTotal
          , ReceivedQty = @ReceivedQty
          , RejectedQty = @RejectedQty
          , StockedQty = @StockedQty
          , ModifiedDate = @ModifiedDate
      WHERE PurchaseOrderID = @PurchaseOrderID , PurchaseOrderDetailID = @PurchaseOrderDetailID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     PurchaseOrderHeaderDeleteByPurchaseOrderHeaderID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'PurchaseOrderHeaderDeleteByPurchaseOrderHeaderID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  PurchaseOrderHeaderDeleteByPurchaseOrderHeaderID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE PurchaseOrderHeaderDeleteByPurchaseOrderHeaderID 
     @PurchaseOrderID int

AS 
     SET NOCOUNT ON;

 DELETE FROM PurchaseOrderHeader 
WHERE PurchaseOrderID = @PurchaseOrderID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     PurchaseOrderHeaderSelectByPurchaseOrderHeaderID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'PurchaseOrderHeaderSelectByPurchaseOrderHeaderID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  PurchaseOrderHeaderSelectByPurchaseOrderHeaderID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE PurchaseOrderHeaderSelectByPurchaseOrderHeaderID 
     @PurchaseOrderID int

AS 
 SET NOCOUNT ON;
SELECT * FROM PurchaseOrderHeader 
WHERE PurchaseOrderID = @PurchaseOrderID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     PurchaseOrderHeaderInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'PurchaseOrderHeaderInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  PurchaseOrderHeaderInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE PurchaseOrderHeaderInsert
            
           @RevisionNumber tinyint
         , @Status tinyint
         , @EmployeeID int
         , @VendorID int
         , @ShipMethodID int
         , @OrderDate datetime
         , @ShipDate datetime
         , @SubTotal money
         , @TaxAmt money
         , @Freight money
         , @TotalDue money
         , @ModifiedDate datetime
        ,@PurchaseOrderID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO PurchaseOrderHeader 
         (
             RevisionNumber
         , Status
         , EmployeeID
         , VendorID
         , ShipMethodID
         , OrderDate
         , ShipDate
         , SubTotal
         , TaxAmt
         , Freight
         , TotalDue
         , ModifiedDate

         ) VALUES (
             @RevisionNumber
         , @Status
         , @EmployeeID
         , @VendorID
         , @ShipMethodID
         , @OrderDate
         , @ShipDate
         , @SubTotal
         , @TaxAmt
         , @Freight
         , @TotalDue
         , @ModifiedDate
         
        )
        SELECT @PurchaseOrderID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     PurchaseOrderHeaderUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'PurchaseOrderHeaderUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  PurchaseOrderHeaderUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE PurchaseOrderHeaderUpdate
            @PurchaseOrderID int
         , @RevisionNumber tinyint
         , @Status tinyint
         , @EmployeeID int
         , @VendorID int
         , @ShipMethodID int
         , @OrderDate datetime
         , @ShipDate datetime
         , @SubTotal money
         , @TaxAmt money
         , @Freight money
         , @TotalDue money
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE PurchaseOrderHeader SET
             RevisionNumber = @RevisionNumber
          , Status = @Status
          , EmployeeID = @EmployeeID
          , VendorID = @VendorID
          , ShipMethodID = @ShipMethodID
          , OrderDate = @OrderDate
          , ShipDate = @ShipDate
          , SubTotal = @SubTotal
          , TaxAmt = @TaxAmt
          , Freight = @Freight
          , TotalDue = @TotalDue
          , ModifiedDate = @ModifiedDate
      WHERE PurchaseOrderID = @PurchaseOrderID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShipMethodDeleteByShipMethodID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShipMethodDeleteByShipMethodID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShipMethodDeleteByShipMethodID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ShipMethodDeleteByShipMethodID 
     @ShipMethodID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ShipMethod 
WHERE ShipMethodID = @ShipMethodID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShipMethodSelectByShipMethodID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShipMethodSelectByShipMethodID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShipMethodSelectByShipMethodID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ShipMethodSelectByShipMethodID 
     @ShipMethodID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ShipMethod 
WHERE ShipMethodID = @ShipMethodID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ShipMethodInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShipMethodInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShipMethodInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ShipMethodInsert
            
           @Name Name
         , @ShipBase money
         , @ShipRate money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ShipMethodID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ShipMethod 
         (
             Name
         , ShipBase
         , ShipRate
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Name
         , @ShipBase
         , @ShipRate
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ShipMethodID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShipMethodUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ShipMethodUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ShipMethodUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ShipMethodUpdate
            @ShipMethodID int
         , @Name Name
         , @ShipBase money
         , @ShipRate money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ShipMethod SET
             Name = @Name
          , ShipBase = @ShipBase
          , ShipRate = @ShipRate
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE ShipMethodID = @ShipMethodID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorDeleteByVendorID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorDeleteByVendorID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorDeleteByVendorID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE VendorDeleteByVendorID 
     @VendorID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Vendor 
WHERE VendorID = @VendorID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorSelectByVendorID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorSelectByVendorID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorSelectByVendorID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE VendorSelectByVendorID 
     @VendorID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Vendor 
WHERE VendorID = @VendorID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     VendorInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE VendorInsert
            
           @AccountNumber AccountNumber
         , @Name Name
         , @CreditRating tinyint
         , @PreferredVendorStatus Flag
         , @ActiveFlag Flag
         , @PurchasingWebServiceURL nvarchar
         , @ModifiedDate datetime
        ,@VendorID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Vendor 
         (
             AccountNumber
         , Name
         , CreditRating
         , PreferredVendorStatus
         , ActiveFlag
         , PurchasingWebServiceURL
         , ModifiedDate

         ) VALUES (
             @AccountNumber
         , @Name
         , @CreditRating
         , @PreferredVendorStatus
         , @ActiveFlag
         , @PurchasingWebServiceURL
         , @ModifiedDate
         
        )
        SELECT @VendorID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'VendorUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  VendorUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE VendorUpdate
            @VendorID int
         , @AccountNumber AccountNumber
         , @Name Name
         , @CreditRating tinyint
         , @PreferredVendorStatus Flag
         , @ActiveFlag Flag
         , @PurchasingWebServiceURL nvarchar
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Vendor SET
             AccountNumber = @AccountNumber
          , Name = @Name
          , CreditRating = @CreditRating
          , PreferredVendorStatus = @PreferredVendorStatus
          , ActiveFlag = @ActiveFlag
          , PurchasingWebServiceURL = @PurchasingWebServiceURL
          , ModifiedDate = @ModifiedDate
      WHERE VendorID = @VendorID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorAddressDeleteByVendorAddressID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorAddressDeleteByVendorAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorAddressDeleteByVendorAddressID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE VendorAddressDeleteByVendorAddressID 
     @VendorID int,
     @AddressID int

AS 
     SET NOCOUNT ON;

 DELETE FROM VendorAddress 
WHERE VendorID = @VendorID
 AND AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorAddressSelectByVendorAddressID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorAddressSelectByVendorAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorAddressSelectByVendorAddressID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE VendorAddressSelectByVendorAddressID 
     @VendorID int,
     @AddressID int

AS 
 SET NOCOUNT ON;
SELECT * FROM VendorAddress 
WHERE VendorID = @VendorID
 AND AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     VendorAddressInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorAddressInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorAddressInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE VendorAddressInsert
               @VendorID int
         , @AddressID int
         , @AddressTypeID int
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO VendorAddress 
         (
             VendorID
         , AddressID
         , AddressTypeID
         , ModifiedDate

         ) VALUES (
             @VendorID
         , @AddressID
         , @AddressTypeID
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorAddressUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'VendorAddressUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  VendorAddressUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE VendorAddressUpdate
            @VendorID int
         , @AddressID int
         , @AddressTypeID int
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE VendorAddress SET
             AddressTypeID = @AddressTypeID
          , ModifiedDate = @ModifiedDate
      WHERE VendorID = @VendorID , AddressID = @AddressID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorContactDeleteByVendorContactID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorContactDeleteByVendorContactID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorContactDeleteByVendorContactID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE VendorContactDeleteByVendorContactID 
     @VendorID int,
     @ContactID int

AS 
     SET NOCOUNT ON;

 DELETE FROM VendorContact 
WHERE VendorID = @VendorID
 AND ContactID = @ContactID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorContactSelectByVendorContactID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorContactSelectByVendorContactID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorContactSelectByVendorContactID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE VendorContactSelectByVendorContactID 
     @VendorID int,
     @ContactID int

AS 
 SET NOCOUNT ON;
SELECT * FROM VendorContact 
WHERE VendorID = @VendorID
 AND ContactID = @ContactID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     VendorContactInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'VendorContactInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  VendorContactInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE VendorContactInsert
               @VendorID int
         , @ContactID int
         , @ContactTypeID int
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO VendorContact 
         (
             VendorID
         , ContactID
         , ContactTypeID
         , ModifiedDate

         ) VALUES (
             @VendorID
         , @ContactID
         , @ContactTypeID
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     VendorContactUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'VendorContactUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  VendorContactUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE VendorContactUpdate
            @VendorID int
         , @ContactID int
         , @ContactTypeID int
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE VendorContact SET
             ContactTypeID = @ContactTypeID
          , ModifiedDate = @ModifiedDate
      WHERE VendorID = @VendorID , ContactID = @ContactID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactCreditCardDeleteByContactCreditCardID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactCreditCardDeleteByContactCreditCardID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactCreditCardDeleteByContactCreditCardID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ContactCreditCardDeleteByContactCreditCardID 
     @ContactID int,
     @CreditCardID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ContactCreditCard 
WHERE ContactID = @ContactID
 AND CreditCardID = @CreditCardID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactCreditCardSelectByContactCreditCardID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactCreditCardSelectByContactCreditCardID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactCreditCardSelectByContactCreditCardID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ContactCreditCardSelectByContactCreditCardID 
     @ContactID int,
     @CreditCardID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ContactCreditCard 
WHERE ContactID = @ContactID
 AND CreditCardID = @CreditCardID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ContactCreditCardInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ContactCreditCardInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ContactCreditCardInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ContactCreditCardInsert
               @ContactID int
         , @CreditCardID int
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ContactCreditCard 
         (
             ContactID
         , CreditCardID
         , ModifiedDate

         ) VALUES (
             @ContactID
         , @CreditCardID
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ContactCreditCardUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ContactCreditCardUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ContactCreditCardUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ContactCreditCardUpdate
            @ContactID int
         , @CreditCardID int
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ContactCreditCard SET
             ModifiedDate = @ModifiedDate
      WHERE ContactID = @ContactID , CreditCardID = @CreditCardID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CountryRegionCurrencyDeleteByCountryRegionCurrencyID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CountryRegionCurrencyDeleteByCountryRegionCurrencyID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CountryRegionCurrencyDeleteByCountryRegionCurrencyID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CountryRegionCurrencyDeleteByCountryRegionCurrencyID 
     @CountryRegionCode nvarchar,
     @CurrencyCode nchar

AS 
     SET NOCOUNT ON;

 DELETE FROM CountryRegionCurrency 
WHERE CountryRegionCode = @CountryRegionCode
 AND CurrencyCode = @CurrencyCode

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CountryRegionCurrencySelectByCountryRegionCurrencyID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CountryRegionCurrencySelectByCountryRegionCurrencyID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CountryRegionCurrencySelectByCountryRegionCurrencyID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CountryRegionCurrencySelectByCountryRegionCurrencyID 
     @CountryRegionCode nvarchar,
     @CurrencyCode nchar

AS 
 SET NOCOUNT ON;
SELECT * FROM CountryRegionCurrency 
WHERE CountryRegionCode = @CountryRegionCode
 AND CurrencyCode = @CurrencyCode

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CountryRegionCurrencyInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CountryRegionCurrencyInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CountryRegionCurrencyInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CountryRegionCurrencyInsert
               @CountryRegionCode nvarchar
         , @CurrencyCode nchar
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO CountryRegionCurrency 
         (
             CountryRegionCode
         , CurrencyCode
         , ModifiedDate

         ) VALUES (
             @CountryRegionCode
         , @CurrencyCode
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CountryRegionCurrencyUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CountryRegionCurrencyUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CountryRegionCurrencyUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CountryRegionCurrencyUpdate
            @CountryRegionCode nvarchar
         , @CurrencyCode nchar
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE CountryRegionCurrency SET
             ModifiedDate = @ModifiedDate
      WHERE CountryRegionCode = @CountryRegionCode , CurrencyCode = @CurrencyCode 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CreditCardDeleteByCreditCardID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CreditCardDeleteByCreditCardID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CreditCardDeleteByCreditCardID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CreditCardDeleteByCreditCardID 
     @CreditCardID int

AS 
     SET NOCOUNT ON;

 DELETE FROM CreditCard 
WHERE CreditCardID = @CreditCardID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CreditCardSelectByCreditCardID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CreditCardSelectByCreditCardID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CreditCardSelectByCreditCardID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CreditCardSelectByCreditCardID 
     @CreditCardID int

AS 
 SET NOCOUNT ON;
SELECT * FROM CreditCard 
WHERE CreditCardID = @CreditCardID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CreditCardInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CreditCardInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CreditCardInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CreditCardInsert
            
           @CardType nvarchar
         , @CardNumber nvarchar
         , @ExpMonth tinyint
         , @ExpYear smallint
         , @ModifiedDate datetime
        ,@CreditCardID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO CreditCard 
         (
             CardType
         , CardNumber
         , ExpMonth
         , ExpYear
         , ModifiedDate

         ) VALUES (
             @CardType
         , @CardNumber
         , @ExpMonth
         , @ExpYear
         , @ModifiedDate
         
        )
        SELECT @CreditCardID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CreditCardUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CreditCardUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CreditCardUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CreditCardUpdate
            @CreditCardID int
         , @CardType nvarchar
         , @CardNumber nvarchar
         , @ExpMonth tinyint
         , @ExpYear smallint
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE CreditCard SET
             CardType = @CardType
          , CardNumber = @CardNumber
          , ExpMonth = @ExpMonth
          , ExpYear = @ExpYear
          , ModifiedDate = @ModifiedDate
      WHERE CreditCardID = @CreditCardID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CurrencyDeleteByCurrencyID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CurrencyDeleteByCurrencyID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CurrencyDeleteByCurrencyID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CurrencyDeleteByCurrencyID 
     @CurrencyCode nchar

AS 
     SET NOCOUNT ON;

 DELETE FROM Currency 
WHERE CurrencyCode = @CurrencyCode

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CurrencySelectByCurrencyID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CurrencySelectByCurrencyID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CurrencySelectByCurrencyID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CurrencySelectByCurrencyID 
     @CurrencyCode nchar

AS 
 SET NOCOUNT ON;
SELECT * FROM Currency 
WHERE CurrencyCode = @CurrencyCode

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CurrencyInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CurrencyInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CurrencyInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CurrencyInsert
               @CurrencyCode nchar
         , @Name Name
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Currency 
         (
             CurrencyCode
         , Name
         , ModifiedDate

         ) VALUES (
             @CurrencyCode
         , @Name
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CurrencyUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CurrencyUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CurrencyUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CurrencyUpdate
            @CurrencyCode nchar
         , @Name Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Currency SET
             Name = @Name
          , ModifiedDate = @ModifiedDate
      WHERE CurrencyCode = @CurrencyCode 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CurrencyRateDeleteByCurrencyRateID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CurrencyRateDeleteByCurrencyRateID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CurrencyRateDeleteByCurrencyRateID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CurrencyRateDeleteByCurrencyRateID 
     @CurrencyRateID int

AS 
     SET NOCOUNT ON;

 DELETE FROM CurrencyRate 
WHERE CurrencyRateID = @CurrencyRateID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CurrencyRateSelectByCurrencyRateID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CurrencyRateSelectByCurrencyRateID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CurrencyRateSelectByCurrencyRateID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CurrencyRateSelectByCurrencyRateID 
     @CurrencyRateID int

AS 
 SET NOCOUNT ON;
SELECT * FROM CurrencyRate 
WHERE CurrencyRateID = @CurrencyRateID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CurrencyRateInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CurrencyRateInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CurrencyRateInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CurrencyRateInsert
            
           @CurrencyRateDate datetime
         , @FromCurrencyCode nchar
         , @ToCurrencyCode nchar
         , @AverageRate money
         , @EndOfDayRate money
         , @ModifiedDate datetime
        ,@CurrencyRateID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO CurrencyRate 
         (
             CurrencyRateDate
         , FromCurrencyCode
         , ToCurrencyCode
         , AverageRate
         , EndOfDayRate
         , ModifiedDate

         ) VALUES (
             @CurrencyRateDate
         , @FromCurrencyCode
         , @ToCurrencyCode
         , @AverageRate
         , @EndOfDayRate
         , @ModifiedDate
         
        )
        SELECT @CurrencyRateID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CurrencyRateUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CurrencyRateUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CurrencyRateUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CurrencyRateUpdate
            @CurrencyRateID int
         , @CurrencyRateDate datetime
         , @FromCurrencyCode nchar
         , @ToCurrencyCode nchar
         , @AverageRate money
         , @EndOfDayRate money
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE CurrencyRate SET
             CurrencyRateDate = @CurrencyRateDate
          , FromCurrencyCode = @FromCurrencyCode
          , ToCurrencyCode = @ToCurrencyCode
          , AverageRate = @AverageRate
          , EndOfDayRate = @EndOfDayRate
          , ModifiedDate = @ModifiedDate
      WHERE CurrencyRateID = @CurrencyRateID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CustomerDeleteByCustomerID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CustomerDeleteByCustomerID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CustomerDeleteByCustomerID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CustomerDeleteByCustomerID 
     @CustomerID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Customer 
WHERE CustomerID = @CustomerID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CustomerSelectByCustomerID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CustomerSelectByCustomerID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CustomerSelectByCustomerID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CustomerSelectByCustomerID 
     @CustomerID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Customer 
WHERE CustomerID = @CustomerID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CustomerInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CustomerInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CustomerInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CustomerInsert
            
           @TerritoryID int
         , @AccountNumber varchar(10)
         , @CustomerType nchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@CustomerID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Customer 
         (
             TerritoryID
         , AccountNumber
         , CustomerType
         , rowguid
         , ModifiedDate

         ) VALUES (
             @TerritoryID
         , @AccountNumber
         , @CustomerType
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @CustomerID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CustomerUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CustomerUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CustomerUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CustomerUpdate
            @CustomerID int
         , @TerritoryID int
         , @AccountNumber varchar(10)
         , @CustomerType nchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Customer SET
             TerritoryID = @TerritoryID
          , AccountNumber = @AccountNumber
          , CustomerType = @CustomerType
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE CustomerID = @CustomerID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CustomerAddressDeleteByCustomerAddressID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CustomerAddressDeleteByCustomerAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CustomerAddressDeleteByCustomerAddressID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CustomerAddressDeleteByCustomerAddressID 
     @CustomerID int,
     @AddressID int

AS 
     SET NOCOUNT ON;

 DELETE FROM CustomerAddress 
WHERE CustomerID = @CustomerID
 AND AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CustomerAddressSelectByCustomerAddressID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CustomerAddressSelectByCustomerAddressID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CustomerAddressSelectByCustomerAddressID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE CustomerAddressSelectByCustomerAddressID 
     @CustomerID int,
     @AddressID int

AS 
 SET NOCOUNT ON;
SELECT * FROM CustomerAddress 
WHERE CustomerID = @CustomerID
 AND AddressID = @AddressID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     CustomerAddressInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'CustomerAddressInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  CustomerAddressInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE CustomerAddressInsert
               @CustomerID int
         , @AddressID int
         , @AddressTypeID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO CustomerAddress 
         (
             CustomerID
         , AddressID
         , AddressTypeID
         , rowguid
         , ModifiedDate

         ) VALUES (
             @CustomerID
         , @AddressID
         , @AddressTypeID
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     CustomerAddressUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'CustomerAddressUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  CustomerAddressUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE CustomerAddressUpdate
            @CustomerID int
         , @AddressID int
         , @AddressTypeID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE CustomerAddress SET
             AddressTypeID = @AddressTypeID
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE CustomerID = @CustomerID , AddressID = @AddressID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     IndividualDeleteByIndividualID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'IndividualDeleteByIndividualID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  IndividualDeleteByIndividualID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE IndividualDeleteByIndividualID 
     @CustomerID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Individual 
WHERE CustomerID = @CustomerID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     IndividualSelectByIndividualID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'IndividualSelectByIndividualID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  IndividualSelectByIndividualID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE IndividualSelectByIndividualID 
     @CustomerID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Individual 
WHERE CustomerID = @CustomerID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     IndividualInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'IndividualInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  IndividualInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE IndividualInsert
               @CustomerID int
         , @ContactID int
         , @Demographics IndividualSurveySchemaCollection
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Individual 
         (
             CustomerID
         , ContactID
         , Demographics
         , ModifiedDate

         ) VALUES (
             @CustomerID
         , @ContactID
         , @Demographics
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     IndividualUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'IndividualUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  IndividualUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE IndividualUpdate
            @CustomerID int
         , @ContactID int
         , @Demographics IndividualSurveySchemaCollection
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Individual SET
             ContactID = @ContactID
          , Demographics = @Demographics
          , ModifiedDate = @ModifiedDate
      WHERE CustomerID = @CustomerID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderDetailDeleteBySalesOrderDetailID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderDetailDeleteBySalesOrderDetailID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderDetailDeleteBySalesOrderDetailID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesOrderDetailDeleteBySalesOrderDetailID 
     @SalesOrderID int,
     @SalesOrderDetailID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesOrderDetail 
WHERE SalesOrderID = @SalesOrderID
 AND SalesOrderDetailID = @SalesOrderDetailID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderDetailSelectBySalesOrderDetailID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderDetailSelectBySalesOrderDetailID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderDetailSelectBySalesOrderDetailID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesOrderDetailSelectBySalesOrderDetailID 
     @SalesOrderID int,
     @SalesOrderDetailID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesOrderDetail 
WHERE SalesOrderID = @SalesOrderID
 AND SalesOrderDetailID = @SalesOrderDetailID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesOrderDetailInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderDetailInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderDetailInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesOrderDetailInsert
               @SalesOrderID int

         , @CarrierTrackingNumber nvarchar
         , @OrderQty smallint
         , @ProductID int
         , @SpecialOfferID int
         , @UnitPrice money
         , @UnitPriceDiscount money
         , @LineTotal numeric
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@SalesOrderDetailID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesOrderDetail 
         (
             SalesOrderID
         , CarrierTrackingNumber
         , OrderQty
         , ProductID
         , SpecialOfferID
         , UnitPrice
         , UnitPriceDiscount
         , LineTotal
         , rowguid
         , ModifiedDate

         ) VALUES (
             @SalesOrderID
         , @CarrierTrackingNumber
         , @OrderQty
         , @ProductID
         , @SpecialOfferID
         , @UnitPrice
         , @UnitPriceDiscount
         , @LineTotal
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @SalesOrderDetailID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderDetailUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesOrderDetailUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesOrderDetailUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesOrderDetailUpdate
            @SalesOrderID int
         , @SalesOrderDetailID int
         , @CarrierTrackingNumber nvarchar
         , @OrderQty smallint
         , @ProductID int
         , @SpecialOfferID int
         , @UnitPrice money
         , @UnitPriceDiscount money
         , @LineTotal numeric
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesOrderDetail SET
             CarrierTrackingNumber = @CarrierTrackingNumber
          , OrderQty = @OrderQty
          , ProductID = @ProductID
          , SpecialOfferID = @SpecialOfferID
          , UnitPrice = @UnitPrice
          , UnitPriceDiscount = @UnitPriceDiscount
          , LineTotal = @LineTotal
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SalesOrderID = @SalesOrderID , SalesOrderDetailID = @SalesOrderDetailID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderDeleteBySalesOrderHeaderID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderHeaderDeleteBySalesOrderHeaderID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderHeaderDeleteBySalesOrderHeaderID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesOrderHeaderDeleteBySalesOrderHeaderID 
     @SalesOrderID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesOrderHeader 
WHERE SalesOrderID = @SalesOrderID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderSelectBySalesOrderHeaderID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderHeaderSelectBySalesOrderHeaderID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderHeaderSelectBySalesOrderHeaderID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesOrderHeaderSelectBySalesOrderHeaderID 
     @SalesOrderID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesOrderHeader 
WHERE SalesOrderID = @SalesOrderID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderHeaderInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderHeaderInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesOrderHeaderInsert
            
           @RevisionNumber tinyint
         , @OrderDate datetime
         , @DueDate datetime
         , @ShipDate datetime
         , @Status tinyint
         , @OnlineOrderFlag Flag
         , @SalesOrderNumber nvarchar
         , @PurchaseOrderNumber OrderNumber
         , @AccountNumber AccountNumber
         , @CustomerID int
         , @ContactID int
         , @SalesPersonID int
         , @TerritoryID int
         , @BillToAddressID int
         , @ShipToAddressID int
         , @ShipMethodID int
         , @CreditCardID int
         , @CreditCardApprovalCode varchar(15)
         , @CurrencyRateID int
         , @SubTotal money
         , @TaxAmt money
         , @Freight money
         , @TotalDue money
         , @Comment nvarchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@SalesOrderID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesOrderHeader 
         (
             RevisionNumber
         , OrderDate
         , DueDate
         , ShipDate
         , Status
         , OnlineOrderFlag
         , SalesOrderNumber
         , PurchaseOrderNumber
         , AccountNumber
         , CustomerID
         , ContactID
         , SalesPersonID
         , TerritoryID
         , BillToAddressID
         , ShipToAddressID
         , ShipMethodID
         , CreditCardID
         , CreditCardApprovalCode
         , CurrencyRateID
         , SubTotal
         , TaxAmt
         , Freight
         , TotalDue
         , Comment
         , rowguid
         , ModifiedDate

         ) VALUES (
             @RevisionNumber
         , @OrderDate
         , @DueDate
         , @ShipDate
         , @Status
         , @OnlineOrderFlag
         , @SalesOrderNumber
         , @PurchaseOrderNumber
         , @AccountNumber
         , @CustomerID
         , @ContactID
         , @SalesPersonID
         , @TerritoryID
         , @BillToAddressID
         , @ShipToAddressID
         , @ShipMethodID
         , @CreditCardID
         , @CreditCardApprovalCode
         , @CurrencyRateID
         , @SubTotal
         , @TaxAmt
         , @Freight
         , @TotalDue
         , @Comment
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @SalesOrderID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesOrderHeaderUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesOrderHeaderUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesOrderHeaderUpdate
            @SalesOrderID int
         , @RevisionNumber tinyint
         , @OrderDate datetime
         , @DueDate datetime
         , @ShipDate datetime
         , @Status tinyint
         , @OnlineOrderFlag Flag
         , @SalesOrderNumber nvarchar
         , @PurchaseOrderNumber OrderNumber
         , @AccountNumber AccountNumber
         , @CustomerID int
         , @ContactID int
         , @SalesPersonID int
         , @TerritoryID int
         , @BillToAddressID int
         , @ShipToAddressID int
         , @ShipMethodID int
         , @CreditCardID int
         , @CreditCardApprovalCode varchar(15)
         , @CurrencyRateID int
         , @SubTotal money
         , @TaxAmt money
         , @Freight money
         , @TotalDue money
         , @Comment nvarchar
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesOrderHeader SET
             RevisionNumber = @RevisionNumber
          , OrderDate = @OrderDate
          , DueDate = @DueDate
          , ShipDate = @ShipDate
          , Status = @Status
          , OnlineOrderFlag = @OnlineOrderFlag
          , SalesOrderNumber = @SalesOrderNumber
          , PurchaseOrderNumber = @PurchaseOrderNumber
          , AccountNumber = @AccountNumber
          , CustomerID = @CustomerID
          , ContactID = @ContactID
          , SalesPersonID = @SalesPersonID
          , TerritoryID = @TerritoryID
          , BillToAddressID = @BillToAddressID
          , ShipToAddressID = @ShipToAddressID
          , ShipMethodID = @ShipMethodID
          , CreditCardID = @CreditCardID
          , CreditCardApprovalCode = @CreditCardApprovalCode
          , CurrencyRateID = @CurrencyRateID
          , SubTotal = @SubTotal
          , TaxAmt = @TaxAmt
          , Freight = @Freight
          , TotalDue = @TotalDue
          , Comment = @Comment
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SalesOrderID = @SalesOrderID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderSalesReasonDeleteBySalesOrderHeaderSalesReasonID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderHeaderSalesReasonDeleteBySalesOrderHeaderSalesReasonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderHeaderSalesReasonDeleteBySalesOrderHeaderSalesReasonID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesOrderHeaderSalesReasonDeleteBySalesOrderHeaderSalesReasonID 
     @SalesOrderID int,
     @SalesReasonID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesOrderHeaderSalesReason 
WHERE SalesOrderID = @SalesOrderID
 AND SalesReasonID = @SalesReasonID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderSalesReasonSelectBySalesOrderHeaderSalesReasonID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderHeaderSalesReasonSelectBySalesOrderHeaderSalesReasonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderHeaderSalesReasonSelectBySalesOrderHeaderSalesReasonID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesOrderHeaderSalesReasonSelectBySalesOrderHeaderSalesReasonID 
     @SalesOrderID int,
     @SalesReasonID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesOrderHeaderSalesReason 
WHERE SalesOrderID = @SalesOrderID
 AND SalesReasonID = @SalesReasonID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderSalesReasonInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesOrderHeaderSalesReasonInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesOrderHeaderSalesReasonInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesOrderHeaderSalesReasonInsert
               @SalesOrderID int
         , @SalesReasonID int
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesOrderHeaderSalesReason 
         (
             SalesOrderID
         , SalesReasonID
         , ModifiedDate

         ) VALUES (
             @SalesOrderID
         , @SalesReasonID
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesOrderHeaderSalesReasonUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesOrderHeaderSalesReasonUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesOrderHeaderSalesReasonUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesOrderHeaderSalesReasonUpdate
            @SalesOrderID int
         , @SalesReasonID int
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesOrderHeaderSalesReason SET
             ModifiedDate = @ModifiedDate
      WHERE SalesOrderID = @SalesOrderID , SalesReasonID = @SalesReasonID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesPersonDeleteBySalesPersonID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesPersonDeleteBySalesPersonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesPersonDeleteBySalesPersonID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesPersonDeleteBySalesPersonID 
     @SalesPersonID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesPerson 
WHERE SalesPersonID = @SalesPersonID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesPersonSelectBySalesPersonID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesPersonSelectBySalesPersonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesPersonSelectBySalesPersonID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesPersonSelectBySalesPersonID 
     @SalesPersonID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesPerson 
WHERE SalesPersonID = @SalesPersonID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesPersonInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesPersonInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesPersonInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesPersonInsert
               @SalesPersonID int
         , @TerritoryID int
         , @SalesQuota money
         , @Bonus money
         , @CommissionPct smallmoney
         , @SalesYTD money
         , @SalesLastYear money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesPerson 
         (
             SalesPersonID
         , TerritoryID
         , SalesQuota
         , Bonus
         , CommissionPct
         , SalesYTD
         , SalesLastYear
         , rowguid
         , ModifiedDate

         ) VALUES (
             @SalesPersonID
         , @TerritoryID
         , @SalesQuota
         , @Bonus
         , @CommissionPct
         , @SalesYTD
         , @SalesLastYear
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesPersonUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesPersonUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesPersonUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesPersonUpdate
            @SalesPersonID int
         , @TerritoryID int
         , @SalesQuota money
         , @Bonus money
         , @CommissionPct smallmoney
         , @SalesYTD money
         , @SalesLastYear money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesPerson SET
             TerritoryID = @TerritoryID
          , SalesQuota = @SalesQuota
          , Bonus = @Bonus
          , CommissionPct = @CommissionPct
          , SalesYTD = @SalesYTD
          , SalesLastYear = @SalesLastYear
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SalesPersonID = @SalesPersonID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesPersonQuotaHistoryDeleteBySalesPersonQuotaHistoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesPersonQuotaHistoryDeleteBySalesPersonQuotaHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesPersonQuotaHistoryDeleteBySalesPersonQuotaHistoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesPersonQuotaHistoryDeleteBySalesPersonQuotaHistoryID 
     @SalesPersonID int,
     @QuotaDate datetime

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesPersonQuotaHistory 
WHERE SalesPersonID = @SalesPersonID
 AND QuotaDate = @QuotaDate

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesPersonQuotaHistorySelectBySalesPersonQuotaHistoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesPersonQuotaHistorySelectBySalesPersonQuotaHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesPersonQuotaHistorySelectBySalesPersonQuotaHistoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesPersonQuotaHistorySelectBySalesPersonQuotaHistoryID 
     @SalesPersonID int,
     @QuotaDate datetime

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesPersonQuotaHistory 
WHERE SalesPersonID = @SalesPersonID
 AND QuotaDate = @QuotaDate

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesPersonQuotaHistoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesPersonQuotaHistoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesPersonQuotaHistoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesPersonQuotaHistoryInsert
               @SalesPersonID int
         , @QuotaDate datetime
         , @SalesQuota money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesPersonQuotaHistory 
         (
             SalesPersonID
         , QuotaDate
         , SalesQuota
         , rowguid
         , ModifiedDate

         ) VALUES (
             @SalesPersonID
         , @QuotaDate
         , @SalesQuota
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesPersonQuotaHistoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesPersonQuotaHistoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesPersonQuotaHistoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesPersonQuotaHistoryUpdate
            @SalesPersonID int
         , @QuotaDate datetime
         , @SalesQuota money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesPersonQuotaHistory SET
             SalesQuota = @SalesQuota
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SalesPersonID = @SalesPersonID , QuotaDate = @QuotaDate 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesReasonDeleteBySalesReasonID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesReasonDeleteBySalesReasonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesReasonDeleteBySalesReasonID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesReasonDeleteBySalesReasonID 
     @SalesReasonID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesReason 
WHERE SalesReasonID = @SalesReasonID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesReasonSelectBySalesReasonID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesReasonSelectBySalesReasonID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesReasonSelectBySalesReasonID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesReasonSelectBySalesReasonID 
     @SalesReasonID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesReason 
WHERE SalesReasonID = @SalesReasonID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesReasonInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesReasonInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesReasonInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesReasonInsert
            
           @Name Name
         , @ReasonType Name
         , @ModifiedDate datetime
        ,@SalesReasonID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesReason 
         (
             Name
         , ReasonType
         , ModifiedDate

         ) VALUES (
             @Name
         , @ReasonType
         , @ModifiedDate
         
        )
        SELECT @SalesReasonID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesReasonUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesReasonUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesReasonUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesReasonUpdate
            @SalesReasonID int
         , @Name Name
         , @ReasonType Name
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesReason SET
             Name = @Name
          , ReasonType = @ReasonType
          , ModifiedDate = @ModifiedDate
      WHERE SalesReasonID = @SalesReasonID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTaxRateDeleteBySalesTaxRateID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTaxRateDeleteBySalesTaxRateID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTaxRateDeleteBySalesTaxRateID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesTaxRateDeleteBySalesTaxRateID 
     @SalesTaxRateID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesTaxRate 
WHERE SalesTaxRateID = @SalesTaxRateID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTaxRateSelectBySalesTaxRateID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTaxRateSelectBySalesTaxRateID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTaxRateSelectBySalesTaxRateID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesTaxRateSelectBySalesTaxRateID 
     @SalesTaxRateID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesTaxRate 
WHERE SalesTaxRateID = @SalesTaxRateID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesTaxRateInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTaxRateInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTaxRateInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesTaxRateInsert
            
           @StateProvinceID int
         , @TaxType tinyint
         , @TaxRate smallmoney
         , @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@SalesTaxRateID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesTaxRate 
         (
             StateProvinceID
         , TaxType
         , TaxRate
         , Name
         , rowguid
         , ModifiedDate

         ) VALUES (
             @StateProvinceID
         , @TaxType
         , @TaxRate
         , @Name
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @SalesTaxRateID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTaxRateUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesTaxRateUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesTaxRateUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesTaxRateUpdate
            @SalesTaxRateID int
         , @StateProvinceID int
         , @TaxType tinyint
         , @TaxRate smallmoney
         , @Name Name
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesTaxRate SET
             StateProvinceID = @StateProvinceID
          , TaxType = @TaxType
          , TaxRate = @TaxRate
          , Name = @Name
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SalesTaxRateID = @SalesTaxRateID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTerritoryDeleteBySalesTerritoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTerritoryDeleteBySalesTerritoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTerritoryDeleteBySalesTerritoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesTerritoryDeleteBySalesTerritoryID 
     @TerritoryID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesTerritory 
WHERE TerritoryID = @TerritoryID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTerritorySelectBySalesTerritoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTerritorySelectBySalesTerritoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTerritorySelectBySalesTerritoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesTerritorySelectBySalesTerritoryID 
     @TerritoryID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesTerritory 
WHERE TerritoryID = @TerritoryID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesTerritoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTerritoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTerritoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesTerritoryInsert
            
           @Name Name
         , @CountryRegionCode nvarchar
         , @Group nvarchar
         , @SalesYTD money
         , @SalesLastYear money
         , @CostYTD money
         , @CostLastYear money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@TerritoryID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesTerritory 
         (
             Name
         , CountryRegionCode
         , Group
         , SalesYTD
         , SalesLastYear
         , CostYTD
         , CostLastYear
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Name
         , @CountryRegionCode
         , @Group
         , @SalesYTD
         , @SalesLastYear
         , @CostYTD
         , @CostLastYear
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @TerritoryID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTerritoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesTerritoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesTerritoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesTerritoryUpdate
            @TerritoryID int
         , @Name Name
         , @CountryRegionCode nvarchar
         , @Group nvarchar
         , @SalesYTD money
         , @SalesLastYear money
         , @CostYTD money
         , @CostLastYear money
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesTerritory SET
             Name = @Name
          , CountryRegionCode = @CountryRegionCode
          , Group = @Group
          , SalesYTD = @SalesYTD
          , SalesLastYear = @SalesLastYear
          , CostYTD = @CostYTD
          , CostLastYear = @CostLastYear
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE TerritoryID = @TerritoryID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTerritoryHistoryDeleteBySalesTerritoryHistoryID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTerritoryHistoryDeleteBySalesTerritoryHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTerritoryHistoryDeleteBySalesTerritoryHistoryID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesTerritoryHistoryDeleteBySalesTerritoryHistoryID 
     @SalesPersonID int,
     @TerritoryID int,
     @StartDate datetime

AS 
     SET NOCOUNT ON;

 DELETE FROM SalesTerritoryHistory 
WHERE SalesPersonID = @SalesPersonID
 AND TerritoryID = @TerritoryID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTerritoryHistorySelectBySalesTerritoryHistoryID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTerritoryHistorySelectBySalesTerritoryHistoryID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTerritoryHistorySelectBySalesTerritoryHistoryID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SalesTerritoryHistorySelectBySalesTerritoryHistoryID 
     @SalesPersonID int,
     @TerritoryID int,
     @StartDate datetime

AS 
 SET NOCOUNT ON;
SELECT * FROM SalesTerritoryHistory 
WHERE SalesPersonID = @SalesPersonID
 AND TerritoryID = @TerritoryID
 AND StartDate = @StartDate

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SalesTerritoryHistoryInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SalesTerritoryHistoryInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SalesTerritoryHistoryInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SalesTerritoryHistoryInsert
               @SalesPersonID int
         , @TerritoryID int
         , @StartDate datetime
         , @EndDate datetime
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SalesTerritoryHistory 
         (
             SalesPersonID
         , TerritoryID
         , StartDate
         , EndDate
         , rowguid
         , ModifiedDate

         ) VALUES (
             @SalesPersonID
         , @TerritoryID
         , @StartDate
         , @EndDate
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SalesTerritoryHistoryUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SalesTerritoryHistoryUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SalesTerritoryHistoryUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SalesTerritoryHistoryUpdate
            @SalesPersonID int
         , @TerritoryID int
         , @StartDate datetime
         , @EndDate datetime
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SalesTerritoryHistory SET
             EndDate = @EndDate
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SalesPersonID = @SalesPersonID , TerritoryID = @TerritoryID , StartDate = @StartDate 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShoppingCartItemDeleteByShoppingCartItemID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShoppingCartItemDeleteByShoppingCartItemID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShoppingCartItemDeleteByShoppingCartItemID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ShoppingCartItemDeleteByShoppingCartItemID 
     @ShoppingCartItemID int

AS 
     SET NOCOUNT ON;

 DELETE FROM ShoppingCartItem 
WHERE ShoppingCartItemID = @ShoppingCartItemID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShoppingCartItemSelectByShoppingCartItemID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShoppingCartItemSelectByShoppingCartItemID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShoppingCartItemSelectByShoppingCartItemID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE ShoppingCartItemSelectByShoppingCartItemID 
     @ShoppingCartItemID int

AS 
 SET NOCOUNT ON;
SELECT * FROM ShoppingCartItem 
WHERE ShoppingCartItemID = @ShoppingCartItemID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     ShoppingCartItemInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'ShoppingCartItemInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  ShoppingCartItemInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE ShoppingCartItemInsert
            
           @ShoppingCartID nvarchar
         , @Quantity int
         , @ProductID int
         , @DateCreated datetime
         , @ModifiedDate datetime
        ,@ShoppingCartItemID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO ShoppingCartItem 
         (
             ShoppingCartID
         , Quantity
         , ProductID
         , DateCreated
         , ModifiedDate

         ) VALUES (
             @ShoppingCartID
         , @Quantity
         , @ProductID
         , @DateCreated
         , @ModifiedDate
         
        )
        SELECT @ShoppingCartItemID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     ShoppingCartItemUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'ShoppingCartItemUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  ShoppingCartItemUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE ShoppingCartItemUpdate
            @ShoppingCartItemID int
         , @ShoppingCartID nvarchar
         , @Quantity int
         , @ProductID int
         , @DateCreated datetime
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE ShoppingCartItem SET
             ShoppingCartID = @ShoppingCartID
          , Quantity = @Quantity
          , ProductID = @ProductID
          , DateCreated = @DateCreated
          , ModifiedDate = @ModifiedDate
      WHERE ShoppingCartItemID = @ShoppingCartItemID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SpecialOfferDeleteBySpecialOfferID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SpecialOfferDeleteBySpecialOfferID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SpecialOfferDeleteBySpecialOfferID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SpecialOfferDeleteBySpecialOfferID 
     @SpecialOfferID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SpecialOffer 
WHERE SpecialOfferID = @SpecialOfferID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SpecialOfferSelectBySpecialOfferID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SpecialOfferSelectBySpecialOfferID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SpecialOfferSelectBySpecialOfferID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SpecialOfferSelectBySpecialOfferID 
     @SpecialOfferID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SpecialOffer 
WHERE SpecialOfferID = @SpecialOfferID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SpecialOfferInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SpecialOfferInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SpecialOfferInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SpecialOfferInsert
            
           @Description nvarchar
         , @DiscountPct smallmoney
         , @Type nvarchar
         , @Category nvarchar
         , @StartDate datetime
         , @EndDate datetime
         , @MinQty int
         , @MaxQty int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@SpecialOfferID int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SpecialOffer 
         (
             Description
         , DiscountPct
         , Type
         , Category
         , StartDate
         , EndDate
         , MinQty
         , MaxQty
         , rowguid
         , ModifiedDate

         ) VALUES (
             @Description
         , @DiscountPct
         , @Type
         , @Category
         , @StartDate
         , @EndDate
         , @MinQty
         , @MaxQty
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @SpecialOfferID = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SpecialOfferUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SpecialOfferUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SpecialOfferUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SpecialOfferUpdate
            @SpecialOfferID int
         , @Description nvarchar
         , @DiscountPct smallmoney
         , @Type nvarchar
         , @Category nvarchar
         , @StartDate datetime
         , @EndDate datetime
         , @MinQty int
         , @MaxQty int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SpecialOffer SET
             Description = @Description
          , DiscountPct = @DiscountPct
          , Type = @Type
          , Category = @Category
          , StartDate = @StartDate
          , EndDate = @EndDate
          , MinQty = @MinQty
          , MaxQty = @MaxQty
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SpecialOfferID = @SpecialOfferID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SpecialOfferProductDeleteBySpecialOfferProductID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SpecialOfferProductDeleteBySpecialOfferProductID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SpecialOfferProductDeleteBySpecialOfferProductID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SpecialOfferProductDeleteBySpecialOfferProductID 
     @SpecialOfferID int,
     @ProductID int

AS 
     SET NOCOUNT ON;

 DELETE FROM SpecialOfferProduct 
WHERE SpecialOfferID = @SpecialOfferID
 AND ProductID = @ProductID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SpecialOfferProductSelectBySpecialOfferProductID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SpecialOfferProductSelectBySpecialOfferProductID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SpecialOfferProductSelectBySpecialOfferProductID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE SpecialOfferProductSelectBySpecialOfferProductID 
     @SpecialOfferID int,
     @ProductID int

AS 
 SET NOCOUNT ON;
SELECT * FROM SpecialOfferProduct 
WHERE SpecialOfferID = @SpecialOfferID
 AND ProductID = @ProductID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     SpecialOfferProductInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'SpecialOfferProductInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  SpecialOfferProductInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE SpecialOfferProductInsert
               @SpecialOfferID int
         , @ProductID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO SpecialOfferProduct 
         (
             SpecialOfferID
         , ProductID
         , rowguid
         , ModifiedDate

         ) VALUES (
             @SpecialOfferID
         , @ProductID
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     SpecialOfferProductUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'SpecialOfferProductUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  SpecialOfferProductUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE SpecialOfferProductUpdate
            @SpecialOfferID int
         , @ProductID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE SpecialOfferProduct SET
             rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE SpecialOfferID = @SpecialOfferID , ProductID = @ProductID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StoreDeleteByStoreID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StoreDeleteByStoreID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StoreDeleteByStoreID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE StoreDeleteByStoreID 
     @CustomerID int

AS 
     SET NOCOUNT ON;

 DELETE FROM Store 
WHERE CustomerID = @CustomerID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StoreSelectByStoreID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StoreSelectByStoreID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StoreSelectByStoreID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE StoreSelectByStoreID 
     @CustomerID int

AS 
 SET NOCOUNT ON;
SELECT * FROM Store 
WHERE CustomerID = @CustomerID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     StoreInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StoreInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StoreInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE StoreInsert
               @CustomerID int
         , @Name Name
         , @SalesPersonID int
         , @Demographics StoreSurveySchemaCollection
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO Store 
         (
             CustomerID
         , Name
         , SalesPersonID
         , Demographics
         , rowguid
         , ModifiedDate

         ) VALUES (
             @CustomerID
         , @Name
         , @SalesPersonID
         , @Demographics
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StoreUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'StoreUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  StoreUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE StoreUpdate
            @CustomerID int
         , @Name Name
         , @SalesPersonID int
         , @Demographics StoreSurveySchemaCollection
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE Store SET
             Name = @Name
          , SalesPersonID = @SalesPersonID
          , Demographics = @Demographics
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE CustomerID = @CustomerID 
        GO




/* -------------------------------------------------------------------------------------*/
/* DELETE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StoreContactDeleteByStoreContactID
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StoreContactDeleteByStoreContactID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StoreContactDeleteByStoreContactID
         GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE StoreContactDeleteByStoreContactID 
     @CustomerID int,
     @ContactID int

AS 
     SET NOCOUNT ON;

 DELETE FROM StoreContact 
WHERE CustomerID = @CustomerID
 AND ContactID = @ContactID

GO
/* -------------------------------------------------------------------------------------*/
/* SELECT BY PRIMARY KEY SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StoreContactSelectByStoreContactID
 /  ------------------------------------------------------------------------------------- */

     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StoreContactSelectByStoreContactID') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StoreContactSelectByStoreContactID
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

 CREATE PROCEDURE StoreContactSelectByStoreContactID 
     @CustomerID int,
     @ContactID int

AS 
 SET NOCOUNT ON;
SELECT * FROM StoreContact 
WHERE CustomerID = @CustomerID
 AND ContactID = @ContactID

GO
/* -------------------------------------------------------------------------------------*/
/* INSERT TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */
         
/* -------------------------------------------------------------------------------------
 /     StoreContactInsert
 /  ------------------------------------------------------------------------------------- */
     
     IF  EXISTS (SELECT * FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'StoreContactInsert') AND type in (N'P', N'PC'))
         DROP PROCEDURE  StoreContactInsert
         GO

         
 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO

     
         CREATE PROCEDURE StoreContactInsert
               @CustomerID int
         , @ContactID int
         , @ContactTypeID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
        ,@ int OUTPUT    
    
         AS
         SET NOCOUNT ON;
         INSERT INTO StoreContact 
         (
             CustomerID
         , ContactID
         , ContactTypeID
         , rowguid
         , ModifiedDate

         ) VALUES (
             @CustomerID
         , @ContactID
         , @ContactTypeID
         , @rowguid
         , @ModifiedDate
         
        )
        SELECT @ = SCOPE_IDENTITY()
        GO


/* -------------------------------------------------------------------------------------*/
/* UPDATE TABLE SCRIPTS */
/* ------------------------------------------------------------------------------------- */

/* -------------------------------------------------------------------------------------
 /     StoreContactUpdate
 /  ------------------------------------------------------------------------------------- */

IF  EXISTS (SELECT * FROM sys.objects 
     WHERE object_id = OBJECT_ID(N'StoreContactUpdate') AND type in (N'P', N'PC'))
 DROP PROCEDURE  StoreContactUpdate
 GO

 SET ANSI_NULLS ON
 GO

 SET QUOTED_IDENTIFIER ON
 GO
         
         CREATE PROCEDURE StoreContactUpdate
            @CustomerID int
         , @ContactID int
         , @ContactTypeID int
         , @rowguid uniqueidentifier
         , @ModifiedDate datetime
    
         AS 
         SET NOCOUNT ON
         UPDATE StoreContact SET
             ContactTypeID = @ContactTypeID
          , rowguid = @rowguid
          , ModifiedDate = @ModifiedDate
      WHERE CustomerID = @CustomerID , ContactID = @ContactID 
        GO




