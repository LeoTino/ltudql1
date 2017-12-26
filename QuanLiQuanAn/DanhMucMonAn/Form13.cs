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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                string j = "đd/mm/yyyy";
                int k = 2;
                Label lb = new Label();
                lb.Parent = flowLayoutPanel1;
                lb.Text = "Đơn hàng "+i +"\r\nNgày: " + j +"\r\nThành tiền: "+ i*k*1024/18 +"VND";
                lb.ForeColor = Color.DarkGreen;
                lb.BackColor = Color.OldLace;
                lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lb.Size = new Size(250, 70);
            }
        }
    }
}
