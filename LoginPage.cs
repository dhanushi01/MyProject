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
using System.Data.SqlClient;

namespace PROJECT
{
    public partial class LoginPage : KryptonForm
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;

        private void LoginPage_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=LAPTOP-V8QJM6HE;Initial Catalog=Itcoursebay01;Integrated Security=True");
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
                this.Hide();
                HomePage f1 = new HomePage();
                f1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Registration f1 = new Registration();
                f1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                da = new SqlDataAdapter("Select Count (*) From Student where StudentID = '" + txt_username.Text + "' and StPassword = '" + txt_password.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Dashboard f1 = new Dashboard();
                    f1.Show();
                }

                else
                    MessageBox.Show("Invalid Login", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("SQL ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            try
            {
                    txt_username.Clear();
                    txt_password.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkbox_pass_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkbox_pass.Checked)
                    txt_password.PasswordChar = '\0';

                else
                    txt_password.PasswordChar = '*';
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
