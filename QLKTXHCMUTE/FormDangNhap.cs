using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKTXHCMUTE.DBLayer;

namespace QLKTXHCMUTE
{
    public partial class FormDangNhap : Form
    {
        MY_DB db;
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            db = new MY_DB();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
