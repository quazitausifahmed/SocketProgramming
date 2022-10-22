using DemoEmployee_Server.Enums;
using DemoEmployee_Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace DemoEmployee_Client
{
    public partial class Form1 : Form
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private const int PORT = 8000;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            EmployeeModel employee = new EmployeeModel();
            employee.EmpCode = txt_Code.Text;
            employee.EmpName = txt_Name.Text;
            employee.EmpDOB = ConverToYYYYMMDD(txt_dob.Text);
            employee.EmpDOJ = ConverToYYYYMMDD(txt_doj.Text);
            employee.EmpContactNo = txt_ContactNo.Text;
            employee.EmpDepartment = txt_Department.Text;
            employee.EmpReportingTo = txt_ReportingTo.Text;
            employee.SaveType = SaveTypeEnum.Add;

            string jsondata = JsonConvert.SerializeObject(employee);

            SendRequest(jsondata);
            ResultModel result = JsonConvert.DeserializeObject<ResultModel>(ReceiveResponse());
            MessageBox.Show(result.Message, result.IsSuccess ? "Added Successfull" : "Failed");
            SetEmployeeDataGrid();
            ResetForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            EmployeeModel employee = new EmployeeModel();
            employee.ID = Convert.ToInt32(txt_ID.Text);
            employee.EmpCode = txt_Code.Text;
            employee.EmpName = txt_Name.Text;
            employee.EmpDOB = ConverToYYYYMMDD(txt_dob.Text);
            employee.EmpDOJ = ConverToYYYYMMDD(txt_doj.Text);
            employee.EmpContactNo = txt_ContactNo.Text;
            employee.EmpDepartment = txt_Department.Text;
            employee.EmpReportingTo = txt_ReportingTo.Text;
            employee.EmpIsResigned = chk_Resign.Checked;
            employee.EmpResignedDate = txt_resignedDate.Text;
            employee.SaveType = SaveTypeEnum.Update;

            string jsondata = JsonConvert.SerializeObject(employee);

            SendRequest(jsondata);
            ResultModel result = JsonConvert.DeserializeObject<ResultModel>(ReceiveResponse());
            MessageBox.Show(result.Message, result.IsSuccess ? "Update Successfull" : "Failed");

            SetEmployeeDataGrid();
            ResetForm();
        }

        private void SetEmployeeDataGrid()
        {
            EmployeeModel employee = new EmployeeModel();
            employee.SaveType = SaveTypeEnum.SelectAll;

            string jsondata = JsonConvert.SerializeObject(employee);

            ConnectToServer();
            SendRequest(jsondata);
            List<EmployeeModel> employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(ReceiveResponse());
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("EmpCode");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("EmpDOB");
            dt.Columns.Add("EmpDOJ");
            dt.Columns.Add("EmpDepartment");
            dt.Columns.Add("EmpReportingTo");
            dt.Columns.Add("EmpContactNo");
            dt.Columns.Add("EmpResigned");
            dt.Columns.Add("EmpResignedDate");

            foreach(var emp in employees)
            {
                dt.Rows.Add(emp.ID, emp.EmpCode, emp.EmpName, emp.EmpDOB, emp.EmpDOJ, emp.EmpDepartment, emp.EmpReportingTo, emp.EmpContactNo, emp.EmpIsResigned, emp.EmpResignedDate);
            }

            empGrid.DataSource = dt;
        }

        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(IPAddress.Loopback, PORT);
                }
                catch (SocketException)
                {
                    
                }
            }
        }

        private static void Exit()
        {
            SendString("exit");
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        private static void SendRequest(string data)
        {
            Console.Write("Send a request: ");
            SendString(data);
        }

        private static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private static string ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return "";
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            
            return text;
        }


        private string ConverToYYYYMMDD(string date)
        {
            string res = string.Empty;

            if(!string.IsNullOrEmpty(date))
            {
                string[] data = date.Split('/');
                res = $"{data[2]}-{data[0]}-{data[1]}";
            }

            return res;
        }

        private string ConverToDDMMYYYY(string date)
        {
            string res = string.Empty;

            if (!string.IsNullOrEmpty(date))
            {
                string[] data = date.Split('/');
                res = $"{data[2]}-{data[0]}-{data[1]}";
            }

            return res;
        }

        private void empGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeModel employee = new EmployeeModel();

            if (empGrid.Columns[e.ColumnIndex].HeaderText == "Update")
            {
                txt_ID.Text = empGrid.Rows[e.RowIndex].Cells["EmpID"].Value.ToString();
                txt_Code.Text = empGrid.Rows[e.RowIndex].Cells["EmpCode"].Value.ToString();
                txt_Name.Text = empGrid.Rows[e.RowIndex].Cells["EmpName"].Value.ToString();
                txt_Department.Text = empGrid.Rows[e.RowIndex].Cells["EmpDepartment"].Value.ToString();
                txt_ReportingTo.Text = empGrid.Rows[e.RowIndex].Cells["EmpReportingTo"].Value.ToString();
                txt_ContactNo.Text = empGrid.Rows[e.RowIndex].Cells["EmpContactNo"].Value.ToString();

                txt_dob.Text = empGrid.Rows[e.RowIndex].Cells["EmpDOB"].Value.ToString();
                txt_doj.Text = empGrid.Rows[e.RowIndex].Cells["EmpDOJ"].Value.ToString();

                if (Convert.ToBoolean(empGrid.Rows[e.RowIndex].Cells["EmpResigned"].Value.ToString()))
                {
                    txt_resignedDate.Text = empGrid.Rows[e.RowIndex].Cells["EmpResignedDate"].Value.ToString();
                    chk_Resign.Checked = true;
                }
                else
                {
                    txt_resignedDate.Text = DateTime.Now.ToString();
                    chk_Resign.Checked = false;
                }
                
            }

            if (empGrid.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(empGrid.Rows[e.RowIndex].Cells["EmpID"].Value);
                    employee.ID = id;
                    employee.SaveType = SaveTypeEnum.Delete;
                    string jsondata = JsonConvert.SerializeObject(employee);
                    SendRequest(jsondata);
                    ResultModel res = JsonConvert.DeserializeObject<ResultModel>(ReceiveResponse());
                    MessageBox.Show(res.Message, res.IsSuccess ? "Added Successfull" : "Failed");
                    SetEmployeeDataGrid();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToServer();
            SetEmployeeDataGrid();
        }

        private void ResetForm()
        {
            txt_Code.Text = string.Empty;
            txt_Name.Text = string.Empty;
            txt_Department.Text = string.Empty;
            txt_ReportingTo.Text = string.Empty;
            txt_ContactNo.Text = string.Empty;
            
            txt_dob.Text = DateTime.Now.ToString();
            txt_doj.Text = DateTime.Now.ToString();
            
            txt_resignedDate.Text = DateTime.Now.ToString();
            chk_Resign.Checked = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
