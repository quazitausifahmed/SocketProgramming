USE DemoEmployee_ZABI
GO

IF EXISTS (SELECT * FROM sys.procedures WHERE name IN ('spDemoEmployee_Employee_DataGrid_Select'))
BEGIN

DROP PROCEDURE spDemoEmployee_Employee_DataGrid_Select;

END
GO

CREATE PROCEDURE spDemoEmployee_Employee_DataGrid_Select
@Length INT,
@Start INT,
@SortCol INT,
@SortDir NVARCHAR(10),
@Search NVARCHAR(255)
AS
BEGIN

DECLARE @FirstRec INT, 
@LastRec INT;

SELECT @FirstRec = @Start,
@LastRec = @Start + @Length;

WITH CTE_Employees AS
(
SELECT ROW_NUMBER() OVER (ORDER BY

CASE WHEN (@SortCol = 0 and @SortDir='asc')
THEN EmpCode
END ASC,
CASE WHEN (@SortCol = 0 and @SortDir='desc')
THEN EmpCode
END DESC,

CASE WHEN (@SortCol = 1 and @SortDir='asc')
THEN EmpName
END ASC,
CASE WHEN (@SortCol = 1 and @SortDir='desc')
THEN EmpName
END DESC,

CASE WHEN (@SortCol = 2 and @SortDir='asc')
THEN DOB
END ASC,
CASE WHEN (@SortCol = 2 and @SortDir='desc')
THEN DOB
END DESC,

CASE WHEN (@SortCol = 3 and @SortDir='asc')
THEN DOJ
END ASC,
CASE WHEN (@SortCol = 3 and @SortDir='desc')
THEN DOJ
END DESC,

CASE WHEN (@SortCol = 4 and @SortDir='asc')
THEN Department
END ASC,
CASE WHEN (@SortCol = 4 and @SortDir='desc')
THEN Department
END DESC,

CASE WHEN (@SortCol = 5 and @SortDir='asc')
THEN ReportingTo
END ASC,
CASE WHEN (@SortCol = 5 and @SortDir='desc')
THEN ReportingTo
END DESC,

CASE WHEN (@SortCol = 6 and @SortDir='asc')
THEN ContactNo
END ASC,
CASE WHEN (@SortCol = 6 and @SortDir='desc')
THEN ContactNo
END DESC,

CASE WHEN (@SortCol = 8 and @SortDir='asc')
THEN ResignedDate
END ASC,
CASE WHEN (@SortCol = 8 and @SortDir='desc')
THEN ResignedDate
END DESC)

AS RowNum,
COUNT(*) OVER() AS 'TotalCount',
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
WHERE (@Search IS NULL
OR EmpCode LIKE '%' + @Search + '%'
OR EmpName LIKE '%' + @Search + '%'
OR DOB LIKE '%' + @Search + '%'
OR DOJ LIKE '%' + @Search + '%'
OR Department LIKE '%' + @Search + '%'
OR ReportingTo LIKE '%' + @Search + '%'
OR ContactNo LIKE '%' + @Search + '%'
OR ResignedDate LIKE '%' + @Search + '%')
AND IsActive IN (1)
)
Select *
from CTE_Employees
where RowNum > @FirstRec and RowNum <= @LastRec;

END