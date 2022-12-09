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
        }

      
        private void btnQuayLai_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

      
     
    }
}
