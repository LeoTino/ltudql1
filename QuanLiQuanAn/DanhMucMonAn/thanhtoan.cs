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
    public partial class thanhtoan : Form
    {
        public thanhtoan()
        {
            InitializeComponent();
        }

        private void thanhtoan_Load(object sender, EventArgs e)
        {
            LoadCBB();
            label5.Visible = false;
            comboBox1.Visible = false;
        }

        void LoadCBB()
        {
            string s = "select tenCN from ChiNhanh";
            var sql = new GetDataFromSQL();
            var dt = new DataTable();
            dt = sql.getDataTable(s);
            foreach(DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row[0].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || maskedTextBox2.Text == "")
            {
                MessageBox.Show("Bạn phải điền đầy đủ thông tin đặt hàng!");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    string lenhKH = "insert into KhachHang(SDT,ten,diaChi,email) values('" + maskedTextBox2.Text + "',N'" + textBox1.Text + "',N'" + textBox3.Text + "','" + textBox2.Text + "')";
                    var sql = new GetDataFromSQL();
                    string dt = DateTime.Now.ToString();
                    string lenhDH = "insert into DonHang(maTTDH,thoiGian,SDT,diaChi,giaTriDonHang) values (8,'" + dt + "','" + maskedTextBox2.Text + "','" + textBox3.Text + "','" + Form12.tien + "')";
                    if (sql.ExecuteNonQuery(lenhKH) > 0 && sql.ExecuteNonQuery(lenhDH) > 0)
                    {
                        int maDH = 0;
                        string lenhmaDH = "select maDH from DonHang where SDT='" + maskedTextBox2.Text + "' and thoiGian='" + dt + "'";
                        var table = new DataTable();
                        table = sql.getDataTable(lenhmaDH);
                        foreach (DataRow madh in table.Rows)
                        {
                            maDH = Convert.ToInt32(madh[0].ToString());
                        }
                        int i = 0, j = Form8.giohang.Rows.Count;
                        foreach (DataRow row in Form8.giohang.Rows)
                        {
                            string lenhCTDH = "insert into ChiTietDonHang(maMA,maDonHang) values (" + row["monan"] + "," + maDH + ")";
                            sql.ExecuteNonQuery(lenhCTDH);
                            i++;
                        }
                        if (i == j)
                        {
                            MessageBox.Show("Đặt hàng thành công. Vui lòng chờ nhân viên liên lạc để nhận hàng!");
                            XoaGioHangKhiDatHang();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể đặt đơn hàng này!");
                    }
                }

                else if (radioButton2.Checked == true)
                {
                    string lenhKH = "insert into KhachHang(SDT,ten,diaChi,email) values('" + maskedTextBox2.Text + "',N'" + textBox1.Text + "',N'" + textBox3.Text + "','" + textBox2.Text + "')";
                    var sql = new GetDataFromSQL();
                    string dt = DateTime.Now.ToString();
                    //tim maCN
                    string lenhmaCN = "select maCN from ChiNhanh where tenCN=N'" + comboBox1.Text + "'";
                    var CN = new DataTable();
                    CN = sql.getDataTable(lenhmaCN);
                    int maCN = 0;
                    foreach (DataRow madh in CN.Rows)
                    {
                        maCN = Convert.ToInt32(madh[0].ToString());
                    }

                    string lenhDH = "insert into DonHang(maTTDH,thoiGian,SDT,diaChi,giaTriDonHang,maCN) values (8,'" + dt + "','" + maskedTextBox2.Text + "','" + textBox3.Text + "','" + Form12.tien + "','" + maCN + "')";
                    if (sql.ExecuteNonQuery(lenhKH) > 0 && sql.ExecuteNonQuery(lenhDH) > 0)
                    {
                        int maDH = 0;
                        string lenhmaDH = "select maDH from DonHang where SDT='" + maskedTextBox2.Text + "' and thoiGian='" + dt + "'";
                        var table = new DataTable();
                        table = sql.getDataTable(lenhmaDH);
                        foreach (DataRow madh in table.Rows)
                        {
                            maDH = Convert.ToInt32(madh[0].ToString());
                        }
                        int i = 0, j = Form8.giohang.Rows.Count;
                        foreach (DataRow row in Form8.giohang.Rows)
                        {
                            string lenhCTDH = "insert into ChiTietDonHang(maMA,maDonHang) values (" + row["monan"] + "," + maDH + ")";
                            sql.ExecuteNonQuery(lenhCTDH);
                            i++;
                        }
                        if (i == j)
                        {
                            MessageBox.Show("Đặt hàng thành công. Vui lòng đến chi nhánh để nhận hàng!");
                            XoaGioHangKhiDatHang();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể đặt đơn hàng này!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn phải hình thức nhận hàng!");
                }
            }
        }

        void XoaGioHangKhiDatHang()
        {
            Form8.giohang.Clear();
            Form8.sl = 0;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            comboBox1.Visible = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            comboBox1.Visible = true;
        }
    }
}
