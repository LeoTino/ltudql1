using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DanhMucMonAn
{
    public partial class Form1 : Form
    {
        public static int maCN = 0;
        public static int curTable = 0;
        private string tenCN = dangnhap.tenCN;
        public static int maDH = 0;
        public static string tenTable = "";
        DataTable dsBan = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Ban An
            //Trong:0
            //Co nguoi: 1
            flowLayoutPanel1.Controls.Clear();
            label1.Text = "Chi nhánh :" + dangnhap.tenCN;
            var sql = new GetDataFromSQL();
            string lenh = "select maBA, tenBA, ghiChu, sucChua, tinhTrang, cn.maCN from BanAn ba, ChiNhanh cn where cn.maCN=ba.maCN and cn.tenCN=N'" + tenCN+ "'";
            dsBan = sql.getDataTable(lenh);
            foreach (DataRow row in dsBan.Rows)
            {
                maCN = Convert.ToInt32(row[5].ToString());
            }


            foreach (DataRow row in dsBan.Rows)
            {
                Button bt = new Button() { Width = 120, Height = 120 };
                bt.Name = row[0].ToString();
                bt.Parent = flowLayoutPanel1;
                bt.Text = "Bàn " + row[1].ToString();
                bt.BackColor = Color.Lavender;
                bt.ForeColor = Color.Navy;
                bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 17, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = Path.Combine(projectPath, "Resources\\Icons8-Ios7-Household-Table.ico");
                bt.Image = Image.FromFile(filePath, true);
                bt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                bt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                bt.BackgroundImageLayout = ImageLayout.Center;
                bt.Click += Bt_Click;
            }
            LoadLabel();
            

            //hide taskbar and fullscreen
            FormState fm = new FormState();
            fm.Maximize(this);

        }

        public void LoadLabel()
        {
            DataTable table = new DataTable();
            string lenh3 = "select maTTDH from DonHang where maCN='" + maCN + "'";
            var sql = new GetDataFromSQL();
            table = sql.getDataTable(lenh3);
            int mangve = 0, tongdai = 0, empty = 0; ;
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row[0].ToString()) == 6)
                    mangve++;
                if (Convert.ToInt32(row[0].ToString()) == 7)
                    tongdai++;
            }

            button11.Text = "Mang về (" + mangve + ")";
            button12.Text = "Tổng đài (" + tongdai + ")";


            var table1 = new DataTable();
            string lenh = "select maBA, tenBA, ghiChu, sucChua, tinhTrang, cn.maCN from BanAn ba, ChiNhanh cn where tinhTrang=0 and cn.maCN=ba.maCN and cn.tenCN=N'" + tenCN + "'";
            table1 = sql.getDataTable(lenh);
            foreach (DataRow row in table1.Rows)
            {
                empty++;
            }
            button7.Text = "Còn trống (" + empty + ")";

            int open = 0;
            var table2 = new DataTable();
            string lenh2 = "select distinct ba.maBA, cn.maCN from BanAn ba, ChiNhanh cn, DonHang dh where dh.maCN=cn.maCN and dh.maTTDH=1 and tinhTrang=1 and cn.maCN=ba.maCN and ba.maBA=dh.maBA and cn.tenCN=N'" + tenCN + "'";
            table2 = sql.getDataTable(lenh2);
            foreach (DataRow row in table2.Rows)
            {
                open++;
            }
            button1.Text = "Bàn đang mở (" + open + ")";

            int chebien = 0;
            var table3 = new DataTable();
            string lenh4 = "select distinct ba.maBA, cn.maCN from BanAn ba, ChiNhanh cn, DonHang dh where dh.maCN=cn.maCN and (dh.maTTDH=2 or dh.maTTDH=3) and tinhTrang=1 and ba.maBA=dh.maBA and cn.maCN=ba.maCN and cn.tenCN=N'" + tenCN + "'";
            table3 = sql.getDataTable(lenh4);
            foreach (DataRow row in table3.Rows)
            {
                chebien++;
            }
            button2.Text = "Đang chế biến (" + chebien + ")";
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            curTable = Convert.ToInt32(bt.Name);

            var sql = new GetDataFromSQL();
            string lenh = "insert into DonHang(maTTDH, maCN, thoiGian, maBA) values (1,'" + maCN + "','" + DateTime.Now.ToString() + "'," + curTable + ")";
            sql.ExecuteNonQuery(lenh);

            var temp = new DataTable();
            string lenh2 = "select maDH from DonHang where maCN=" + maCN + " and maBA=" + curTable;
            temp = sql.getDataTable(lenh2);
            foreach(DataRow row in temp.Rows)
            {
                maDH = Convert.ToInt32(row[0].ToString());
            }

            string lenh3 = "update BanAn set tinhTrang=1 where maBA='" + curTable + "' and maCN="+maCN;
            sql.ExecuteNonQuery(lenh3);
            tenTable = bt.Text;
            Form4 f3 = new Form4();
            f3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Close();
            dangnhap dn = new dangnhap();
            dn.Activate();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoadLabel();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form6 f5 = new Form6();
            f5.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Giờ hiện tại: " + DateTime.Now.ToString();
            LoadLabel();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var table = new DataTable();
            string lenh = "select maBA, tenBA, ghiChu, sucChua, tinhTrang, cn.maCN from BanAn ba, ChiNhanh cn where tinhTrang=0 and cn.maCN=ba.maCN and cn.tenCN=N'" + tenCN + "'";
            var sql = new GetDataFromSQL();
            table = sql.getDataTable(lenh);
            foreach (DataRow row in table.Rows)
            {
                Button bt = new Button() { Width = 120, Height = 120 };
                bt.Name = row[0].ToString();
                bt.Parent = flowLayoutPanel1;
                bt.Text = "Bàn " + row[1].ToString();
                bt.BackColor = Color.Lavender;
                bt.ForeColor = Color.Navy;
                bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 17, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = Path.Combine(projectPath, "Resources\\Icons8-Ios7-Household-Table.ico");
                bt.Image = Image.FromFile(filePath, true);
                bt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                bt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                bt.BackgroundImageLayout = ImageLayout.Center;
                bt.Click += Bt_Click;
            }
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button7_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new openingForm();
            f.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new chebien();
            f.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new chiPhi();
            f.ShowDialog(this);
        }
    }
}
