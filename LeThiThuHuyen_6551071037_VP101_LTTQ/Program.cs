using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LeThiThuHuyen_6551071037_VP101_LTTQ
{
    public class frmCongViec : Form
    {

        private string connectionString = @"Data Source=KHUONGSOSAD\SQLEXPRESS;Initial Catalog=DuLieu;User ID=sa;Password=12345";

        private Label lblTieuDe;
        private GroupBox grpThongTin;
        private Label lblMaCV, lblTenCV, lblLuongThang;
        private TextBox txtMaCV, txtTenCV, txtLuongThang;
        private GroupBox grpDanhSach;
        private DataGridView dgvCongViec;
        private Button btnThem, btnSua, btnXoa, btnThoat;

        public frmCongViec()
        {
            KhoiTaoGiaoDien();
        }
        private void KhoiTaoGiaoDien()
        {
            this.Text = "Quản lý Danh mục Công Việc - frmCongViec";
            this.Size = new Size(640, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(235, 236, 239);
            this.Load += FrmCongViec_Load;

            lblTieuDe = new Label()
            {
                Text = "DANH MỤC CÔNG VIỆC",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 15),
                Size = new Size(600, 35)
            };
            this.Controls.Add(lblTieuDe);

            grpThongTin = new GroupBox()
            {
                Text = "Thông tin công việc",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                Location = new Point(30, 55),
                Size = new Size(565, 130)
            };

            lblMaCV = new Label()
            {
                Text = "Mã công việc:",
                Location = new Point(110, 28),
                AutoSize = true
            };

            txtMaCV = new TextBox()
            {
                Location = new Point(250, 25),
                Size = new Size(150, 22),
                MaxLength = 10
            };

            lblTenCV = new Label()
            {
                Text = "Tên công việc:",
                Location = new Point(110, 60),
                AutoSize = true
            };

            txtTenCV = new TextBox()
            {
                Location = new Point(250, 57),
                Size = new Size(150, 22)
            };

            lblLuongThang = new Label()
            {
                Text = "Lương tháng:",
                Location = new Point(110, 92),
                AutoSize = true
            };

            txtLuongThang = new TextBox()
            {
                Location = new Point(250, 89),
                Size = new Size(150, 22),
                MaxLength = 8 
            };
            txtLuongThang.KeyPress += TxtLuongThang_KeyPress;

            grpThongTin.Controls.Add(lblMaCV);
            grpThongTin.Controls.Add(txtMaCV);
            grpThongTin.Controls.Add(lblTenCV);
            grpThongTin.Controls.Add(txtTenCV);
            grpThongTin.Controls.Add(lblLuongThang);
            grpThongTin.Controls.Add(txtLuongThang);
            this.Controls.Add(grpThongTin);
            grpDanhSach = new GroupBox()
            {
                Text = "Danh sách công việc",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular),
                Location = new Point(30, 195),
                Size = new Size(565, 195)
            };

            dgvCongViec = new DataGridView()
            {
                Location = new Point(15, 22),
                Size = new Size(535, 158),
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.Gray
            };
            dgvCongViec.CellClick += DgvCongViec_CellClick;

            grpDanhSach.Controls.Add(dgvCongViec);
            this.Controls.Add(grpDanhSach);
            btnThem = new Button()
            {
                Text = "➕\nThêm",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                Location = new Point(115, 405),
                Size = new Size(80, 55),
                UseVisualStyleBackColor = true
            };
            btnThem.Click += BtnThem_Click;

            btnSua = new Button()
            {
                Text = "✎\nSửa",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                Location = new Point(220, 405),
                Size = new Size(80, 55),
                UseVisualStyleBackColor = true
            };
            btnSua.Click += BtnSua_Click;

            btnXoa = new Button()
            {
                Text = "✖\nXóa",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                Location = new Point(325, 405),
                Size = new Size(80, 55),
                UseVisualStyleBackColor = true
            };
            btnXoa.Click += BtnXoa_Click;

            btnThoat = new Button()
            {
                Text = "↪\nThoát",
                Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold),
                Location = new Point(430, 405),
                Size = new Size(80, 55),
                UseVisualStyleBackColor = true
            };
            btnThoat.Click += BtnThoat_Click;

            this.Controls.Add(btnThem);
            this.Controls.Add(btnSua);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnThoat);
        }
        private void TaiDuLieuLenLuoi()
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
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void XoaRongTextBox()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
            txtLuongThang.Clear();
            txtMaCV.Focus();
        }


        private void FrmCongViec_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnThoat.Enabled = true;

            TaiDuLieuLenLuoi();
        }

        private void TxtLuongThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void BtnThoat_Click(object sender, EventArgs e)
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


        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCV.Text) ||
                string.IsNullOrWhiteSpace(txtTenCV.Text) ||
                string.IsNullOrWhiteSpace(txtLuongThang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu vào các ô TextBox!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            MessageBox.Show("Mã công việc này đã tồn tại, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                TaiDuLieuLenLuoi();
                XoaRongTextBox();
                btnThem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
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
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có muốn xóa công việc này không?",
                "Xác nhận xóa",
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
                    TaiDuLieuLenLuoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            XoaRongTextBox();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCV.Text) ||
                string.IsNullOrWhiteSpace(txtTenCV.Text) ||
                string.IsNullOrWhiteSpace(txtLuongThang.Text))
            {
                MessageBox.Show("Vui lòng không để trống thông tin khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                TaiDuLieuLenLuoi();
                XoaRongTextBox();
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnThem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCongViec());
        }
    }
}