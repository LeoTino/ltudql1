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
    public partial class themBan : Form
    {
        int slBan = 0;
        int dem = 1;
        public themBan()
        {
            InitializeComponent();
        }

        private void themBan_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
        }

        void LoadLabel()
        {
            dem++;
            string s = "Ban " + dem + "/" + slBan;
            label12.Text = s;
            if(dem==(slBan+1))
            {
                string z = "Đã thêm thành công " + slBan + " bàn vào chi nhánh";
                MessageBox.Show(z);
                //var form2 = new Form2();
                int maCN = Form2.masoCN;
                string sqlupdatetable = "update ChiNhanh set soLuongBan='" + slBan + "' where maCN= " + maCN;
                var sql = new GetDataFromSQL();
                sql.ExecuteNonQuery(sqlupdatetable);
                this.Close();
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            slBan = Convert.ToInt32(numericUpDown1.Value);
            label12.Text = "Ban " + dem + "/" + slBan;
            maskedTextBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            themBan_Load(sender, e);
            //code here
            string tenBan = textBox2.Text.ToString();
            int sucChua = Convert.ToInt32(maskedTextBox1.Text);
            string ghiChu = textBox4.Text.ToString();
            string sqladdtable = "insert into BanAn(maCN,tenBA,ghiChu,sucChua) values ('" + Form2.masoCN + "','" + tenBan + "','" + ghiChu + "','" + sucChua + "')";
            var sql = new GetDataFromSQL();
            int ra=sql.ExecuteNonQuery(sqladdtable);
            if (ra > 0)
                LoadLabel();
            else
                MessageBox.Show("Không thể thêm bàn này vào chi nhánh!!!");
            textBox2.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;

            
        }
    }
}
