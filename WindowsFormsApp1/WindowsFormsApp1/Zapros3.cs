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
    public partial class Zapros3 : Form
    {
        DataSet ds;
        DataSet ds2;
        SqlDataAdapter adapter;
        string sql2 = "SELECT Кодпроизводителя, Название FROM Производители";
        public Zapros3()
        {
            InitializeComponent();
        }

        private void Zapros3_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sql = "SELECT * FROM autosalon.dbo.Автомобили WHERE Наименование_поставщика ='" + textBox1.Text +"'";
            string sql = "SELECT TOP (5) ФИО, Адрес_покупателя, SUM(Цена) AS 'Сумма' FROM Покупатели JOIN Заказы ON Код_покупатель = Код_покупателя JOIN Автомобили ON Автомобиль = Код GROUP BY фИО, Адрес_покупателя ORDER BY Сумма DESC";
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
