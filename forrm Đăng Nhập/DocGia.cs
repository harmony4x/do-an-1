using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forrm_Đăng_Nhập
{
    public class DocGia
    {
        public int MSSV { get; set; }
        public String hoten { get; set; }
        public DateTime ngaysinh { get; set; }
        public String gioitinh { get; set; }

        public DocGia(int mSSV, string hoten, DateTime ngaysinh, string gioitinh)
        {
            this.MSSV = mSSV;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
        }
    }
}
