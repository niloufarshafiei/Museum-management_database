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
    public partial class FormTicketseller : Office2007Form
    {
        public FormTicketseller()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Responsible_for_Tickect_sales";
            adp.Fill(ds, "Responsible_for_Tickect_sales");
            dataGridticketseller.DataSource = ds;
            dataGridticketseller.DataMember = "Responsible_for_Tickect_sales";
            //*********************************
            dataGridticketseller.Columns[0].Width = 150;
            dataGridticketseller.Columns[1].Width = 150;
            dataGridticketseller.Columns[2].Width = 150;
            dataGridticketseller.Columns[3].Width = 150;
            dataGridticketseller.Columns[4].Width = 150;
            dataGridticketseller.Columns[5].Width = 150;
        }
        private void FormTicketseller_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeT.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Responsible_for_Tickect_sales] (Personal_Code, Room_Number, Working_Hours_Responsible, Overtime_Responsible, Delaytime_Responsible)" +
                "values(@Personal_Code, @Room_Number, @Working_Hours_Responsible, @Overtime_Responsible, @Delaytime_Responsible)";
            cmd.Parameters.AddWithValue("@Personal_Code", textpersonalcodeT.Text);
            cmd.Parameters.AddWithValue("@Room_Number", textroomnumberT.Text);
            cmd.Parameters.AddWithValue("@Working_Hours_Responsible", textworkinghourseT.Text);
            cmd.Parameters.AddWithValue("@Overtime_Responsible", textovertimeT.Text);
            cmd.Parameters.AddWithValue("@Delaytime_Responsible", textdelaytimeT.Text);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textpersonalcodeT.Text = textroomnumberT.Text = textworkinghourseT.Text = textovertimeT.Text = textdelaytimeT.Text = textsalaryT.Text= "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textpersonalcodeT.Text == "")
            {
                MessageBox.Show("Please Enter The PerconalCode.");
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Responsible_for_Tickect_sales  set Room_Number='" + textroomnumberT.Text +
                "',Working_Hours_Responsible='" + textworkinghourseT.Text 
              + "',Overtime_Responsible='" + textovertimeT.Text + "',Delaytime_Responsible='" + textdelaytimeT.Text
              + "' WHERE Personal_Code=" + textpersonalcodeT.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textpersonalcodeT.Text = textroomnumberT.Text = textworkinghourseT.Text = textovertimeT.Text = textdelaytimeT.Text = textsalaryT.Text= "";
        }

        private void dataGridticketseller_MouseUp(object sender, MouseEventArgs e)
        {
            textpersonalcodeT.Text = dataGridticketseller.CurrentRow.Cells[0].Value.ToString();
            textroomnumberT.Text = dataGridticketseller.CurrentRow.Cells[1].Value.ToString();
            textsalaryT.Text = dataGridticketseller.CurrentRow.Cells[2].Value.ToString();
            textworkinghourseT.Text = dataGridticketseller.CurrentRow.Cells[3].Value.ToString();
            textovertimeT.Text = dataGridticketseller.CurrentRow.Cells[4].Value.ToString();
            textdelaytimeT.Text = dataGridticketseller.CurrentRow.Cells[5].Value.ToString();
        
           
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Responsible_for_Tickect_sales] WHERE Personal_Code=@Personal_Code";
                cmd.Parameters.AddWithValue("@Personal_Code", dataGridticketseller.CurrentRow.Cells["Personal_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textpersonalcodeT.Text = textroomnumberT.Text = textworkinghourseT.Text = textovertimeT.Text = textdelaytimeT.Text = textsalaryT.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Responsible_for_Tickect_sales WHERE Personal_Code like '%' + @Personal_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Personal_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "dataGridticketseller");
            dataGridticketseller.DataSource = ds;
            dataGridticketseller.DataMember = "dataGridticketseller";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
