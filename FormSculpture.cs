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
    public partial class FormSculpture : Office2007Form
    {
        public FormSculpture()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Sculpture";
            adp.Fill(ds, "Sculpture");
            dataGridsculpture.DataSource = ds;
            dataGridsculpture.DataMember = "Sculpture";
            //*********************************
            dataGridsculpture.Columns[0].Width = 150;
            dataGridsculpture.Columns[1].Width = 150;
        }
        private void FormSculpture_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textartcodeS.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Sculpture] (WorkOfArt_Code, Gender)values(@WorkOfArt_Code, @Gender)";
            cmd.Parameters.AddWithValue("@WorkOfArt_Code", textartcodeS.Text);
            cmd.Parameters.AddWithValue("@Gender", textgenderS.Text);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textartcodeS.Text = textgenderS.Text = "";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Sculpture] WHERE WorkOfArt_Code=@WorkOfArt_Code";
                cmd.Parameters.AddWithValue("@WorkOfArt_Code", dataGridsculpture.CurrentRow.Cells["WorkOfArt_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textartcodeS.Text = textgenderS.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textartcodeS.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Sculpture SET Gender='" + textgenderS.Text + "' WHERE WorkOfArt_Code=" + textartcodeS.Text;
               
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textartcodeS.Text = textgenderS.Text = "";
        }

        private void dataGridsculpture_MouseUp(object sender, MouseEventArgs e)
        {
            textartcodeS.Text = dataGridsculpture.CurrentRow.Cells[0].Value.ToString();
            textgenderS.Text = dataGridsculpture.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Sculpture WHERE WorkOfArt_Code like '%' + @WorkOfArt_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@WorkOfArt_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Work_Of_Art");
            dataGridsculpture.DataSource = ds;
            dataGridsculpture.DataMember = "Work_Of_Art";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
