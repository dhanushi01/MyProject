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
    public partial class UpdateProfile : KryptonForm
    {
        public UpdateProfile()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        private void UpdateProfile_Load(object sender, EventArgs e)
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
                Profile f1 = new Profile();
                f1.Show();
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
                DialogResult result = MessageBox.Show("Clear Data Entered?", "CLEAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    txt_firstname.Clear();
                    txt_lastname.Clear();
                    txt_address.Clear();
                    txt_password.Clear();
                    txt_confpass.Clear();
                    txt_telno.Clear();
                    txt_stid.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_checkdata_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txt_firstname.Text))
                    MessageBox.Show("Please Enter Your First Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_firstname.Text.Any(char.IsDigit))
                    MessageBox.Show("Please Enter Valid First Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_lastname.Text))
                    MessageBox.Show("Please Enter Your Last Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_lastname.Text.Any(char.IsDigit))
                    MessageBox.Show("Please Enter Valid Last Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_address.Text))
                    MessageBox.Show("Please Enter Your Address", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_telno.Text))
                    MessageBox.Show("Please Enter Telephone Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_telno.Text.Length != 10 || txt_telno.Text.Any(char.IsLetter))
                    MessageBox.Show("Please Enter Valid Telephone Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_password.Text))
                    MessageBox.Show("Please Enter Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_confpass.Text))
                    MessageBox.Show("Please Confirm Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_password.Text != txt_confpass.Text)
                    MessageBox.Show("Passwords Don't Match", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_stid.Text))
                    MessageBox.Show("Please Enter Your Student ID Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                    MessageBox.Show("Data Entered Is Acceptable", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txt_firstname.Text))
                    MessageBox.Show("Please Enter Your First Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_firstname.Text.Any(char.IsDigit))
                    MessageBox.Show("Please Enter Valid First Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_lastname.Text))
                    MessageBox.Show("Please Enter Your Last Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_lastname.Text.Any(char.IsDigit))
                    MessageBox.Show("Please Enter Valid Last Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_address.Text))
                    MessageBox.Show("Please Enter Your Address", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_telno.Text))
                    MessageBox.Show("Please Enter Telephone Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_telno.Text.Length != 10 || txt_telno.Text.Any(char.IsLetter))
                    MessageBox.Show("Please Enter Valid Telephone Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_password.Text))
                    MessageBox.Show("Please Enter Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_confpass.Text))
                    MessageBox.Show("Please Confirm Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_password.Text != txt_confpass.Text)
                    MessageBox.Show("Passwords Don't Match", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_stid.Text))
                    MessageBox.Show("Please Enter Your Student ID Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    DialogResult result = MessageBox.Show("Update Your Profile?", "CLEAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("Update Student set FirstName = '" + txt_firstname.Text + "', LastName = '" + txt_lastname.Text + "', StAddress = '" + txt_address.Text + "', TelephoneNo = '" + txt_telno.Text + "', StPassword = '" + txt_password.Text + "' where StudentID = '" + txt_stid.Text + "'", con);
                        int i = cmd.ExecuteNonQuery();

                        if (i == 1)
                            MessageBox.Show("Data Updated Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                            MessageBox.Show("Data Not Updated", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();

                        txt_firstname.Clear();
                        txt_lastname.Clear();
                        txt_address.Clear();
                        txt_password.Clear();
                        txt_confpass.Clear();
                        txt_telno.Clear();
                        txt_stid.Clear();
                    }
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
