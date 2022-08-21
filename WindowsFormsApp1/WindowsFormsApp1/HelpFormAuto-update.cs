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
    public partial class HelpFormAuto_update : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Код_перегонщика,ФИО  FROM Перегонщики; SELECT Код_поставщика, Наименование FROM Поставщики; SELECT Код_Модели, Наименование_Модели FROM Модель";

        string id_auto;
        string modelcode;
        string peregonshik;
        string postavshik;

        string name_postavshik;
        string name_peregon;
        string name_model;

        public void updatedataauto(string idauto, string textbox1, string codemodel, string combobox3, string textbox2, string textbox3, string textbox4,string peregon, string combobox1,string postavsh, string combobox2, object checkbox1)
        {
            id_auto = idauto;
            textBox1.Text = textbox1;
            modelcode = codemodel;
            name_model = combobox3;
            textBox2.Text = textbox2;
            textBox3.Text = textbox3;
            textBox4.Text = textbox4;
            peregonshik = peregon;
            name_peregon = combobox1;
            postavshik = postavsh;
            name_postavshik = combobox2;
            checkBox1.Checked = Convert.ToBoolean(checkbox1);

        }
        public HelpFormAuto_update()
        {
            InitializeComponent();
        }

        private void HelpFormAuto_update_Load(object sender, EventArgs e)
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
                comboBox1.Text = name_peregon;

                comboBox2.DataSource = ds.Tables[1];
                comboBox2.DisplayMember = "Наименование";
                comboBox2.ValueMember = "Код_поставщика";
                comboBox2.Text = name_postavshik;

                comboBox3.DataSource = ds.Tables[2];
                comboBox3.DisplayMember = "Наименование_Модели";
                comboBox3.ValueMember = "Код_Модели";
                comboBox3.Text = name_model;

                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Connector.connectionString))
            {


                SqlCommand command = new SqlCommand("UPDATE Автомобили SET Дата_поставки = @textbox1, Модель_авто = @model_auto, Цена = @textbox2, Объём_двигателя = @textbox3, Номер_двигателя = @textbox4, Перегонщик = @peregonshik, Поставщик = @postavshik, Продано = @checkbox1 WHERE Код = @id_auto", con);
                con.Open();

                SqlParameter Param1 = new SqlParameter("@textbox1", textBox1.Text); //Дата_поставки
                SqlParameter Param2 = new SqlParameter("@model_auto", comboBox3.SelectedValue); // модель_авто
                SqlParameter Param4 = new SqlParameter("@textbox2", Convert.ToSingle(textBox2.Text)); //Цена
                SqlParameter Param5 = new SqlParameter("@textbox3", textBox3.Text); // Объём двигателя
                SqlParameter Param6 = new SqlParameter("@textbox4", textBox4.Text); // номер двигателя
                SqlParameter Param7 = new SqlParameter("@peregonshik", comboBox1.SelectedValue); // перегонщик
                SqlParameter Param9 = new SqlParameter("@postavshik", comboBox2.SelectedValue); // поставщик
                SqlParameter Param11 = new SqlParameter("@checkbox1", checkBox1.Checked); // наименование поставщика
                SqlParameter Param12 = new SqlParameter("@id_auto", id_auto); // номер авто

                command.Parameters.Add(Param1);
                command.Parameters.Add(Param2);
                command.Parameters.Add(Param4);
                command.Parameters.Add(Param5);
                command.Parameters.Add(Param6);
                command.Parameters.Add(Param7);
                command.Parameters.Add(Param9);
                command.Parameters.Add(Param11);
                command.Parameters.Add(Param12);

                
                try
                {
                    command.ExecuteNonQuery();

                    MessageBox.Show("Обновление успешно");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Возникли ошибки");
                }
                
                con.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
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
        */
    }
}
