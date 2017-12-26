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
    public partial class Form10 : Form
    {
        GetDataFromSQL sql = new GetDataFromSQL();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
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
                bt.Click += Bt_Click; ;
            }


        }

        private void Bt_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Refresh();
            Button selectedBT = (Button)sender;
            var sql = new GetDataFromSQL();
            var monan = new DataTable();
            string lenh = "select distinct tenMA,maMA from DanhMucMonAn dm, MonAn ma where dm.maDM=ma.danhMuc and dm.tenDM=N'" + selectedBT.Text + "'";
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

        private void BtMon_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            DialogResult result = MessageBox.Show("Bạn có muốn thêm vào giỏ hàng?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataRow row = Form8.giohang.NewRow();
                row["monan"] = bt.Name;
                Form8.giohang.Rows.Add(row);
                MessageBox.Show("Đã thêm vào giỏ hàng");
                Form8.sl++;
            }
            else
                MessageBox.Show("Không thể thêm vào giỏ hàng!");
        }
    }
}
