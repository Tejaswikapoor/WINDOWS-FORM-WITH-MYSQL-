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

namespace TEJAS
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=(LocalDB)\mydb;Initial Catalog=Test_app;Integrated security=true";

            cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText= ("INSERT  into ExtraWork VALUES (@Name,@Hours,@Date)");
            int age;
            if (int.TryParse(txtHours.Text, out age))
            {
                if (age > 25)
                {
                    MessageBox.Show("The number of hours cannot be greater than 8 ! Please correct the entered value !");
                    return;
                }
                else
                {
                   
                }
            }
            else
            {
                MessageBox.Show("Please insert an integer into Hours textbox !");
                return;
            }

            
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Hours", age);
            cmd.Parameters.AddWithValue("@Date", dateOverTime.Value);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("The age was added ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection ! ");
            }

          
        }
    }
}
