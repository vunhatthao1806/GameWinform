using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace BTL
{
    public partial class frmMain : Form
    {
        //  Các thuộc tính cơ bản của trò bầu cua
        public static string tenDNhap;
        public static int gioitinh;
        private int tienNai = 0, tienBau = 0, tienCua = 0;
        private int tienCa = 0, tienTom = 0, tienGa = 0;
        private int tienMacDinh = 50000;
        private int tienGoc = 50000;
        private int tienMay = 50000;
        private int phatLoa = 0;
        //   Các fd hình sử dụng trong bài tập
        private String path = @"hinhBauCua\";
        private String path1 = @"avatar\";
        //   Thuộc tính dùng để chạy hình bầu cua
        private int intervalTime = 300;
        private int sumtime = 0;
        private int n1, n2, n3;   
        public frmMain(string username, int gender, int loa)
        {
            //   Cách truyền tên và giới tính từ form đăng nhập sang form chính (tạo contruster 2 tham số)
            tenDNhap = username;
            gioitinh = gender;
            phatLoa = loa;

            InitializeComponent();
        }
        private void init()
        {
         
           if(phatLoa%2 ==1)
           {
                axWindowsMediaPlayerNhacNen.URL = "";
           }    
           else
           {
                axWindowsMediaPlayerNhacNen.Ctlcontrols.play();
           }
            // Xử lý nhạc nền chạy liên tục
            axWindowsMediaPlayerNhacNen.settings.setMode("loop", true);

            lbTienDatBau.Text = tienBau.ToString();
            lbTienDatCa.Text = tienCa.ToString();
            lbTienDatCua.Text = tienCua.ToString();
            lbTienDatGa.Text = tienGa.ToString();
            lbTienDatNai.Text = tienNai.ToString();
            lbTienDatTom.Text = tienTom.ToString();

            lbTienPlayer.Text = tenDNhap + ": " + tienMacDinh.ToString();
            lbTienMay.Text = "Nhà cái: " + tienMacDinh.ToString();
            labelBienDong.Text = "Tiền biến động: ";
            ptXucSac1.Image = ptXucSac2.Image = ptXucSac3.Image = Image.FromFile(path1 + "3.PNG");
            ptAvatarPlayer.Image = Image.FromFile(path1 + gioitinh + ".JPG");
        }

        // Hàm chạy khi form chạy
        private void frmMain_Load(object sender, EventArgs e)
        {           
            init();
        }

        //Xử lý sự kiện nhấn nút đặt
        private void btnDatNai_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btnDatNai":
                    {
                        tienNai += 100;
                        lbTienDatNai.Text = tienNai.ToString();
                        break;
                    }
                case "btnDatBau":
                    {
                        tienBau += 100;
                        lbTienDatBau.Text = tienBau.ToString();
                        break;
                    }
                case "btnDatGa":
                    {
                        tienGa += 100;
                        lbTienDatGa.Text = tienGa.ToString();
                        break;
                    }
                case "btnDatCua":
                    {
                        tienCua += 100;
                        lbTienDatCua.Text = tienCua.ToString();
                        break;
                    }
                case "btnDatCa":
                    {
                        tienCa += 100;
                        lbTienDatCa.Text = tienCa.ToString();
                        break;
                    }
                case "btnDatTom":
                    {
                        tienTom += 100;
                        lbTienDatTom.Text = tienTom.ToString();
                        break;
                    }
            }
        }

        //  Hàm quay ba xúc sắc
        private void btnQuay_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem người chơi đã đặt cửa chưa
            if (tienBau == 0 && tienCa == 0 && tienCua == 0 && tienGa == 0 && tienNai == 0 && tienTom == 0)
            {
                MessageBox.Show("Bạn chưa đặt cửa!!", "Cảnh báo",
                    MessageBoxButtons.OK);
            }
            else
            {
                //Mỗi lần bấm nút quay tổng thời gian đã quay sẽ trở lại là 0
                sumtime = 0;              
                timer1.Start();
                //axWindowsMediaPlayer1.URL = @"nhacNen\nhacNenBauCua.mp3"; 
                //axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }



        // Xự kiện timer
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            Random rand = new Random();
            //Kiểm tra xem thời gian đã chạy được 3s chưa
            //Nếu chưa cứ chạy hình liên tục
            if (sumtime < 3000)
            {
                  n1 = rand.Next(1, 7);
                ptXucSac1.Image = Image.FromFile(path + n1 + ".PNG");
              
                n2 = rand.Next(1, 7);
                ptXucSac2.Image = Image.FromFile(path + n2 + ".PNG");
               
                n3 = rand.Next(1, 7);
                ptXucSac3.Image = Image.FromFile(path + n3 + ".PNG");

                sumtime += intervalTime;
            }
            //Nếu chạy 3s rồi thì dừng
            else
            {
                timer1.Stop();
                //axWindowsMediaPlayer1.URL = @"nhacNen\AmRungChuong.mp3";
                int bienDong = 0;
                int tien = tienGoc;
                int[] a = { tienBau, tienCa, tienCua, tienGa, tienNai, tienTom };
                for (int i = 0; i <= a.Length - 1; i++)
                {
                    if (a[i] > 0)
                    {
                        if (i + 1 == n1)
                        {
                            tienGoc += a[i];
                        }
                        if (i + 1 == n2)
                        {
                            tienGoc += a[i];
                        }
                        if (i + 1 == n3)
                        {
                            tienGoc += a[i];
                        }
                        if (i + 1 != n1 && i + 1 != n2 && i + 1 != n3)
                        {
                            tienGoc -= a[i];
                        }
                    }
                }
                // Hiện tiền sau khi chơi 1 ván
                lbTienPlayer.Text = tenDNhap + ": " + tienGoc.ToString();

                //Kiểm tra chơi thắng hay thua
                bienDong = tienGoc - tien;
               
                if (bienDong >=0)
                {
                    tienMay -= bienDong;
                    labelBienDong.Text = "Tiền biến động: +" + bienDong.ToString() + "(nghìn đồng)";
                    lbTienMay.Text = "Nhà cái: " + tienMay.ToString();
                }
                else
                {
                    labelBienDong.Text = "Tiền biến động: " + bienDong.ToString() + "(nghìn đồng)";
                    // Trừ cho trừ tiền biến động
                    tienMay -= bienDong;
                    lbTienMay.Text = "Nhà cái: " + tienMay.ToString();
                } 
            }

        }

        // Hàm mô tả cách chơi khi click vào icon question
        private void picMoTa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Người chơi đặt cược vào các linh vật, quay 3 xúc sắc." +
                " Nếu xúc sắc xuất hiện linh vật mà người chơi đã chọn, người chơi sẽ thắng" +
                " được số tiền người chơi đã đặt vào linh vật đó!!!", 
                "Mô tả cách chơi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        
        // Hàm bỏ đặt
        private void btnBoNai_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            tienNai = tienBau = tienCua = 0;
            tienCa = tienTom = tienGa = 0;
            switch (b.Name)
            {
                case "btnBoNai":
                    lbTienDatNai.Text = tienNai.ToString();
                    break;
                case "btnBoBau":
                    lbTienDatBau.Text = tienBau.ToString();
                    break;
                case "btnBoCa":
                    lbTienDatCa.Text = tienCa.ToString();
                    break;
                case "btnBoCua":
                    lbTienDatCua.Text = tienCua.ToString();
                    break;
                case "btnBoGa":
                    lbTienDatGa.Text = tienGa.ToString();
                    break;
                case "btnBoTom":
                    lbTienDatTom.Text = tienTom.ToString();
                    break;

            }
        }
        
        // Hàm chơi lại
        private void btnThoat_Click(object sender, EventArgs e)
        {
            btnBoNai_Click(sender, e);
            init();
        }

        // Xử lý sự kiện đóng form được sở hữu thì form chủ sở hữu cũng được đóng (main đóng thì đăng nhập đóng)
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
               DialogResult dl =  MessageBox.Show("Bạn có chắc chắn đóng", "Đóng", MessageBoxButtons.YesNo);
                if (dl == DialogResult.Yes)
                {
                    this.Owner.Close();
                }
                else
                    e.Cancel = true;
              
            }
               
        }
    }
}
