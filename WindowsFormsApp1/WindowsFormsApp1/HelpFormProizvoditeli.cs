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

namespace WindowsFormsApp1
{
    public partial class HelpFormProizvoditeli : Form
    {
        public HelpFormProizvoditeli()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            HelpFormModel helpFormModel = new HelpFormModel();
            helpFormModel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Connector.connectionString);


            SqlCommand command = new SqlCommand("INSERT INTO autosalon.dbo.Производители (Название, Страна) VALUES (@textBox1, @textBox2)",con);
            con.Open();

            SqlParameter Param1 = new SqlParameter("@textbox1", textBox1.Text);
            SqlParameter Param2 = new SqlParameter("@textbox2", textBox2.Text);
            command.Parameters.Add(Param1);
            command.Parameters.Add(Param2);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Добавление успешно");
            }
            catch (SqlException)
            {
                MessageBox.Show("Возникли ошибки");
            }
            con.Close();
        }
    }
}
