using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
namespace ProjectMuseum
{
    public partial class FormMuseum_Contacts : Office2007Form
    {
        public FormMuseum_Contacts()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=(local);initial catalog=PROJECTMUSEUM;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Museum_Contacts";
            adp.Fill(ds, "Museum_Contacts");
            dataGridMuseum_Contacts.DataSource = ds;
            dataGridMuseum_Contacts.DataMember = "Museum_Contacts";
            //*********************************
            dataGridMuseum_Contacts.Columns[0].Width = 150;
            dataGridMuseum_Contacts.Columns[1].Width = 150;
        }
        private void FormMuseum_Contacts_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textnumberbranchs.Text == "")
            {
                MessageBox.Show("Please Enter The BranchNumber.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Museum_Contacts] (Museum_Contact,Number_Branch)values(@Museum_Contact,@Number_Branch)";
            cmd.Parameters.AddWithValue("@Museum_Contact", textmuseumcontact.Text);
            cmd.Parameters.AddWithValue("@Number_Branch", textnumberbranchs.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textmuseumcontact.Text = textnumberbranchs.Text = "";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var Museum_Contact = dataGridMuseum_Contacts.CurrentRow.Cells[0].Value;
                var Number_Branch = dataGridMuseum_Contacts.CurrentRow.Cells[1].Value;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Museum_Contacts WHERE Museum_Contact=@Museum_Contact and  Number_Branch=@Number_Branch";
                cmd.Parameters.AddWithValue("@Museum_Contact", Museum_Contact);
                cmd.Parameters.AddWithValue("@Number_Branch", Number_Branch);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textmuseumcontact.Text = textnumberbranchs.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Museum_Contacts WHERE Number_Branch like '%' + @Number_Branch + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Number_Branch", textBoxSearch.Text + "%");
            adp.Fill(ds, "Museum_Contacts");
            dataGridMuseum_Contacts.DataSource = ds;
            dataGridMuseum_Contacts.DataMember = "Museum_Contacts";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (textBoxEditNumber_Branch.Text == "")
            {
                MessageBox.Show("Please Enter The BranchNumber.");
                return;
            }
            if (textBoxEditMuseum_Contact.Text == "")
            {
                MessageBox.Show("Please Enter The Contact.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Museum_Contacts SET Museum_Contact='" + textBoxEditMuseum_Contact.Text + "' ," +
                " Number_Branch=" + textBoxEditNumber_Branch.Text +" where Museum_Contact='" + textmuseumcontact.Text + "'" +
                " and Number_Branch=" + textnumberbranchs.Text;    
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textmuseumcontact.Text = textnumberbranchs.Text = textBoxEditMuseum_Contact.Text = textBoxEditNumber_Branch.Text="";
        }

        private void dataGridMuseum_Contacts_MouseUp_1(object sender, MouseEventArgs e)
        {
            textmuseumcontact.Text = dataGridMuseum_Contacts.CurrentRow.Cells[0].Value.ToString();
            textnumberbranchs.Text = dataGridMuseum_Contacts.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
