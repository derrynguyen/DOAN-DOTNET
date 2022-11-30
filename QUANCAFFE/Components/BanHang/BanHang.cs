using QUANCAFFE.CaffeDAO;
using QUANCAFFE.CaffeDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANCAFFE.Components.BanHang
{
    public partial class BanHang : UserControl
    {

        public BanHang()
        {
            InitializeComponent();
            getData();
        }

        public static string textNameProduct;
        public static string textPrice;
        public static string itemStatus;


        private void btnQuayLaiBanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public  void getData()
        {    
            flowLayoutPanel1.Controls.Clear();

            List<Product> products = ProductDAO.Instance.LoadProductList();

            foreach (Product product in products)
            {
                if (product.Status == "Còn Hàng")
                {
                    Item item = new Item();
                    textPrice = product.Price.ToString();
                    textNameProduct = product.Name.ToString();
                    itemStatus = product.Status.ToString();
                    //textNameProduct = data["ProductName"].ToString();
                    flowLayoutPanel1.Controls.Add(item);
                }
                else
                {
                    Button button = new Button() { Width = Product.ProductWith, Height = Product.ProductHeight, BackColor = Color.Gray };
                    flowLayoutPanel1.Controls.Add(button);
                    button.Text = product.Name;
                    button.Enabled = true;
                }

            }

        }

        private void textSearch_TextChange(object sender, EventArgs e)
        {
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
          


        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.Show();
        }
    }
}
