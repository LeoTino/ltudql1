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
    public partial class Form4 : Form
    {
        decimal tien = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
            var sql = new GetDataFromSQL();
            DataTable danhmuc = new DataTable();
            string lenh = "select distinct tenDM from DanhMucMonAn dm, MonAn ma, MenuChiNhanh mn where dm.maDM=ma.danhMuc and ma.maMA=mn.maMA and mn.maCN='" + Form1.maCN + "'";
            danhmuc = sql.getDataTable(lenh);
            foreach (DataRow row in danhmuc.Rows)
            {
                Button bt = new Button();
                bt.Parent = flowLayoutPanel1;
                bt.Size = new Size(165, 165);
                bt.Text = row[0].ToString();
                bt.ForeColor = Color.DodgerBlue;
                bt.BackColor = Color.Navy;
                bt.Font = new Font(this.Font, FontStyle.Bold);
                bt.Click += Bt_Click;
            }
            label1.Text = Form1.tenTable;
            

            //hide task and fullscreen
            FormState fm = new FormState();
            fm.Maximize(this);
            
        }

        
        private void Bt_Click(object sender, EventArgs e)
        {
            //flow pannel 2
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Refresh();
            Button selectedBT = (Button)sender;
            var sql = new GetDataFromSQL();
            var monan = new DataTable();
            string lenh = "select distinct tenMA, donGia from DanhMucMonAn dm, MonAn ma, MenuChiNhanh mn where dm.maDM=ma.danhMuc and ma.maMA=mn.maMA and mn.maCN='" + Form1.maCN + "' and dm.tenDM=N'" + selectedBT.Text + "'";
            monan = sql.getDataTable(lenh);
            foreach (DataRow row in monan.Rows)
            {
                Button btMon = new Button();
                btMon.Parent = flowLayoutPanel2;
                btMon.Size = new Size(185, 185);
                btMon.Text = row[0].ToString();
                btMon.Name = row[1].ToString();
                btMon.ForeColor = Color.Lavender;
                btMon.BackColor = Color.DarkGreen;
                btMon.Font = new Font(this.Font, FontStyle.Bold);
                btMon.Click += BtMon_Click;
            }
        }

        void LoadTongTien() //label6
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                tien +=Convert.ToDecimal(row.Cells[1].Value);
                label6.Text = tien.ToString();
            }
            tien = 0;
        }

        private void BtMon_Click(object sender, EventArgs e)
        {
            Button selectedBT = (Button)sender;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thêm món này?", "Thông báo", MessageBoxButtons.YesNo);
            if(dialogResult==DialogResult.No)
            {
                MessageBox.Show("Bạn KHÔNG chọn món này!");
            }
            if(dialogResult==DialogResult.Yes)
            {
                dataGridView1.Rows.Add(selectedBT.Text, selectedBT.Name);
                LoadTongTien();
                MessageBox.Show("Bạn ĐÃ thêm món này vào hóa đơn!");
            }
        }

        private void Form4_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sql = new GetDataFromSQL();
            string lenh = "update DonHang set maTTDH=5 where maDH='" + Form1.maDH + "'";
            DialogResult result = MessageBox.Show("Bạn có muốn HỦY đơn hàng?", "Thông báo", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                if (sql.ExecuteNonQuery(lenh) > 0)
                    MessageBox.Show("Đã hủy thành công");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn chuyển xuống bếp?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                int i = dataGridView1.RowCount, j = 0;
                decimal tien = 0;
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
                    string lenh = "insert into ChiTietDonHang(maDonHang,maMA) values ('" + Form1.maDH + "','" + maMA + "')";
                    if (sql.ExecuteNonQuery(lenh) > 0)
                        j++;
                    tien += Convert.ToDecimal(row.Cells[1].Value.ToString());
                }
                if (i == j)
                {
                    string s = "update DonHang set maTTDH=2 , giaTriDonHang='" + tien + "' where maDH='" + Form1.maDH + "'";
                    sql.ExecuteNonQuery(s);
                    string s1 = "update BanAn set tinhTrang=1 where maBA=" + Form1.curTable + " and maCN=" + Form1.maCN;
                    if(sql.ExecuteNonQuery(s1)>0)
                        MessageBox.Show("Đã chuyển xuống bếp");
                    var f1 = new Form1();
                    this.Close();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Không thể chuyển đơn hàng này xuống bếp!");
                }
            }
            else
            {
                MessageBox.Show("Đã hủy chuyển đơn xuống bếp");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thanh toán đơn hàng này và in hóa đơn?", "Thanh toán", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                int i = dataGridView1.RowCount, j = 0;
                decimal tien = 0;
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    var dt = new DataTable();
                    string tenMonAn = row.Cells[0].Value.ToString();
                    string timMaMA = "select maMA from MonAn where tenMA=N'" + tenMonAn + "'";
                    dt = sql.getDataTable(timMaMA);
                    int maMA = 0;
                    foreach(DataRow dtRow in dt.Rows)
                    {
                        maMA = Convert.ToInt32(dtRow[0].ToString());
                    }
                    string lenh = "insert into ChiTietDonHang(maDonHang,maMA) values ('" + Form1.maDH + "','" + maMA + "')";
                    if(sql.ExecuteNonQuery(lenh)>0)
                        j++;
                    string rank = "update MonAn set dem=dem+1 where maMA=" + maMA;
                    sql.ExecuteNonQuery(rank);
                    tien += Convert.ToDecimal(row.Cells[1].Value.ToString());
                }
                if (i == j)
                {
                    string s = "update DonHang set maTTDH=4 , giaTriDonHang='"+tien+"' where maDH='" + Form1.maDH + "'";
                    sql.ExecuteNonQuery(s);
                    MessageBox.Show("Đã thanh toán. Vui lòng chờ in hóa đơn");
                    var f1 = new Form1();
                    this.Close();
                    f1.Show();
                };
            }
            else
            {
                MessageBox.Show("Đã hủy thanh toán");
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cur = (dataGridView1.CurrentRow.Index);
            dataGridView1.Rows.RemoveAt(cur);
        }
    }
}
