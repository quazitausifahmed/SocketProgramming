<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DemoEmployee_Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.datatables.net/1.12.1/css/jquery.dataTables.min.css" rel="stylesheet" />
</head>
<body>
    <div>
        <table id="emp" class="display" style="width:100%">
        <thead>
            <tr>
                <th>Emp Code</th>
                <th>Emp Name</th>
                <th>DOB</th>
                <th>DOJ</th>
                <th>Department</th>
                <th>Reporting To</th>
                <th>Contact No</th>
                <th>Resigned</th>
                <th>Resigned Date</th>
            </tr>
        </thead>
    </table>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#emp').DataTable({
                bServerSide: true,
                sAjaxSource: 'EmployeeService.asmx/Emp_Index',
                sServerMethod: 'POST',
                columns: [
                    { data: 'EmpCode' },
                    { data: 'EmpName' },
                    { data: 'EmpDOB' },
                    { data: 'EmpDOJ' },
                    { data: 'EmpDepartment' },
                    { data: 'EmpReportingTo' },
                    { data: 'EmpContactNo' },
                    { data: 'EmpIsResigned' },
                    { data: 'EmpResignedDate' }
                ],
            });
        });

    </script>
</body>
</html>
