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
    public partial class FormExpert : Office2007Form
    {
        public FormExpert()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Expert";
            adp.Fill(ds, "Expert");
            dataGridExpert.DataSource = ds;
            dataGridExpert.DataMember = "Expert";
            //*********************************
            dataGridExpert.Columns[0].Width = 150;
            dataGridExpert.Columns[1].Width = 150;
            dataGridExpert.Columns[2].Width = 150;
            dataGridExpert.Columns[3].Width = 150;
            dataGridExpert.Columns[4].Width = 150;
            dataGridExpert.Columns[5].Width = 150;
        }

        private void FormExpert_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeEx.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Expert] (Personal_Code, Education, Working_Hours_Expert, Overtime_Expert, Delaytime_Expert)" +
                "values(@Personal_Code, @Education, @Working_Hours_Expert, @Overtime_Expert, @Delaytime_Expert)";
            cmd.Parameters.AddWithValue("@Personal_Code", textpersonalcodeEx.Text);
            cmd.Parameters.AddWithValue("@Education", comboeducationEx.Text);
            cmd.Parameters.AddWithValue("@Working_Hours_Expert", textworkinghourseEx.Text);
            cmd.Parameters.AddWithValue("@Overtime_Expert", textovertimeEx.Text);
            cmd.Parameters.AddWithValue("@Delaytime_Expert", textdelaytimeEx.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textpersonalcodeEx.Text = comboeducationEx.Text = textworkinghourseEx.Text = textworkinghourseEx.Text = textovertimeEx.Text = textdelaytimeEx.Text= "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeEx.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "update Expert  set Education='" + comboeducationEx.Text +
                "',Working_Hours_Expert='" + textworkinghourseEx.Text + "',Overtime_Expert='" + textovertimeEx.Text
              + "',Delaytime_Expert='" + textdelaytimeEx.Text + "' where Personal_Code=" + textpersonalcodeEx.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textpersonalcodeEx.Text = comboeducationEx.Text = textworkinghourseEx.Text = textworkinghourseEx.Text = textovertimeEx.Text = textdelaytimeEx.Text = "";
        }

        private void dataGridExpert_MouseUp(object sender, MouseEventArgs e)
        {
            textpersonalcodeEx.Text = dataGridExpert.CurrentRow.Cells[0].Value.ToString();
            comboeducationEx.Text = dataGridExpert.CurrentRow.Cells[1].Value.ToString();
            textsalary.Text = dataGridExpert.CurrentRow.Cells[2].Value.ToString();
            textworkinghourseEx.Text = dataGridExpert.CurrentRow.Cells[3].Value.ToString();
            textovertimeEx.Text = dataGridExpert.CurrentRow.Cells[4].Value.ToString();
            textdelaytimeEx.Text = dataGridExpert.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Expert] WHERE Personal_Code=@Personal_Code";
                cmd.Parameters.AddWithValue("@Personal_Code", dataGridExpert.CurrentRow.Cells["Personal_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textpersonalcodeEx.Text = comboeducationEx.Text = textworkinghourseEx.Text = textworkinghourseEx.Text = textovertimeEx.Text = textdelaytimeEx.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Expert WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Expert");
            dataGridExpert.DataSource = ds;
            dataGridExpert.DataMember = "Expert";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
