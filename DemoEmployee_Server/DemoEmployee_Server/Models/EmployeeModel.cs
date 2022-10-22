using DemoEmployee_Server.Enums;

namespace DemoEmployee_Server.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string EmpDOB { get; set; }
        public string EmpDOJ { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpReportingTo { get; set; }
        public string EmpContactNo { get; set; }
        public bool EmpIsResigned { get; set; }
        public string EmpResignedDate { get; set; }
        public SaveTypeEnum SaveType { get; set; }
    }
}
