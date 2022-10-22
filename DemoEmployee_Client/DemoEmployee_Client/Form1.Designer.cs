namespace DemoEmployee_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_update = new System.Windows.Forms.Button();
            this.txt_doj = new System.Windows.Forms.DateTimePicker();
            this.txt_resignedDate = new System.Windows.Forms.DateTimePicker();
            this.txt_dob = new System.Windows.Forms.DateTimePicker();
            this.btn_Add = new System.Windows.Forms.Button();
            this.chk_Resign = new System.Windows.Forms.CheckBox();
            this.txt_ContactNo = new System.Windows.Forms.TextBox();
            this.txt_ReportingTo = new System.Windows.Forms.TextBox();
            this.txt_Department = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.empGrid = new System.Windows.Forms.DataGridView();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.EmpID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpDOJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpReportingTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpContactNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpResigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpResignedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.txt_ID);
            this.panel1.Controls.Add(this.btn_update);
            this.panel1.Controls.Add(this.txt_doj);
            this.panel1.Controls.Add(this.txt_resignedDate);
            this.panel1.Controls.Add(this.txt_dob);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.chk_Resign);
            this.panel1.Controls.Add(this.txt_ContactNo);
            this.panel1.Controls.Add(this.txt_ReportingTo);
            this.panel1.Controls.Add(this.txt_Department);
            this.panel1.Controls.Add(this.txt_Name);
            this.panel1.Controls.Add(this.txt_Code);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 667);
            this.panel1.TabIndex = 0;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(182, 520);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(93, 31);
            this.btn_update.TabIndex = 31;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // txt_doj
            // 
            this.txt_doj.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_doj.Location = new System.Drawing.Point(175, 214);
            this.txt_doj.Name = "txt_doj";
            this.txt_doj.Size = new System.Drawing.Size(200, 22);
            this.txt_doj.TabIndex = 29;
            // 
            // txt_resignedDate
            // 
            this.txt_resignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_resignedDate.Location = new System.Drawing.Point(175, 431);
            this.txt_resignedDate.Name = "txt_resignedDate";
            this.txt_resignedDate.Size = new System.Drawing.Size(200, 22);
            this.txt_resignedDate.TabIndex = 28;
            // 
            // txt_dob
            // 
            this.txt_dob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_dob.Location = new System.Drawing.Point(175, 158);
            this.txt_dob.Name = "txt_dob";
            this.txt_dob.Size = new System.Drawing.Size(200, 22);
            this.txt_dob.TabIndex = 30;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(34, 520);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(142, 31);
            this.btn_Add.TabIndex = 27;
            this.btn_Add.Text = "Add Employee";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // chk_Resign
            // 
            this.chk_Resign.AutoSize = true;
            this.chk_Resign.Location = new System.Drawing.Point(34, 435);
            this.chk_Resign.Name = "chk_Resign";
            this.chk_Resign.Size = new System.Drawing.Size(88, 20);
            this.chk_Resign.TabIndex = 25;
            this.chk_Resign.Text = "Resigned";
            this.chk_Resign.UseVisualStyleBackColor = true;
            // 
            // txt_ContactNo
            // 
            this.txt_ContactNo.Location = new System.Drawing.Point(175, 369);
            this.txt_ContactNo.Name = "txt_ContactNo";
            this.txt_ContactNo.Size = new System.Drawing.Size(204, 22);
            this.txt_ContactNo.TabIndex = 24;
            // 
            // txt_ReportingTo
            // 
            this.txt_ReportingTo.Location = new System.Drawing.Point(175, 314);
            this.txt_ReportingTo.Name = "txt_ReportingTo";
            this.txt_ReportingTo.Size = new System.Drawing.Size(204, 22);
            this.txt_ReportingTo.TabIndex = 23;
            // 
            // txt_Department
            // 
            this.txt_Department.Location = new System.Drawing.Point(175, 265);
            this.txt_Department.Name = "txt_Department";
            this.txt_Department.Size = new System.Drawing.Size(204, 22);
            this.txt_Department.TabIndex = 22;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(175, 107);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(204, 22);
            this.txt_Name.TabIndex = 19;
            // 
            // txt_Code
            // 
            this.txt_Code.Location = new System.Drawing.Point(175, 58);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(204, 22);
            this.txt_Code.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Contact No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Reporting To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "DOJ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "DOB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Emp Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Emp Code";
            // 
            // empGrid
            // 
            this.empGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmpID,
            this.EmpCode,
            this.EmpName,
            this.EmpDOB,
            this.EmpDOJ,
            this.EmpDepartment,
            this.EmpReportingTo,
            this.EmpContactNo,
            this.EmpResigned,
            this.EmpResignedDate,
            this.UpdateButton,
            this.DeleteButton});
            this.empGrid.Location = new System.Drawing.Point(445, 29);
            this.empGrid.Name = "empGrid";
            this.empGrid.RowHeadersWidth = 51;
            this.empGrid.RowTemplate.Height = 24;
            this.empGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empGrid.Size = new System.Drawing.Size(872, 667);
            this.empGrid.TabIndex = 1;
            this.empGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.empGrid_CellContentClick);
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(175, 16);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(100, 22);
            this.txt_ID.TabIndex = 32;
            this.txt_ID.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(295, 520);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 31);
            this.btnReset.TabIndex = 33;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // EmpID
            // 
            this.EmpID.DataPropertyName = "ID";
            this.EmpID.HeaderText = "ID";
            this.EmpID.MinimumWidth = 6;
            this.EmpID.Name = "EmpID";
            this.EmpID.ReadOnly = true;
            this.EmpID.Visible = false;
            this.EmpID.Width = 125;
            // 
            // EmpCode
            // 
            this.EmpCode.DataPropertyName = "EmpCode";
            this.EmpCode.HeaderText = "Emp Code";
            this.EmpCode.MinimumWidth = 6;
            this.EmpCode.Name = "EmpCode";
            this.EmpCode.ReadOnly = true;
            this.EmpCode.Width = 125;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderText = "Name";
            this.EmpName.MinimumWidth = 6;
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            this.EmpName.Width = 125;
            // 
            // EmpDOB
            // 
            this.EmpDOB.DataPropertyName = "EmpDOB";
            this.EmpDOB.HeaderText = "DOB";
            this.EmpDOB.MinimumWidth = 6;
            this.EmpDOB.Name = "EmpDOB";
            this.EmpDOB.ReadOnly = true;
            this.EmpDOB.Width = 125;
            // 
            // EmpDOJ
            // 
            this.EmpDOJ.DataPropertyName = "EmpDOJ";
            this.EmpDOJ.HeaderText = "DOJ";
            this.EmpDOJ.MinimumWidth = 6;
            this.EmpDOJ.Name = "EmpDOJ";
            this.EmpDOJ.ReadOnly = true;
            this.EmpDOJ.Width = 125;
            // 
            // EmpDepartment
            // 
            this.EmpDepartment.DataPropertyName = "EmpDepartment";
            this.EmpDepartment.HeaderText = "Department";
            this.EmpDepartment.MinimumWidth = 6;
            this.EmpDepartment.Name = "EmpDepartment";
            this.EmpDepartment.ReadOnly = true;
            this.EmpDepartment.Width = 125;
            // 
            // EmpReportingTo
            // 
            this.EmpReportingTo.DataPropertyName = "EmpReportingTo";
            this.EmpReportingTo.HeaderText = "Reporting To";
            this.EmpReportingTo.MinimumWidth = 6;
            this.EmpReportingTo.Name = "EmpReportingTo";
            this.EmpReportingTo.ReadOnly = true;
            this.EmpReportingTo.Width = 125;
            // 
            // EmpContactNo
            // 
            this.EmpContactNo.DataPropertyName = "EmpContactNo";
            this.EmpContactNo.HeaderText = "Contact No";
            this.EmpContactNo.MinimumWidth = 6;
            this.EmpContactNo.Name = "EmpContactNo";
            this.EmpContactNo.ReadOnly = true;
            this.EmpContactNo.Width = 125;
            // 
            // EmpResigned
            // 
            this.EmpResigned.DataPropertyName = "EmpResigned";
            this.EmpResigned.HeaderText = "Resigned";
            this.EmpResigned.MinimumWidth = 6;
            this.EmpResigned.Name = "EmpResigned";
            this.EmpResigned.ReadOnly = true;
            this.EmpResigned.Width = 125;
            // 
            // EmpResignedDate
            // 
            this.EmpResignedDate.DataPropertyName = "EmpResignedDate";
            this.EmpResignedDate.HeaderText = "Resigned Date";
            this.EmpResignedDate.MinimumWidth = 6;
            this.EmpResignedDate.Name = "EmpResignedDate";
            this.EmpResignedDate.ReadOnly = true;
            this.EmpResignedDate.Width = 125;
            // 
            // UpdateButton
            // 
            this.UpdateButton.HeaderText = "Update";
            this.UpdateButton.MinimumWidth = 6;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseColumnTextForButtonValue = true;
            this.UpdateButton.Width = 125;
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "Delete";
            this.DeleteButton.MinimumWidth = 6;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseColumnTextForButtonValue = true;
            this.DeleteButton.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1383, 731);
            this.Controls.Add(this.empGrid);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1401, 778);
            this.MinimumSize = new System.Drawing.Size(1401, 778);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txt_doj;
        private System.Windows.Forms.DateTimePicker txt_resignedDate;
        private System.Windows.Forms.DateTimePicker txt_dob;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.CheckBox chk_Resign;
        private System.Windows.Forms.TextBox txt_ContactNo;
        private System.Windows.Forms.TextBox txt_ReportingTo;
        private System.Windows.Forms.TextBox txt_Department;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView empGrid;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpDOJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpReportingTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpContactNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpResigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpResignedDate;
        private System.Windows.Forms.DataGridViewButtonColumn UpdateButton;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}

