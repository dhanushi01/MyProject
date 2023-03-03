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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJECT
{
    public partial class Registration : KryptonForm
    {
        public Registration()
        {
            InitializeComponent();
        }

        double num = 0;
        string st = "ST";

        SqlConnection con;
        SqlCommand cmd;

        private void Registration_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=LAPTOP-V8QJM6HE;Initial Catalog=Itcoursebay01;Integrated Security=True");
                AutoStNumber();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutoStNumber()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count (StudentID) from [Student]", con);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                i++;
                lbl_Stidnum.Text = st + num + i.ToString();
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
                LoginPage f1 = new LoginPage();
                f1.Show();
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
                int age = DateTime.Now.Year - dob_picker.Value.Year;

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
                else if (String.IsNullOrWhiteSpace(cmb_gender.Text))
                    MessageBox.Show("Please Select Your Gender", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (age < 15 || age > 65)
                    MessageBox.Show("Please Select A Valid Age", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                else
                    MessageBox.Show("Data Entered Is Acceptable", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("FORMAT ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dob_picker.Value = DateTime.Now;
                    cmb_gender.Text = " ";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                int age = DateTime.Now.Year - dob_picker.Value.Year;

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
                else if (String.IsNullOrWhiteSpace(cmb_gender.Text))
                    MessageBox.Show("Please Select Your Gender", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (age < 15 || age > 65)
                    MessageBox.Show("Please Select A Valid Age", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_telno.Text))
                    MessageBox.Show("Please Enter Telephone Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txt_telno.Text.Length != 10 || txt_telno.Text.Any(char.IsLetter))
                    MessageBox.Show("Please Enter Valid Telephone Number", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_password.Text))
                    MessageBox.Show("Please Enter Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_confpass.Text))
                    MessageBox.Show("Please Confirm Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    DialogResult result = MessageBox.Show("Confirm Registration?", "REGISTER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("Insert into Student values('" + lbl_Stidnum.Text + "', '" + txt_firstname.Text + "', '" + txt_lastname.Text + "', '" + txt_address.Text + "', '" + dob_picker.Value + "', '" + cmb_gender.Text + "', '" + txt_telno.Text + "', '" + txt_password.Text + "')", con);
                        int i = cmd.ExecuteNonQuery();

                        if (i == 1)
                            MessageBox.Show("Data Saved Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                            MessageBox.Show("Data Not Saved", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();

                        AutoStNumber();

                        this.Hide();
                        LoginPage f1 = new LoginPage();
                        f1.Show();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("FORMAT ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
