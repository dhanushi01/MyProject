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
    public partial class Profile : KryptonForm
    {
        public Profile()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;

        private void Profile_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=LAPTOP-V8QJM6HE;Initial Catalog=Itcoursebay01;Integrated Security=True");
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Dashboard f1 = new Dashboard();
                f1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_updateprofile_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                UpdateProfile f1 = new UpdateProfile();
                f1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_viewprofile_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txt_stidnum.Text))
                    MessageBox.Show("Please Enter Your Student ID Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    con.Open();
                    da = new SqlDataAdapter("Select * from Student where StudentID = '" + txt_stidnum.Text + "' ", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    kryptonDataGridView1.DataSource = dt;
                    con.Close();
                }
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
    }
}
