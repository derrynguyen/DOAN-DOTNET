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
using System.Windows.Forms.DataVisualization.Charting;

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
            dataNhanVien.SelectionChanged += DataNhanVien_SelectionChanged;
            btnChinhSuaNhanVien.Click += BtnChinhSuaNhanVien_Click;

        }

        private void BtnChinhSuaNhanVien_Click(object sender, EventArgs e)
        {
            BingDingEmp();

           
        }
        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            int pId = int.Parse(Id.Text);
            string message = "Bạn chắc chắn muốn xóa";
            string title = "Xóa nhân viên";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Question;
            DialogResult result = MessageBox.Show(message, title, buttons, messageBoxIcon);
            if (result == DialogResult.Yes)
            {
                if (EmployeesDAO.Instance.idelEmp(pId))
                {
                    MessageBox.Show("Xóa thành công!");

                    loadEmpList();
                }
            }
            else
            {
                this.Hide();
            }
        }

        private void DataNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            btnXoaNhanVien.Enabled = true;
            btnChinhSuaNhanVien.Enabled = true;
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

        //Thêm nhân viên
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
            if (pName != string.Empty || pPhone != string.Empty || pAdd != string.Empty || pPositon != string.Empty || pGender != string.Empty || pUserName != string.Empty || pPassword != string.Empty)
            {
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
                        loadEmpList();
                    }
                    else
                    {
                        MessageBox.Show("Tạo tài khoản thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Không được để trống ô điền");
                }
            }
            
        }
        //Load Nhân viên
        public void loadEmpList()
        {
            string query = "select *  from Employees";

            BindingSourceEmp.DataSource = DataProvider.Instance.ExecutedQuery(query);
        }
        //Bindding Nhân viên
        private void BingDingEmp()
        {
            Id.DataBindings.Add(new Binding("Text", dataNhanVien.DataSource, "EmployeeID", true, DataSourceUpdateMode.Never));
            txtHoVaten.DataBindings.Add(new Binding("Text", dataNhanVien.DataSource, "FullName", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dataNhanVien.DataSource, "NumberPhone", true, DataSourceUpdateMode.Never));
            txtNgaySinh.DataBindings.Add(new Binding("Value", dataNhanVien.DataSource, "BirthOfDay", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dataNhanVien.DataSource, "Address", true, DataSourceUpdateMode.Never));
            comboboxSex.DataBindings.Add(new Binding("Text", dataNhanVien.DataSource, "Gender", true, DataSourceUpdateMode.Never));
            comboboxRole.DataBindings.Add(new Binding("Text", dataNhanVien.DataSource, "Position", true, DataSourceUpdateMode.Never));
        }
        private void BingDingEmpClear()
        {
            Id.DataBindings.Clear();  
            txtHoVaten.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtNgaySinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            comboboxSex.DataBindings.Clear();
            comboboxRole.DataBindings.Clear();
        }
        private void btnLuuNhanVien_Click(object sender, EventArgs e)
        {
            int pId = int.Parse(Id.Text);
            string pName = txtHoVaten.Text;
            DateTime pDay = txtNgaySinh.Value;
            string pAddr = txtDiaChi.Text;
            string pPhone = txtSDT.Text;
            string pPosition = comboboxRole.SelectedItem.ToString();
            string pGender = comboboxSex.SelectedItem.ToString();
            string message = "cập nhật thành công";
            string title = "Cập nhật";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon messageBoxIcon = MessageBoxIcon.Question;
            DialogResult result = MessageBox.Show(message, title, buttons, messageBoxIcon);

            if (EmployeesDAO.Instance.updateEmp(pId, pName, pDay, pAddr, pPosition, pPhone, pGender))
            {
                MessageBox.Show("Cập nhật thành công!");
                if (result == DialogResult.Yes)
                {
                    loadEmpList();
                }

            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            BingDingEmpClear();

        }
    }
}
