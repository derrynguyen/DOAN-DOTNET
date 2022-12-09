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

namespace QUANCAFFE.Components.NhanVien
{
    public partial class NhanVien : UserControl
    {
        int maxLength = 11;
        DateTime dateTime = DateTime.Today;
        BindingSource BindingSourceEmp = new BindingSource();
        BindingSource BindingSourcePro = new BindingSource();
        BindingSource BindingSourceLine = new BindingSource();
        public NhanVien()
        {
            InitializeComponent();
            loadEmpList();
            dataNhanVien.DataSource = BindingSourceEmp;

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private bool Validation()
        {
            if (txtSDT.Text.Length != 11)
            {
                MessageBox.Show("Số điện thoại phải có 11 kí tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }
            return true;
        }
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            string pName = txtHoVaten.Text;
            string pPhone = txtSDT.Text;
            string pAdd = txtDiaChi.Text;
            DateTime pDay = txtNgaySinh.Value;
            string pPositon = comboboxRole.SelectedItem.ToString();
            string pGender = comboboxSex.SelectedItem.ToString();
            string pUserName = txtTaiKhoan.Text;
            string pPassword = txtMatKhau.Text;
            if (!Validation())
            {
                if (EmployeesDAO.Instance.newEmployee(pName, pDay, pAdd, pPositon, pPhone, pGender) == 1)
                {
                    MessageBox.Show("Susses!!\n" + pName + "\n" + pPhone + "\n" + pAdd + "\n" + pPositon + "\n" + pGender + "\n" + pPhone);
                }

                int pId = EmployeesDAO.Instance.getIdEmp(pName);


                int Permission = 0;
                if (comboboxRole.SelectedItem.ToString() == "Manager")
                {
                    Permission = 1;
                }

                if (Account.Instance.newAccount(pId, pUserName, pPassword, Permission) == 1)
                {
                    MessageBox.Show("Tạo tài khoản thành công ");
                }
                else
                {
                    MessageBox.Show("Tạo tài khoản thất bại");
                }
            }
        }

        public void loadEmpList()
        {
            string query = "select *  from Employees";

            BindingSourceEmp.DataSource = DataProvider.Instance.ExecutedQuery(query);
        }
    }
}
