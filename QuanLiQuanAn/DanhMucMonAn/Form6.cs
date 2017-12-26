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
    public partial class Form6 : Form
    {
        bool isClick = false;
        int maDH = 0;
        string curSDT = "";
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoadDonHangTuTongDai();



            FormState fm = new FormState();
            fm.Maximize(this);
        }

        void LoadDonHangTuTongDai()
        {
            var table = new DataTable();
            string lenh = "select ten, kh.SDT, maDH from KhachHang kh, DonHang dh where dh.SDT = kh.SDT and maTTDH = 7 and dh.maCN="+Form1.maCN;
            var sql = new GetDataFromSQL();
            table = sql.getDataTable(lenh);
            foreach (DataRow row in table.Rows)
            {
                Button bt = new Button();
                bt.Parent = flowLayoutPanel1;
                bt.Size = new Size(315, 165);
                bt.Text = row[0].ToString() + "\r\n" + row[1].ToString();
                bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bt.ForeColor = Color.DodgerBlue;
                bt.BackColor = Color.Navy;
                bt.Click += Bt_Click;
                bt.LostFocus += Bt_LostFocus;
                bt.Name = row[1].ToString();
                bt.AccessibleName = row[2].ToString();
            }
        }

        void LoadDGVChiTietDonHang()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            var table = new DataTable();
            string lenh = "select tenMA from MonAn ma, ChiTietDonHang ctdh where ma.maMA=ctdh.maMA and ctdh.maDonHang='" + maDH + "'";
            var sql = new GetDataFromSQL();
            table = sql.getDataTable(lenh);
            foreach(DataRow row in table.Rows)
            {
                dataGridView1.Rows.Add(row[0].ToString());
            }
        }

        private void Bt_LostFocus(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.Navy;
            bt.Refresh();
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            curSDT = bt.Name;
            bt.BackColor = Color.Aquamarine;
            isClick = bt.CanSelect;
            maDH = Convert.ToInt32(bt.AccessibleName);
            LoadDGVChiTietDonHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (isClick == true)
            {
                DialogResult result = MessageBox.Show("Bạn muốn NHẬN đơn hàng này và chế biến?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var sql = new GetDataFromSQL();
                    string lenh = "update DonHang set maTTDH=2 where SDT='" + curSDT + "'";
                    if (sql.ExecuteNonQuery(lenh) > 0)
                    {
                        MessageBox.Show("NHẬN đơn hàng thành công! Đang chuyển đơn hàng xuống bếp");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Không thể NHẬN đơn hàng này!");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn đơn hàng cần NHẬN!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (isClick == true)
            {
                DialogResult result = MessageBox.Show("Bạn muốn CHUYỂN đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var sql = new GetDataFromSQL();
                    string lenh = "update DonHang set maTTDH=8 where SDT='" + curSDT + "'";
                    if (sql.ExecuteNonQuery(lenh) > 0)
                    {
                        MessageBox.Show("CHUYỂN đơn hàng thành công!");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Không thể CHUYỂN đơn hàng này!");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn đơn hàng cần CHUYỂN!");
            }
        }
    }
}
