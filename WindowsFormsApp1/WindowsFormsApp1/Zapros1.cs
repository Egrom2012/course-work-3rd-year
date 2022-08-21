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
    public partial class Zapros1 : Form
    {
        DataSet ds;
        DataSet ds2;
        SqlDataAdapter adapter;
        string sql2 = "SELECT Код_перегонщика, ФИО FROM Перегонщики";
        public Zapros1()
        {
            InitializeComponent();
        }

        private void Zapros1_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connector.connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql2, connection);
                ds2 = new DataSet();
                adapter.Fill(ds2);

                comboBox1.DataSource = ds2.Tables[0];
                comboBox1.DisplayMember = "ФИО";
                comboBox1.ValueMember = "Код_перегонщика";
                comboBox1.Text = "Выберите перегонщика";
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sql = "SELECT * FROM autosalon.dbo.Автомобили WHERE Наименование_поставщика ='" + textBox1.Text +"'";

            string sql = "SELECT Модель_авто, Наименование_Модели, Поставщик, Наименование, Объём_двигателя, КП, Тип_Кузова, Цвет, Год_выпуска, Код_покупатель, ФИО, Адрес_покупателя  FROM autosalon.dbo.Автомобили JOIN Модель ON Код_модели = Модель_авто  JOIN Поставщики ON Код_поставщика=Поставщик JOIN Заказы ON Автомобиль = Код JOIN Покупатели ON Код_покупателя = Код_покупатель" +
                " WHERE Перегонщик = '" + comboBox1.SelectedValue + "'AND Дата_поставки BETWEEN'" + textBox1.Text + "' AND '" + textBox2.Text + "'";
            //'" + comboBox1.SelectedValue + "'";
            using (SqlConnection con = new SqlConnection(Connector.connectionString))
            {
                
                try
                {
                    con.Open();
                    adapter = new SqlDataAdapter(sql, con);
                    ds = new DataSet();
                    ds.Clear();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Возникли ошибки");
                }
                dataGridView1.Columns["Модель_авто"].Visible = false;
                dataGridView1.Columns["Поставщик"].Visible = false;
                dataGridView1.Columns["Код_покупатель"].Visible = false;
            }
        }
    }
}
