using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp10
{
    public partial class SuaMayBay : Form
    {

        private string connectionString = "server=localhost;database=SanBay;user=root;password=771099;";
        public SuaMayBay()
        {
            InitializeComponent();
            LoadMaMB();
        }

        private void LoadMaMB()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MaMB FROM MayBay";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["MaMB"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE MayBay SET TenMayBay = @TenMayBay, NamSX = @NamSX, SoGioBay = @SoGioBay " +
                                         "WHERE MaMB = @MaMB";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaMB", comboBox1.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@TenMayBay", textBox1.Text);
                        command.Parameters.AddWithValue("@NamSX", int.Parse(textBox2.Text));
                        command.Parameters.AddWithValue("@SoGioBay", int.Parse(textBox3.Text));

                        command.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin máy bay thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
