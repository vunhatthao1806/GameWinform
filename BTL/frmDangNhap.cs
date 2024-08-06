using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class frmDangNhap : Form
    {
        int loa = 0;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        // Kiểm tra người dùng chỉ được nhập tên đăng nhập là chữ cái
        private void txtTenUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là chữ cái không
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải chữ cái, hủy sự kiện KeyPress
                e.Handled = true;
            }
        }

        //   Xử lý sự kiện đăng nhập
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            //Kiểm tra tên đăng nhập và mật khẩu đã được nhập đầy đủ chưa
            if(txtTenUser.Text.Trim() == string.Empty || txtPass.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Phải nhập tên và mật khẩu!!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int gioiTinh = rdNam.Checked ? 1 : 2;
                string tenDNhap = txtTenUser.Text;

                frmMain main = new frmMain(tenDNhap, gioiTinh, loa);
                //  Thiết lập main được sở hữu bởi form hiện tại (tức là form )
                main.Owner = this;
                // Ẩn form đăng nhập
                this.Hide();
                // Hiện form main lên
                main.ShowDialog();
            }

        }

        //Sự kiện đóng form đăng nhập
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loa += 1;
            if(loa%2==1)
            {
                pictureBoxLoa.Image = Image.FromFile(@"avatar\khongLoa.png");
            }
            else
                pictureBoxLoa.Image = Image.FromFile(@"avatar\loa.png");
        }
    }
}
