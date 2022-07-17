using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace forrm_Đăng_Nhập
{
    public partial class QuanLyThuThu : Form
    {
        String id = "";
        SqlConnection ketnoi;
        SqlCommand cmd;
        SqlDataReader rs;
        Taikhoan tk;
        int indexQLT = -1;
        int indexDG = -1;
        int indexPhat = -1;
        int indexSach = -1;
        int indexTK = -1;
        public QuanLyThuThu(Taikhoan tk)
        {
            InitializeComponent();
            this.CenterToScreen();
            ketnoi = new SqlConnection(@"Data Source=DESKTOP-USRJIQP;Initial Catalog=QLTS;Integrated Security=True");
            this.tk = tk;
            if(tk.role == "thủ thư") // phan quyen
            {
                //form quanlytra
                txtid.Enabled = false;
                cbbMSSV.Enabled = false;
                cbmasach.Enabled = false;
                dtpday1.Enabled = false;
                dtpday2.Enabled = false;
                txthanche.Enabled = false;

                //form docgia
                txtmssv.Enabled = false;
                txtht.Enabled = false;
                dtpns.Enabled = false;
                rdoNam.Enabled = false;
                rdoNu.Enabled = false;
                btnthemm.Visible = false;
                btnsuaa.Visible = false;
                btnxoaa.Visible = false;
                btnClear.Visible = false;

                btnxoaw.Visible = false;
                btnThemSach.Visible = false;
                btnSuaSach.Visible = false;
                btnXoaSach.Visible = false;
            }

            this.dtpday2.Enabled = false;
            this.cbtt.Enabled = false;
            this.txthanche.Enabled = false;

            rdoNam.Checked = true;
            rdMP1.Checked = true;
            // goi ham
            comboboxDocGia();
            comboboxMaSach();
            comboBoxMaTra();
            loadcomboboxTimSach();
            loaddsQLTS();
            loaddsDocGia();
            loaddsPhat();
            loaddsSach();
        }

        public void loaddsQLTS()  // lam moi quan ly tra
        {
            ketnoi.Open();
            string sqlSELECT = "select * from QuanlyTra";
            SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
            SqlDataReader mt = t.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(mt);
            dsTra.DataSource = dt;
            ketnoi.Close();
            dsTra.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            dsTra.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
        }

        public void comboboxDocGia()  // cbb MSSV bang QLT
        {
            ketnoi.Open();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select MSSV from DocGia", ketnoi);
                sda.Fill(dt);
                ketnoi.Close();
                // lay gia tri va hien thi gia tri 
                cbbMSSV.DataSource = dt;
                cbbMSSV.DisplayMember = "MSSV";
                cbbMSSV.ValueMember = "MSSV";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void comboboxMaSach()  // cbb masach QLT
        {
            ketnoi.Open();

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select MaSach from Sach", ketnoi);
                sda.Fill(dt);
                ketnoi.Close();

                cbmasach.DataSource = dt;
                cbmasach.DisplayMember = "MaSach";
                cbmasach.ValueMember = "MaSach";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clearQLTS() // nut lam moi QLT
        {
            this.cbbMSSV.Text = "";
            this.cbmasach.Text = "";
            this.txthanche.Text = "";
            this.cbtt.Checked = false;  // boi den nut da tra
        }

        //bang doc gia

        public void loaddsDocGia()   // lam moi bang doc gia
        {
            ketnoi.Open();
            string sqlSELECT = "select * from DocGia";
            SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
            SqlDataReader mt = t.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(mt);
            dsdocgia.DataSource = dt;
            ketnoi.Close();
            dsdocgia.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            dsdocgia.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnthemm_Click(object sender, EventArgs e)  // nut them bang doc gia
        {
            String MSSV = txtmssv.Text.Trim();
            String Hoten = txtht.Text.Trim();
            DateTime ns = dtpns.Value;
            String gt = "";
            if (rdoNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            if (MSSV == "" || Hoten == "")
            {
                MessageBox.Show("Các ô không được để trống ! ", "Lưu ý");
            }
            else
            {
                try
                {
                    ketnoi.Open(); // nhan gia tri cua sql 
                    String query = "Insert into DocGia (MSSV, HoTen, NgaySinh, GioiTinh) VALUES ('" + MSSV + "' , N'" + Hoten + "', '" + ns + "', '" + gt + "')";
                    SqlCommand t = new SqlCommand(query, ketnoi); // tao bang nhan gia tri moi them
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsdocgia.DataSource = tb;
                    MessageBox.Show("Thêm thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsDocGia(); // lam moi gia tri bang doc gia
                }
                catch(Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnsuaa_Click(object sender, EventArgs e)  // nut sua bang doc gia
        {
            String MSSV = txtmssv.Text.Trim();
            String Hoten = txtht.Text.Trim();
            DateTime ns = dtpns.Value;
            String gt = "";
            if (rdoNam.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            if (this.indexDG < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị cần sửa", "Lưu ý");
            }
            else
            {
                //sửa đối tượng
                try
                {
                    ketnoi.Open();
                    String query = "Update DocGia SET HoTen=N'" + Hoten + "', NgaySinh='" + ns + "', GioiTinh=N'" + gt + "' where MSSV='" + MSSV + "'";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsdocgia.DataSource = tb;
                    MessageBox.Show("Sửa thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsDocGia();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnxoaa_Click(object sender, EventArgs e)  //nut xoa bang doc gia
        {
            String MSSV = txtmssv.Text.Trim();
            if (this.indexDG < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị cần xóa", "Lưu ý");
            }
            else
            {
                //xóa đối tượng
                try
                {
                    ketnoi.Open();
                    String query = "DELETE from DocGia where MSSV='" + MSSV + "'";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsdocgia.DataSource = tb;
                    MessageBox.Show("Xóa thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsDocGia();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dsdocgia_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)  // tuong tac datagrid bang doc gia
        {
            this.indexDG = dsdocgia.CurrentRow.Index;
            this.txtmssv.Text = dsdocgia.Rows[this.indexDG].Cells[0].Value.ToString();
            this.txtht.Text = dsdocgia.Rows[this.indexDG].Cells[1].Value.ToString();
            this.dtpns.Text = dsdocgia.Rows[this.indexDG].Cells[2].Value.ToString();
            String gt = dsdocgia.Rows[this.indexDG].Cells[3].Value.ToString();
            if (gt == "Nam")
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;
        }

        private void btntimm_Click(object sender, EventArgs e) // nut tim bang doc gia ( tim bang MSSV)
        {
            String searchDG = txtTimDG.Text.Trim();

            try
            {
                ketnoi.Open();
                string sqlSELECT = "select * from DocGia where MSSV='" + searchDG + "'";
                SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
                SqlDataReader mt = t.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(mt);
                dsdocgia.DataSource = dt;
                ketnoi.Close();
                dsdocgia.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                dsdocgia.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                ketnoi.Close();
                MessageBox.Show(ex.Message);
            }
        }

        //  tương tác datagrid bảng quản lý trả
        private void dsTra_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indexQLT = dsTra.CurrentRow.Index;
            this.txtid.Text = dsTra.Rows[this.indexQLT].Cells[0].Value.ToString();
            this.cbbMSSV.Text = dsTra.Rows[this.indexQLT].Cells[1].Value.ToString();
            this.cbmasach.Text = dsTra.Rows[this.indexQLT].Cells[2].Value.ToString();
            this.dtpday1.Text = dsTra.Rows[this.indexQLT].Cells[3].Value.ToString();
            this.txthanche.Text = dsTra.Rows[this.indexQLT].Cells[4].Value.ToString();
            this.dtpday2.Text = dsTra.Rows[this.indexQLT].Cells[5].Value.ToString();
            String trangthai = dsTra.Rows[this.indexQLT].Cells[6].Value.ToString();
            if (trangthai == "đã trả") // nếu click đã trả sẽ hiển thị ngày trả
            {
                cbtt.Checked = true;
                dtpday2.Enabled = true;
            }
            else 
            {
                cbtt.Checked = false;
                dtpday2.Enabled = false;
            }
            this.cbtt.Enabled = true;
        }

        private void btnsua_Click(object sender, EventArgs e)  // nút thêm bảng QLT
        {
            String maTra = txtid.Text.Trim();
            String MSSV = cbbMSSV.Text.Trim();
            String MaSach = cbmasach.Text.Trim();
            dtpday1.CustomFormat = "dd-MM-yyyy"; 
            DateTime NgayMuon = dtpday1.Value;
            int HanTra = Convert.ToInt32(txthanche.Text.Trim());
            DateTime NgayTra = dtpday2.Value;
            dtpday2.CustomFormat = "dd-MM-yyyy";
            String TrangThai = "";
            if (cbtt.Checked == true)
            {
                TrangThai = "đã trả";
            }
            else
            {
                TrangThai = "chưa trả";
            }


            if (this.indexQLT < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị cần sửa", "Lưu ý");
            }
            else
            {
                //sửa đối tượng
                try
                {
                    ketnoi.Open();
                    String query="";
                    if (cbtt.Checked == true)
                        query = "Update QuanLyTra SET MSSV='" + MSSV + "', MaSach='" + MaSach + "', NgayMuon='" + NgayMuon + "', HanTra='"+HanTra+"', NgayTra='"+NgayTra+"', TrangThai=N'"+TrangThai+"' where MaTra='" + maTra + "'";
                    else
                        query = "Update QuanLyTra SET MSSV='" + MSSV + "', MaSach='" + MaSach + "', NgayMuon='" + NgayMuon + "', HanTra='" + HanTra + "', NgayTra='NULL', TrangThai=N'" + TrangThai + "' where MaTra='" + maTra + "'";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsTra.DataSource = tb;
                    MessageBox.Show("Sửa thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsQLTS();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLoadQLTS_Click(object sender, EventArgs e)  // nút làm mới bảng quản lý trả
        {
            loaddsQLTS();
            this.dtpday2.Enabled = false; //tô đen ngày trả
            this.cbtt.Enabled = false; // tô đen đã trả
            
            this.indexQLT = -1; // set lại giá trị indexQLT
        }

        private void btntim_Click(object sender, EventArgs e)  // nút tìm bảng quản lý trả (tìm bằng MSSV)
        {
            String searchMSSV = txttim.Text.Trim();

            try
            {
                ketnoi.Open();
                string sqlSELECT = "select * from QuanLyTra where MSSV='" + searchMSSV + "'";
                SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
                SqlDataReader mt = t.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(mt);
                dsTra.DataSource = dt;
                ketnoi.Close();
                dsTra.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                dsTra.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                ketnoi.Close();
                MessageBox.Show(ex.Message);
            }
        }
        //bang phat

        public void loaddsPhat()  // làm mới bảng phạt
        {
            ketnoi.Open();
            string sqlSELECT = "select * from Phat";
            SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
            SqlDataReader mt = t.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(mt);
            dsPhat.DataSource = dt;
            ketnoi.Close();
            dsPhat.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            dsPhat.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
        }

        public void comboBoxMaTra()  // cbb mã trả 
        {
            ketnoi.Open();

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select MaTra from QuanLyTra where TrangThai=N'đã trả'", ketnoi);
                sda.Fill(dt);
                ketnoi.Close();
                cbbMaTra.DataSource = dt;
                cbbMaTra.DisplayMember = "MaTra";
                cbbMaTra.ValueMember = "MaTra";
            }
            catch (Exception ex)
            {
                ketnoi.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void btnthemw_Click(object sender, EventArgs e)  // nút thêm bảng phạt
        {
            String matra = cbbMaTra.SelectedValue.ToString();
            String lydophat = txtldp.Text.Trim();
            String htxl = txthtxl.Text.Trim();
            int mp = 0; // tạo biến mp
            if (rdMP1.Checked == true)
                mp = 1;
            else if (rdMP2.Checked == true)
                mp = 2;
            else if (rdMP3.Checked == true)
                mp = 3;

            if (matra == "" ||lydophat == "" || htxl == "")
            {
                MessageBox.Show("Các ô không được để trống ! ", "Lưu ý");
            }
            else
            {
                try
                {
                    // thêm mã trả lý do phạt htxly mức phạt
                    ketnoi.Open();
                    String query = "Insert into Phat (MaTra, LyDoPhat, HTXuLy, MucPhat) VALUES ('" + matra + "',  N'" + lydophat + "',  N'" + htxl + "', "+mp+")";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsPhat.DataSource = tb;
                    MessageBox.Show("Thêm thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsPhat();
                }
                catch(Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnsuaw_Click(object sender, EventArgs e)  // nút sửa bảng phạt
        {
            String MaPhat = txtmp.Text.Trim();
            String matra = cbbMaTra.SelectedValue.ToString();
            String lydophat = txtldp.Text.Trim();
            String htxl = txthtxl.Text.Trim();
            int mp = 0;
            if (rdMP1.Checked == true)
                mp = 1;
            else if (rdMP2.Checked == true)
                mp = 2;
            else if (rdMP3.Checked == true)
                mp = 3;

            if (this.indexPhat < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị cần sửa", "Lưu ý");
            }
            else
            {
                //sửa đối tượng mã trả, lý do phạt, ht xử lý, mức phạt
                try
                {
                    ketnoi.Open();
                    String query = "Update Phat SET MaTra='" + matra + "', LydoPhat=N'" + lydophat + "', HTXuLy=N'" + htxl + "', MucPhat='"+mp+"' where MaPhat='" + MaPhat + "'";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsPhat.DataSource = tb;
                    MessageBox.Show("Sửa thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsPhat();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnxoaw_Click(object sender, EventArgs e)  // nút xóa bảng phạt
        {
            String MaPhat = txtmp.Text.Trim();
            if (this.indexPhat < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị cần xóa", "Lưu ý");
            }
            else
            {
                //xóa đối tượng
                try
                {
                    ketnoi.Open();
                    String query = "DELETE from Phat where MaPhat='" + MaPhat + "'";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsPhat.DataSource = tb;
                    MessageBox.Show("Xóa thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsPhat();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btntimw_Click(object sender, EventArgs e)  // nút tìm bảng phạt tìm bằng mã phạt
        {
            String searchPhat = txttimw.Text.Trim();

            try
            {
                ketnoi.Open();
                string sqlSELECT = "select * from Phat where MaPhat='" + searchPhat + "'";
                SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
                SqlDataReader mt = t.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(mt);
                dsPhat.DataSource = dt;
                ketnoi.Close();
                dsPhat.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                dsPhat.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                ketnoi.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadPhat_Click(object sender, EventArgs e)  // nút làm mới bảng phạt
        {
            loaddsPhat();
        }

        private void dsPhat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)  // tương tác datagrid bảng phạt
        {
            this.indexPhat = dsPhat.CurrentRow.Index;
            this.txtmp.Text = dsPhat.Rows[this.indexPhat].Cells[0].Value.ToString();
            this.cbbMaTra.Text = dsPhat.Rows[this.indexPhat].Cells[1].Value.ToString();
            this.txtldp.Text = dsPhat.Rows[this.indexPhat].Cells[2].Value.ToString();
            this.txthtxl.Text = dsPhat.Rows[this.indexPhat].Cells[3].Value.ToString();
            int mp = Convert.ToInt32(dsPhat.Rows[this.indexPhat].Cells[4].Value.ToString());
            switch (mp)
            {
                case 1:
                    rdMP1.Checked = true;
                    break;
                case 2:
                    rdMP2.Checked = true;
                    break;
                case 3:
                    rdMP3.Checked = true;
                    break;

            }
                
        }

        //bang quanlysach
        public void loaddsSach() //load quản lý sách
        {
            ketnoi.Open();
            string sqlSELECT = "select * from Sach";
            SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
            SqlDataReader mt = t.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(mt);
            dsSach.DataSource = dt;
            ketnoi.Close();
            dsSach.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            dsSach.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void btnThemSach_Click(object sender, EventArgs e)  // nút thêm quản lý sách
        {
            String Masach = txtMaSach.Text.Trim();
            String TenSach = txtTenSach.Text.Trim();
            String Tacgia = txtTacGia.Text.Trim();
            String Theloai = txtTheLoai.Text.Trim();
            String NXB = txtNXB.Text.Trim();

            if (Masach == "" || TenSach == "" || Tacgia == "" || Theloai == "" || NXB == "")
            {
                MessageBox.Show("Các ô không được để trống ! ", "Lưu ý");
            }
            else
            {
                try
                { 
                    //thêm mã sách, tên sách, tác giả, thể loại, nhà xuất bảng
                    ketnoi.Open();
                    String query = "Insert into Sach (MaSach, TenSach, TacGia, TheLoai, NhaXuatBan) VALUES ('" + Masach + "' , N'" + TenSach + "', N'" + Tacgia + "', N'" + Theloai + "', N'" + NXB + "')";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsSach.DataSource = tb;
                    MessageBox.Show("Thêm thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsSach();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)  // nút sửa bảng sách
        {
            String Masach = txtMaSach.Text.Trim();
            String TenSach = txtTenSach.Text.Trim();
            String Tacgia = txtTacGia.Text.Trim();
            String Theloai = txtTheLoai.Text.Trim();
            String NXB = txtNXB.Text.Trim();

            if (this.indexSach < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị cần sửa", "Lưu ý");
            }
            else
            {
                //sửa đối tượng
                try
                {
                    // sửa tên sách, tác giả, thể loại, nhà xuất bảng
                    ketnoi.Open();
                    String query = "Update Sach SET TenSach=N'" + TenSach + "', TacGia=N'" + Tacgia + "', TheLoai=N'" + Theloai + "', NhaXuatBan=N'" + NXB + "' where MaSach='" + Masach + "'";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsSach.DataSource = tb;
                    MessageBox.Show("Sửa thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsSach();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)  //  nút xóa sách
        {
            String MaSach = txtMaSach.Text.Trim();
            if (this.indexSach < 0)
            {
                MessageBox.Show("Vui lòng chọn giá trị cần xóa", "Lưu ý");
            }
            else
            {
                //xóa đối tượng
                try
                {
                    ketnoi.Open();
                    String query = "DELETE from Sach where MaSach='" + MaSach + "'";
                    SqlCommand t = new SqlCommand(query, ketnoi);
                    DataTable tb = new DataTable();
                    t.ExecuteNonQuery();
                    dsSach.DataSource = tb;
                    MessageBox.Show("Xóa thành công ", "Thông Báo");
                    ketnoi.Close();
                    loaddsSach();
                }
                catch (Exception ex)
                {
                    ketnoi.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnTimSach_Click(object sender, EventArgs e) // nút tìm sách (tìm bằng tên sách)
        {
            String searchSach = cbbTimkiem.Text.Trim();

            try
            {
                ketnoi.Open();
                string sqlSELECT = "select * from Sach where TenSach=N'" + searchSach + "'";
                SqlCommand t = new SqlCommand(sqlSELECT, ketnoi);
                SqlDataReader mt = t.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(mt);
                dsSach.DataSource = dt;
                ketnoi.Close();
                dsSach.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                dsSach.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                ketnoi.Close();
                MessageBox.Show(ex.Message);
            }
        }
        // nút  làm mới datagridview bảng sách
        private void btnLoadSach_Click(object sender, EventArgs e)
        {
            loaddsSach();
        }

        private void dsSach_MouseClick(object sender, MouseEventArgs e)  // tương tác datagridview bảng sách
        {
            this.indexSach = dsSach.CurrentRow.Index;
            this.txtMaSach.Text = dsSach.Rows[this.indexSach].Cells[0].Value.ToString();
            this.txtTenSach.Text = dsSach.Rows[this.indexSach].Cells[1].Value.ToString();
            this.txtTacGia.Text = dsSach.Rows[this.indexSach].Cells[2].Value.ToString();
            this.txtTheLoai.Text = dsSach.Rows[this.indexSach].Cells[3].Value.ToString();
            this.txtNXB.Text = dsSach.Rows[this.indexSach].Cells[4].Value.ToString();
        }
        // làm mới cbb tìm sách
        public void loadcomboboxTimSach()
        {
            ketnoi.Open();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("select TenSach from Sach", ketnoi);
                sda.Fill(dt);
                ketnoi.Close();

                cbbTimkiem.DataSource = dt;
                cbbTimkiem.DisplayMember = "TenSach";
                cbbTimkiem.ValueMember = "TenSach";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //code đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            new QLTS(null).Show();
            this.Dispose();
        }

        //code chỗ ngày trả
        private void cbtt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtt.Checked == true) 
                dtpday2.Enabled = true;
            else
                dtpday2.Enabled = false;
        }

        // thống kê theo tháng
        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thang = Convert.ToInt32(cbbThang.SelectedItem);
            try
            {
                ketnoi.Open();
                string query = "select MaSach, NgayMuon, NgayTra from QuanlyTra where MONTH(NgayTra) = " + thang;
                SqlCommand t = new SqlCommand(query, ketnoi);
                SqlDataReader mt = t.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(mt);
                dsTraTk.DataSource = dt; // hien thi datagrid thong ke thang
                dsPhatTk.DataSource = null; // khong hien thi datagrd thong ke nam
                dsTheoNam.DataSource = null; // khong hien thi datagrid thong ke phat
                ketnoi.Close();
                dsTraTk.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                dsTraTk.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // thống kê theo năm
        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nam = Convert.ToInt32(cbbNam.SelectedItem);
            try
            {
                ketnoi.Open();
                    using (SqlCommand command = ketnoi.CreateCommand())
                    {
                        command.CommandText = "SELECT MaSach, LyDoPhat, HTXuLy FROM Phat INNER JOIN QuanlyTra ON QuanlyTra.MaTra = Phat.MaTra where Year(QuanlyTra.NgayTra) = " + nam;
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dsPhatTk.DataSource = AutonumberTable(dataTable);
                    ketnoi.Close();
                        dsPhatTk.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                        dsPhatTk.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                ketnoi.Open();
                String query = "select  MaSach, NgayMuon, NgayTra from QuanlyTra where Year(NgayTra) = " + nam;
                SqlCommand t = new SqlCommand(query, ketnoi);
                SqlDataReader mt = t.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(mt);
                dsTheoNam.DataSource = dt;
                ketnoi.Close();
                dsTheoNam.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
                dsTheoNam.AutoSizeRowsMode = (DataGridViewAutoSizeRowsMode)DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dsTraTk.DataSource = null;  // khong hien thi datagrid thong ke thang
        }
        /* hàm thêm cột tăng số thứ tự */
        public DataTable AutonumberTable(DataTable soucre)
        {
            DataTable dt = new DataTable();
            DataColumn autoNumberColumn = new DataColumn();
            autoNumberColumn.ColumnName = "Số thứ tự";
            autoNumberColumn.DataType = typeof(int);
            autoNumberColumn.AutoIncrement = true;
            autoNumberColumn.AutoIncrementSeed = 1;
            autoNumberColumn.AutoIncrementStep = 1;
            dt.Columns.Add(autoNumberColumn);
            dt.Merge(soucre);
            return dt;
        }

        private void dtpday1_ValueChanged(object sender, EventArgs e)
        {
            dtpday1.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpday2_ValueChanged(object sender, EventArgs e)
        {
            dtpday2.CustomFormat = "dd/MM/yyyy";
        }

        private void dsTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dsTraTk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dsTheoNam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rdMP4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdMP3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbbMaTra_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dsPhat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtTimDG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttimw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            loaddsDocGia();
        }
    }
}
