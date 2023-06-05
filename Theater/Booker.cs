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
using Excel = Microsoft.Office.Interop.Excel;

namespace Theater
{
    public partial class Booker : Form
    {
        DataBase dataBase = new DataBase();

        public UserData userData;

        public Booker(UserData userData)
        {
            InitializeComponent();
            this.userData = userData;
        }

        private void Booker_Load(object sender, EventArgs e)
        {
            ShowUserData();
        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            LoadDataHistory();
            btnExportHistory.Enabled = true;
        }
        private void ShowUserData() // метод отвечает за вывод данных пользователя в левом верхнем углу.
        {
            try
            {
                string userID = userData.UserID;
                if (userID != null)
                {
                    labelFName.Text = userData.UserFName;
                    labelLName.Text = userData.UserLNmae;
                    labelRole.Text = userData.UserWorkPosition;
                }
                else
                {
                    labelFName.Text = "";//очищаем поля
                    labelLName.Text = "";//очищаем поля
                    labelRole.Text = "";//очищаем поля
                    MessageBox.Show("Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataHistory() // загрузка данных из бд
        {
            try
            {
                dataBase.GetConnection();
                dataBase.openConnection();

                string query = "SELECT [Билеты].[Код билета], [Дата покупки], Залы.Наименование, Ряд, Место, Сотрудники.Фамилия, Мероприятия.Наименование FROM " +
                    "(([Билеты] inner join Залы on [Билеты].[Код зала] = Залы.[Код зала]) " +
                    "inner join Сотрудники on Билеты.[Код сотрудника] = Сотрудники.[Код сотрудника]) " +
                    "inner join Мероприятия on Билеты.[Код мероприятия] = Мероприятия.[Код мероприятия]";

                SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[7]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                    data[data.Count - 1][6] = reader[6].ToString();
                }

                reader.Close();

                dataBase.closeConnection();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportHistory_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            int i, j;
            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 2; j++) // -2 для того, чобы не брать строчку с кнопкой delete 
                {
                    wsh.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString(); // добавляет к данным название столбцов
                    wsh.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
        }

    }
}
