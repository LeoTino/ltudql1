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
    public partial class Form8 : Form
    {
        int selectedMA = 0;
        public static DataTable giohang = new DataTable();
        GetDataFromSQL sql = new GetDataFromSQL();
        public static int sl = 0;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadFlowPanel2();
            LoadFlowPanel1();
            giohang.Columns.Add("monan");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new gioiThieu();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();            
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        void LoadFlowPanel2()
        {
            var dt = new DataTable();
            dt = sql.getDataTable("select top(8) tenMA,maMA from MonAn order by dem desc");
            foreach (DataRow row in dt.Rows)
            {
                Button btTop = new Button();
                btTop.Parent = flowLayoutPanel2;
                btTop.Text = row[0].ToString();
                btTop.ForeColor = Color.MediumBlue;
                btTop.BackColor = Color.SeaShell;
                btTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btTop.Size = new Size(386, 55);
                btTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btTop.Click += BtTop_Click;
                btTop.Name = row[1].ToString();
            }
        }

        private void BtTop_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            selectedMA = Convert.ToInt32(bt.Name);
            DialogResult result = MessageBox.Show("Bạn có muốn thêm vào giỏ hàng?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataRow row = giohang.NewRow();
                row["monan"] = selectedMA;
                giohang.Rows.Add(row);
                MessageBox.Show("Đã thêm vào giỏ hàng");
                sl++;
                LoadCart();
            }
            else
                MessageBox.Show("Không thể thêm vào giỏ hàng!");
        }

       void LoadCart()
        {
            button1.Text = "Giỏ hàng (" + sl + ")";
        }

        void LoadFlowPanel1()
        {
            var dt = new DataTable();
            dt = sql.getDataTable("select tenMA, donGia, maMA from MonAn");
            foreach(DataRow row in dt.Rows)
            {
                Button btMon = new Button();
                btMon.Parent = flowLayoutPanel1;
                btMon.Text = row[0].ToString() + "\r\nGiá: "+row[1].ToString();
                btMon.ForeColor = Color.DarkGreen;
                btMon.BackColor = Color.SeaShell;
                btMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btMon.Size = new Size(320, 100);
                btMon.Click += BtMon_Click;
                btMon.Name = row[2].ToString();
            }
        }

        private void BtMon_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            selectedMA = Convert.ToInt32(bt.Name);
            DialogResult result = MessageBox.Show("Bạn có muốn thêm vào giỏ hàng?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataRow row = giohang.NewRow();
                row["monan"] = selectedMA;
                giohang.Rows.Add(row);
                MessageBox.Show("Đã thêm vào giỏ hàng");
                sl++;
                LoadCart();
            }
            else
                MessageBox.Show("Không thể thêm vào giỏ hàng!");
        }

        void LoadTruyCap()
        {
            int sl = 0;
            string lenh = "select dem from SoLuotTruyCap";
            var table = new DataTable();
            table = sql.getDataTable(lenh);
            foreach(DataRow row in table.Rows)
            {
                sl = Convert.ToInt32(row[0].ToString());
            }
            label2.Text = "Số lượt truy cập: " + sl;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadCart();
            LoadTruyCap();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var dt = new DataTable();
            string search = "select tenMA, donGia, maMA from MonAn where tenMA like '%" + textBox1.Text + "%'";
            dt = sql.getDataTable(search);
            foreach (DataRow row in dt.Rows)
            {
                Button btMon = new Button();
                btMon.Parent = flowLayoutPanel1;
                btMon.Text = row[0].ToString() + "\r\nGiá: " + row[1].ToString();
                btMon.ForeColor = Color.DarkGreen;
                btMon.BackColor = Color.SeaShell;
                btMon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btMon.Size = new Size(320, 100);
                btMon.Click += BtMon_Click;
                btMon.Name = row[2].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1_TextChanged(sender, e);
        }
    }
}
