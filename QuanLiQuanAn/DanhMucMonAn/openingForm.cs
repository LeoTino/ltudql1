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
    public partial class openingForm : Form
    {
        public openingForm()
        {
            InitializeComponent();
        }

        private void openingForm_Load(object sender, EventArgs e)
        {
            var sql = new GetDataFromSQL();
            DataTable dh = new DataTable();
            string lenh = "select tenBA, dh.maBA, maDH, dh.thoiGian from DonHang dh, BanAn ba where maTTDH=1 and dh.maCN='"+Form1.maCN+"' and dh.maBA=ba.maBA";
            dh = sql.getDataTable(lenh);
            foreach (DataRow row in dh.Rows)
            {
                Button open = new Button();
                open.Parent = flowLayoutPanel1;
                open.Size = new Size(250, 150);
                open.Text = "Bàn " + row[0].ToString()+"\r\n" + row[3].ToString() ;
                open.Font = new System.Drawing.Font("Microsoft Sans Serif", 20, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            DialogResult result = MessageBox.Show("Bạn có muốn HỦY đơn hàng này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var sql = new GetDataFromSQL();
                string lenh = "update DonHang set maTTDH=5 where maDH='" + bt.AccessibleName + "'";
                if (sql.ExecuteNonQuery(lenh) > 0)
                {
                    string lenh2 = "update BanAn set tinhTrang=0 where maCN=" + Form1.maCN + "and maBA=" + bt.Name;
                    sql.ExecuteNonQuery(lenh2);
                    MessageBox.Show("Đã hủy thành công");
                    flowLayoutPanel1.Controls.Remove(bt);
                }
                else
                    MessageBox.Show("Không thể hủy đơn hàng này");
            }
        }
    }
}




