using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANCAFFE.Components.BanHang
{
    public partial class Item : UserControl
    {
       
        public Item()
        {
            InitializeComponent();
            loadData();
        }
    

        public void loadData()
        {
            itemName.Text = BanHang.textNameProduct;
            itemStatus.Text = BanHang.itemStatus;

            priceItem.Text = BanHang.textPrice + "VNĐ";

        }
    }
}
