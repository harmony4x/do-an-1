using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forrm_Đăng_Nhập
{
    public partial class QLTS : Form
    {
        SqlConnection ketnoi;
        Taikhoan tk;
        private object strPassWord;
        private object StrUserName;

        public QLTS(Taikhoan tk)
        {
            InitializeComponent();
            ketnoi = new SqlConnection(@"Data Source=DESKTOP-USRJIQP;Initial Catalog=QLTS;Integrated Security=True");
            this.CenterToScreen();
            txtMK.Text = "";
            txtMK.PasswordChar = '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDN_Click(object sender, EventArgs e)
        {
            String tk = txtTK.Text.Trim();
            String mk = txtMK.Text.Trim();

            if(tk == "" || mk == ""){
                MessageBox.Show("Tai khoan va mat khau khong duoc de trong");
            }
            else
            {
                try
                {
                    ketnoi.Open();
                    String sql = "Select * from TaiKhoan where Taikhoan='" + tk + "' AND MatKhau='" + mk + "'";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi);
                    SqlDataReader rs = cmd.ExecuteReader();
                    if (rs.Read() == true)
                    {
                        Taikhoan nguoidung = new Taikhoan(Convert.ToInt32(rs["MaTaiKhoan"].ToString()), rs["TaiKhoan"].ToString(), rs["MatKhau"].ToString(), rs["Role"].ToString());
                        new QuanLyThuThu(nguoidung).Show();
                        this.Hide();
                        ketnoi.Close();

                    }
                    else
                    {
                        MessageBox.Show("Tai khoan khong ton tai", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ketnoi.Close();
                    }

                }
               catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void QLTS_Load(object sender, EventArgs e)
        {

        }
    }

}

