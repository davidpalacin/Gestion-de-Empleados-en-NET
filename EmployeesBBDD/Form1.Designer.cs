namespace EmployeesBBDD
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.davidPalacinEmployeesDataSet = new EmployeesBBDD.DavidPalacinEmployeesDataSet();
            this.davidPalacinEmployeesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCrearJob = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.txtMinSalary = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxSalary = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstJobs = new System.Windows.Forms.ListBox();
            this.btnActualizarTabla = new System.Windows.Forms.Button();
            this.btnDeleteJob = new System.Windows.Forms.Button();
            this.btnAbrirEmployees = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.davidPalacinEmployeesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.davidPalacinEmployeesDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // davidPalacinEmployeesDataSet
            // 
            this.davidPalacinEmployeesDataSet.DataSetName = "DavidPalacinEmployeesDataSet";
            this.davidPalacinEmployeesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // davidPalacinEmployeesDataSetBindingSource
            // 
            this.davidPalacinEmployeesDataSetBindingSource.DataSource = this.davidPalacinEmployeesDataSet;
            this.davidPalacinEmployeesDataSetBindingSource.Position = 0;
            // 
            // btnCrearJob
            // 
            this.btnCrearJob.Location = new System.Drawing.Point(29, 375);
            this.btnCrearJob.Name = "btnCrearJob";
            this.btnCrearJob.Size = new System.Drawing.Size(153, 49);
            this.btnCrearJob.TabIndex = 2;
            this.btnCrearJob.Text = "Crear Job";
            this.btnCrearJob.UseVisualStyleBackColor = true;
            this.btnCrearJob.Click += new System.EventHandler(this.btnCrearJob_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Job Name";
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(29, 151);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(202, 26);
            this.txtJobName.TabIndex = 4;
            // 
            // txtMinSalary
            // 
            this.txtMinSalary.Location = new System.Drawing.Point(29, 236);
            this.txtMinSalary.Name = "txtMinSalary";
            this.txtMinSalary.Size = new System.Drawing.Size(202, 26);
            this.txtMinSalary.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Minimum salary";
            // 
            // txtMaxSalary
            // 
            this.txtMaxSalary.Location = new System.Drawing.Point(29, 321);
            this.txtMaxSalary.Name = "txtMaxSalary";
            this.txtMaxSalary.Size = new System.Drawing.Size(202, 26);
            this.txtMaxSalary.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Maximum salary";
            // 
            // lstJobs
            // 
            this.lstJobs.FormattingEnabled = true;
            this.lstJobs.ItemHeight = 20;
            this.lstJobs.Location = new System.Drawing.Point(367, 118);
            this.lstJobs.Name = "lstJobs";
            this.lstJobs.Size = new System.Drawing.Size(564, 304);
            this.lstJobs.TabIndex = 10;
            // 
            // btnActualizarTabla
            // 
            this.btnActualizarTabla.Location = new System.Drawing.Point(367, 429);
            this.btnActualizarTabla.Name = "btnActualizarTabla";
            this.btnActualizarTabla.Size = new System.Drawing.Size(146, 51);
            this.btnActualizarTabla.TabIndex = 11;
            this.btnActualizarTabla.Text = "Actualizar";
            this.btnActualizarTabla.UseVisualStyleBackColor = true;
            this.btnActualizarTabla.Click += new System.EventHandler(this.btnActualizarTabla_Click);
            // 
            // btnDeleteJob
            // 
            this.btnDeleteJob.Location = new System.Drawing.Point(785, 429);
            this.btnDeleteJob.Name = "btnDeleteJob";
            this.btnDeleteJob.Size = new System.Drawing.Size(146, 51);
            this.btnDeleteJob.TabIndex = 12;
            this.btnDeleteJob.Text = "Eliminar Job";
            this.btnDeleteJob.UseVisualStyleBackColor = true;
            this.btnDeleteJob.Click += new System.EventHandler(this.btnDeleteJob_Click);
            // 
            // btnAbrirEmployees
            // 
            this.btnAbrirEmployees.Location = new System.Drawing.Point(938, 118);
            this.btnAbrirEmployees.Name = "btnAbrirEmployees";
            this.btnAbrirEmployees.Size = new System.Drawing.Size(169, 43);
            this.btnAbrirEmployees.TabIndex = 13;
            this.btnAbrirEmployees.Text = "Ir a Employees";
            this.btnAbrirEmployees.UseVisualStyleBackColor = true;
            this.btnAbrirEmployees.Click += new System.EventHandler(this.btnAbrirEmployees_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 716);
            this.Controls.Add(this.btnAbrirEmployees);
            this.Controls.Add(this.btnDeleteJob);
            this.Controls.Add(this.btnActualizarTabla);
            this.Controls.Add(this.lstJobs);
            this.Controls.Add(this.txtMaxSalary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMinSalary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearJob);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.davidPalacinEmployeesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.davidPalacinEmployeesDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource davidPalacinEmployeesDataSetBindingSource;
        private DavidPalacinEmployeesDataSet davidPalacinEmployeesDataSet;
        private System.Windows.Forms.Button btnCrearJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.TextBox txtMinSalary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxSalary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstJobs;
        private System.Windows.Forms.Button btnActualizarTabla;
        private System.Windows.Forms.Button btnDeleteJob;
        private System.Windows.Forms.Button btnAbrirEmployees;
    }
}

