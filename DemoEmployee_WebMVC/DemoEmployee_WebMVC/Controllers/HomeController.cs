using DemoEmployee_WebMVC.Library;
using DemoEmployee_WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DemoEmployee_WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetData(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            List<EmployeeModel> listEmployees = new List<EmployeeModel>();
            int filteredCount = 0;
            string query = $"EXEC spDemoEmployee_Employee_DataGrid_Select {iDisplayLength}, {iDisplayStart}, {iSortCol_0}, '{sSortDir_0}', '{sSearch}';";

            DBContext dBContext = new DBContext();
            DataTable dt = dBContext.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
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

            return Json(new { iTotalRecords = GetEmployeeTotalCount(), iTotalDisplayRecords = filteredCount, aaData = listEmployees }, JsonRequestBehavior.AllowGet);
        }

        private int GetEmployeeTotalCount()
        {
            DBContext dBContext = new DBContext();

            return Convert.ToInt32(dBContext.ExecuteQuery("select count(*) from tblEmployee where isActive in (1)").Rows[0][0].ToString());
        }
    }
}