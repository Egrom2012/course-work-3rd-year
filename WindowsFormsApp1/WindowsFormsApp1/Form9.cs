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
    public partial class Form9 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
       // string connectionString = @"Data Source=DESKTOP-4OC7QLJ\SQLEXPRESS;Initial Catalog=autosalon;Integrated Security=True";
        string sql = "SELECT * FROM Personal";
        SqlCommandBuilder commandBuilder;
        public Form9()
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
                dataGridView1.Columns["Code_personal"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Connector.connectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(sql, connection);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                }
                MessageBox.Show("Данные успешно обновлены");
            }
            catch
            {
                MessageBox.Show("Ошибка в заполнении данных");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HelpFormPersonal helpFormPersonal = new HelpFormPersonal();
            helpFormPersonal.Show();
        }
    }
}
