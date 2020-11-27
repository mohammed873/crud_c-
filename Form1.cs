using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int userId;



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            

            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(address.Text) || string.IsNullOrEmpty(number.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(department.Text))
            {
                MessageBox.Show("please insert your information", "warnnaing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into  users (user_name, user_email, user_address, user_phone,  country, city, department) values ('" + name.Text + "', '" + email.Text + "' ,'" + address.Text + "','" + number.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + department.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("the user information is saved ", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("user information is unsaved", "warnnaing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                GetUsersRecord();
                ResetData();
            }
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MOROCCO")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("AGADIR");
                comboBox2.Items.Add("TANGER");
                comboBox2.Items.Add("MARRAKESH");
                comboBox2.Items.Add("SAFI");

            }
            if (comboBox1.Text == "USA")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("NEW YORK");
                comboBox2.Items.Add("LOS SANTOS");
                comboBox2.Items.Add("CHICAGO");
                comboBox2.Items.Add("LAS VEGAS");

            }
            if (comboBox1.Text == "FRANCE")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("PARIS");
                comboBox2.Items.Add("LILE");
                comboBox2.Items.Add("BORDEAUX");
                comboBox2.Items.Add("MARSEILLE");

            }
        }

        private void name_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                e.Cancel = true;
                name.Focus();
                errorProvider1.SetError(name,  "user name required");
            }
            else
            {
                errorProvider1.SetError(name, null);
            }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                
                errorProvider2.SetError(email, null);
            }
            else
            {
               
                errorProvider2.SetError(email, "user email unvalid");
            }
        }

        private void signup_Validating(object sender, CancelEventArgs e)
        {

        }

        private void email_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text))
            {
                e.Cancel = true;
                email.Focus();
                errorProvider2.SetError(email, "user email required");
            }
            else
            {
                errorProvider2.SetError(email, null);
            }
        }

        private void address_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(address.Text))
            {
                e.Cancel = true;
                address.Focus();
                errorProvider3.SetError(address, "address required");
            }
            else
            {
                errorProvider3.SetError(address, null);
            }
        }

        private void number_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(number.Text))
            {
                e.Cancel = true;
                address.Focus();
                errorProvider4.SetError(number, "number phone required");
            }
            else
            {
                errorProvider4.SetError(number, null);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetUsersRecord();
        }

        private void GetUsersRecord()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");
        

            SqlCommand cmd = new SqlCommand("Select * from users  ORDER BY user_id DESC", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            UsersGridRcord.DataSource = dt;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void reset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void ResetData()
        {
            userId = 0;
            name.Text = string.Empty;
            email.Text = string.Empty;
            address.Text = string.Empty;
            number.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            department.Text = string.Empty;

            name.Focus();
        }

        private void UsersGridRcord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UsersGridRcord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userId = Convert.ToInt32(UsersGridRcord.SelectedRows[0].Cells[0].Value);
            name.Text = UsersGridRcord.SelectedRows[0].Cells[1].Value.ToString();
            email.Text = UsersGridRcord.SelectedRows[0].Cells[2].Value.ToString();
            address.Text = UsersGridRcord.SelectedRows[0].Cells[3].Value.ToString(); 
            number.Text = UsersGridRcord.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = UsersGridRcord.SelectedRows[0].Cells[5].Value.ToString();
            comboBox2.Text = UsersGridRcord.SelectedRows[0].Cells[6].Value.ToString();
            department.Text = UsersGridRcord.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void update_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");

            if (userId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Users SET user_name = @name , user_email = @email , user_address = @address , user_phone = @phone  , country = @country  ,  city = @city , department = @department WHERE user_id = @id" , con
                    );
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@address", address.Text);
                cmd.Parameters.AddWithValue("@phone", number.Text);
                cmd.Parameters.AddWithValue("@country", comboBox1.Text);
                cmd.Parameters.AddWithValue("@city", comboBox2.Text);
                cmd.Parameters.AddWithValue("@department", department.Text);
                cmd.Parameters.AddWithValue("@id", this.userId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("user information updated successfuly", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("please select a someone to update", "Select ?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GetUsersRecord();
            ResetData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");

            if (userId > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE  from Users  WHERE user_id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", this.userId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("user information deleted successfuly", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("please select a someone to delete", "select ?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GetUsersRecord();
            ResetData();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void number_TextChanged(object sender,  EventArgs e)
        {
            

            if (Regex.IsMatch(number.Text, @"(\+212[0-9]{2}|\+[0-9]{2}\(0\)|\(\+[0-9]{2}\)\(0\)|00[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,17})"))
            {
                errorProvider4.SetError(number, null);
                
            }
            else
            {
               
                errorProvider4.SetError(number, "user number unvalid");
            }

        }

        private void total_number_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users", con);
            con.Open();
            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            label7.ForeColor = Color.Red;
            label7.Text = "total number is" + rows_count.ToString();
            con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE department = 'FULL STACK'", con);
            con.Open();
            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            label7.ForeColor = Color.Green;
            label7.Text = "total number of full stack student is" + rows_count.ToString();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE department = 'C#'", con);
            con.Open();
            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            label7.ForeColor = Color.Blue;
            label7.Text = "total number of C# student is" + rows_count.ToString();
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J4UV8B5;Initial Catalog=login_system;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE department = 'JAVA EE'", con);
            con.Open();
            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Dispose();
            label7.ForeColor = Color.Brown;
            label7.Text = "total number of JEE student is" + rows_count.ToString();
            con.Close();
        }
    }
    }

