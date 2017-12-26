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
    public partial class chebien : Form
    {
        public chebien()
        {
            InitializeComponent();
        }

        private void chebien_Load(object sender, EventArgs e)
        {
            var sql = new GetDataFromSQL();
            DataTable dh = new DataTable();
            string lenh = "select tenBA, dh.maBA, maDH, dh.thoiGian from DonHang dh, BanAn ba where (maTTDH=2 or maTTDH=3) and dh.maCN='" + Form1.maCN + "' and dh.maBA=ba.maBA";
            DataTable dh2 = new DataTable();
            dh2 = sql.getDataTable(lenh);
            foreach (DataRow row in dh2.Rows)
            {
                Button open = new Button();
                open.Parent = flowLayoutPanel1;
                open.Size = new Size(350, 150);
                open.Text = "Bàn: " + row[0].ToString() + "\r\nThời gian: " + row[3].ToString();
                open.Font = new System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                open.ForeColor = Color.DodgerBlue;
                open.BackColor = Color.Navy;
                open.Click += open_Click;
                open.LostFocus += open_LostFocus;
                open.Name = row[1].ToString();
                open.AccessibleName = row[2].ToString();
            }

            string lenh2 = "select kh.ten, dh.maBA, maDH, dh.SDT from DonHang dh, KhachHang kh where (maTTDH=2 or maTTDH=3) and dh.maCN='" + Form1.maCN + "' and dh.SDT=kh.SDT";
            dh = sql.getDataTable(lenh2);
            foreach (DataRow row in dh.Rows)
            {
                Button open = new Button();
                open.Parent = flowLayoutPanel1;
                open.Size = new Size(350, 150);
                open.Text = "Khách hàng: " + row[0].ToString() + "\r\nSDT: " + row[3].ToString();
                open.Font = new System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                open.ForeColor = Color.DodgerBlue;
                open.BackColor = Color.Navy;
                open.Click += open_Click;
                open.LostFocus += open_LostFocus;
                open.Name = row[1].ToString();
                open.AccessibleName = row[2].ToString();
            }
        }

        private void open_LostFocus(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.Navy;
            bt.Refresh();
        }

        private void open_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = Color.Aquamarine;
            DialogResult result = MessageBox.Show("Bạn có muốn THANH TOÁN đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                string lenh = "update DonHang set maTTDH=4 where maDH='" + bt.AccessibleName + "'";
                if (sql.ExecuteNonQuery(lenh) > 0)
                {
                    string lenh2 = "update BanAn set tinhTrang=0 where maCN=" + Form1.maCN + "and maBA='" + bt.Name+"'";
                    sql.ExecuteNonQuery(lenh2);
                    MessageBox.Show("Đã THANH TOÁN thành công");

                    //cap nhat rank mon an
                    string lenhrank = "select ctdh.maMA from ChiTietDonHang ctdh, DonHang dh where ctdh.maDonHang=dh.maDH and maDH='" + bt.AccessibleName + "'";
                    var tablerank = new DataTable();
                    tablerank = sql.getDataTable(lenhrank);
                    foreach (DataRow rowrank in tablerank.Rows)
                    {
                        int rankMA = Convert.ToInt32(rowrank[0].ToString());
                        string rank = "update MonAn set dem=dem+1 where maMA=" + rankMA;
                        sql.ExecuteNonQuery(rank);
                    }

                    flowLayoutPanel1.Controls.Remove(bt);
                }
                else
                    MessageBox.Show("Không thể THANH TOÁN đơn hàng này");
            }
        }
    }
}
