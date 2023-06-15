using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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

        // билеты
        private void btnShow2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadDataTicketsHistory();
            btnExportHistory.Enabled = true;
        }
        private void btnExportHistory_Click(object sender, EventArgs e)
        {
            ExcelExportTickets();
        }
       
        // мероприятия
        private void btnShowEvents_Click(object sender, EventArgs e)
        {
            dataGridViewEvent.Rows.Clear();
            LoadDataEventsHistory();
            btnExportEvents.Enabled = true;
        }
        private void btnExportEvents_Click(object sender, EventArgs e)
        {
            ExcelExportEvents();
        }
        
        // сотрудники
        private void btnEmployersShow_Click(object sender, EventArgs e)
        {
            dataGridViewEmployers.Rows.Clear(); 
            LoadDataEmployers();
            btnEmployersExport.Enabled= true;
        }
        private void btnEmployersExport_Click(object sender, EventArgs e)
        {
            ExcelExportEmployers();
        }

        private void LoadDataTicketsHistory() // загрузка данных из билеты
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
        private void LoadDataEventsHistory() // загрузка данных из мероприятия
        {
            try
            {
                dataBase.GetConnection();
                dataBase.openConnection();

                string query = "SELECT [Код мероприятия], Мероприятия.Наименование, Описание, Вид.Наименование, Дата, [Время начала], Длительность, Стоимость FROM " +
                    "Мероприятия inner join Вид on Мероприятия.[Код вида] = Вид.[Код вида]";

                SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[8]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                    data[data.Count - 1][6] = reader[6].ToString();
                    data[data.Count - 1][7] = reader[7].ToString();
                }

                reader.Close();

                dataBase.closeConnection();

                foreach (string[] s in data)
                    dataGridViewEvent.Rows.Add(s);
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataEmployers() // загрузка данных из сотрудники
        {
            try
            {
                dataBase.GetConnection();
                dataBase.openConnection();

                string query = "SELECT [Код сотрудника], Фамилия, Имя, Отчество, Адрес, Телефон, Должности.Наименование FROM " +
                    "Сотрудники inner join Должности on Сотрудники.[Код должности] = Должности.[Код должности]";

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
                    dataGridViewEmployers.Rows.Add(s);
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExcelExportTickets() //экспорт в эксель билеты
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            int i, j;
            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++) // -2 для того, чобы не брать строчку с кнопкой delete 
                {
                    wsh.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString(); // добавляет к данным название столбцов
                    wsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
        }
        private void ExcelExportEvents() //экспорт в эксель мероприятия
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            int i, j;
            for (i = 0; i <= dataGridViewEvent.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridViewEvent.ColumnCount - 1; j++) // -2 для того, чобы не брать строчку с кнопкой delete 
                {
                    wsh.Cells[1, j + 1] = dataGridViewEvent.Columns[j].HeaderText.ToString(); // добавляет к данным название столбцов
                    wsh.Cells[i + 2, j + 1] = dataGridViewEvent[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
        }
        private void ExcelExportEmployers() //экспорт в эксель сотрудники
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            int i, j;
            for (i = 0; i <= dataGridViewEmployers.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridViewEmployers.ColumnCount - 1; j++) // -2 для того, чобы не брать строчку с кнопкой delete 
                {
                    wsh.Cells[1, j + 1] = dataGridViewEmployers.Columns[j].HeaderText.ToString(); // добавляет к данным название столбцов
                    wsh.Cells[i + 2, j + 1] = dataGridViewEmployers[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Booker_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string date = txtTicketSearch.Text;
            try
            {
                dataBase.openConnection();

                string query = $"SELECT * FROM [Билеты] where [Дата покупки] = '{date}'";

                SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                if (reader.HasRows)
                {
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

                        foreach (string[] s in data)
                            dataGridView1.Rows.Add(s);
                    }
                }
                else
                {
                    MessageBox.Show("Билетов по данному запросу не найдено.");
                }

                reader.Close();

                dataBase.closeConnection();
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show("Похоже вы ввели что-то не то. Пожалуйста, введите дату.");
            }
        }

        private void btnEventSearch_Click(object sender, EventArgs e)
        {
            dataGridViewEvent.Rows.Clear();

            string name = txtEventSearch.Text;
            try
            {
                dataBase.openConnection();

                string query = $"SELECT * FROM Мероприятия where Наименование = '{name}'";

                SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data.Add(new string[8]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                        data[data.Count - 1][4] = reader[4].ToString();
                        data[data.Count - 1][5] = reader[5].ToString();
                        data[data.Count - 1][6] = reader[6].ToString();
                        data[data.Count - 1][7] = reader[7].ToString();

                        foreach (string[] s in data)
                            dataGridViewEvent.Rows.Add(s);
                    }
                }
                else
                {
                    MessageBox.Show("Мероприятий по данному запросу не найдено.");
                }

                reader.Close();

                dataBase.closeConnection();
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show("Похоже вы ввели что-то не то. Пожалуйста, введите название мероприятия.");
            }
        }

        private void btnEmpSearch_Click(object sender, EventArgs e)
        {
            dataGridViewEmployers.Rows.Clear();

            string name = txtEmpSearch.Text;
            try
            {
                dataBase.openConnection();

                string query = $"SELECT * FROM Сотрудники where Имя = '{name}'";

                SqlCommand command = new SqlCommand(query, dataBase.GetConnection());

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                if (reader.HasRows)
                {
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

                        foreach (string[] s in data)
                            dataGridViewEmployers.Rows.Add(s);
                    }
                }
                else
                {
                    MessageBox.Show("Сотрудников по данному имени не найдено.");
                }

                reader.Close();

                dataBase.closeConnection();
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show("Похоже вы ввели что-то не то. Пожалуйста, введите имя сотрудника.");
            }
        }
    }
}

