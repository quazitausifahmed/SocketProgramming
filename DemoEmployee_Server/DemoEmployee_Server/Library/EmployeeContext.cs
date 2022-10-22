using DemoEmployee_Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace DemoEmployee_Server.Library
{
    public class EmployeeContext
    {
        Constants constants = new Constants();
        public string Save(string data)
        {
            EmployeeModel model = new EmployeeModel();
            model = JsonConvert.DeserializeObject<EmployeeModel>(data);
            string result = string.Empty;
            switch ((int)model.SaveType)
            {
                case 0:
                    result = AddEmployee(model);
                    break;
                case 1:
                    result = UpdateEmployee(model);
                    break;
                case 2:
                    result = DeleteEmployee(model.ID);
                    break;
                case 3:
                    result = GetEmployees();
                    break;
                case 4:
                    result = GetEmployee(model.ID);
                    break;
                    default:
                    break;
            }

            return result;
        }

        private string AddEmployee(EmployeeModel employee)
        {
            DBContext dB = new DBContext();
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("@EmpCode", employee.EmpCode.ToString()));
            data.Add(new KeyValuePair<string, string>("@EmpName", employee.EmpName.ToString()));
            data.Add(new KeyValuePair<string, string>("@DOB", employee.EmpDOB.ToString()));
            data.Add(new KeyValuePair<string, string>("@DOJ", employee.EmpDOJ.ToString()));
            data.Add(new KeyValuePair<string, string>("@Department", employee.EmpDepartment.ToString()));
            data.Add(new KeyValuePair<string, string>("@ReportingTo", employee.EmpReportingTo.ToString()));
            data.Add(new KeyValuePair<string, string>("@ContactNo", employee.EmpContactNo.ToString()));

            string query = constants.EMPLOYEE_ADD;

            foreach(var d in data)
            {
                query = query.Replace(d.Key, d.Value);
            }

            DataTable dt = dB.ExecuteQuery(query);

            ResultModel result = new ResultModel();
            result.IsSuccess = Convert.ToBoolean(dt.Rows[0][0].ToString());
            result.Message = dt.Rows[0][1].ToString();

            return JsonConvert.SerializeObject(result);
        }

        private string UpdateEmployee(EmployeeModel employee)
        {
            DBContext dB = new DBContext();
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("@ID", employee.ID.ToString()));
            data.Add(new KeyValuePair<string, string>("@EmpCode", employee.EmpCode.ToString()));
            data.Add(new KeyValuePair<string, string>("@EmpName", employee.EmpName.ToString()));
            data.Add(new KeyValuePair<string, string>("@DOB", employee.EmpDOB.ToString()));
            data.Add(new KeyValuePair<string, string>("@DOJ", employee.EmpDOJ.ToString()));
            data.Add(new KeyValuePair<string, string>("@Department", employee.EmpDepartment.ToString()));
            data.Add(new KeyValuePair<string, string>("@ReportingTo", employee.EmpReportingTo.ToString()));
            data.Add(new KeyValuePair<string, string>("@ContactNo", employee.EmpContactNo.ToString()));

            if (employee.EmpIsResigned)
            {
                data.Add(new KeyValuePair<string, string>("@IsResigned", employee.EmpIsResigned.ToString()));
                data.Add(new KeyValuePair<string, string>("@ResignedDate", employee.EmpResignedDate.ToString()));
            }
            else
            {
                data.Add(new KeyValuePair<string, string>("@IsResigned", employee.EmpIsResigned.ToString()));
                data.Add(new KeyValuePair<string, string>("@ResignedDate", null));
            }

            string query = constants.EMPLOYEE_UPDATE;

            foreach (var d in data)
            {
                query = query.Replace(d.Key, d.Value);
            }

            DataTable dt = dB.ExecuteQuery(query);

            ResultModel result = new ResultModel();
            result.IsSuccess = Convert.ToBoolean(dt.Rows[0][0].ToString());
            result.Message = dt.Rows[0][1].ToString();

            return JsonConvert.SerializeObject(result);
        }

        private string DeleteEmployee(int ID)
        {
            DBContext dB = new DBContext();
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("@ID", ID.ToString()));

            string query = constants.EMPLOYEE_DELETE;

            foreach (var d in data)
            {
                query = query.Replace(d.Key, d.Value);
            }

            DataTable dt = dB.ExecuteQuery(query);

            ResultModel result = new ResultModel();
            result.IsSuccess = Convert.ToBoolean(dt.Rows[0][0].ToString());
            result.Message = dt.Rows[0][1].ToString();

            return JsonConvert.SerializeObject(result);
        }

        private string GetEmployees()
        {
            DBContext dB = new DBContext();

            string query = constants.EMPLOYEES_SELECT;

            DataTable dt = dB.ExecuteQuery(query);

            List<EmployeeModel> emp = new List<EmployeeModel>();

            foreach(DataRow dr in dt.Rows)
            {
                emp.Add(new EmployeeModel
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    EmpCode = dr["EmpCode"].ToString(),
                    EmpName = dr["EmpName"].ToString(),
                    EmpDOB = dr["DOB"].ToString(),
                    EmpDOJ = dr["DOJ"].ToString(),
                    EmpDepartment = dr["Department"].ToString(),
                    EmpReportingTo = dr["ReportingTo"].ToString(),
                    EmpContactNo = dr["ContactNo"].ToString(),
                    EmpIsResigned = Convert.ToBoolean(dr["IsResigned"]),
                    EmpResignedDate = dr["ResignedDate"].ToString()
                });
            }

            return JsonConvert.SerializeObject(emp);
        }

        private string GetEmployee(int ID)
        {
            DBContext dB = new DBContext();
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("@ID", ID.ToString()));

            string query = constants.EMPLOYEE_SELECT;

            foreach (var d in data)
            {
                query = query.Replace(d.Key, d.Value);
            }

            DataTable dt = dB.ExecuteQuery(query);

            EmployeeModel model = new EmployeeModel();

            model.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
            model.EmpCode = dt.Rows[0]["EmpCode"].ToString();
            model.EmpName = dt.Rows[0]["EmpName"].ToString();
            model.EmpDOB = dt.Rows[0]["DOB"].ToString();
            model.EmpDOJ = dt.Rows[0]["DOJ"].ToString();
            model.EmpDepartment = dt.Rows[0]["Department"].ToString();
            model.EmpReportingTo = dt.Rows[0]["ReportingTo"].ToString();
            model.EmpContactNo = dt.Rows[0]["ContactNo"].ToString();
            model.EmpIsResigned = Convert.ToBoolean(dt.Rows[0]["IsResigned"]);
            model.EmpResignedDate = dt.Rows[0]["ResignedDate"].ToString();

            return JsonConvert.SerializeObject(model);
        }
    }
}
