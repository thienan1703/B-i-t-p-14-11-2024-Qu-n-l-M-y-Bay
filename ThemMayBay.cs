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
    public partial class ThemMayBay : Form
    {

        private string connectionString = "server=localhost;database=SanBay;user=root;password=771099;";
        public ThemMayBay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO MayBay (MaMB, TenMayBay, NamSX, SoGioBay) " +
                                         "VALUES (@MaMB, @TenMayBay, @NamSX, @SoGioBay)";

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaMB", textBox1.Text);
                        command.Parameters.AddWithValue("@TenMayBay", textBox2.Text);
                        command.Parameters.AddWithValue("@NamSX", int.Parse(textBox3.Text));
                        command.Parameters.AddWithValue("@SoGioBay", int.Parse(textBox4.Text));

                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm máy bay thành công!");
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
