using DemoEmployee_Web.Library;
using DemoEmployee_Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace DemoEmployee_Web
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public void Emp_Index(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            List<EmployeeModel> listEmployees = new List<EmployeeModel>();
            int filteredCount = 0;
            string query = $"EXEC spDemoEmployee_Employee_DataGrid_Select {iDisplayLength}, {iDisplayStart}, {iSortCol_0}, '{sSortDir_0}', '{sSearch}';";

            DBContext dBContext = new DBContext();
            DataTable dt = dBContext.ExecuteQuery(query);

            foreach(DataRow row in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpCode = row["EmpCode"].ToString();
                emp.EmpName = row["EmpName"].ToString();
                emp.EmpDOB = row["DOB"].ToString();
                emp.EmpDOJ = row["DOJ"].ToString();
                emp.EmpDepartment = row["Department"].ToString();
                emp.EmpReportingTo = row["ReportingTo"].ToString();
                emp.EmpContactNo = row["ContactNo"].ToString();
                emp.EmpIsResigned = Convert.ToBoolean(row["IsResigned"]).ToString();
                emp.EmpResignedDate = row["ResignedDate"].ToString();

                filteredCount = Convert.ToInt32(row["TotalCount"]);

                listEmployees.Add(emp);
            }

            var result = new
            {
                iTotalRecords = GetEmployeeTotalCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = listEmployees
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetEmployeeTotalCount()
        {
            DBContext dBContext = new DBContext();
            
            return Convert.ToInt32(dBContext.ExecuteQuery("select count(*) from tblEmployee where isActive in (1)").Rows[0][0].ToString());
        }
    }
}
