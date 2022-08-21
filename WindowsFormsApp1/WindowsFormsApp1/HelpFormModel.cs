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
    public partial class HelpFormModel : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Кодпроизводителя, Название FROM Производители";
        public HelpFormModel()
        {
            InitializeComponent();
        }

        private void HelpFormModel_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Автомат";
            using (SqlConnection connection = new SqlConnection(Connector.connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);

                comboBox2.DataSource = ds.Tables[0];
                comboBox2.DisplayMember = "Название";
                comboBox2.ValueMember = "Кодпроизводителя";

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Connector.connectionString))
            {


                SqlCommand command = new SqlCommand("INSERT INTO autosalon.dbo.Модель (Марка, Тип_Кузова, КП, Наименование_Модели, Год_выпуска, Цвет, Код_производителя) VALUES (@textBox1, @textBox2,@kp,@textBox3,@textBox4,@textBox5,@id)", con);
                
                con.Open();

                SqlParameter Param1 = new SqlParameter("@textbox1", textBox1.Text);
                SqlParameter Param2 = new SqlParameter("@textbox2", textBox2.Text);
                SqlParameter Param3 = new SqlParameter("@textbox3", textBox3.Text);
                SqlParameter Param4 = new SqlParameter("@kp", comboBox1.SelectedItem);
                SqlParameter Param5 = new SqlParameter("@textbox4", textBox4.Text);
                SqlParameter Param6 = new SqlParameter("@textbox5", textBox5.Text);
                SqlParameter Param7 = new SqlParameter("@id", comboBox2.SelectedValue);

                command.Parameters.Add(Param1);
                command.Parameters.Add(Param2);
                command.Parameters.Add(Param3);
                command.Parameters.Add(Param4);
                command.Parameters.Add(Param5);
                command.Parameters.Add(Param6);
                command.Parameters.Add(Param7);
                
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

        private void button3_Click(object sender, EventArgs e)
        {
            HelpFormProizvoditeli fh = new HelpFormProizvoditeli();
            fh.Show();
        }
    }
}
