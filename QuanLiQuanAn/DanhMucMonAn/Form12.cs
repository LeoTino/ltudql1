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
    public partial class Form12 : Form
    {
        public static double tien = 0;
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
            foreach (DataRow row in Form8.giohang.Rows)
            {
                Button btMon = new Button();
                btMon.Parent = flowLayoutPanel1;
                string lenh = "select tenMA,donGia from MonAn where maMA=" + row["monan"];
                var sql = new GetDataFromSQL();
                var tbMon = new DataTable();
                tbMon = sql.getDataTable(lenh);
                foreach (DataRow rowtenMA in tbMon.Rows)
                {
                    btMon.Text = "Tên món: " + rowtenMA[0].ToString() + "\r\nGía: " + rowtenMA[1].ToString() + "VND";
                    tien = tien + Convert.ToDouble(rowtenMA[1]);
                }
                label1.Text = "Thành tiền: " + tien + "VND";
                btMon.ForeColor = Color.DarkGreen;
                btMon.BackColor = Color.OldLace;
                btMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btMon.Size = new Size(254, 70);
                btMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new thanhtoan();
            f.ShowDialog();
            this.Close();
        }
    }
}
