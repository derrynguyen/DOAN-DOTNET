using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANCAFFE.CaffeDAO
{
    public class CustommerDAO
    {
        private static CustommerDAO instance;

        public static CustommerDAO Instance
        {
            get
            {
                if (instance == null) instance = new CustommerDAO();
                return CustommerDAO.instance;
            }

            private set => instance = value;
        }

        private CustommerDAO() { }

        public int addNew(string pName, string pPhone, int pPoint = 0)
        {
            string query = "AddNewCus @pName , @pPhone , @pPoint";
            int result;
            result = DataProvider.Instance.ExecutedNonQuery(query, new object[] { pName, pPhone, pPoint });
            return result;
        }
    }
}
