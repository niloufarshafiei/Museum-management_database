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
    public partial class FormPainting : Office2007Form
    {
        public FormPainting()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Painting";
            adp.Fill(ds, "Painting");
            dataGridPainting.DataSource = ds;
            dataGridPainting.DataMember = "Painting";
            //*********************************
            dataGridPainting.Columns[0].Width = 150;
            dataGridPainting.Columns[1].Width = 150;
        }
        private void FormPainting_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textartcodeP.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Painting] (WorkOfArt_Code, Style)values(@WorkOfArt_Code, @Style)";
            cmd.Parameters.AddWithValue("@WorkOfArt_Code", textartcodeP.Text);
            cmd.Parameters.AddWithValue("@Style", textstyleP.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textartcodeP.Text = textstyleP.Text = "";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Painting] WHERE WorkOfArt_Code=@WorkOfArt_Code";
                cmd.Parameters.AddWithValue("@WorkOfArt_Code", dataGridPainting.CurrentRow.Cells["WorkOfArt_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textartcodeP.Text = textstyleP.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textartcodeP.Text == "")
            {
                MessageBox.Show("Please Enter The ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Painting SET Style='" + textstyleP.Text + "' WHERE WorkOfArt_Code=" + textartcodeP.Text;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textartcodeP.Text = textstyleP.Text = "";
        }

        private void dataGridPainting_MouseUp(object sender, MouseEventArgs e)
        {
            textartcodeP.Text = dataGridPainting.CurrentRow.Cells[0].Value.ToString();
            textstyleP.Text = dataGridPainting.CurrentRow.Cells[1].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Painting WHERE WorkOfArt_Code like '%' + @WorkOfArt_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@WorkOfArt_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Work_Of_Art");
            dataGridPainting.DataSource = ds;
            dataGridPainting.DataMember = "Work_Of_Art";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
