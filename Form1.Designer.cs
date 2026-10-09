namespace PrintPopup
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used....
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnEbill = new System.Windows.Forms.Button();
            this.underlinePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(136, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(162, 42);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Paper-Bill";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnEbill
            // 
            this.btnEbill.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEbill.Location = new System.Drawing.Point(136, 201);
            this.btnEbill.Name = "btnEbill";
            this.btnEbill.Size = new System.Drawing.Size(160, 54);
            this.btnEbill.TabIndex = 1;
            this.btnEbill.Text = "E-Bill";
            this.btnEbill.UseVisualStyleBackColor = true;
            // 
            // underlinePanel
            // 
            this.underlinePanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.underlinePanel.Location = new System.Drawing.Point(136, 139);
            this.underlinePanel.Name = "underlinePanel";
            this.underlinePanel.Size = new System.Drawing.Size(160, 5);
            this.underlinePanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 345);
            this.Controls.Add(this.underlinePanel);
            this.Controls.Add(this.btnEbill);
            this.Controls.Add(this.checkBox1);
            this.Name = "Form1";
            this.Text = "BillBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnEbill;
        private System.Windows.Forms.Panel underlinePanel;
    }
}

