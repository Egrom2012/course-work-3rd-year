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
    public partial class Form4 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        //string connectionString = @"Data Source=DESKTOP-4OC7QLJ\SQLEXPRESS;Initial Catalog=autosalon;Integrated Security=True";
        string sql = "SELECT Код, Дата_поставки,Модель_авто,Наименование_Модели, Цена, Объём_двигателя, Номер_двигателя, Перегонщик, ФИО, Поставщик, Наименование, Продано  FROM Автомобили JOIN Модель ON Код_Модели = Модель_авто JOIN Перегонщики ON Код_перегонщика = Перегонщик JOIN Поставщики ON Код_поставщика = Поставщик";
        public Form4()
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
                dataGridView1.Columns["Код"].Visible = false;
                dataGridView1.Columns["Модель_авто"].Visible = false;
                dataGridView1.Columns["Перегонщик"].Visible = false;
                dataGridView1.Columns["Поставщик"].Visible = false;
                dataGridView1.Columns["ФИО"].HeaderText = "ФИО перегонщика";
                dataGridView1.Columns["Наименование"].HeaderText = "Наименование поставщика";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HelpFormAuto helpFormAuto = new HelpFormAuto();
            helpFormAuto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {

                using (SqlConnection connection = new SqlConnection(Connector.connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Автомобили WHERE Код=@kod", connection);
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

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected); i++)
            {
                HelpFormAuto_update formAuto_Update = new HelpFormAuto_update();
                formAuto_Update.updatedataauto(dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), dataGridView1.SelectedRows[i].Cells[2].Value.ToString(), dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), dataGridView1.SelectedRows[i].Cells[5].Value.ToString(), dataGridView1.SelectedRows[i].Cells[6].Value.ToString(), dataGridView1.SelectedRows[i].Cells[7].Value.ToString(), dataGridView1.SelectedRows[i].Cells[8].Value.ToString(), dataGridView1.SelectedRows[i].Cells[9].Value.ToString(), dataGridView1.SelectedRows[i].Cells[10].Value.ToString(), dataGridView1.SelectedRows[i].Cells[11].Value);
                formAuto_Update.Show();
            }
        }
    }
}
