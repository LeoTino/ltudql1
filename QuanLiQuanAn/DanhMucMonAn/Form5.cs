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
    public partial class Form5 : Form
    {
        bool isClick = false;
        string curSDT = "";
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var sql = new GetDataFromSQL();
            DataTable dh = new DataTable();
            string lenh = "select ten, kh.SDT, maDH from KhachHang kh, DonHang dh where dh.SDT=kh.SDT and maTTDH=6 and dh.maCN="+Form1.maCN;
            dh = sql.getDataTable(lenh);
            foreach (DataRow row in dh.Rows)
            {
                Button bt = new Button();
                bt.Parent = flowLayoutPanel1;
                bt.Size = new Size(365, 165);
                bt.Text = row[0].ToString() + "\r\n" + row[1].ToString();
                bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bt.ForeColor = Color.DodgerBlue;
                bt.BackColor = Color.Navy;
                bt.Click += Bt_Click;
                bt.LostFocus += Bt_LostFocus;
                bt.Name = row[1].ToString();

            }


            //hide task and fullscreen
            FormState fm = new FormState();
            fm.Maximize(this);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (isClick == true)
            {
                DialogResult result= MessageBox.Show("Bạn muốn hủy đơn hàng này?","Thông báo",MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    var sql = new GetDataFromSQL();
                    string lenh = "update DonHang set maTTDH=5 where SDT='" + curSDT + "'";
                    if (sql.ExecuteNonQuery(lenh) > 0)
                    {
                        MessageBox.Show("HỦY đơn hàng thành công!");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Không thể hủy đơn hàng này!");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn đơn hàng cần hủy!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn chuyển xuống bếp?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                string lenh = "update DonHang set maTTDH=2 where SDT='" + curSDT + "'";
                if (sql.ExecuteNonQuery(lenh) > 0)
                    MessageBox.Show("Đã chuyển xuống bếp");
            }
            else
            {
                MessageBox.Show("Đã hủy chuyển đơn xuống bếp");
            }
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (isClick == true)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thanh toán đơn hàng này và in hóa đơn?", "Thanh toán", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var sql = new GetDataFromSQL();
                    string lenh = "update DonHang set maTTDH=4 where SDT='" + curSDT + "'";
                    if (sql.ExecuteNonQuery(lenh) > 0)
                    {
                        MessageBox.Show("THANH TOÁN đơn hàng thành công! Vui lòng chờ in hóa đơn!");

                        //cap nhat rank mon an
                        string lenhrank = "select ctdh.maMA from ChiTietDonHang ctdh, DonHang dh where ctdh.maDonHang=dh.maDH and SDT='" + curSDT + "'";
                        var tablerank = new DataTable();
                        tablerank = sql.getDataTable(lenhrank);
                        foreach(DataRow rowrank in tablerank.Rows)
                        {
                            int rankMA = Convert.ToInt32(rowrank[0].ToString());
                            string rank = "update MonAn set dem=dem+1 where maMA=" + rankMA;
                            sql.ExecuteNonQuery(rank);
                        }
                        this.Close();
                    }
                    else
                        MessageBox.Show("Không thể thanh toán đơn hàng này!");
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn đơn hàng cần thanh toán!");
            }

            
        }
    }
}
