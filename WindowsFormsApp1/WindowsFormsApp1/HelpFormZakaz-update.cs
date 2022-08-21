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
    public partial class HelpFormZakaz_update : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Код_покупателя, ФИО FROM Покупатели; SELECT Код, Номер_двигателя, Цена, Продано FROM Автомобили; SELECT Code_personal, FIO FROM Personal WHERE Dolshnost = 'Менеджер' OR Dolshnost = 'Ст.Менеджер'";
        string id_zakaz;
        string combobof1;
        string combobof2;
        string combobof3;
        string texbox2;

        public void updatedatazakaz(string idzakaz, string textbox1, string combobox1, string combobox2, string textbox2, string checkbox, string combobox3)
        {
            id_zakaz = idzakaz;
            textBox1.Text = textbox1;
            combobof1 = combobox1;
            combobof2 = combobox2;
            texbox2 = textbox2;
            checkBox1.Checked = Convert.ToBoolean(checkbox);
            combobof3 = combobox3;



        }

        public HelpFormZakaz_update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpFormZakaz_update_Load(object sender, EventArgs e)
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
                comboBox1.Text = combobof1;

                comboBox2.DataSource = ds.Tables[1];
                comboBox2.DisplayMember = "Номер_двигателя";
                comboBox2.ValueMember = "Код";
                comboBox2.Text = combobof2;
                textBox2.Text = ds.Tables[1].Rows[0][2].ToString();
                textBox2.Text = texbox2;

                comboBox3.DataSource = ds.Tables[2];
                comboBox3.DisplayMember = "FIO";
                comboBox3.ValueMember = "Code_personal";
                comboBox3.Text = combobof3;

                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Connector.connectionString))
            {


                SqlCommand command = new SqlCommand("UPDATE autosalon.dbo.Заказы SET Дата_заказа = @textbox1, Код_покупатель = @combobox1val, Автомобиль = @combobox2val, Статус_оплаты = @checkbox, Продавец = @combobox3val WHERE Номер_заказа = @idzakaz", con);

                con.Open();

                SqlParameter Param0 = new SqlParameter("@idzakaz", id_zakaz); //id заказа
                SqlParameter Param1 = new SqlParameter("@textbox1", textBox1.Text); //Дата заказа
                SqlParameter Param2 = new SqlParameter("@combobox1val", comboBox1.SelectedValue); // Код покупателя
                SqlParameter Param4 = new SqlParameter("@combobox2val", comboBox2.SelectedValue); // Номер авто
                SqlParameter Param7 = new SqlParameter("@checkbox", checkBox1.Checked); // статус оплаты
                SqlParameter Param8 = new SqlParameter("@combobox3val", comboBox3.SelectedValue); // номер продавца

                command.Parameters.Add(Param0);
                command.Parameters.Add(Param1);
                command.Parameters.Add(Param2);
                command.Parameters.Add(Param4);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = ds.Tables[1].Rows[comboBox2.SelectedIndex][2].ToString();
        }
    }
}
