using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANCAFFE.CaffeDAO
{
    public class OrdersDAO
    {
        private static OrdersDAO instance;

        public static OrdersDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrdersDAO();
                return OrdersDAO.instance;
            }
            private set => instance = value;
        }

        public void saveOrders(int Emp, int Cus, int totail, int discount, string date)
        {
            string query = "SaveOrders  @CusID , @OrderDay , @totail , @discount , @EmpID";
            DataProvider.Instance.ExecutedNonQuery(query, new object[] { Cus, date, totail, discount, Emp });
        }
    }
}
