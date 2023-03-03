using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace PROJECT
{
    public partial class HomePage : KryptonForm
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btn_getstart_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                LoginPage f1 = new LoginPage();
                f1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
