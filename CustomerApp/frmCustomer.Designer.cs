namespace CustomerApp
{
    partial class frmCustomer
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
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.btnGenerateCustomers = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtNoOfCustomers = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstCustomers
            // 
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.Location = new System.Drawing.Point(12, 17);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(445, 212);
            this.lstCustomers.Sorted = true;
            this.lstCustomers.TabIndex = 0;
            // 
            // btnGenerateCustomers
            // 
            this.btnGenerateCustomers.Location = new System.Drawing.Point(301, 237);
            this.btnGenerateCustomers.Name = "btnGenerateCustomers";
            this.btnGenerateCustomers.Size = new System.Drawing.Size(156, 23);
            this.btnGenerateCustomers.TabIndex = 1;
            this.btnGenerateCustomers.Text = "Generate Customers";
            this.btnGenerateCustomers.UseVisualStyleBackColor = true;
            this.btnGenerateCustomers.Click += new System.EventHandler(this.btnGenerateCustomers_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Location = new System.Drawing.Point(13, 236);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 2;
            // 
            // txtNoOfCustomers
            // 
            this.txtNoOfCustomers.Location = new System.Drawing.Point(195, 238);
            this.txtNoOfCustomers.MaxLength = 7;
            this.txtNoOfCustomers.Name = "txtNoOfCustomers";
            this.txtNoOfCustomers.Size = new System.Drawing.Size(100, 20);
            this.txtNoOfCustomers.TabIndex = 3;
            this.txtNoOfCustomers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfCustomers_KeyPress);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 261);
            this.Controls.Add(this.txtNoOfCustomers);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnGenerateCustomers);
            this.Controls.Add(this.lstCustomers);
            this.Name = "frmCustomer";
            this.Text = "Test Data Generation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.Button btnGenerateCustomers;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtNoOfCustomers;
    }
}

