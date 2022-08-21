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
    public partial class HelpFormZakaz : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Код_покупателя, ФИО FROM Покупатели; SELECT Код, Номер_двигателя, Цена, Продано FROM Автомобили; SELECT Code_personal, FIO FROM Personal WHERE Dolshnost = 'Менеджер' OR Dolshnost = 'Ст.Менеджер'";

        public HelpFormZakaz()
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


                SqlCommand command = new SqlCommand("INSERT INTO autosalon.dbo.Заказы (Дата_заказа, Код_покупатель, Автомобиль, Статус_оплаты, Продавец) VALUES (@textbox1, @combobox1val, @combobox2val, @checkbox, @combobox3val)", con);

                con.Open();

                SqlParameter Param1 = new SqlParameter("@textbox1", textBox1.Text); //Дата заказа
                SqlParameter Param2 = new SqlParameter("@combobox1val", comboBox1.SelectedValue); // Код покупателя
                SqlParameter Param4 = new SqlParameter("@combobox2val", comboBox2.SelectedValue); // Номер авто
                SqlParameter Param6 = new SqlParameter("@textbox2", textBox2.Text); // Сумма оплаты
                SqlParameter Param7 = new SqlParameter("@checkbox", checkBox1.Checked); // статус оплаты
                SqlParameter Param8 = new SqlParameter("@combobox3val", comboBox3.SelectedValue); // номер продавца

                command.Parameters.Add(Param1);
                command.Parameters.Add(Param2);
                command.Parameters.Add(Param4);
                command.Parameters.Add(Param6);
                command.Parameters.Add(Param7);
                command.Parameters.Add(Param8);

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

        private void HelpFormZakaz_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Connector.connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);

                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "ФИО";
                comboBox1.ValueMember = "Код_покупателя";

                comboBox2.DataSource = ds.Tables[1];
                comboBox2.DisplayMember = "Номер_двигателя";
                comboBox2.ValueMember = "Код";
                textBox2.Text = ds.Tables[1].Rows[0][2].ToString();

                comboBox3.DataSource = ds.Tables[2];
                comboBox3.DisplayMember = "FIO";
                comboBox3.ValueMember = "Code_personal";

                connection.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = ds.Tables[1].Rows[comboBox2.SelectedIndex][2].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpFormPokypatel helpFormPokypatel = new HelpFormPokypatel();
            helpFormPokypatel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HelpFormAuto helpFormAuto = new HelpFormAuto();
            helpFormAuto.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HelpFormPersonal helpFormPersonal = new HelpFormPersonal();
            helpFormPersonal.Show();
        }
    }
}
