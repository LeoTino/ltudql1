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
    public partial class chiPhi : Form
    {
        public chiPhi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sql = new GetDataFromSQL();
            string lenh = "insert into ChiPhiChiNhanh(tenCPCN,giaTienCPCN,loaiCPCN,maCN) values(N'" + comboBox2.Text + "','" + numericUpDown1.Value + "',N'" + comboBox1.Text + "','" + Form1.maCN + "')";
            if (sql.ExecuteNonQuery(lenh) > 0)
            {
                MessageBox.Show("Đã thêm thành công chi phí chi nhánh!");
                this.Close();
            }
            else
                MessageBox.Show("Không thể thêm chi phí chi nhánh!");
        }

        private void chiPhi_Load(object sender, EventArgs e)
        {

        }
    }
}
