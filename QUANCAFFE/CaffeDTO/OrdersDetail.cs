using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANCAFFE.CaffeDTO
{
    public class OrderDetail
    {

        int productID;
        int quantity;


        public int ProductID { get => productID; set => productID = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public OrderDetail(int productId, int quantity)
        {
            this.productID = productId;
            this.Quantity = quantity;
        }


    }
}
