using QUANCAFFE.CaffeDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANCAFFE.CaffeDAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;


        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return ProductDAO.instance;
            }
            set
            {
                instance = value;
            }
        }

        private ProductDAO() { }

        public List<Product> LoadProductList()
        {
            List<Product> products = new List<Product>();

            DataTable data = DataProvider.Instance.ExecutedQuery("GetProductList");

            foreach (DataRow item in data.Rows)
            { 
                Product product = new Product(item);
                products.Add(product);
            }

            return products;
        }
    }
}
