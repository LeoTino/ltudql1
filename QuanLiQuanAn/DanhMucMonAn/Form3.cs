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
    public partial class Form3 : Form
    {
        
        private DataTable dtMA = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            LoadcbbDanhMuc();
            dtMA.Columns.Add("ten");
            dtMA.Columns.Add("ghichu");
            dataGridView2.DataSource = dtMA;
            //Load du lieu vao data table
            /*var sql = new GetDataFromSQL();
            dt = sql.getDataTable("select dm.tenDM, ma.tenMA from DanhMucMonAn dm, MonAn ma where dm.maDM=ma.danhMuc");
            dataGridView2.DataSource = dt;*/
        }

        void LoadcbbDanhMuc()
        {
            var dtDM = new DataTable();
            var sql = new GetDataFromSQL();
            dtDM = sql.getDataTable("select tenDM from DanhMucMonAn");
            foreach (DataRow row in dtDM.Rows)
            {
                cb_DM.Items.Add(row["tenDM"]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DataRow row = dtMA.NewRow();
            row["ten"] = cb_TenMA.Text;
            row["ghichu"] = tb_ghiChu.Text;
            dtMA.Rows.Add(row);
        }

        void LoadcbbMonAn(string danhmuc)
        {
            cb_TenMA.Items.Clear();
            var dtMA = new DataTable();
            var sql =new GetDataFromSQL();
            int s = sql.timMaDanhMuc(danhmuc);
            string query = "select distinct tenMA from MonAn ma, DanhMucMonAn dm where ma.danhMuc=" + s;
            dtMA = sql.getDataTable(query);
            foreach (DataRow row in dtMA.Rows)
            {
                cb_TenMA.Items.Add(row["tenMA"]);
            }
        }

        private void cb_DM_TextChanged(object sender, EventArgs e)
        {
            LoadcbbMonAn(cb_DM.Text);
        }

        //xoa mon trong list
        private void button1_Click(object sender, EventArgs e)
        {
            int currentIndex = dataGridView2.CurrentRow.Index;
            dataGridView2.Rows.RemoveAt(currentIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cn = new ChiNhanh();
            cn.DienThoai = textBox5.Text;
            cn.TinhThanh = textBox3.Text;
            cn.DiaChi = textBox7.Text;
            cn.TenCN = textBox8.Text;
            var sql = new GetDataFromSQL();
            bool temp=sql.themChiNhanh(cn);
            cn.MaCN = sql.timMaChiNhanh(cn.TenCN);
            bool test = false;
            foreach(DataGridViewRow row in dataGridView2.Rows)
            {
                var menu = new MenuChiNhanh();
                menu.MaMA = sql.timMaMonAn(Convert.ToString(row.Cells["ten"].Value));
                menu.GhiChu =Convert.ToString(row.Cells["ghichu"].Value);
                menu.MaCN = cn.MaCN;
                if (sql.themMenuChiNhanh(menu))
                    test = true;
                else
                    return;
            }
            if(temp==true && test==true)
            {
                MessageBox.Show("Thêm chi nhánh thành công!");
            }
            else
            {
                MessageBox.Show("Không thêm được chi nhánh!");
            }
            this.Close();
            
        }
    }
}
