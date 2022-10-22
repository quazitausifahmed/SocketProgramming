IF NOT EXISTS (SELECT * FROM sys.databases WHERE name IN ('DemoEmployee_ZABI'))
BEGIN

CREATE DATABASE DemoEmployee_ZABI;

END
GO

USE DemoEmployee_ZABI;
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name IN ('tblEmployee'))
BEGIN

DROP TABLE tblEmployee;

END

CREATE TABLE tblEmployee(
ID INT IDENTITY(1,1) PRIMARY KEY,
EmpCode NVARCHAR(10) NOT NULL,
EmpName NVARCHAR(200) NOT NULL,
DOB DATE,
DOJ DATE,
Department NVARCHAR(100),
ReportingTo NVARCHAR(200),
ContactNo NVARCHAR(50),
IsResigned BIT DEFAULT(0),
ResignedDate DATE,
IsActive BIT DEFAULT(1),
CreatedByID INT,
CreatedOn DATETIME DEFAULT(GETDATE()),
ModifiedBy INT,
ModifiedOn DATETIME
);

GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name IN ('spDemoEmployee_Employee_Insert'))
BEGIN

DROP PROCEDURE spDemoEmployee_Employee_Insert;

END
GO

CREATE PROCEDURE spDemoEmployee_Employee_Insert
@EmpCode NVARCHAR(10),
@EmpName NVARCHAR(200),
@DOB DATE,
@DOJ DATE,
@Department NVARCHAR(100),
@ReportingTo NVARCHAR(200),
@ContactNo NVARCHAR(50)
AS
BEGIN

DECLARE @IsSuccess BIT = 0,
@Message NVARCHAR(100);

BEGIN TRANSACTION;
BEGIN TRY

IF EXISTS (SELECT * FROM tblEmployee 
WHERE EmpCode IN (@EmpCode)
AND EmpName IN (@EmpName)
AND DOB IN (@DOB)
AND DOJ IN (@DOJ)
AND Department IN (@Department)
AND ContactNo IN (@ContactNo)
AND IsActive IN (1)
)
BEGIN

SELECT @IsSuccess = 0, 
@Message = CONCAT_WS(' ', @EmpName , 'is already available.');

END
ELSE
BEGIN

INSERT INTO tblEmployee(
EmpCode,
EmpName,
DOB,
DOJ,
Department,
ReportingTo,
ContactNo,
CreatedByID)
VALUES (
@EmpCode,
@EmpName,
@DOB,
@DOJ,
@Department,
@ReportingTo,
@ContactNo,
0
);

SELECT @IsSuccess = 1, 
@Message = CONCAT_WS(' ', @EmpName , 'has beed added.');

END
COMMIT TRANSACTION;
END TRY
BEGIN CATCH

ROLLBACK TRANSACTION;

SELECT @IsSuccess = 0, 
@Message = CONCAT_WS(' ', 'Error occured while adding',@EmpName , '.');

END CATCH

SELECT @IsSuccess AS 'IsSuccess', @Message AS 'Message';

END
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name IN ('spDemoEmployee_Employee_Update'))
BEGIN

DROP PROCEDURE spDemoEmployee_Employee_Update;

END
GO

CREATE PROCEDURE spDemoEmployee_Employee_Update
@ID INT,
@EmpCode NVARCHAR(10),
@EmpName NVARCHAR(200),
@DOB DATE,
@DOJ DATE,
@Department NVARCHAR(100),
@ReportingTo NVARCHAR(200),
@ContactNo NVARCHAR(50),
@IsResigned BIT = 0,
@ResignedDate DATE = NULL
AS
BEGIN

DECLARE @IsSuccess BIT = 0,
@Message NVARCHAR(100);

BEGIN TRANSACTION;
BEGIN TRY

IF EXISTS (SELECT * FROM tblEmployee 
WHERE EmpCode IN (@EmpCode)
AND EmpName IN (@EmpName)
AND DOB IN (@DOB)
AND DOJ IN (@DOJ)
AND Department IN (@Department)
AND ContactNo IN (@ContactNo)
AND IsResigned IN (@IsResigned)
AND ResignedDate IN (@ResignedDate)
AND IsActive IN (1)
)
BEGIN

SELECT @IsSuccess = 0, 
@Message = CONCAT_WS(' ', @EmpName , 'is already available.');

END
ELSE
BEGIN

UPDATE tblEmployee
SET EmpCode = @EmpCode,
EmpName = @EmpName,
DOB = @DOB,
DOJ = @DOJ,
Department = @Department,
ContactNo = @ContactNo,
IsResigned = @IsResigned,
ResignedDate = (CASE WHEN @IsResigned IN (0) THEN NULL ELSE @ResignedDate END),
ModifiedBy = 0,
ModifiedOn = GETDATE()
WHERE ID IN (@ID);

SELECT @IsSuccess = 1, 
@Message = CONCAT_WS(' ', @EmpName , 'details has beed udpated.');

END
COMMIT TRANSACTION;
END TRY
BEGIN CATCH

ROLLBACK TRANSACTION;

SELECT @IsSuccess = 0, 
@Message = CONCAT_WS(' ', 'Error occured while updating',@EmpName , ' details.');

END CATCH

SELECT @IsSuccess AS 'IsSuccess', @Message AS 'Message';

END
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name IN ('spDemoEmployee_Employee_Delete'))
BEGIN

DROP PROCEDURE spDemoEmployee_Employee_Delete;

END
GO

CREATE PROCEDURE spDemoEmployee_Employee_Delete
@ID INT
AS
BEGIN

DECLARE @IsSuccess BIT = 0,
@Message NVARCHAR(100),
@Name NVARCHAR(200);

BEGIN TRANSACTION;
BEGIN TRY

SELECT 
@Name = EmpName
FROM tblEmployee
WHERE ID IN (@ID)
AND IsActive IN (1);

IF NOT EXISTS (SELECT * FROM tblEmployee 
WHERE ID IN (@ID)
AND IsActive IN (1)
)
BEGIN

SELECT @IsSuccess = 0, 
@Message = CONCAT_WS(' ', @Name , 'is not available.');

END
ELSE
BEGIN

UPDATE tblEmployee
SET IsActive = 0,
ModifiedBy = 0,
ModifiedOn = GETDATE()
WHERE ID IN (@ID);

SELECT @IsSuccess = 1, 
@Message = CONCAT_WS(' ', @Name , 'has beed delete.');

END
COMMIT TRANSACTION;
END TRY
BEGIN CATCH

ROLLBACK TRANSACTION;

SELECT @IsSuccess = 0, 
@Message = CONCAT_WS(' ', 'Error occured while deleting', @Name, '.');

END CATCH

SELECT @IsSuccess AS 'IsSuccess', @Message AS 'Message';

END
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name IN ('spDemoEmployee_Employees_Select'))
BEGIN

DROP PROCEDURE spDemoEmployee_Employees_Select;

END
GO

CREATE PROCEDURE spDemoEmployee_Employees_Select
AS
BEGIN

SELECT 
ID,
EmpCode,
EmpName,
DOB,
DOJ,
Department,
ReportingTo,
ContactNo,
IsResigned,
ResignedDate
FROM tblEmployee
WHERE IsActive IN (1);

END
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name IN ('spDemoEmployee_Employee_Select'))
BEGIN

DROP PROCEDURE spDemoEmployee_Employee_Select;

END
GO

CREATE PROCEDURE spDemoEmployee_Employee_Select
@ID INT
AS
BEGIN

SELECT 
ID,
EmpCode,
EmpName,
DOB,
DOJ,
Department,
ReportingTo,
ContactNo,
IsResigned,
ResignedDate
FROM tblEmployee
WHERE IsActive IN (1)
AND ID IN (@ID);

END
GO