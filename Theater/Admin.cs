using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Theater
{
    public partial class Admin : Form
    {
        public UserData userData;

        public Admin(UserData userData)
        {
            InitializeComponent();
            this.userData = userData;
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
