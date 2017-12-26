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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            string lenh = "select tenCN,diaChi,dienThoai from ChiNhanh";
            var dt = new DataTable();
            var sql = new GetDataFromSQL();
            dt = sql.getDataTable(lenh);
            foreach (DataRow row in dt.Rows)
            {
                Button lb = new Button();
                lb.Parent = flowLayoutPanel1;
                lb.Text = "Chi nhánh "+row[0].ToString()  + "\r\nĐịa chỉ: "+row[1].ToString()+"\r\nĐiện thoại " + row[2].ToString();
                lb.ForeColor = Color.DarkGreen;
                lb.BackColor = Color.AliceBlue;
                lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.Size = new Size(400, 150);
            }
        }
    }
}
