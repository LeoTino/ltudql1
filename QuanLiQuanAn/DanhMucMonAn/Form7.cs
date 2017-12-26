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
    public partial class Form7 : Form
    {
        int maDH = 0;
        decimal tien = 0;
        bool isClick = false;
        int maCNChon = 0;
        DataTable dtDuyet = new DataTable();
        int curMaDHDuyet = 0;
        int curMaDHChiNhanh = 0;
        int curMADHHuyDoi = 0;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            var sql = new GetDataFromSQL();
            string lenh = "select SDT from KhachHang";
            table = sql.getDataTable(lenh);
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (DataRow row in table.Rows)
            {
                collection.Add(row[0].ToString());
            }
            textBox1.AutoCompleteCustomSource = collection;

            DataTable danhmuc = new DataTable();
            string lenh2 = "select distinct tenDM from DanhMucMonAn dm ";
            danhmuc = sql.getDataTable(lenh2);
            foreach (DataRow row in danhmuc.Rows)
            {
                Button bt = new Button();
                bt.Parent = flowLayoutPanel1;
                bt.Size = new Size(180, 55);
                bt.Text = row[0].ToString();
                bt.ForeColor = Color.DodgerBlue;
                bt.BackColor = Color.SeaShell;
                bt.Font = new Font(this.Font, FontStyle.Bold);
                bt.Click += Bt_Click;
            }

            LoadDonHangChuyenXuongCN(); //chinhanh de don hang chuyen xuong
            LoadDGVDuyetDonHang(); //dgv2
            LoadDGVDonHang(); //dgv3
            LoadDGVXemTTDonHang(); //dgv4
            LoadDGVHuyDoi();
            hidetabpage();

        }

        private void Bt_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Refresh();
            Button selectedBT = (Button)sender;
            var sql = new GetDataFromSQL();
            var monan = new DataTable();
            string lenh = "select distinct tenMA, donGia from DanhMucMonAn dm, MonAn ma where dm.maDM=ma.danhMuc and dm.tenDM=N'" + selectedBT.Text + "'";
            monan = sql.getDataTable(lenh);
            foreach (DataRow row in monan.Rows)
            {
                Button btMon = new Button();
                btMon.Parent = flowLayoutPanel2;
                btMon.Size = new Size(560, 55);
                btMon.Text = row[0].ToString();
                btMon.Name = row[1].ToString();
                btMon.ForeColor = Color.Lavender;
                btMon.BackColor = Color.DarkGreen;
                btMon.Font = new Font(this.Font, FontStyle.Bold);
                btMon.Click += BtMon_Click;
            }
        }

        void LoadTongTien() //label8
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                tien += Convert.ToDecimal(row.Cells[1].Value);
                label8.Text ="Danh sách đã chọn ("+ tien.ToString()+"VND)";
            }
            tien = 0;
        }

        private void BtMon_Click(object sender, EventArgs e)
        {
            Button selectedBT = (Button)sender;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thêm món này?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Bạn KHÔNG chọn món này!");
            }
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView1.Rows.Add(selectedBT.Text, selectedBT.Name);
                MessageBox.Show("Bạn ĐÃ thêm món này vào hóa đơn!");
                LoadTongTien();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var kh = new DataTable();
            string lenh = "select SDT,ten,diaChi,email from KhachHang where SDT=N'"+textBox1.Text+"'";
            var sql =new GetDataFromSQL();
            kh = sql.getDataTable(lenh);
            foreach(DataRow row in kh.Rows)
            {
                label2.Text = "Tên khách hàng: " + row[1].ToString();
                label2.Name= row[1].ToString();
                label4.Text = "Địa chỉ: " + row[2].ToString();
                label4.Name= row[2].ToString();
                label6.Text = "Email: " + row[3].ToString();
                label6.Name= row[3].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                tien += Convert.ToDecimal(row.Cells[1].Value);
            }
            var sql = new GetDataFromSQL();
            string time = DateTime.Now.ToString();
            string lenh = "insert into DonHang(maTTDH,thoiGian,SDT,diaChi,giaTriDonHang) values (9,'"+time+"','"+textBox1.Text+"',N'"+label4.Name+"',"+tien+")";
            if (sql.ExecuteNonQuery(lenh)>0)
            {
                string lenhx = "select maDH from DonHang where SDT='" + textBox1.Text + "' and thoiGian='" + time + "'";
                DataTable tab = new DataTable();
                tab = sql.getDataTable(lenhx);
                foreach (DataRow row in tab.Rows)
                {
                    maDH = Convert.ToInt32(row[0].ToString());
                    textBox1.Text = "dsa " + maDH;
                }

                int i = dataGridView1.RowCount, j = 0 ;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var dt = new DataTable();
                    string tenMonAn = row.Cells[0].Value.ToString();
                    string timMaMA = "select maMA from MonAn where tenMA=N'" + tenMonAn + "'";
                    dt = sql.getDataTable(timMaMA);
                    int maMA = 0;
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        maMA = Convert.ToInt32(dtRow[0].ToString());
                    }
                    
                    string lenh1 = "insert into ChiTietDonHang(maDonHang,maMA) values ('" + maDH + "','" + maMA + "')";
                    if (sql.ExecuteNonQuery(lenh1) > 0)
                        j++;
                }
                if (i == j)
                {
                    MessageBox.Show("Tạo đơn hàng thành công!");
                    this.Refresh();
                }
                else
                {
                    MessageBox.Show("Không thể tạo đơn hàng này!");
                }
            }

        }

        private void button22_Click(object sender, EventArgs e)
        {
            string lenh = "insert into KhachHang(SDT,ten,diaChi,email) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            var sql = new GetDataFromSQL();
            if(sql.ExecuteNonQuery(lenh)>0)
            {
                MessageBox.Show("Thêm khách hàng thành công!");

            }
            else
            {
                MessageBox.Show("Không thể thêm khách hàng này!");
            }
        }

        void LoadDonHangChuyenXuongCN()
        {
            var table = new DataTable();
            string lenh = "select tenCN,maCN from ChiNhanh";
            var sql = new GetDataFromSQL();
            table = sql.getDataTable(lenh);
            double congsuat = 0;
            double tong = 0;
            double hien = 0;
            foreach (DataRow row in table.Rows)
            {
                var temp = new DataTable();
                string cmd = "select maBA,tinhTrang from BanAn ba, ChiNhanh cn where ba.maCN=cn.maCN and cn.maCN=" + Convert.ToInt32(row[1].ToString());
                temp = sql.getDataTable(cmd);
                foreach(DataRow rowtemp in temp.Rows)
                {
                    tong++;
                    if (Convert.ToInt32(rowtemp[1]) == 1)
                        hien++;
                }
                congsuat = (hien / tong) * 100;
                if(hien==0 || tong==0)
                {
                    congsuat = 0;
                }
                Button btDuyet = new Button();
                btDuyet.Parent = flowLayoutPanel6;
                btDuyet.Size = new Size(290, 100);
                btDuyet.Text = row[0].ToString()+ "\r\nCông suất: "+Math.Round(congsuat,1)+"%";
                btDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btDuyet.ForeColor = Color.DodgerBlue;
                btDuyet.BackColor = Color.Navy;
                btDuyet.Click += btDuyet_Click;
                btDuyet.LostFocus += btDuyet_LostFocus;
                btDuyet.Name = row[1].ToString();
                //btDuyet.AccessibleName = row[2].ToString();
            }
        }

        private void btDuyet_LostFocus(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.Navy;
            bt.Refresh();
        }

        private void btDuyet_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.Aquamarine;
            isClick = bt.CanSelect;
            maCNChon = Convert.ToInt32(bt.Name);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cur = (dataGridView1.CurrentRow.Index);
            dataGridView1.Rows.RemoveAt(cur);
        }

        void LoadDGVDuyetDonHang() //dgv2
        {
            string lenh = "select maDH as N'Mã đơn hàng', ten as N'Tên khách hàng', kh.SDT as N'Số điện thoại', dh.thoiGian as N'Thời gian đặt hàng' from KhachHang kh, DonHang dh where dh.SDT = kh.SDT and maTTDH = 8 ";
            var sql = new GetDataFromSQL();
            dtDuyet = sql.getDataTable(lenh);
            dataGridView2.DataSource = dtDuyet;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cur = (dataGridView2.CurrentRow.Index);
            curMaDHDuyet = Convert.ToInt32(dataGridView2.Rows[cur].Cells[0].Value.ToString());
        }

        private void button14_Click(object sender, EventArgs e) //button duyet
        {
            string lenh = "update DonHang set maTTDH=9 where maDH=" + curMaDHDuyet;
            var sql =new GetDataFromSQL();
            if(sql.ExecuteNonQuery(lenh)>0)
            {
                MessageBox.Show("Đã duyệt đơn hàng này!");
                LoadDGVDuyetDonHang();
            }
            else
            {
                MessageBox.Show("Không thể duyệt đơn hàng này!");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string lenh = "update DonHang set maTTDH=5 where maDH=" + curMaDHDuyet;
            var sql = new GetDataFromSQL();
            DialogResult result = MessageBox.Show("Bạn có muốn hủy đơn này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (sql.ExecuteNonQuery(lenh) > 0)
                {
                    MessageBox.Show("Đã HỦY đơn hàng này!");
                    LoadDGVDuyetDonHang();
                }
                else
                {
                    MessageBox.Show("Không thể hủy đơn hàng này!");
                }
            }
            else
            {
                MessageBox.Show("Đã bỏ hủy đơn này!");
            }
        }

        void LoadDGVDonHang() //dgv3
        {
            string lenh = "select maDH as N'Mã đơn hàng', ten as N'Tên khách hàng', kh.SDT as N'Số điện thoại', dh.thoiGian as N'Thời gian đặt hàng' from KhachHang kh, DonHang dh where dh.SDT = kh.SDT and maTTDH = 9 ";
            var sql = new GetDataFromSQL();
            dtDuyet = sql.getDataTable(lenh);
            dataGridView3.DataSource = dtDuyet;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cur = (dataGridView3.CurrentRow.Index);
            curMaDHChiNhanh = Convert.ToInt32(dataGridView3.Rows[cur].Cells[0].Value.ToString());
            flowLayoutPanel6.Enabled = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (maCNChon == 0)
                MessageBox.Show("Bạn phải chọn chi nhánh chuyển xuống!");
            else
            {
                string lenh = "update DonHang set maTTDH=7, maCN=" + maCNChon + " where maDH=" + curMaDHChiNhanh;
                var sql = new GetDataFromSQL();
                DialogResult result = MessageBox.Show("Bạn có muốn chuyển đơn này?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (sql.ExecuteNonQuery(lenh) > 0)
                    {
                        MessageBox.Show("Đã CHUYỂN đơn hàng này!");
                        LoadDGVDonHang();
                    }
                    else
                    {
                        MessageBox.Show("Không thể chuyển đơn hàng này!");
                    }
                }
                else
                {
                    MessageBox.Show("Đã bỏ chuyển đơn này!");
                }
            }
            flowLayoutPanel6.Enabled = false;
        }

        void  LoadDGVXemTTDonHang() //dgv4
        {
            string lenh = "select maDH as N'Mã đơn hàng', tenTTDH as 'Trạng thái' ,ten as N'Tên khách hàng', kh.SDT as N'Số điện thoại', dh.thoiGian as N'Thời gian đặt hàng' from KhachHang kh, DonHang dh, TinhTrangDonHang ttdh where dh.SDT = kh.SDT and dh.maTTDH=ttdh.maTTDH and (dh.maTTDH = 4 or dh.maTTDH = 5 or dh.maTTDH = 6 or dh.maTTDH =7 or dh.maTTDH =8 or dh.maTTDH =9 or dh.maTTDH =10 or dh.maTTDH =11) and dh.maBA is null";
            var sql = new GetDataFromSQL();
            dtDuyet = sql.getDataTable(lenh);
            dataGridView4.DataSource = dtDuyet;
        }

        void LoadDGVHuyDoi() //dgv5
        {
            string lenh = "select maDH as N'Mã đơn hàng', tenTTDH as 'Trạng thái' ,ten as N'Tên khách hàng', kh.SDT as N'Số điện thoại', dh.thoiGian as N'Thời gian đặt hàng' from KhachHang kh, DonHang dh, TinhTrangDonHang ttdh where dh.SDT = kh.SDT and dh.maTTDH=ttdh.maTTDH and (dh.maTTDH = 4 or dh.maTTDH = 6 or dh.maTTDH =7 or dh.maTTDH =8 or dh.maTTDH =9 or dh.maTTDH =10 or dh.maTTDH =11) and dh.maBA is null";
            var sql = new GetDataFromSQL();
            dtDuyet = sql.getDataTable(lenh);
            dataGridView5.DataSource = dtDuyet;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cur = (dataGridView5.CurrentRow.Index);
            curMADHHuyDoi = Convert.ToInt32(dataGridView5.Rows[cur].Cells[0].Value.ToString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (curMADHHuyDoi == 0)
                MessageBox.Show("Bạn phải chọn đơn hàng cần hủy!");
            else
            {
                string lenh = "update DonHang set maTTDH=5 where maDH=" + curMADHHuyDoi;
                var sql = new GetDataFromSQL();
                DialogResult result = MessageBox.Show("Bạn có muốn hủy đơn này?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (sql.ExecuteNonQuery(lenh) > 0)
                    {
                        MessageBox.Show("Đã hủy đơn hàng này!");
                        LoadDGVHuyDoi();
                    }
                    else
                    {
                        MessageBox.Show("Không thể hủy đơn hàng này!");
                    }
                }
                else
                {
                    MessageBox.Show("Đã bỏ hủy đơn này!");
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (curMADHHuyDoi == 0)
                MessageBox.Show("Bạn phải chọn đơn hàng cần đổi!");
            else
            {
                string lenh = "update DonHang set maTTDH=11 where maDH=" + curMADHHuyDoi;
                var sql = new GetDataFromSQL();
                DialogResult result = MessageBox.Show("Bạn có muốn đổi đơn này?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (sql.ExecuteNonQuery(lenh) > 0)
                    {
                        MessageBox.Show("Đã đổi đơn hàng này!");
                        LoadDGVHuyDoi();
                    }
                    else
                    {
                        MessageBox.Show("Không thể đổi đơn hàng này!");
                    }
                }
                else
                {
                    MessageBox.Show("Đã bỏ đổi đơn này!");
                }
            }
        }

        public void hidetabpage()
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Remove(tabPage9);
        }

        public void showtabpage(TabPage tabPage)
        {
            hidetabpage();
            tabControl1.TabPages.Add(tabPage);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                MessageBox.Show("Đang hoạt động");
            }
            else
            {
                showtabpage(tabPage1);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                MessageBox.Show("Đang hoạt động");
                LoadDGVDuyetDonHang();
            }
            else
            {
                showtabpage(tabPage2);
                LoadDGVDuyetDonHang();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage6)
            {
                MessageBox.Show("Đang hoạt động");
                LoadDGVDonHang();
            }
            else
            {
                showtabpage(tabPage6);
                LoadDGVDonHang();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage7)
            {
                MessageBox.Show("Đang hoạt động");
                LoadDGVHuyDoi();
            }
            else
            {
                showtabpage(tabPage7);
                LoadDGVHuyDoi();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage8)
            {
                MessageBox.Show("Đang hoạt động");
                LoadDGVXemTTDonHang();
            }
            else
            {
                showtabpage(tabPage8);
                LoadDGVXemTTDonHang();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage9)
            {
                MessageBox.Show("Đang hoạt động");
            }
            else
            {
                showtabpage(tabPage9);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
