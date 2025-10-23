using System;
using System.Data;
using System.Data.SqlClient; // Cần thêm thư viện này
using System.Windows.Forms;

namespace NguyenHoangNam_1150080149_Bttuan8 // Namespace của bạn
{
    public partial class Form1 : Form
    {
        // ====================================================================
        // I. KHAI BÁO BIẾN & KẾT NỐI
        // Chuỗi kết nối mới đã được dán vào đây
        // ====================================================================

        string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyBanSach;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Đối tượng kết nối
        SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
        }

        // ====================================================================
        // II. HÀM QUẢN LÝ KẾT NỐI
        // ====================================================================

        private void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        // ====================================================================
        // III. THỰC HÀNH 1: HIỂN THỊ DỮ LIỆU (READ)
        // ====================================================================

        private void HienThiDanhSachNXB()
        {
            MoKetNoi();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "HienThiNXB";
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvDanhSach.Items.Clear();

            while (reader.Read())
            {
                string maNXB = reader.GetString(0);
                string tenNXB = reader.GetString(1);
                string diaChi = reader.GetString(2);

                ListViewItem lvi = new ListViewItem(maNXB);
                lvi.SubItems.Add(tenNXB);
                lvi.SubItems.Add(diaChi);
                lsvDanhSach.Items.Add(lvi);
            }
            reader.Close();
            DongKetNoi();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNXB();
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvDanhSach.SelectedItems[0];
            string maNXB = lvi.SubItems[0].Text;

            HienThiThongTinNXBTheoMa(maNXB);
        }

        private void HienThiThongTinNXBTheoMa(string maNXB)
        {
            MoKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "HienThiChiTietNXB";
            sqlCmd.Connection = sqlCon;

            SqlParameter parMaNXB = new SqlParameter("@maNXB", SqlDbType.Char);
            parMaNXB.Value = maNXB;
            sqlCmd.Parameters.Add(parMaNXB);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            // Đảm bảo bạn có các controls sau trên Form: txtMaNXB, txtTenNXB, txtDiaChi
            // Nếu không, chương trình sẽ lỗi.
            txtMaNXB.Text = txtTenNXB.Text = txtDiaChi.Text = "";

            if (reader.Read())
            {
                string _maNXB = reader.GetString(0);
                string tenNXB = reader.GetString(1);
                string diaChi = reader.GetString(2);

                txtMaNXB.Text = _maNXB;
                txtTenNXB.Text = tenNXB;
                txtDiaChi.Text = diaChi;
            }
            reader.Close();
            DongKetNoi();
        }

        // ====================================================================
        // IV. THỰC HÀNH 2: THÊM DỮ LIỆU (CREATE) - Bạn cần thêm nút và sự kiện này
        // ====================================================================

        private void btnThemDL_Click(object sender, EventArgs e)
        {
            MoKetNoi();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "ThemDuLieu";

            SqlParameter parMaNXB = new SqlParameter("@maNXB", SqlDbType.Char);
            SqlParameter parTenNXB = new SqlParameter("@tenNXB", SqlDbType.NVarChar);
            SqlParameter parDiaChi = new SqlParameter("@diaChi", SqlDbType.NVarChar);

            parMaNXB.Value = txtMaNXB.Text.Trim();
            parTenNXB.Value = txtTenNXB.Text.Trim();
            parDiaChi.Value = txtDiaChi.Text.Trim();

            sqlCmd.Parameters.Add(parMaNXB);
            sqlCmd.Parameters.Add(parTenNXB);
            sqlCmd.Parameters.Add(parDiaChi);

            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();

            if (kq > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!");
                HienThiDanhSachNXB();
                txtMaNXB.Text = txtTenNXB.Text = txtDiaChi.Text = "";
            }
            DongKetNoi();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void lsvDanhSach_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}