using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LeThiThuHuyen_6551071037_VP101_LTTQ 
{
    public partial class Form1 : Form
    {

        private string connectionString = @"Data Source=KHUONGSOSAD\SQLEXPRESS;Initial Catalog=DuLieu;User ID=sa;Password=12345";

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT MaCongViec, TenCongViec, LuongThang FROM CongViec";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCongViec.DataSource = dt;

                    if (dgvCongViec.Columns.Count >= 3)
                    {
                        dgvCongViec.Columns["MaCongViec"].HeaderText = "Mã công việc";
                        dgvCongViec.Columns["TenCongViec"].HeaderText = "Tên công việc";
                        dgvCongViec.Columns["LuongThang"].HeaderText = "Lương tháng";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaRongTextBox()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
            txtLuongThang.Clear();
            txtMaCV.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;

            LoadData();
        }

        private void txtLuongThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn thoát không",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCV.Text) ||
                string.IsNullOrWhiteSpace(txtTenCV.Text) ||
                string.IsNullOrWhiteSpace(txtLuongThang.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ dữ liệu vào các ô TextBox!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    string sqlCheck = "SELECT COUNT(*) FROM CongViec WHERE MaCongViec = @MaCV";
                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@MaCV", txtMaCV.Text.Trim());
                        int count = (int)cmdCheck.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Mã công việc đã tồn tại, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaCV.Focus();
                            txtMaCV.SelectAll();
                            return;
                        }
                    }

                    string sqlInsert = "INSERT INTO CongViec (MaCongViec, TenCongViec, LuongThang) VALUES (@MaCV, @TenCV, @LuongThang)";
                    using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@MaCV", txtMaCV.Text.Trim());
                        cmdInsert.Parameters.AddWithValue("@TenCV", txtTenCV.Text.Trim());
                        cmdInsert.Parameters.AddWithValue("@LuongThang", txtLuongThang.Text.Trim());
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                LoadData();
                XoaRongTextBox();
                btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCongViec.Rows.Count)
            {
                DataGridViewRow row = dgvCongViec.Rows[e.RowIndex];
                txtMaCV.Text = row.Cells["MaCongViec"].Value?.ToString();
                txtTenCV.Text = row.Cells["TenCongViec"].Value?.ToString();
                txtLuongThang.Text = row.Cells["LuongThang"].Value?.ToString();

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn xóa công việc này không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sqlDelete = "DELETE FROM CongViec WHERE MaCongViec = @MaCV";
                        using (SqlCommand cmdDelete = new SqlCommand(sqlDelete, conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@MaCV", txtMaCV.Text.Trim());
                            cmdDelete.ExecuteNonQuery();
                        }
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            XoaRongTextBox();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCV.Text) ||
                string.IsNullOrWhiteSpace(txtTenCV.Text) ||
                string.IsNullOrWhiteSpace(txtLuongThang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlUpdate = "UPDATE CongViec SET TenCongViec = @TenCV, LuongThang = @LuongThang WHERE MaCongViec = @MaCV";
                    using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@MaCV", txtMaCV.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@TenCV", txtTenCV.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@LuongThang", txtLuongThang.Text.Trim());
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                LoadData();
                XoaRongTextBox();
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}