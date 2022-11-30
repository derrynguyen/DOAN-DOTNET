using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANCAFFE.CaffeDAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return AccountDAO.instance;
            }
            private set
            {
                instance = value;
            }
        }

        private AccountDAO() { }


        public bool LogIn(string username, string password)
        {
            string query = "proLogIn @username , @password";
            DataTable r = DataProvider.Instance.ExecutedQuery(query, new object[] { username, password });
            return r.Rows.Count > 0;
        }

        public int getIDStaff(string username)
        {
            string query = "getIDStaff @username";
            int reuslt = (int)DataProvider.Instance.ExecutedScalar(query, new object[] { username });
            return reuslt;
        }

        public int getIDCus(string pName)
        {
            string query = "getCusID @cusName";
            int reuslt = (int)DataProvider.Instance.ExecutedScalar(query, new object[] { pName });
            return reuslt;
        }
    }
}
