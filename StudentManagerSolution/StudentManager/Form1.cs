using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-IL5D5HG\\SQLEXPRESS;Initial Catalog=StudentManager;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            LabelHide();
            Label2Hide();
            dataGridView1.Hide();
        }

        public void Label2Hide()
        {
            NUME_LABEL.Hide();
            PRENUME_LABEL.Hide();
            GRUPA_LABEL.Hide();
            GRUPA_1RADIO.Hide();
            GRUPA_2RADIO.Hide();
            GRUPA_3RADIO.Hide();
            DATA_LABEL.Hide();
            DATA_PICKER.Hide();
            CNP_LABEL.Hide();
            AN_LABEL.Hide();
            AN_SCOLAR_TEXT.Hide();
            FACULTATE_LABEL.Hide();
            SPECIALIZARE_LABEL.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            pictureBox10.Hide();
            ADD_BUTTON.Hide();
        }

        public void LabelShow()
        {
            NUME_LABEL.Show();
            PRENUME_LABEL.Show();
            GRUPA_LABEL.Show();
            GRUPA_1RADIO.Show();
            GRUPA_2RADIO.Show();
            GRUPA_3RADIO.Show();
            DATA_LABEL.Show();
            DATA_PICKER.Show();
            CNP_LABEL.Show();
            AN_LABEL.Show();
            AN_SCOLAR_TEXT.Show();
            FACULTATE_LABEL.Show();
            SPECIALIZARE_LABEL.Show();
            pictureBox5.Show();
            pictureBox6.Show();
            pictureBox7.Show();
            pictureBox8.Show();
            pictureBox9.Show();
            pictureBox10.Show();
            ADD_BUTTON.Show();
        }

        public void LabelHide()
        {
            CREATE_LABEL.Hide();
            UPDATE_LABEL.Hide();
            READ_LABEL.Hide();
            DELETE_LABEL.Hide();
        }


        private void CREATE_Click(object sender, EventArgs e)
        {
            

            LabelShow();

            CREATE_LABEL.Show();
            UPDATE_LABEL.Hide();
            READ_LABEL.Hide();
            DELETE_LABEL.Hide();
            dataGridView1.Hide();

            
        }

        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec ListEmp_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void READ_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();

            READ_LABEL.Show();
            UPDATE_LABEL.Hide();
            CREATE_LABEL.Hide();
            DELETE_LABEL .Hide();

            Label2Hide();
            
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            CREATE_LABEL.Hide();
            UPDATE_LABEL.Show();
            READ_LABEL.Hide();
            DELETE_LABEL.Hide();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            CREATE_LABEL.Hide();
            UPDATE_LABEL.Hide();
            READ_LABEL.Hide();
            DELETE_LABEL.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void ADD_BUTTON_Click(object sender, EventArgs e)
        {
            string nume = NUME_TEXT.Text;
            string prenume = PRENUME_TEXT.Text;
            string anscoala = AN_SCOLAR_TEXT.Text;
            string facultate = FACULTATE_TEXT.Text;
            string specializare = SPECIALIZARE_TEXT.Text;
            int cnp = int.Parse(textBox1.Text);
            string grupa = "";
            DateTime timp = DateTime.Parse(DATA_PICKER.Text);
            if (GRUPA_1RADIO.Checked == true)
            {
                grupa = "GRUPA I";
            }
            else if (GRUPA_2RADIO.Checked == true)
            {
                grupa = "GRUPA II";
            }
            else  
            {
                grupa = "grupa III";
            }

            con.Open();
            SqlCommand c = new SqlCommand("exec InsertEmp_SP '" + nume + "','" + prenume + "','" + anscoala + "','" + facultate + "','" + specializare + "','" + cnp + "','" + grupa + "','" + timp + "'", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Introdus cu succes");
            GetEmpList();
        }
    }
}
