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
    public partial class FormLineboard : Office2007Form
    {
        public FormLineboard()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Lineboard";
            adp.Fill(ds, "Lineboard");
            dataGridlineboard.DataSource = ds;
            dataGridlineboard.DataMember = "Lineboard";
            //*********************************
            dataGridlineboard.Columns[0].Width = 150;
            dataGridlineboard.Columns[1].Width = 150;
        }
        private void FormLineboard_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (textartcodeL.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Lineboard] (WorkOfArt_Code, Style)values(@WorkOfArt_Code, @Style)";
            cmd.Parameters.AddWithValue("@WorkOfArt_Code", textartcodeL.Text);
            cmd.Parameters.AddWithValue("@Style", textstyleL.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textartcodeL.Text = textstyleL.Text = "";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Lineboard] WHERE WorkOfArt_Code=@WorkOfArt_Code";
                cmd.Parameters.AddWithValue("@WorkOfArt_Code", dataGridlineboard.CurrentRow.Cells["WorkOfArt_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textartcodeL.Text = textstyleL.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textartcodeL.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Lineboard SET Style='" + textstyleL.Text + "' WHERE WorkOfArt_Code=" + textartcodeL.Text;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textartcodeL.Text = textstyleL.Text = "";
        }

        private void dataGridlineboard_MouseUp(object sender, MouseEventArgs e)
        {
            textartcodeL.Text = dataGridlineboard.CurrentRow.Cells[0].Value.ToString();
            textstyleL.Text = dataGridlineboard.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Lineboard WHERE WorkOfArt_Code like '%' + @WorkOfArt_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@WorkOfArt_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Work_Of_Art");
            dataGridlineboard.DataSource = ds;
            dataGridlineboard.DataMember = "Work_Of_Art";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
