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
    public partial class Form7 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Номер_заказа, Дата_заказа,Код_покупателя, ФИО, Автомобиль, Номер_двигателя, Цена, Статус_оплаты, FIO  FROM Заказы JOIN Покупатели ON Код_покупателя = Код_покупатель JOIN Personal ON Code_personal = Продавец JOIN Автомобили ON Код = Автомобиль ";
        public Form7()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(Connector.connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["Код_покупателя"].Visible = false;
                dataGridView1.Columns["Автомобиль"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HelpFormZakaz helpFormZakaz = new HelpFormZakaz();
            helpFormZakaz.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                using (SqlConnection connection = new SqlConnection(Connector.connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Заказы WHERE Номер_заказа=@kod", connection);
                    connection.Open();
                    SqlParameter Param1 = new SqlParameter("@kod", row.Cells[0].Value);
                    command.Parameters.Add(Param1);

                    try
                    {
                        command.ExecuteNonQuery();

                        MessageBox.Show("Удаление успешно");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Возникли ошибки");
                    }
                    connection.Close();
                }
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpFormPokypatel f1 = new HelpFormPokypatel();
            f1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected); i++)
            {
                HelpFormZakaz_update helpFormZakaz_Update = new HelpFormZakaz_update();
                helpFormZakaz_Update.updatedatazakaz(dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), dataGridView1.SelectedRows[i].Cells[5].Value.ToString(), dataGridView1.SelectedRows[i].Cells[6].Value.ToString(), dataGridView1.SelectedRows[i].Cells[7].Value.ToString(), dataGridView1.SelectedRows[i].Cells[8].Value.ToString());
                helpFormZakaz_Update.Show();
            }
        }
    }
}
