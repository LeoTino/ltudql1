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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string lenh = "insert into DangKyTheoDoi(email,thoiGian) values ('" + textBox1.Text + "','" + DateTime.Now.ToString() + "')";
                var sql = new GetDataFromSQL();
                if (sql.ExecuteNonQuery(lenh) > 0)
                    MessageBox.Show("Cảm ơn bạn đã đăng ký theo dõi quán ăn!");
            }
            this.Close();
        }
    }
}
