using MySql.Data.MySqlClient;
using System.Data;

namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;database=SanBay;user=root;password=771099;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu sẵn khi form mở
            LoadMayBayData();
        }

        private void LoadMayBayData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM MayBay ORDER BY TenMayBay ASC";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMayBayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemMayBay themForm = new ThemMayBay();
            themForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuaMayBay suaForm = new SuaMayBay();
            suaForm.ShowDialog();
        }
    }
}
