
namespace TimetableManagementSystem
{
    partial class HomepageTeacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomepageTeacher));
            this.label1 = new System.Windows.Forms.Label();
            this.btnMngAcc = new System.Windows.Forms.Button();
            this.btnMngTtb = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Teacher Homepage";
            // 
            // btnMngAcc
            // 
            this.btnMngAcc.Location = new System.Drawing.Point(85, 123);
            this.btnMngAcc.Name = "btnMngAcc";
            this.btnMngAcc.Size = new System.Drawing.Size(116, 23);
            this.btnMngAcc.TabIndex = 1;
            this.btnMngAcc.Text = "&Manage Account";
            this.btnMngAcc.UseVisualStyleBackColor = true;
            this.btnMngAcc.Click += new System.EventHandler(this.btnMngAcc_Click);
            // 
            // btnMngTtb
            // 
            this.btnMngTtb.Location = new System.Drawing.Point(228, 123);
            this.btnMngTtb.Name = "btnMngTtb";
            this.btnMngTtb.Size = new System.Drawing.Size(112, 23);
            this.btnMngTtb.TabIndex = 2;
            this.btnMngTtb.Text = "&Manage Timetable";
            this.btnMngTtb.UseVisualStyleBackColor = true;
            this.btnMngTtb.Click += new System.EventHandler(this.btnMngTtb_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(369, 123);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 60);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // HomepageTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 184);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMngTtb);
            this.Controls.Add(this.btnMngAcc);
            this.Controls.Add(this.label1);
            this.Name = "HomepageTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomepageTeacher";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMngAcc;
        private System.Windows.Forms.Button btnMngTtb;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}