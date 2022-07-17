using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forrm_Đăng_Nhập
{
    partial class QLTS
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
            this.lnbTK = new System.Windows.Forms.Label();
            this.lnbMK = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.btnĐN = new System.Windows.Forms.Button();
            this.btnT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lnbTK
            // 
            this.lnbTK.AutoSize = true;
            this.lnbTK.Location = new System.Drawing.Point(235, 81);
            this.lnbTK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnbTK.Name = "lnbTK";
            this.lnbTK.Size = new System.Drawing.Size(75, 17);
            this.lnbTK.TabIndex = 0;
            this.lnbTK.Text = "Tài khoản:";
            // 
            // lnbMK
            // 
            this.lnbMK.AutoSize = true;
            this.lnbMK.Location = new System.Drawing.Point(235, 166);
            this.lnbMK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnbMK.Name = "lnbMK";
            this.lnbMK.Size = new System.Drawing.Size(70, 17);
            this.lnbMK.TabIndex = 1;
            this.lnbMK.Text = "Mật khẩu:";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(413, 76);
            this.txtTK.Margin = new System.Windows.Forms.Padding(4);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(177, 22);
            this.txtTK.TabIndex = 2;
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(413, 166);
            this.txtMK.Margin = new System.Windows.Forms.Padding(4);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(177, 22);
            this.txtMK.TabIndex = 3;
            // 
            // btnĐN
            // 
            this.btnĐN.Location = new System.Drawing.Point(238, 265);
            this.btnĐN.Margin = new System.Windows.Forms.Padding(4);
            this.btnĐN.Name = "btnĐN";
            this.btnĐN.Size = new System.Drawing.Size(100, 28);
            this.btnĐN.TabIndex = 4;
            this.btnĐN.Text = "Đăng nhập";
            this.btnĐN.UseVisualStyleBackColor = true;
            this.btnĐN.Click += new System.EventHandler(this.BtnDN_Click);
            // 
            // btnT
            // 
            this.btnT.Location = new System.Drawing.Point(490, 265);
            this.btnT.Margin = new System.Windows.Forms.Padding(4);
            this.btnT.Name = "btnT";
            this.btnT.Size = new System.Drawing.Size(100, 28);
            this.btnT.TabIndex = 5;
            this.btnT.Text = "Thoát";
            this.btnT.UseVisualStyleBackColor = true;
            this.btnT.Click += new System.EventHandler(this.btnT_Click);
            // 
            // QLTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::forrm_Đăng_Nhập.Properties.Resources.tt;
            this.ClientSize = new System.Drawing.Size(872, 399);
            this.Controls.Add(this.btnT);
            this.Controls.Add(this.btnĐN);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.lnbMK);
            this.Controls.Add(this.lnbTK);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QLTS";
            this.Text = "Quản lý trả sách";
            this.Load += new System.EventHandler(this.QLTS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnT_Click(object sender, EventArgs e)
        {
           this.Close();
        }



        //private void btnĐN_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private System.Windows.Forms.Label lnbTK;
        private System.Windows.Forms.Label lnbMK;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Button btnĐN;
        private System.Windows.Forms.Button btnT;

        public object MessageBoxButton { get; private set; }
    }
}

