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
    public partial class opening : Form
    {
        public opening()
        {
            InitializeComponent();
        }

        private void opening_Load(object sender, EventArgs e)
        {
            var sql = new GetDataFromSQL();
            DataTable dh = new DataTable();
            string lenh = "select ten, dh.maBA, maDH from KhachHang kh, DonHang dh where dh.SDT=kh.SDT and maTTDH=1";
            dh = sql.getDataTable(lenh);
            foreach (DataRow row in dh.Rows)
            {
                Button open = new Button();
                open.Parent = flowLayoutPanel1;
                open.Size = new Size(365, 165);
                open.Text = row[0].ToString() + "\r\n" + row[1].ToString();
                open.Font = new System.Drawing.Font("Microsoft Sans Serif", 25, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                open.ForeColor = Color.DodgerBlue;
                open.BackColor = Color.Navy;
                open.Click += open_Click;
                open.LostFocus += open_LostFocus;
                open.Name = row[1].ToString();

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
            DialogResult result = MessageBox.Show("Bạn có muốn HỦY đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                string lenh = "update DonHang set maTTDH=5 where maDH='" + Form1.maDH + "'";
                if (sql.ExecuteNonQuery(lenh) > 0)
                {
                    string lenh2 = "update BanAn set tinhTrang=1 where maCN=" + Form1.maCN + " maBA='" + bt.Name + "'";
                    MessageBox.Show("Đã hủy thành công");
                }
                else
                    MessageBox.Show("Không thể hủy đơn hàng này");
            }
         }
    }
}
