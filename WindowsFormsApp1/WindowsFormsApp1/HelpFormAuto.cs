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
    public partial class HelpFormAuto : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Код_перегонщика,ФИО  FROM Перегонщики; SELECT Код_поставщика, Наименование FROM Поставщики; SELECT Код_Модели, Наименование_Модели FROM Модель";

        public HelpFormAuto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(Connector.connectionString))
            {


                SqlCommand command = new SqlCommand("INSERT INTO autosalon.dbo.Автомобили (Дата_поставки, Модель_авто, Цена, Объём_двигателя, Номер_двигателя, Перегонщик, Поставщик, Продано) VALUES (@textBox1, @model_auto, @textbox2,@textbox3,@textbox4, @peregonshik, @postavshik, @checkbox1)", con);

                con.Open();

                SqlParameter Param1 = new SqlParameter("@textbox1", textBox1.Text); //Дата_поставки
                SqlParameter Param2 = new SqlParameter("@model_auto", comboBox3.SelectedValue); // модель_авто
                SqlParameter Param4 = new SqlParameter("@textbox2", textBox2.Text); //Цена
                SqlParameter Param5 = new SqlParameter("@textbox3", textBox3.Text); // Объём двигателя
                SqlParameter Param6 = new SqlParameter("@textbox4", textBox4.Text); // номер двигателя
                SqlParameter Param7 = new SqlParameter("@peregonshik", comboBox1.SelectedValue); // перегонщик
                SqlParameter Param9 = new SqlParameter("@postavshik", comboBox2.SelectedValue); // поставщик
                SqlParameter Param11 = new SqlParameter("@checkbox1", checkBox1.Checked); // наименование поставщика

                command.Parameters.Add(Param1);
                command.Parameters.Add(Param2);
                command.Parameters.Add(Param4);
                command.Parameters.Add(Param5);
                command.Parameters.Add(Param6);
                command.Parameters.Add(Param7);
                command.Parameters.Add(Param9);
                command.Parameters.Add(Param11);
                
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

        private void HelpFormAuto_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connector.connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);

                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "ФИО";
                comboBox1.ValueMember = "Код_перегонщика";

                comboBox2.DataSource = ds.Tables[1];
                comboBox2.DisplayMember = "Наименование";
                comboBox2.ValueMember = "Код_поставщика";

                comboBox3.DataSource = ds.Tables[2];
                comboBox3.DisplayMember = "Наименование_Модели";
                comboBox3.ValueMember = "Код_Модели";

                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpFormModel f1 = new HelpFormModel();
            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HelpFormPeregonshiki f2 = new HelpFormPeregonshiki();
            f2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HelpFormPostavshick f3 = new HelpFormPostavshick();
            f3.Show();
        }
    }
}
