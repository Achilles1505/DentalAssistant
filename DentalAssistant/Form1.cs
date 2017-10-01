using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DentalAssistant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection("Server = dentalassistantdbinstance.chgcnjcdjlrn.ap-south-1.rds.amazonaws.com; Port = 3306; Database = Patients; Uid = admin001; Pwd = ayodhyadental;");

        private void RefreshGrid()
        {
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT patient_id as `Patient ID`, patient_name as `Patient Name`, age as `Age`, sex as `Sex` FROM patient_records";

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                conn.Open();
                MessageBox.Show("Connection Open!");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not open connection." + ex);
            }

            RefreshGrid();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string oldText = string.Empty;

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nameTextBox.Text.All(chr => char.IsLetter(chr)))
            {
                oldText = nameTextBox.Text;
                nameTextBox.Text = oldText;
            }
            else
            {
                nameTextBox.Text = oldText;
                MessageBox.Show("Invalid Character. Only alphabets are allowed in this field.");
            }

            nameTextBox.SelectionStart = nameTextBox.Text.Length;
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            if(ageTextBox.Text.All(chr => char.IsDigit(chr)))
            {
                oldText = ageTextBox.Text;
                ageTextBox.Text = oldText;
            }
            else
            {
                ageTextBox.Text = oldText;
                MessageBox.Show("Invalid character. Only digits are allowed in this field.");
            }

            ageTextBox.SelectionStart = ageTextBox.Text.Length;
        }

        private void ageTextBox_Click(object sender, EventArgs e)
        {
            oldText = string.Empty;
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            oldText = string.Empty;
        }

        private void groupBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void medicineCostTextBox_TextChanged(object sender, EventArgs e)
        {
            if(medicineCostTextBox.Text.All(chr => char.IsDigit(chr)))
            {
                oldText = medicineCostTextBox.Text;
                medicineCostTextBox.Text = oldText;
            }
            else
            {
                medicineCostTextBox.Text = oldText;
                MessageBox.Show("Invalid character. This field can only accept digits.");
            }

            medicineCostTextBox.SelectionStart = medicineCostTextBox.Text.Length;
        }

        private void medicineCostTextBox_Click(object sender, EventArgs e)
        {
            oldText = string.Empty;
        }

        private void treatmentCostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (treatmentCostTextBox.Text.All(chr => char.IsDigit(chr)))
            {
                oldText = treatmentCostTextBox.Text;
                treatmentCostTextBox.Text = oldText;
            }
            else
            {
                treatmentCostTextBox.Text = oldText;
                MessageBox.Show("Invalid character. This field can only accept digits.");
            }

            treatmentCostTextBox.SelectionStart = treatmentCostTextBox.Text.Length;
        }

        private void treatmentCostTextBox_Click(object sender, EventArgs e)
        {
            oldText = string.Empty;
        }

        private void balanceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (balanceTextBox.Text.All(chr => char.IsDigit(chr)))
            {
                oldText = balanceTextBox.Text;
                balanceTextBox.Text = oldText;
            }
            else
            {
                balanceTextBox.Text = oldText;
                MessageBox.Show("Invalid character. This field can only accept digits.");
            }

            balanceTextBox.SelectionStart = balanceTextBox.Text.Length;
        }

        private void balanceTextBox_Click(object sender, EventArgs e)
        {
            oldText = string.Empty;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void totalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (totalTextBox.Text.All(chr => char.IsDigit(chr)))
            {
                oldText = totalTextBox.Text;
                totalTextBox.Text = oldText;
            }
            else
            {
               totalTextBox.Text = oldText;
                MessageBox.Show("Invalid character. This field can only accept digits.");
            }

           totalTextBox.SelectionStart = totalTextBox.Text.Length;
        }

        private void totalTextBox_Click(object sender, EventArgs e)
        {
            oldText = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oldText = string.Empty;

            nameTextBox.Text = oldText;
            ageTextBox.Text = oldText;
            sexComboBox.Text = oldText;
            dateTimePicker1.Value = DateTime.Today;
            medicineCostTextBox.Text = string.Empty;
            treatmentCostTextBox.Text = string.Empty;
            balanceTextBox.Text = string.Empty;
            totalTextBox.Text = string.Empty;
            medicineTextBox.Text = string.Empty;
            treatmentTextBox.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Close();
            System.Environment.Exit(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name : "+nameTextBox.Text+" Age : "+ageTextBox.Text+" Sex : "+sexComboBox.Text+" Date : "+dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") +" Medicine : "+medicineCostTextBox.Text+" Treatment : "+treatmentCostTextBox.Text+" Balance : "+balanceTextBox.Text+" Total : "+totalTextBox.Text+" Medicine : "+medicineTextBox.Text+" Treatment : "+treatmentTextBox.Text+" Today : "+DateTime.Today.Date.ToString("yyyy-MM-dd HH:mm"));

            char ch;

            String str = sexComboBox.Text.ToString();

            if (str.Equals("Male", StringComparison.Ordinal))
            {
                ch = 'M';
            }
            else if (str.Equals("Female", StringComparison.Ordinal))
            {
                ch = 'F';
            }
            else
                ch = 'O';

            try
            {
                MySqlCommand command = conn.CreateCommand();

                
                command.CommandText = "INSERT INTO patient_records VALUES ('DOC001', '"+nameTextBox.Text+"', "+ageTextBox.Text+", 'm', '2017-09-30', 150, 200, 350, 'jsasha ajkdnwqk jksdn', 'askdas skjdnas kjn', '2017-09-24', 1);";
                command.CommandText = "INSERT INTO patient_records (doctor_id, patient_name, age, sex, next_appointment, medicine_cost, treatment_cost, balance, total, medicine, treatment, curr_date) VALUES ('DOC1', " +
                    "'"+nameTextBox.Text+"', " +
                    "" +ageTextBox.Text+", " +
                    "'"+ch+"', " +
                    "'"+dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")+"', " +
                    ""+medicineCostTextBox.Text+", " +
                    ""+treatmentCostTextBox.Text+", " +
                    ""+balanceTextBox.Text+", " +
                    ""+"12, " +
                    "'"+medicineTextBox.Text+"', " +
                    "'"+treatmentTextBox.Text+"', " +
                    "'"+DateTime.Today.Date.ToString("yyyy-MM-dd")+"')";

                command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Could no  execute query." + ex);
            }
            
        }
    }
}
