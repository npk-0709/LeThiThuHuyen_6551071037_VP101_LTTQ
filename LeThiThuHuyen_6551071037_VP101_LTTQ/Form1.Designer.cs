namespace LeThiThuHuyen_6551071037_VP101_LTTQ 
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtLuongThang = new System.Windows.Forms.TextBox();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.txtMaCV = new System.Windows.Forms.TextBox();
            this.lblLuongThang = new System.Windows.Forms.Label();
            this.lblTenCV = new System.Windows.Forms.Label();
            this.lblMaCV = new System.Windows.Forms.Label();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvCongViec = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongViec)).BeginInit();
            this.SuspendLayout();
            this.lblTieuDe.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.Location = new System.Drawing.Point(12, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(600, 35);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "DANH MỤC CÔNG VIỆC";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.grpThongTin.Controls.Add(this.txtLuongThang);
            this.grpThongTin.Controls.Add(this.txtTenCV);
            this.grpThongTin.Controls.Add(this.txtMaCV);
            this.grpThongTin.Controls.Add(this.lblLuongThang);
            this.grpThongTin.Controls.Add(this.lblTenCV);
            this.grpThongTin.Controls.Add(this.lblMaCV);
            this.grpThongTin.Location = new System.Drawing.Point(30, 55);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(565, 130);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin công việc";

            this.txtLuongThang.Location = new System.Drawing.Point(250, 89);
            this.txtLuongThang.MaxLength = 8;
            this.txtLuongThang.Name = "txtLuongThang";
            this.txtLuongThang.Size = new System.Drawing.Size(150, 20);
            this.txtLuongThang.TabIndex = 5;
            this.txtLuongThang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLuongThang_KeyPress);

            this.txtTenCV.Location = new System.Drawing.Point(250, 57);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(150, 20);
            this.txtTenCV.TabIndex = 4;

            this.txtMaCV.Location = new System.Drawing.Point(250, 25);
            this.txtMaCV.MaxLength = 10;
            this.txtMaCV.Name = "txtMaCV";
            this.txtMaCV.Size = new System.Drawing.Size(150, 20);
            this.txtMaCV.TabIndex = 3;

            this.lblLuongThang.AutoSize = true;
            this.lblLuongThang.Location = new System.Drawing.Point(110, 92);
            this.lblLuongThang.Name = "lblLuongThang";
            this.lblLuongThang.Size = new System.Drawing.Size(70, 13);
            this.lblLuongThang.TabIndex = 2;
            this.lblLuongThang.Text = "Lương tháng:";

            this.lblTenCV.AutoSize = true;
            this.lblTenCV.Location = new System.Drawing.Point(110, 60);
            this.lblTenCV.Name = "lblTenCV";
            this.lblTenCV.Size = new System.Drawing.Size(78, 13);
            this.lblTenCV.TabIndex = 1;
            this.lblTenCV.Text = "Tên công việc:";

            this.lblMaCV.AutoSize = true;
            this.lblMaCV.Location = new System.Drawing.Point(110, 28);
            this.lblMaCV.Name = "lblMaCV";
            this.lblMaCV.Size = new System.Drawing.Size(74, 13);
            this.lblMaCV.TabIndex = 0;
            this.lblMaCV.Text = "Mã công việc:";

            this.grpDanhSach.Controls.Add(this.dgvCongViec);
            this.grpDanhSach.Location = new System.Drawing.Point(30, 195);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(565, 195);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách công việc";

            this.dgvCongViec.AllowUserToAddRows = false;
            this.dgvCongViec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongViec.Location = new System.Drawing.Point(15, 22);
            this.dgvCongViec.MultiSelect = false;
            this.dgvCongViec.Name = "dgvCongViec";
            this.dgvCongViec.ReadOnly = true;
            this.dgvCongViec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongViec.Size = new System.Drawing.Size(535, 158);
            this.dgvCongViec.TabIndex = 0;
            this.dgvCongViec.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCongViec_CellClick);

            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.Location = new System.Drawing.Point(115, 405);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 50);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(220, 405);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 50);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(325, 405);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 50);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(430, 405);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 50);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.ClientSize = new System.Drawing.Size(624, 475);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Danh mục Công Việc - frmCongViec";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongViec)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtLuongThang;
        private System.Windows.Forms.TextBox txtTenCV;
        private System.Windows.Forms.TextBox txtMaCV;
        private System.Windows.Forms.Label lblLuongThang;
        private System.Windows.Forms.Label lblTenCV;
        private System.Windows.Forms.Label lblMaCV;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvCongViec;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
    }
}