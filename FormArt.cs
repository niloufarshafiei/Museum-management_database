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
    public partial class FormArt : Office2007Form
    {
        public FormArt()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Work_Of_Art ";
            adp.Fill(ds, "Work_Of_Art ");
            dataGridArt.DataSource = ds;
            dataGridArt.DataMember = "Work_Of_Art ";
            //*********************************
            dataGridArt.Columns[0].Width = 150;
            dataGridArt.Columns[1].Width = 150;
            dataGridArt.Columns[2].Width = 150;
            dataGridArt.Columns[3].Width = 150;
            dataGridArt.Columns[4].Width = 150;
            dataGridArt.Columns[5].Width = 150;
            dataGridArt.Columns[5].Width = 150;
        }
        private void FormArt_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textartcodeA.Text == "")
            {
                MessageBox.Show("Please Enter the ArtCode.");
                return;
            }
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Work_Of_Art] (WorkOfArt_Code, Name_WorkOfArt, Creater_FName, Creater_LName, Creation_Time, Country, Number_Branch)values(@WorkOfArt_Code, @Name_WorkOfArt, @Creater_FName, @Creater_LName, @Creation_Time, @Country, @Number_Branch)";
            cmd.Parameters.AddWithValue("@WorkOfArt_Code", textartcodeA.Text);
            cmd.Parameters.AddWithValue("@Name_WorkOfArt", textnameart.Text);
            cmd.Parameters.AddWithValue("@Creater_FName", textfirstnamecreater.Text);
            cmd.Parameters.AddWithValue("@Creater_LName", textlastnamecreater.Text);
            cmd.Parameters.AddWithValue("@Creation_Time", textcreationtime.Text);
            cmd.Parameters.AddWithValue("@Country", textcountry.Text);
            cmd.Parameters.AddWithValue("@Number_Branch", textNumberbranchA.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textartcodeA.Text = textnameart.Text = textfirstnamecreater.Text = textlastnamecreater.Text = textcreationtime.Text = textcountry.Text = textNumberbranchA.Text = "";
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Work_Of_Art] WHERE WorkOfArt_Code=@WorkOfArt_Code";
                cmd.Parameters.AddWithValue("@WorkOfArt_Code", dataGridArt.CurrentRow.Cells["WorkOfArt_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textartcodeA.Text = textnameart.Text = textfirstnamecreater.Text = textlastnamecreater.Text = textcreationtime.Text = textcountry.Text = textNumberbranchA.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textartcodeA.Text == "")
            {
                MessageBox.Show("Please Enter the ArtCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Work_Of_Art SET Name_WorkOfArt='" + textnameart.Text + "',Creater_FName='" + textfirstnamecreater.Text + "',Creater_LName='" +
                textlastnamecreater.Text + "',Creation_Time='" + textcreationtime.Text + "',Country='" + textcountry.Text + "',Number_Branch='" +
                textNumberbranchA.Text + "' WHERE WorkOfArt_Code=" + textartcodeA.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textartcodeA.Text = textnameart.Text = textfirstnamecreater.Text = textlastnamecreater.Text = textcreationtime.Text = textcountry.Text = textNumberbranchA.Text = "";
        }

        private void dataGridArt_MouseUp(object sender, MouseEventArgs e)
        {

            textartcodeA.Text = dataGridArt.CurrentRow.Cells[0].Value.ToString();
            textnameart.Text = dataGridArt.CurrentRow.Cells[1].Value.ToString();
            textfirstnamecreater.Text = dataGridArt.CurrentRow.Cells[2].Value.ToString();
            textlastnamecreater.Text = dataGridArt.CurrentRow.Cells[3].Value.ToString();
            textcreationtime.Text = dataGridArt.CurrentRow.Cells[4].Value.ToString();
            textcountry.Text = dataGridArt.CurrentRow.Cells[5].Value.ToString();
            textNumberbranchA.Text = dataGridArt.CurrentRow.Cells[6].Value.ToString();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Work_Of_Art WHERE WorkOfArt_Code like '%' + @WorkOfArt_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@WorkOfArt_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Work_Of_Art");
            dataGridArt.DataSource = ds;
            dataGridArt.DataMember = "Work_Of_Art";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
