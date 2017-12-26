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
    public partial class dangnhap : Form
    {
        public static string tenCN = "";
        private DataTable table = new DataTable();
        public dangnhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var sql = new GetDataFromSQL();
            string lenh = "select tenCN from ChiNhanh";
            table= sql.getDataTable(lenh);
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (DataRow row in table.Rows)
            {
                collection.Add(row[0].ToString());
            }
            textBox1.AutoCompleteCustomSource = collection;
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Xài tiếp đi, thoát mần chi. Ahihi");
            }
            else
            {
                MessageBox.Show("ahihi");
            }
           
        }

        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="admin")
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else if(textBox1.Text=="sale")
            {
                Form1 f1 = new Form1();
                f1.Show();
            }
            else if(textBox1.Text == "cc")
            {
                Form7 f = new Form7();
                f.Show();
            }
            else if (textBox1.Text == "kh")
            {
                var sql = new GetDataFromSQL();
                sql.ExecuteNonQuery("update SoLuotTruyCap set dem=dem+1");
                Form8 f = new Form8();
                f.Show();
            }
            else
            {
                MessageBox.Show("Nhập 'admin' để vào trang quản lý, nhập 'sale' để vào trang bán hàng. Nhập 'cc' để vào trang tổng đài, nhập 'kh' để vào trang đặt hàng trên ứng dụng. Không nhập khỏi vào");
            }
            foreach (DataRow row in table.Rows)
            {
                if(textBox1.Text==row[0].ToString())
                {
                    tenCN = textBox1.Text;
                    Form1 f1 = new Form1();
                    f1.Show();
                }
            }
        }
    }
}
