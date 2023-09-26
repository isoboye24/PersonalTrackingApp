namespace PersonalTrackingApp
{
    partial class FormEmployee
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
            this.rbIsAdmin = new System.Windows.Forms.RadioButton();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbIsAdmin);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUserNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 60);
            this.panel1.TabIndex = 0;
            // 
            // rbIsAdmin
            // 
            this.rbIsAdmin.AutoSize = true;
            this.rbIsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbIsAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIsAdmin.Location = new System.Drawing.Point(659, 18);
            this.rbIsAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbIsAdmin.Name = "rbIsAdmin";
            this.rbIsAdmin.Size = new System.Drawing.Size(101, 25);
            this.rbIsAdmin.TabIndex = 3;
            this.rbIsAdmin.TabStop = true;
            this.rbIsAdmin.Text = "Is Admin?";
            this.rbIsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(260, 13);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(104, 34);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 34;
            this.label1.Text = "User No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 32;
            this.label5.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(494, 16);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(139, 29);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(104, 16);
            this.txtUserNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(139, 29);
            this.txtUserNo.TabIndex = 0;
            this.txtUserNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserNo_KeyPress);
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(137, 274);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(190, 29);
            this.cmbPosition.TabIndex = 7;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(137, 235);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(190, 29);
            this.cmbDepartment.TabIndex = 6;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cmbDepartment_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 277);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 30;
            this.label6.Text = "Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 238);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Department";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 77);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 29);
            this.txtName.TabIndex = 1;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(137, 116);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(190, 29);
            this.txtSurname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 32;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 33;
            this.label3.Text = "Surname";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 200);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 33;
            this.label7.Text = "Salary";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 161);
            this.label8.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 21);
            this.label8.TabIndex = 32;
            this.label8.Text = "Image Path";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(137, 197);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(190, 29);
            this.txtSalary.TabIndex = 5;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(137, 158);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(190, 29);
            this.txtImagePath.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 352);
            this.label9.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 21);
            this.label9.TabIndex = 32;
            this.label9.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(137, 349);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(547, 86);
            this.txtAddress.TabIndex = 9;
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(342, 161);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(104, 34);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(246, 457);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 34);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(413, 457);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 34);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateTimePickerBirthday
            // 
            this.dateTimePickerBirthday.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerBirthday.Location = new System.Drawing.Point(137, 311);
            this.dateTimePickerBirthday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            this.dateTimePickerBirthday.Size = new System.Drawing.Size(284, 29);
            this.dateTimePickerBirthday.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 317);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 21);
            this.label10.TabIndex = 37;
            this.label10.Text = "Birthday";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(538, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 504);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dateTimePickerBirthday);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.cmbPosition);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbIsAdmin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserNo;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthday;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}