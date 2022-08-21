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
    public partial class Zapros2 : Form
    {
        DataSet ds;
        DataSet ds2;
        SqlDataAdapter adapter;
        string sql2 = "SELECT Кодпроизводителя, Название FROM Производители";
        public Zapros2()
        {
            InitializeComponent();
        }

        private void Zapros2_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connector.connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql2, connection);
                ds2 = new DataSet();
                adapter.Fill(ds2);

                comboBox1.DataSource = ds2.Tables[0];
                comboBox1.DisplayMember = "Название";
                comboBox1.ValueMember = "Кодпроизводителя";
                comboBox1.Text = "Выберите производителя";
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

            string sql = "SELECT Наименование_модели, COUNT(Модель_авто) AS 'Количество' FROM Модель JOIN автомобили ON Модель_авто = Код_модели WHERE Дата_поставки LIKE '%2020%' AND Код_производителя ='" + comboBox1.SelectedValue + "' GROUP BY Наименование_Модели";
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
            }
        }
    }
}
