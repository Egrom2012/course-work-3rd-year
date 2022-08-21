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
    public partial class Form3 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string sql = "SELECT Код_Модели, Марка, Тип_Кузова, КП, Наименование_Модели, Год_выпуска, Цвет, Код_Производителя, Название FROM Модель JOIN Производители ON Код_производителя = Кодпроизводителя";
        public Form3()
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
                dataGridView1.Columns["Код_Модели"].Visible = false;
                dataGridView1.Columns["Код_Производителя"].Visible = false;
                dataGridView1.Columns["Название"].HeaderText = "Название производителя";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            HelpFormModel f1 = new HelpFormModel();
            f1.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                
                using (SqlConnection connection = new SqlConnection(Connector.connectionString))
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Модель WHERE Код=@kod", connection);
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

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected); i++)
            {
                HelpFormModelupdate f1 = new HelpFormModelupdate();
                f1.updatedata(dataGridView1.SelectedRows[i].Cells[0].Value.ToString(), dataGridView1.SelectedRows[i].Cells[1].Value.ToString(), dataGridView1.SelectedRows[i].Cells[2].Value.ToString(), dataGridView1.SelectedRows[i].Cells[3].Value.ToString(), dataGridView1.SelectedRows[i].Cells[4].Value.ToString(), dataGridView1.SelectedRows[i].Cells[5].Value.ToString(), dataGridView1.SelectedRows[i].Cells[6].Value.ToString(), dataGridView1.SelectedRows[i].Cells[7].Value.ToString(), dataGridView1.SelectedRows[i].Cells[8].Value.ToString());
                f1.Show();
                Close();
            }
        }
    }
}
