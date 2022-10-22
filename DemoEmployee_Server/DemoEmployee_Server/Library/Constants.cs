namespace DemoEmployee_Server.Library
{
    public class Constants
    {
        public string EMPLOYEE_ADD = "EXEC spDemoEmployee_Employee_Insert '@EmpCode', '@EmpName', '@DOB', '@DOJ', '@Department', '@ReportingTo', '@ContactNo';";
        public string EMPLOYEE_UPDATE = "EXEC spDemoEmployee_Employee_Update @ID, '@EmpCode', '@EmpName', '@DOB', '@DOJ', '@Department', '@ReportingTo', '@ContactNo', @IsResigned, '@ResignedDate';";
        public string EMPLOYEE_DELETE = "EXEC spDemoEmployee_Employee_Delete @ID;";
        public string EMPLOYEES_SELECT = "EXEC spDemoEmployee_Employees_Select;";
        public string EMPLOYEE_SELECT = "EXEC spDemoEmployee_Employee_Select @ID;";
    }
}
