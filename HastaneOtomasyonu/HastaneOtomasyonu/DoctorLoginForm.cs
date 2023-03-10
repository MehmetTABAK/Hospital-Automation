using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace HastaneOtomasyonu
{
    public partial class DoctorLoginForm : Form
    {
        public DoctorLoginForm()
        {
            InitializeComponent();
        }

        private void giris_Click(object sender, EventArgs e)
        {
            try
            {
                if (docName.Text == "" || docPass.Text == "") //İf içinde belirtilen özellikler doğru ise
                {
                    MessageBox.Show("Lütfen bilgilerin tam olarak girildiğine emin olunuz!");
                }
                else
                {
                    SqlDataAdapter adp = new SqlDataAdapter("select Count(*) from Doktor where doktor_ismi='" + docName.Text + "' and doktor_şifre='" + docPass.Text + "'", Conn.Con);  //veritabanındaki ulaşmak istediğimiz tablo ve o tablonun içeriğine erişmemizi sağlar.adp ile de verileri almak için kullanılır.

                    DataTable dt = new DataTable(); //yeni bir datatable nesnesi oluşturur.

                    adp.Fill(dt); //veri kaynağındakilerle DataSet eşleşecek şekilde içindeki satırları ekler veya yeniler.

                    if (dt.Rows[0][0].ToString() == "1") //veritabanında kayıtlı olan bilgiler doğru ise doktorhomeforma git.
                    {
                        DoctorHomeForm dhf = new DoctorHomeForm();
                        dhf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Adınızı ya da şifrenizi hatalı girdiniz!");
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata meydana geldi" + hata.Message);
            }
        }

        private void cikis_Click(object sender, EventArgs e) //giriş yöntemi seçme formuna gönderir.
        {
            LoginForm log = new LoginForm();
            log.Show();
            this.Hide();
        }

        private void kapat_Click(object sender, EventArgs e) //uygulamayı kapat
        {
            Application.Exit();
        }
    }
}
