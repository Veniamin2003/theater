using Microsoft.Office.Interop.Excel;
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
    public partial class Admin : Form
    {
        public UserData userData;

        DataBase dataBase = new DataBase();
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilderTicket = null;
        private SqlCommandBuilder sqlBuilderEvent = null;
        private SqlCommandBuilder sqlBuilderEmployer = null;

        private SqlDataAdapter sqlDataAdapterTicket = null;
        private SqlDataAdapter sqlDataAdapterEvent = null;
        private SqlDataAdapter sqlDataAdapterEmployer = null;

        private DataSet dataSetTicket = null;
        private DataSet dataSetEvent = null;
        private DataSet dataSetEmployers = null;

        private bool newRowAdding = false;

        public Admin(UserData userData)
        {
            InitializeComponent();
            this.userData = userData;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            ShowUserData();
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

        //////////////////////////////////////////////////////////////////////

        private void btnShowTickets_Click(object sender, EventArgs e)
        {
            LoadDataTickets();
            btnUpdate.Enabled= true;
            btnExportTickets.Enabled= true; 
        }
        private void btnExportTickets_Click(object sender, EventArgs e)
        {
            ExcelExportTickets();
        }

        private void LoadDataTickets() // загрузка данных из бд
        {
            try
            {
                dataBase.openConnection();
                sqlDataAdapterTicket = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] FROM [Билеты]", dataBase.GetConnection());

                sqlBuilderTicket = new SqlCommandBuilder(sqlDataAdapterTicket);

                sqlBuilderTicket.GetInsertCommand();
                sqlBuilderTicket.GetUpdateCommand();
                sqlBuilderTicket.GetDeleteCommand();

                dataSetTicket = new DataSet();

                sqlDataAdapterTicket.Fill(dataSetTicket, "Билеты");

                dataGridViewTickets.DataSource = dataSetTicket.Tables["Билеты"];

                for (int i = 0; i < dataGridViewTickets.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridViewTickets[7, i] = linkCell;
                }
                dataBase.closeConnection();
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTickets_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false) // проверка на режим редактирования
                {
                    int rowIndex = dataGridViewTickets.SelectedCells[0].RowIndex; // получаем индекс строки выделенной ячейки

                    DataGridViewRow editingRow = dataGridViewTickets.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridViewTickets[7, rowIndex] = linkCell; // обращаемся к ячейке, где находится кнопка с действием

                    editingRow.Cells["Command"].Value = "Update"; // меняем тип действия кнопки на insert
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// метод срабатывает, когда происходит добавление новой строки

        private void dataGridViewTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    string task = dataGridViewTickets.Rows[e.RowIndex].Cells[7].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex; // получаем индекс строки, которую нужно удалить

                            dataGridViewTickets.Rows.RemoveAt(rowIndex); // удаление только из приложения

                            dataSetTicket.Tables["Билеты"].Rows[rowIndex].Delete(); // удаление из самой базы данных

                            sqlDataAdapterTicket.Update(dataSetTicket, "Билеты"); // обновление базы данных 
                        }
                    }

                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridViewTickets.Rows.Count - 2;

                        DataRow row = dataSetTicket.Tables["Билеты"].NewRow();

                        row["Код билета"] = dataGridViewTickets.Rows[rowIndex].Cells["Код билета"].Value;
                        row["Дата покупки"] = dataGridViewTickets.Rows[rowIndex].Cells["Дата покупки"].Value;
                        row["Код зала"] = dataGridViewTickets.Rows[rowIndex].Cells["Код зала"].Value;
                        row["Ряд"] = dataGridViewTickets.Rows[rowIndex].Cells["Ряд"].Value;
                        row["Место"] = dataGridViewTickets.Rows[rowIndex].Cells["Место"].Value;
                        row["Код сотрудника"] = dataGridViewTickets.Rows[rowIndex].Cells["Код сотрудника"].Value;
                        row["Код мероприятия"] = dataGridViewTickets.Rows[rowIndex].Cells["Код мероприятия"].Value;

                        dataSetTicket.Tables["Билеты"].Rows.Add(row);

                        dataSetTicket.Tables["Билеты"].Rows.RemoveAt(dataSetTicket.Tables["Билеты"].Rows.Count - 2);

                        dataGridViewTickets.Rows.RemoveAt(dataGridViewTickets.Rows.Count - 2);

                        dataGridViewTickets.Rows[e.RowIndex].Cells[7].Value = "Delete";

                        sqlDataAdapterTicket.Update(dataSetTicket, "Билеты");

                        newRowAdding = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex; // получаем индекс выделенной строки

                        dataSetTicket.Tables["Билеты"].Rows[r]["Код билета"] = dataGridViewTickets.Rows[r].Cells["Код билета"].Value;
                        dataSetTicket.Tables["Билеты"].Rows[r]["Дата покупки"] = dataGridViewTickets.Rows[r].Cells["Дата покупки"].Value; // ячейкам из базы данных под нужным индексом r присваиваем значения из dataGrid по этому же индексу r
                        dataSetTicket.Tables["Билеты"].Rows[r]["Код зала"] = dataGridViewTickets.Rows[r].Cells["Код зала"].Value;
                        dataSetTicket.Tables["Билеты"].Rows[r]["Ряд"] = dataGridViewTickets.Rows[r].Cells["Ряд"].Value;
                        dataSetTicket.Tables["Билеты"].Rows[r]["Место"] = dataGridViewTickets.Rows[r].Cells["Место"].Value;
                        dataSetTicket.Tables["Билеты"].Rows[r]["Код сотрудника"] = dataGridViewTickets.Rows[r].Cells["Код сотрудника"].Value;
                        dataSetTicket.Tables["Билеты"].Rows[r]["Код мероприятия"] = dataGridViewTickets.Rows[r].Cells["Код мероприятия"].Value;

                        sqlDataAdapterTicket.Update(dataSetTicket, "Билеты");


                        dataGridViewTickets.Rows[r].Cells[7].Value = "Delete";
                    }


                    ReloadDataTicket();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// метод срабатывает, когда происходит удаление строки

        private void ReloadDataTicket() // обновление бд
        {
            try
            {
                dataSetTicket.Tables["Билеты"].Clear();
                sqlDataAdapterTicket.Fill(dataSetTicket, "Билеты");

                dataGridViewTickets.DataSource = dataSetTicket.Tables["Билеты"];

                for (int i = 0; i < dataGridViewTickets.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridViewTickets[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTickets_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridViewTickets.Rows.Count - 2;

                    DataGridViewRow row = dataGridViewTickets.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridViewTickets[7, lastRow] = linkCell;

                    row.Cells["Command"].Value = "Insert"; // меняем тип действия кнопки на insert
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            ReloadDataTicket();
        }
        private void ExcelExportTickets() //экспорт в эксель билеты
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            int i, j;
            for (i = 0; i <= dataGridViewTickets.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridViewTickets.ColumnCount - 2; j++) // -2 для того, чобы не брать строчку с кнопкой delete 
                {
                    wsh.Cells[1, j + 1] = dataGridViewTickets.Columns[j].HeaderText.ToString(); // добавляет к данным название столбцов
                    wsh.Cells[i + 2, j + 1] = dataGridViewTickets[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
        }



        //////////////////////////////////////////////////////////////////////

        private void btnShowEvents_Click(object sender, EventArgs e)
        {
            LoadDataEvents();
            btnUpdateEvents.Enabled= true;
            btnExportEvents.Enabled= true;
        }

        private void btnUpdateEvents_Click(object sender, EventArgs e)
        {
            ReloadDataEvents();
        }
        private void btnExportEvents_Click(object sender, EventArgs e)
        {
            ExcelExportEvents();
        }

        private void dgvEvents_CellValueChanged(object sender, DataGridViewCellEventArgs e)// метод срабатывает, когда происходит добавление новой строки
        {
            try
            {
                if (newRowAdding == false) // проверка на режим редактирования
                {
                    int rowIndex = dgvEvents.SelectedCells[0].RowIndex; // получаем индекс строки выделенной ячейки

                    DataGridViewRow editingRow = dgvEvents.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEvents[8, rowIndex] = linkCell; // обращаемся к ячейке, где находится кнопка с действием

                    editingRow.Cells["Command"].Value = "Update"; // меняем тип действия кнопки на insert
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEvents_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dgvEvents.Rows.Count - 2;

                    DataGridViewRow row = dgvEvents.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEvents[8, lastRow] = linkCell;

                    row.Cells["Command"].Value = "Insert"; // меняем тип действия кнопки на insert
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    string task = dgvEvents.Rows[e.RowIndex].Cells[8].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex; // получаем индекс строки, которую нужно удалить

                            dgvEvents.Rows.RemoveAt(rowIndex); // удаление только из приложения

                            dataSetEvent.Tables["Мероприятия"].Rows[rowIndex].Delete(); // удаление из самой базы данных

                            sqlDataAdapterEvent.Update(dataSetEvent, "Мероприятия"); // обновление базы данных 
                        }
                    }

                    else if (task == "Insert")
                    {
                        int rowIndex = dgvEvents.Rows.Count - 2;

                        DataRow row = dataSetEvent.Tables["Мероприятия"].NewRow();

                        row["Код мероприятия"] = dgvEvents.Rows[rowIndex].Cells["Код мероприятия"].Value;
                        row["Наименование"] = dgvEvents.Rows[rowIndex].Cells["Наименование"].Value;
                        row["Описание"] = dgvEvents.Rows[rowIndex].Cells["Описание"].Value;
                        row["Код вида"] = dgvEvents.Rows[rowIndex].Cells["Код вида"].Value;
                        row["Дата"] = dgvEvents.Rows[rowIndex].Cells["Дата"].Value;
                        row["Время начала"] = dgvEvents.Rows[rowIndex].Cells["Время начала"].Value;
                        row["Длительность"] = dgvEvents.Rows[rowIndex].Cells["Длительность"].Value;
                        row["Стоимость"] = dgvEvents.Rows[rowIndex].Cells["Стоимость"].Value;

                        dataSetEvent.Tables["Мероприятия"].Rows.Add(row);

                        dataSetEvent.Tables["Мероприятия"].Rows.RemoveAt(dataSetEvent.Tables["Мероприятия"].Rows.Count - 2);

                        dgvEvents.Rows.RemoveAt(dgvEvents.Rows.Count - 2);

                        dgvEvents.Rows[e.RowIndex].Cells[8].Value = "Delete";

                        sqlDataAdapterEvent.Update(dataSetEvent, "Мероприятия");

                        newRowAdding = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex; // получаем индекс выделенной строки

                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Код мероприятия"] = dgvEvents.Rows[r].Cells["Код мероприятия"].Value;
                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Наименование"] = dgvEvents.Rows[r].Cells["Наименование"].Value; // ячейкам из базы данных под нужным индексом r присваиваем значения из dataGrid по этому же индексу r
                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Описание"] = dgvEvents.Rows[r].Cells["Описание"].Value;
                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Код вида"] = dgvEvents.Rows[r].Cells["Код вида"].Value;
                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Дата"] = dgvEvents.Rows[r].Cells["Дата"].Value;
                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Время начала"] = dgvEvents.Rows[r].Cells["Время начала"].Value;
                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Длительность"] = dgvEvents.Rows[r].Cells["Длительность"].Value;
                        dataSetEvent.Tables["Мероприятия"].Rows[r]["Стоимость"] = dgvEvents.Rows[r].Cells["Стоимость"].Value;

                        sqlDataAdapterEvent.Update(dataSetEvent, "Мероприятия");


                        dgvEvents.Rows[r].Cells[8].Value = "Delete";
                    }


                    ReloadDataEvents();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataEvents() // загрузка мероприятий из бд
        {
            try
            {
                dataBase.openConnection();
                sqlDataAdapterEvent = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] FROM [Мероприятия]", dataBase.GetConnection());

                sqlBuilderEvent = new SqlCommandBuilder(sqlDataAdapterEvent);

                sqlBuilderEvent.GetInsertCommand();
                sqlBuilderEvent.GetUpdateCommand();
                sqlBuilderEvent.GetDeleteCommand();

                dataSetEvent = new DataSet();

                sqlDataAdapterEvent.Fill(dataSetEvent, "Мероприятия");

                dgvEvents.DataSource = dataSetEvent.Tables["Мероприятия"];

                for (int i = 0; i < dgvEvents.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEvents[8, i] = linkCell;
                }
                dataBase.closeConnection();
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReloadDataEvents() // обновление бд мероприятия
        {
            try
            {
                dataSetEvent.Tables["Мероприятия"].Clear();
                sqlDataAdapterEvent.Fill(dataSetEvent, "Мероприятия");

                dgvEvents.DataSource = dataSetEvent.Tables["Мероприятия"];

                for (int i = 0; i < dgvEvents.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEvents[8, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExcelExportEvents() //экспорт в эксель билеты
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            int i, j;
            for (i = 0; i <= dgvEvents.RowCount - 2; i++)
            {
                for (j = 0; j <= dgvEvents.ColumnCount - 2; j++) // -2 для того, чобы не брать строчку с кнопкой delete 
                {
                    wsh.Cells[1, j + 1] = dgvEvents.Columns[j].HeaderText.ToString(); // добавляет к данным название столбцов
                    wsh.Cells[i + 2, j + 1] = dgvEvents[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
        }




        //////////////////////////////////////////////////////////////////////

        private void btnShowEmployers_Click(object sender, EventArgs e)
        {
            LoadDataEmployers();
            btnUpdateEmployers.Enabled = true;
            btnExportEmployers.Enabled = true;
        }
        private void btnExportEmployers_Click(object sender, EventArgs e)
        {
            ExcelExportEmployers();
        }

        private void btnUpdateEmployers_Click(object sender, EventArgs e)
        {
            ReloadDataEmployers();
        }

        private void LoadDataEmployers() // загрузка сотрудников из бд
        {
            try
            {
                dataBase.openConnection();
                sqlDataAdapterEmployer = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] FROM [Сотрудники]", dataBase.GetConnection());

                sqlBuilderEmployer = new SqlCommandBuilder(sqlDataAdapterEmployer);

                sqlBuilderEmployer.GetInsertCommand();
                sqlBuilderEmployer.GetUpdateCommand();
                sqlBuilderEmployer.GetDeleteCommand();

                dataSetEmployers = new DataSet();

                sqlDataAdapterEmployer.Fill(dataSetEmployers, "Сотрудники");

                dgvEmployers.DataSource = dataSetEmployers.Tables["Сотрудники"];

                for (int i = 0; i < dgvEmployers.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEmployers[9, i] = linkCell;
                }
                dataBase.closeConnection();
            }

            catch (Exception ex)
            {
                dataBase.closeConnection();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false) // проверка на режим редактирования
                {
                    int rowIndex = dgvEmployers.SelectedCells[0].RowIndex; // получаем индекс строки выделенной ячейки

                    DataGridViewRow editingRow = dgvEmployers.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEmployers[9, rowIndex] = linkCell; // обращаемся к ячейке, где находится кнопка с действием

                    editingRow.Cells["Command"].Value = "Update"; // меняем тип действия кнопки на insert
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployers_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dgvEmployers.Rows.Count - 2;

                    DataGridViewRow row = dgvEmployers.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEmployers[9, lastRow] = linkCell;

                    row.Cells["Command"].Value = "Insert"; // меняем тип действия кнопки на insert
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9)
                {
                    string task = dgvEmployers.Rows[e.RowIndex].Cells[9].Value.ToString();

                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex; // получаем индекс строки, которую нужно удалить

                            dgvEmployers.Rows.RemoveAt(rowIndex); // удаление только из приложения

                            dataSetEmployers.Tables["Сотрудники"].Rows[rowIndex].Delete(); // удаление из самой базы данных

                            sqlDataAdapterEmployer.Update(dataSetEmployers, "Сотрудники"); // обновление базы данных 
                        }
                    }

                    else if (task == "Insert")
                    {
                        int rowIndex = dgvEmployers.Rows.Count - 2;

                        DataRow row = dataSetEmployers.Tables["Сотрудники"].NewRow();

                        row["Код сотрудника"] = dgvEmployers.Rows[rowIndex].Cells["Код сотрудника"].Value;
                        row["Фамилия"] = dgvEmployers.Rows[rowIndex].Cells["Фамилия"].Value;
                        row["Имя"] = dgvEmployers.Rows[rowIndex].Cells["Имя"].Value;
                        row["Отчество"] = dgvEmployers.Rows[rowIndex].Cells["Отчество"].Value;
                        row["Адрес"] = dgvEmployers.Rows[rowIndex].Cells["Адрес"].Value;
                        row["Телефон"] = dgvEmployers.Rows[rowIndex].Cells["Телефон"].Value;
                        row["Код должности"] = dgvEmployers.Rows[rowIndex].Cells["Код должности"].Value;
                        row["Логин"] = dgvEmployers.Rows[rowIndex].Cells["Логин"].Value;
                        row["Пароль"] = dgvEmployers.Rows[rowIndex].Cells["Пароль"].Value;

                        dataSetEmployers.Tables["Сотрудники"].Rows.Add(row);

                        dataSetEmployers.Tables["Сотрудники"].Rows.RemoveAt(dataSetEmployers.Tables["Сотрудники"].Rows.Count - 2);

                        dgvEmployers.Rows.RemoveAt(dgvEmployers.Rows.Count - 2);

                        dgvEmployers.Rows[e.RowIndex].Cells[9].Value = "Delete";

                        sqlDataAdapterEmployer.Update(dataSetEmployers, "Сотрудники");

                        newRowAdding = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex; // получаем индекс выделенной строки

                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Код сотрудника"] = dgvEmployers.Rows[r].Cells["Код сотрудника"].Value;
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Фамилия"] = dgvEmployers.Rows[r].Cells["Фамилия"].Value; // ячейкам из базы данных под нужным индексом r присваиваем значения из dataGrid по этому же индексу r
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Имя"] = dgvEmployers.Rows[r].Cells["Имя"].Value;
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Отчество"] = dgvEmployers.Rows[r].Cells["Отчество"].Value;
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Адрес"] = dgvEmployers.Rows[r].Cells["Адрес"].Value;
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Телефон"] = dgvEmployers.Rows[r].Cells["Телефон"].Value;
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Код должности"] = dgvEmployers.Rows[r].Cells["Код должности"].Value;
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Логин"] = dgvEmployers.Rows[r].Cells["Логин"].Value;
                        dataSetEmployers.Tables["Сотрудники"].Rows[r]["Пароль"] = dgvEmployers.Rows[r].Cells["Пароль"].Value;

                        sqlDataAdapterEmployer.Update(dataSetEmployers, "Сотрудники");


                        dgvEmployers.Rows[r].Cells[9].Value = "Delete";
                    }


                    ReloadDataEmployers();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadDataEmployers() // обновление бд сотрудники
        {
            try
            {
                dataSetEmployers.Tables["Сотрудники"].Clear();
                sqlDataAdapterEmployer.Fill(dataSetEmployers, "Сотрудники");

                dgvEmployers.DataSource = dataSetEmployers.Tables["Сотрудники"];

                for (int i = 0; i < dgvEmployers.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dgvEmployers[9, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExcelExportEmployers() //экспорт в эксель сотрудники
        {
            Excel.Application exApp = new Excel.Application();

            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            int i, j;
            for (i = 0; i <= dgvEmployers.RowCount - 2; i++)
            {
                for (j = 0; j <= dgvEmployers.ColumnCount - 2; j++) // -2 для того, чобы не брать строчку с кнопкой delete 
                {
                    wsh.Cells[1, j + 1] = dgvEmployers.Columns[j].HeaderText.ToString(); // добавляет к данным название столбцов
                    wsh.Cells[i + 2, j + 1] = dgvEmployers[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HallPlaces hallPlaces = new HallPlaces();
            hallPlaces.Show();
        }
    }
}
