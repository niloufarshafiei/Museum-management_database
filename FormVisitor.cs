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
    public partial class FormVisitor : Office2007Form
    {
        public FormVisitor()
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
            adp.SelectCommand.CommandText = "Select * From Visitor";
            adp.Fill(ds, "Visitor");
            dataGridvisitor.DataSource = ds;
            dataGridvisitor.DataMember = "Visitor";
            //*********************************
            dataGridvisitor.Columns[0].Width = 150;
            dataGridvisitor.Columns[1].Width = 150;
            dataGridvisitor.Columns[2].Width = 150;
            dataGridvisitor.Columns[3].Width = 150;           
        }
      
        private void FormVisitor_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textVisitorcode.Text == "")
            {
                MessageBox.Show("Please Enter The VisitorCode.");
                return;
            }
            if (textnumberbranchv.Text == "")
            {
                MessageBox.Show("Please Enter The BranchNumber.");
                return;
            }
            string Date = textdateticket.Text;
            string DayD = Convert.ToString(Date[9]);
            string DayY = Convert.ToString(Date[8]);
            string MonthD = Convert.ToString(Date[5]);
            string MonthY = Convert.ToString(Date[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdateticket.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && ( DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdateticket.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdateticket.Text = "";
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Visitor] (Visitor_Code, Date_Ticket, Sex, Number_Branch)values(@Visitor_Code, @Date_Ticket, @Sex, @Number_Branch)";
            cmd.Parameters.AddWithValue("@Visitor_Code", textVisitorcode.Text);
            cmd.Parameters.AddWithValue("@Date_Ticket", textdateticket.Text);
            cmd.Parameters.AddWithValue("@Sex", combosextv.Text);
            cmd.Parameters.AddWithValue("@Number_Branch", textnumberbranchv.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textVisitorcode.Text = textdateticket.Text = combosextv.Text = textnumberbranchv.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textVisitorcode.Text == "")
            {
                MessageBox.Show("Please Enter The VisitorCode.");
                return;
            }
            if (textnumberbranchv.Text == "")
            {
                MessageBox.Show("Please Enter The BranchNumber.");
                return;
            }
            string Date = textdateticket.Text;
            string DayD = Convert.ToString(Date[9]);
            string DayY = Convert.ToString(Date[8]);
            string MonthD = Convert.ToString(Date[5]);
            string MonthY = Convert.ToString(Date[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdateticket.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && (DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdateticket.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                textdateticket.Text = "";
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Visitor SET Date_Ticket='" + textdateticket.Text + "',Sex='" + combosextv.Text + "',Number_Branch='" +
                textnumberbranchv.Text + "' where Visitor_Code=" + textVisitorcode.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textVisitorcode.Text = textdateticket.Text = combosextv.Text = textnumberbranchv.Text = "";
        }

        private void dataGridvisitor_MouseUp(object sender, MouseEventArgs e)
        {
            textVisitorcode.Text = dataGridvisitor.CurrentRow.Cells[0].Value.ToString();
            textdateticket.Text = dataGridvisitor.CurrentRow.Cells[1].Value.ToString();
            combosextv.Text = dataGridvisitor.CurrentRow.Cells[2].Value.ToString();
            textnumberbranchv.Text = dataGridvisitor.CurrentRow.Cells[3].Value.ToString();
 
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Visitor] WHERE Visitor_Code=@Visitor_Code ";
                cmd.Parameters.AddWithValue("@Visitor_Code", dataGridvisitor.CurrentRow.Cells["Visitor_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textVisitorcode.Text = textdateticket.Text = combosextv.Text = textnumberbranchv.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT * FROM Visitor WHERE Visitor_Code like '%' + @Visitor_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Visitor_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Visitor");
            dataGridvisitor.DataSource = ds;
            dataGridvisitor.DataMember = "Visitor";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
