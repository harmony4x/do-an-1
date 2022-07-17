using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forrm_Đăng_Nhập
{
    public class Taikhoan
    {
        public int maTaiKhoan { get; set; }
        public String taikhoan { get; set; }
        public String matkhau { get; set; }
        public String role { get; set; }

        public Taikhoan(int maTaiKhoan, string taikhoan, string matkhau, string role)
        {
            this.maTaiKhoan = maTaiKhoan;
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.role = role;
        }
    }
}
