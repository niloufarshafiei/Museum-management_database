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
    public partial class FormTicket : Office2007Form
    {
        public FormTicket()
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
            adp.SelectCommand.CommandText = "SELECT * FROM Ticket";
            adp.Fill(ds, "Ticket");
            dataGridTicket.DataSource = ds;
            dataGridTicket.DataMember = "Ticket";
            //*********************************
            dataGridTicket.Columns[0].Width = 150;
            dataGridTicket.Columns[1].Width = 150;
            dataGridTicket.Columns[2].Width = 150;
            dataGridTicket.Columns[3].Width = 150;
            dataGridTicket.Columns[4].Width = 150;
        }
        private void FormTicket_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textTicketcodeT.Text == "")
            {
                MessageBox.Show("Please Enter The TicketCode.");
                return;
            }
            //DATE
            string Date = texttickettime.Text;
            string DayD = Convert.ToString(Date[9]);
            string DayY = Convert.ToString(Date[8]);
            string MonthD = Convert.ToString(Date[5]);
            string MonthY = Convert.ToString(Date[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                texttickettime.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && (DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                texttickettime.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                texttickettime.Text = "";
                return;
            }
            //TIME
            string Time = texttickettime.Text;
            string HourD = Convert.ToString(Time[11]);
            string HourY = Convert.ToString(Time[12]);
            string MinutesD = Convert.ToString(Time[14]);      
            string SecondsD = Convert.ToString(Time[17]);
       
            if (((HourD == "2" && (HourY == "5" || HourY == "6" || HourY == "7" || HourY == "8" || HourY == "9")) || HourD == "3" || HourD == "4" || HourD == "5" || HourD == "6" || HourD == "7" || HourD == "8" || HourD == "9") ||
                (MinutesD =="6" || MinutesD == "7"|| MinutesD == "8"|| MinutesD == "9") ||
                (SecondsD == "6" || SecondsD == "7" || SecondsD == "8" || SecondsD == "9"))
            {
                MessageBox.Show("Please Enter The Correct Time.");
                texttickettime.Text = "";
                return;
            }

            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO [Ticket] (Ticket_Code, Cost, Ticket_Time, Visitor_Code, Personal_Code)values(@Ticket_Code, @Cost, @Ticket_Time, @Visitor_Code, @Personal_Code)";
            cmd.Parameters.AddWithValue("@Ticket_Code", textTicketcodeT.Text);
            cmd.Parameters.AddWithValue("@Cost", textCost.Text);
            cmd.Parameters.AddWithValue("@Ticket_Time", texttickettime.Text);
            cmd.Parameters.AddWithValue("@Visitor_Code", textvisitorcodeT.Text);
            cmd.Parameters.AddWithValue("@Personal_Code", textpersonalcodeT.Text);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
            MessageBox.Show("Save Done");
            textTicketcodeT.Text = textCost.Text = texttickettime.Text = textvisitorcodeT.Text = textpersonalcodeT.Text = "";
         }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textTicketcodeT.Text == "")
            {
                MessageBox.Show("Please Enter The TicketCode.");
                return;
            }
            //DATE
            string Date = texttickettime.Text;
            string DayD = Convert.ToString(Date[9]);
            string DayY = Convert.ToString(Date[8]);
            string MonthD = Convert.ToString(Date[5]);
            string MonthY = Convert.ToString(Date[6]);

            if ((MonthD == "1" && (MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6" || MonthY == "7" || MonthY == "8" || MonthY == "9")) || MonthD == "2" || MonthD == "3" || MonthD == "4" || MonthD == "5" || MonthD == "6" || MonthD == "7" || MonthD == "8" || MonthD == "9")
            {
                MessageBox.Show("Please Enter The Correct Date.");
                texttickettime.Text = "";
                return;
            }

            if ((MonthD == "0" && (MonthY == "1" || MonthY == "2" || MonthY == "3" || MonthY == "4" || MonthY == "5" || MonthY == "6")) && (DayY == "3" && (DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                texttickettime.Text = "";
                return;
            }

            if ((MonthD == "0" && ((MonthY == "7" || MonthY == "8" || MonthY == "9")) || (MonthD == "1" && (MonthY == "0" || MonthY == "1" || MonthY == "2"))) && (DayY == "3" && (DayD == "1" || DayD == "2" || DayD == "3" || DayD == "4" || DayD == "5" || DayD == "6" || DayD == "7" || DayD == "8" || DayD == "9")))
            {
                MessageBox.Show("Please Enter The Correct Date.");
                texttickettime.Text = "";
                return;
            }
            //TIME
            string Time = texttickettime.Text;
            string HourD = Convert.ToString(Time[11]);
            string HourY = Convert.ToString(Time[12]);
            string MinutesD = Convert.ToString(Time[14]);
            string SecondsD = Convert.ToString(Time[17]);

            if (((HourD == "2" && (HourY == "5" || HourY == "6" || HourY == "7" || HourY == "8" || HourY == "9")) || HourD == "3" || HourD == "4" || HourD == "5" || HourD == "6" || HourD == "7" || HourD == "8" || HourD == "9") ||
                (MinutesD == "6" || MinutesD == "7" || MinutesD == "8" || MinutesD == "9") ||
                (SecondsD == "6" || SecondsD == "7" || SecondsD == "8" || SecondsD == "9"))
            {
                MessageBox.Show("Please Enter The Correct Time.");
                texttickettime.Text = "";
                return;
            }
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Ticket SET Cost='" + textCost.Text + "',Ticket_Time='" + texttickettime.Text + "',Visitor_Code='" +
                textvisitorcodeT.Text + "',Personal_Code='" + textpersonalcodeT.Text + "' WHERE Ticket_Code=" + textTicketcodeT.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edit Done");
            Display();
            textTicketcodeT.Text = textCost.Text = texttickettime.Text = textvisitorcodeT.Text = textpersonalcodeT.Text = "";
        }

        private void dataGridTicket_MouseUp(object sender, MouseEventArgs e)
        {
            textTicketcodeT.Text = dataGridTicket.CurrentRow.Cells[0].Value.ToString();
            textCost.Text = dataGridTicket.CurrentRow.Cells[1].Value.ToString();
            texttickettime.Text = dataGridTicket.CurrentRow.Cells[2].Value.ToString();
            textvisitorcodeT.Text = dataGridTicket.CurrentRow.Cells[3].Value.ToString();
            textpersonalcodeT.Text = dataGridTicket.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do You Want to Delete?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM [Ticket] WHERE Ticket_Code=@Ticket_Code";
                cmd.Parameters.AddWithValue("@Ticket_Code", dataGridTicket.CurrentRow.Cells["Ticket_Code"].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("Delet Done");
                textTicketcodeT.Text = textCost.Text = texttickettime.Text = textvisitorcodeT.Text = textpersonalcodeT.Text = "";
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "SELECT *  FROM Ticket WHERE Ticket_Code like '%' + @Ticket_Code + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@Ticket_Code", textBoxSearch.Text + "%");
            adp.Fill(ds, "Ticket");
            dataGridTicket.DataSource = ds;
            dataGridTicket.DataMember = "Ticket";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
