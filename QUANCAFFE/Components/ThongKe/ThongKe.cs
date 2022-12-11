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
            loadThongKe();
            loadThongKeSP();
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

    }
}
