namespace EHRT
{
    partial class frmAbout
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
            this.lblCompLoc = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRelDate = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.pnlpanel1 = new System.Windows.Forms.Panel();
            this.panelBorder.SuspendLayout();
            this.pnlpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompLoc
            // 
            this.lblCompLoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompLoc.Location = new System.Drawing.Point(101, 66);
            this.lblCompLoc.Name = "lblCompLoc";
            this.lblCompLoc.Size = new System.Drawing.Size(190, 21);
            this.lblCompLoc.TabIndex = 16;
            this.lblCompLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.LightCoral;
            this.cmdExit.ForeColor = System.Drawing.Color.White;
            this.cmdExit.Location = new System.Drawing.Point(286, 5);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(20, 20);
            this.cmdExit.TabIndex = 31;
            this.cmdExit.Text = "X";
            this.cmdExit.UseVisualStyleBackColor = false;
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(101, 42);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(190, 21);
            this.lblCompany.TabIndex = 15;
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Company:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRelDate
            // 
            this.lblRelDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelDate.Location = new System.Drawing.Point(101, 128);
            this.lblRelDate.Name = "lblRelDate";
            this.lblRelDate.Size = new System.Drawing.Size(197, 21);
            this.lblRelDate.TabIndex = 10;
            this.lblRelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(101, 91);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(131, 21);
            this.lblVersion.TabIndex = 9;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "About - CADRotor";
            // 
            // panelBorder
            // 
            this.panelBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBorder.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBorder.Controls.Add(this.lblCompLoc);
            this.panelBorder.Controls.Add(this.lblCompany);
            this.panelBorder.Controls.Add(this.label5);
            this.panelBorder.Controls.Add(this.lblRelDate);
            this.panelBorder.Controls.Add(this.lblVersion);
            this.panelBorder.Controls.Add(this.label2);
            this.panelBorder.Controls.Add(this.lblVer);
            this.panelBorder.Controls.Add(this.pnlpanel1);
            this.panelBorder.Location = new System.Drawing.Point(1, 1);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(317, 172);
            this.panelBorder.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Rel Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVer
            // 
            this.lblVer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVer.Location = new System.Drawing.Point(9, 91);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(75, 21);
            this.lblVer.TabIndex = 6;
            this.lblVer.Text = "Version:";
            this.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlpanel1
            // 
            this.pnlpanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlpanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlpanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlpanel1.Controls.Add(this.cmdExit);
            this.pnlpanel1.Controls.Add(this.label1);
            this.pnlpanel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlpanel1.Location = new System.Drawing.Point(0, -1);
            this.pnlpanel1.Name = "pnlpanel1";
            this.pnlpanel1.Size = new System.Drawing.Size(316, 32);
            this.pnlpanel1.TabIndex = 2;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(319, 175);
            this.ControlBox = false;
            this.Controls.Add(this.panelBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAbout";
            this.panelBorder.ResumeLayout(false);
            this.pnlpanel1.ResumeLayout(false);
            this.pnlpanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblCompLoc;
        private System.Windows.Forms.Button cmdExit;
        internal System.Windows.Forms.Label lblCompany;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label lblRelDate;
        internal System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBorder;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.Panel pnlpanel1;
    }
}