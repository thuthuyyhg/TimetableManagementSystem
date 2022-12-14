
namespace TimetableManagementSystem
{
    partial class TeacherAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherAccount));
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUsrInf = new System.Windows.Forms.Button();
            this.btnAcc = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(348, 153);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teacher Account Management";
            // 
            // btnUsrInf
            // 
            this.btnUsrInf.Location = new System.Drawing.Point(172, 153);
            this.btnUsrInf.Name = "btnUsrInf";
            this.btnUsrInf.Size = new System.Drawing.Size(109, 23);
            this.btnUsrInf.TabIndex = 2;
            this.btnUsrInf.Text = "&User Information";
            this.btnUsrInf.UseVisualStyleBackColor = true;
            this.btnUsrInf.Click += new System.EventHandler(this.btnUsrInf_Click);
            // 
            // btnAcc
            // 
            this.btnAcc.Location = new System.Drawing.Point(31, 153);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Size = new System.Drawing.Size(75, 23);
            this.btnAcc.TabIndex = 1;
            this.btnAcc.Text = "&Account";
            this.btnAcc.UseVisualStyleBackColor = true;
            this.btnAcc.Click += new System.EventHandler(this.btnAcc_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(137, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 60);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // TeacherAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 205);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUsrInf);
            this.Controls.Add(this.btnAcc);
            this.Name = "TeacherAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherAccount";
            this.Load += new System.EventHandler(this.TeacherAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUsrInf;
        private System.Windows.Forms.Button btnAcc;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}