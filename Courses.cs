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
    public partial class Courses : KryptonForm
    {
        public Courses()
        {
            InitializeComponent();
        }

        double num = 0;
        string st = "ORDER";


        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;

        private void Courses_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=LAPTOP-V8QJM6HE;Initial Catalog=Itcoursebay01;Integrated Security=True");
                AutoOrderNum();
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

        private void AutoOrderNum()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select count(OrderNo) from [Orders]", con);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                i++;
                lbl_ordernum.Text = st + num + i.ToString();
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

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.kryptonDataGridView1.Rows[e.RowIndex];
                    txt_courseid.Text = row.Cells["CourseID"].Value.ToString();
                    txt_coursename.Text = row.Cells["CourseName"].Value.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_viewcourses_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                da = new SqlDataAdapter("Select * from Courses", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                kryptonDataGridView1.DataSource = dt;
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
                DialogResult result = MessageBox.Show("Clear Data Entered?", "CLEAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    txt_firstname.Clear();
                    txt_lastname.Clear();
                    txt_stidnum.Clear();
                    txt_courseid.Clear();
                    txt_coursename.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txt_firstname.Text))
                    MessageBox.Show("Please Enter Your First Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_lastname.Text))
                    MessageBox.Show("Please Enter Your Last Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_stidnum.Text))
                    MessageBox.Show("Please Enter Your Student ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_coursename.Text))
                    MessageBox.Show("Please Enter The Course Name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (String.IsNullOrWhiteSpace(txt_courseid.Text))
                    MessageBox.Show("Please Enter The Course ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    DialogResult result = MessageBox.Show("Confirm Placing Order?", "ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        con.Open();
                        cmd = new SqlCommand("Insert into Orders values('" + lbl_ordernum.Text + "', '" + txt_stidnum.Text + "', '" + txt_firstname.Text + "', '" + txt_lastname.Text + "', '" + txt_courseid.Text + "', '" + txt_coursename.Text + "')", con);
                        int i = cmd.ExecuteNonQuery();

                        if (i == 1)
                        {
                            MessageBox.Show("Order Placed Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            InfoPage f1 = new InfoPage();
                            f1.Show();
                        }

                        else
                            MessageBox.Show("Order Not Placed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();

                        txt_firstname.Clear();
                        txt_lastname.Clear();
                        txt_stidnum.Clear();
                        txt_courseid.Clear();
                        txt_coursename.Clear();

                        AutoOrderNum();
                    }

                    else
                    {
                        txt_firstname.Clear();
                        txt_lastname.Clear();
                        txt_stidnum.Clear();
                        txt_courseid.Clear();
                        txt_coursename.Clear();
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
