using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanhMucMonAn
{
    public partial class Form2 : Form
    {
        DataTable dt = new DataTable(); //datatable danh muc
        DataTable dt2 = new DataTable();//mon an
        DataTable cbb = new DataTable();//Du lieu danh muc comboBox
        DataTable cn = new DataTable();//chi nhanh
        public static int masoCN;
        string tenCN = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDGVDanhMuc();
            LoadDGVMonAn();
            LoadComboBoxDanhMuc();
            tb_tenDM.Enabled = false;
            tb_ghiChu.Enabled = false;
            LoadChiNhanh();
            toolStripButton5.Enabled = false;
            toolStripButton6.Enabled = false;
            
            
            
            //load chart

            for (int i = 0; i < 30; i++)
            {
                Random rd = new Random();
                int so = rd.Next(i, 100);
                chart1.Series["Doanh thu"].Points.AddXY("Ngày " + i, so);
            }

            //Ẩn tabpage
            hidetabpage();
        }

        public void LoadChiNhanh()
        {
            var sql = new GetDataFromSQL();
            cn = sql.getDataTable("select maCN, tenCN, dienThoai, diaChi, tinhThanh from ChiNhanh");
            dataGridView3.DataSource = cn;
            dataGridView3.ReadOnly = true;
        }

        public void hidetabpage()
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
        }

        public void showtabpage(TabPage tabPage)
        {
            hidetabpage();
            tabControl1.TabPages.Add(tabPage);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                MessageBox.Show("Đang hoạt động");
            }
            else
            {
                showtabpage(tabPage2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                MessageBox.Show("Đang hoạt động");
            }
            else
            {
                showtabpage(tabPage1);
                LoadDGVMonAn();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                MessageBox.Show("Đang hoạt động");
            }
            else
            {
                showtabpage(tabPage3);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
            {
                MessageBox.Show("Đang hoạt động");
            }
            else
            {
                showtabpage(tabPage4);
            }
        }


        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            var f = new themBan();
            f.ShowDialog();
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
            LoadChiNhanh();
        }


        //DANH MUC
        private void LoadDGVDanhMuc()
        {
            tb_ghiChu.Clear();
            tb_tenDM.Clear();
            tb_ghiChu.Enabled = false;
            tb_tenDM.Enabled = false;
            bt_sua.Enabled = true;
            bt_xoa.Enabled = true;
            bt_them.Enabled = true;
            bt_luu.Enabled = false;
            
            var sql = new GetDataFromSQL();
            dt = sql.getDataTable("select maDM as 'Mã danh mục', tenDM as 'Tên danh mục', ghiChu as 'Ghi chú'  from DanhMucMonAn");
            dataGridView1.DataSource = dt;
        }

        bool isAdd = false;
        bool isEdit = false;
        //bool isDelete = false;
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            tb_tenDM.Enabled = true;
            tb_ghiChu.Enabled = true;
            isAdd = true;
            bt_them.Enabled = false;
            bt_sua.Enabled = false;
            bt_xoa.Enabled = false;
            bt_luu.Enabled = true;
            LoadComboBoxDanhMuc();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (isAdd == true)
            {
                if (tb_tenDM.Text != "")
                {
                    var danhmuc = new DanhMuc();
                    danhmuc.TenDanhMuc = tb_tenDM.Text;
                    danhmuc.GhiChuDanhMuc = tb_ghiChu.Text;
                    var sql = new GetDataFromSQL();
                    if(sql.themDanhMuc(danhmuc))
                    {
                        MessageBox.Show("Thêm thành công");
                        isAdd = false;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
            }
            if(isEdit==true)
            {
                if (tb_tenDM.Text != "")
                {
                    var danhmuc = new DanhMuc();
                    danhmuc.TenDanhMuc = tb_tenDM.Text;
                    danhmuc.GhiChuDanhMuc = tb_ghiChu.Text;
                    var sql = new GetDataFromSQL();
                    int currentIndex = dataGridView1.CurrentRow.Index;
                    int maDM = int.Parse(dataGridView1.Rows[currentIndex].Cells[0].Value.ToString());
                    if (sql.capNhatDanhMuc(danhmuc,maDM))
                    {
                        MessageBox.Show("Sửa thành công!");
                        isEdit = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể sửa thành NULL!");
                    return;
                }
            }
            LoadDGVDanhMuc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentIndex = dataGridView1.CurrentRow.Index;
            tb_ghiChu.Text = dataGridView1.Rows[currentIndex].Cells[2].Value.ToString();
            tb_tenDM.Text=dataGridView1.Rows[currentIndex].Cells[1].Value.ToString();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            tb_tenDM.Enabled = true;
            tb_ghiChu.Enabled = true;
            isEdit = true;
            bt_them.Enabled = false;
            bt_xoa.Enabled = false;
            bt_sua.Enabled = false;
            bt_luu.Enabled = true;
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                int currentIndex = dataGridView1.CurrentRow.Index;
                int maDM = int.Parse(dataGridView1.Rows[currentIndex].Cells[0].Value.ToString());
                if (sql.xoaDanhMuc(maDM))
                    MessageBox.Show("Đã xóa thành công");
                else
                    MessageBox.Show("Không thể xóa");
            }
            LoadDGVDanhMuc();
        }


        //MON AN

        private void LoadComboBoxDanhMuc()
        {
            cb_MADanhMuc.Items.Clear();
            var sql = new GetDataFromSQL();
            cbb = sql.getDataTable("select distinct tenDM from DanhMucMonAn");
            foreach (DataRow row in cbb.Rows)
            {
                cb_MADanhMuc.Items.Add(row["tenDM"]);
            }
        }

        private void LoadDGVMonAn()
        {
            tb_MATen.Clear();
            tb_MADonGia.Clear();
            tb_MADonViTinh.Clear();
            tb_MAGhiChu.Clear();

            tb_MATen.Enabled = false;
            tb_MADonGia.Enabled = false;
            tb_MADonViTinh.Enabled = false;
            tb_MAGhiChu.Enabled = false;
            cb_MADanhMuc.Enabled = false;
            
            bt_MALuu.Enabled = false;
            bt_MASua.Enabled = true;
            bt_MAThem.Enabled = true;
            bt_MAXoa.Enabled = true;

            var sql = new GetDataFromSQL();
            dt2 = sql.getDataTable("select maMA as 'Mã món ăn', tenMA as 'Tên món ăn', dm.tenDM as 'Danh mục', donGia as 'Đơn giá', donViTinh as 'Đơn vị tính', ma.ghiChu as 'Ghi chú'  from MonAn ma, DanhMucMonAn dm where ma.danhMuc=dm.maDM");
            dataGridView2.DataSource = dt2;
            LoadComboBoxDanhMuc();
        }

        private void bt_MAThem_Click(object sender, EventArgs e)
        {
            tb_MADonGia.Enabled = true;
            tb_MADonViTinh.Enabled = true;
            tb_MAGhiChu.Enabled = true;
            tb_MATen.Enabled = true;
            cb_MADanhMuc.Enabled = true;
            isAdd = true;

            bt_MALuu.Enabled = true;
            bt_MASua.Enabled = false;
            bt_MAThem.Enabled = false;
            bt_MAXoa.Enabled = false;
        }

        private void bt_MALuu_Click(object sender, EventArgs e)
        {
            if (isAdd == true)
            {
                if (tb_MATen.Text != "")
                {
                    var monAn = new MonAn();
                    var sql = new GetDataFromSQL();
                    monAn.TenMonAn = tb_MATen.Text;
                    monAn.DonViTinh = tb_MADonViTinh.Text;
                    monAn.DonGia = Convert.ToDouble(tb_MADonGia.Text);
                    monAn.GhiChu = tb_MAGhiChu.Text;
                    monAn.DanhMuc = sql.timMaDanhMuc(cb_MADanhMuc.Text);
                    
                    if (sql.themMonAn(monAn))
                    {
                        MessageBox.Show("Thêm thành công");
                        isAdd = false;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }
            }
            if (isEdit == true)
            {
                if (tb_MATen.Text != "")
                {
                    var ma = new MonAn();
                    var sql = new GetDataFromSQL();
                    ma.DanhMuc = sql.timMaDanhMuc(cb_MADanhMuc.Text);
                    ma.DonGia =Convert.ToDouble(tb_MADonGia.Text);
                    ma.DonViTinh = tb_MADonViTinh.Text;
                    ma.GhiChu = tb_MAGhiChu.Text;
                    ma.TenMonAn = tb_MATen.Text;
                    int currentIndex = dataGridView2.CurrentRow.Index;
                    int maMA = int.Parse(dataGridView2.Rows[currentIndex].Cells[0].Value.ToString());
                    if (sql.capNhatMonAn(ma,maMA))
                    {
                        MessageBox.Show("Sửa thành công!");
                        isEdit = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể sửa thành NULL!");
                    return;
                }
            }

            LoadDGVMonAn();
        }

        private void bt_MASua_Click(object sender, EventArgs e)
        {
            tb_MADonGia.Enabled = true;
            tb_MADonViTinh.Enabled = true;
            tb_MAGhiChu.Enabled = true;
            tb_MATen.Enabled = true;
            cb_MADanhMuc.Enabled = true;
            isEdit = true;

            bt_MALuu.Enabled = true;
            bt_MASua.Enabled = false;
            bt_MAThem.Enabled = false;
            bt_MAXoa.Enabled = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentIndex = dataGridView2.CurrentRow.Index;
            tb_MADonGia.Text = dataGridView2.Rows[currentIndex].Cells[3].Value.ToString();
            tb_MADonViTinh.Text = dataGridView2.Rows[currentIndex].Cells[4].Value.ToString();
            tb_MAGhiChu.Text = dataGridView2.Rows[currentIndex].Cells[5].Value.ToString();
            tb_MATen.Text = dataGridView2.Rows[currentIndex].Cells[1].Value.ToString();
            cb_MADanhMuc.Text = dataGridView2.Rows[currentIndex].Cells[2].Value.ToString();
        }

        private void bt_MAXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                int currentIndex = dataGridView2.CurrentRow.Index;
                int maMA = int.Parse(dataGridView2.Rows[currentIndex].Cells[0].Value.ToString());
                if (sql.xoaMonAn(maMA))
                    MessageBox.Show("Đã xóa thành công");
                else
                    MessageBox.Show("Không thể xóa");
            }
            LoadDGVMonAn();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = false;
            toolStripButton7.Enabled = false;
            toolStripButton10.Enabled = false;
            toolStripButton5.Enabled = true;
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            dataGridView3.ReadOnly = true;
            toolStripButton7.Enabled = true;
            toolStripButton10.Enabled = true;
            toolStripButton5.Enabled = false;
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            int test = 0;
            int kq = 0;
            foreach(DataGridViewRow row in dataGridView3.Rows)
            {
                int maCN = Convert.ToInt32(row.Cells[0].Value);
                var sql = new GetDataFromSQL();
                string tenCN = Convert.ToString(row.Cells[1].Value);
                string diaChi = Convert.ToString(row.Cells[3].Value);
                string dienThoai = Convert.ToString(row.Cells[2].Value);
                string tinhThanh = Convert.ToString(row.Cells[4].Value);
                string cm = "update ChiNhanh set tenCN =N'" + tenCN + "', diaChi =N'" + diaChi + "', dienThoai =N'" + dienThoai + "', tinhThanh =N'" + tinhThanh + "' where maCN="+maCN;
                if (sql.ExecuteNonQuery(cm) > 0)
                    test++;
                kq++;
            }
            if(test>0 && test==kq)
            {
                MessageBox.Show("Sửa thành công!!!");
            }
        }

        
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            masoCN =Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            tenCN = Convert.ToString(dataGridView3.CurrentRow.Cells[1].Value);
            var tableOfCN = new DataTable();
            var sql = new GetDataFromSQL();
            string lenh = "select maBA,tenBA,ghiChu,sucChua from BanAn where maCN= " + masoCN;
            tableOfCN = sql.getDataTable(lenh);
            dataGridView4.DataSource = tableOfCN;
            dataGridView4.ReadOnly = true;
            textBox3.Text = "Danh sách bàn chi nhánh: " + tenCN;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa chi nhánh này?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                string cm = "delete from ChiNhanh where maCN=" + masoCN;
                string deltable = "delete from BanAn where maCN=" + masoCN;
                string delmenu = "delete from MenuChiNhanh where maCN=" + masoCN;
                if (sql.ExecuteNonQuery(delmenu) >= 0 && sql.ExecuteNonQuery(deltable) >= 0 && sql.ExecuteNonQuery(cm) > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadChiNhanh();
                }
                else
                    MessageBox.Show("Không thể xóa chi nhánh này");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dataGridView4.ReadOnly = false;
            toolStripButton1.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton6.Enabled = true;
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            dataGridView4.ReadOnly = true;
            toolStripButton1.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton6.Enabled = false;
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            int test = 0;
            int kq = 0;
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                var sql = new GetDataFromSQL();
                string maBA = Convert.ToString(row.Cells[0].Value);
                string tenBA = Convert.ToString(row.Cells[1].Value);
                string ghiChu = Convert.ToString(row.Cells[2].Value);
                string sucChua = Convert.ToString(row.Cells[3].Value);
                string cm = "update BanAn set tenBA ='" + tenBA + "', ghiChu ='" + ghiChu + "', sucChua ='" + sucChua + "' where maBA='" + maBA + "' and maCN='" + masoCN+"'";
                if (sql.ExecuteNonQuery(cm) > 0)
                    test++;
                kq++;
            }
            if (test > 0 && test == kq)
            {
                MessageBox.Show("Sửa thông tin bàn thành công!!!");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa bàn này?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                int maBA =Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                string deltable = "delete from BanAn where maBA='" + maBA + "' and maCN='" + masoCN + "'";
                if (sql.ExecuteNonQuery(deltable) > 0 )
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadChiNhanh();
                }
                else
                    MessageBox.Show("Không thể xóa chi nhánh này");
            }
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            var tableOfCN = new DataTable();
            var sql = new GetDataFromSQL();
            string lenh = "select maBA,tenBA,ghiChu,sucChua from BanAn where maCN= " + masoCN;
            tableOfCN = sql.getDataTable(lenh);
            dataGridView4.DataSource = tableOfCN;
        }
    }
}
