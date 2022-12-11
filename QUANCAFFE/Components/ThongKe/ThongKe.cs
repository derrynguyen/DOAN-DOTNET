using MyCoffee.MyCoffeeDAO;
using MyCoffee.Same;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANCAFFE.Components.ThongKe
{
    public partial class ThongKe : UserControl
    {
        public ThongKe()
        {
            InitializeComponent();
            Load += ThongKe_Load;
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            BindingSource BindingSourceLine = new BindingSource();

            loadThongKe();
            loadThongKeSP();
            ThongKeDanhThu.Show();
            loadThongKeLuong();
            ThongKeBangLuong.Hide();
            XepLineNhanVien.Hide();
            gridviewEmpLine.DataSource = BindingSourceLine;

        }

        public void loadThongKeLuong()
        {
            int pMonth = 12;
            dataGridViewThongKeLuong.DataSource = SalaryDAO.Instance.getThongKeLuong(pMonth);
        }
        private void btnQuayLai_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void loadThongKe()
        {
            string query = "select * from getDoanhThu()";
            DataTable dataTable = DataProvider.Instance.ExecutedQuery(query);
            dataGridViewDoanhThu.DataSource = dataTable;
        }
        public void loadThongKeSP()
        {
            string query = "select * from getSPBanChay()";
            DataTable dataTable = DataProvider.Instance.ExecutedQuery(query);
            GridViewSPBanChay.DataSource = dataTable;
        }
        public void loadEmp(DateTime dateTime)
        {
            gridviewEmpLine.ReadOnly = true;
            string query = "select IdEmp as 'Mã', EmpName as 'Tên', Position as 'Vị Trí', NameLine as 'Line', TimeBegin as 'Bắt Đầu', TimeEnd as 'Kết Thúc' from getListLineToDay( @daytime )";
            BindingSourceLine.DataSource = DataProvider.Instance.ExecutedQuery(query, new object[] { dateTime });
            loadComboBoxEmp();

        }
        public void BingDingLine()
        {
            txtNameEmpLine.DataBindings.Add(new Binding("Text", gridviewEmpLine.DataSource, "Tên", true, DataSourceUpdateMode.Never));
            txtTimeBegin.DataBindings.Add(new Binding("Text", gridviewEmpLine.DataSource, "Bắt đầu", true, DataSourceUpdateMode.Never));
            txtTimeEnd.DataBindings.Add(new Binding("Text", gridviewEmpLine.DataSource, "Kết Thúc", true, DataSourceUpdateMode.Never));
            cbNameLine.DataBindings.Add(new Binding("Text", gridviewEmpLine.DataSource, "Line", true, DataSourceUpdateMode.Never));
        }
        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            ThongKeDanhThu.Show();
            ThongKeBangLuong.Hide();
            XepLineNhanVien.Hide();
        }

        private void btnBangLuong_Click(object sender, EventArgs e)
        {
            ThongKeDanhThu.Hide();
            ThongKeBangLuong.Show();
            XepLineNhanVien.Hide();
        }

        private void btnXepLine_Click(object sender, EventArgs e)
        {
            ThongKeDanhThu.Hide();
            ThongKeBangLuong.Hide();
            XepLineNhanVien.Show();
        }
    }
}
