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
    public partial class HelpFormModelupdate : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Кодпроизводителя, Название FROM Производители";
        string proizvodbox;
        string modelcode;

        public void updatedata(string codemodel,string textbox1,string textbox2,string combobox1, string textbox3, string textbox4, string textbox5, string id, string combobox2)
        {
            modelcode = codemodel;
            textBox1.Text = textbox1;
            textBox2.Text = textbox2;
            comboBox1.Text = combobox1;
            textBox3.Text = textbox3;
            textBox4.Text = textbox4;
            textBox5.Text = textbox5;
            proizvodbox = combobox2;

        }
        public HelpFormModelupdate()
        {
            InitializeComponent();
        }

        private void HelpFormModel_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connector.connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);

                comboBox2.DataSource = ds.Tables[0];
                comboBox2.DisplayMember = "Название";
                comboBox2.ValueMember = "Кодпроизводителя";
                comboBox2.Text = proizvodbox;
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Connector.connectionString))
            {


                SqlCommand command = new SqlCommand("UPDATE Модель SET Марка = @textbox1, Тип_Кузова = @textbox2 , КП = @kp, Наименование_Модели = @textbox3, Год_выпуска = @textbox4, Цвет = @textbox5, Код_производителя = @id WHERE Код = @modelcode ", con);

                con.Open();

                SqlParameter Param1 = new SqlParameter("@textbox1", textBox1.Text);
                SqlParameter Param2 = new SqlParameter("@textbox2", textBox2.Text);
                SqlParameter Param3 = new SqlParameter("@textbox3", textBox3.Text);
                SqlParameter Param4 = new SqlParameter("@kp", comboBox1.SelectedItem);
                SqlParameter Param5 = new SqlParameter("@textbox4", textBox4.Text);
                SqlParameter Param6 = new SqlParameter("@textbox5", textBox5.Text);
                SqlParameter Param7 = new SqlParameter("@id", comboBox2.SelectedValue);
                SqlParameter Param9 = new SqlParameter("@modelcode", modelcode);

                command.Parameters.Add(Param1);
                command.Parameters.Add(Param2);
                command.Parameters.Add(Param3);
                command.Parameters.Add(Param4);
                command.Parameters.Add(Param5);
                command.Parameters.Add(Param6);
                command.Parameters.Add(Param7);
                command.Parameters.Add(Param9);

                
                try
                {
                    command.ExecuteNonQuery();

                    MessageBox.Show("Обновление успешно");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Возникли ошибки");
                }
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        /*
        private void button3_Click(object sender, EventArgs e)
        {
            HelpFormProizvoditeli fh = new HelpFormProizvoditeli();
            fh.Show();
            Close();
        }
        */
    }
}
