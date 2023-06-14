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

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        private bool newRowAdding = false;

        public Admin(UserData userData)
        {
            InitializeComponent();
            this.userData = userData;
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

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
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] FROM [Билеты]", dataBase.GetConnection());

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Билеты");

                dataGridViewTickets.DataSource = dataSet.Tables["Билеты"];

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

                            dataSet.Tables["Билеты"].Rows[rowIndex].Delete(); // удаление из самой базы данных

                            sqlDataAdapter.Update(dataSet, "Билеты"); // обновление базы данных 
                        }
                    }

                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridViewTickets.Rows.Count - 2;

                        DataRow row = dataSet.Tables["Билеты"].NewRow();

                        row["Код билета"] = dataGridViewTickets.Rows[rowIndex].Cells["Код билета"].Value;
                        row["Дата покупки"] = dataGridViewTickets.Rows[rowIndex].Cells["Дата покупки"].Value;
                        row["Код зала"] = dataGridViewTickets.Rows[rowIndex].Cells["Код зала"].Value;
                        row["Ряд"] = dataGridViewTickets.Rows[rowIndex].Cells["Ряд"].Value;
                        row["Место"] = dataGridViewTickets.Rows[rowIndex].Cells["Место"].Value;
                        row["Код сотрудника"] = dataGridViewTickets.Rows[rowIndex].Cells["Код сотрудника"].Value;
                        row["Код мероприятия"] = dataGridViewTickets.Rows[rowIndex].Cells["Код мероприятия"].Value;

                        dataSet.Tables["Билеты"].Rows.Add(row);

                        dataSet.Tables["Билеты"].Rows.RemoveAt(dataSet.Tables["Билеты"].Rows.Count - 2);

                        dataGridViewTickets.Rows.RemoveAt(dataGridViewTickets.Rows.Count - 2);

                        dataGridViewTickets.Rows[e.RowIndex].Cells[7].Value = "Delete";

                        sqlDataAdapter.Update(dataSet, "Билеты");

                        newRowAdding = false;
                    }

                    else if (task == "Update")
                    {
                        int r = e.RowIndex; // получаем индекс выделенной строки

                        dataSet.Tables["Билеты"].Rows[r]["Код билета"] = dataGridViewTickets.Rows[r].Cells["Код билета"].Value;
                        dataSet.Tables["Билеты"].Rows[r]["Дата покупки"] = dataGridViewTickets.Rows[r].Cells["Дата покупки"].Value; // ячейкам из базы данных под нужным индексом r присваиваем значения из dataGrid по этому же индексу r
                        dataSet.Tables["Билеты"].Rows[r]["Код зала"] = dataGridViewTickets.Rows[r].Cells["Код зала"].Value;
                        dataSet.Tables["Билеты"].Rows[r]["Ряд"] = dataGridViewTickets.Rows[r].Cells["Ряд"].Value;
                        dataSet.Tables["Билеты"].Rows[r]["Место"] = dataGridViewTickets.Rows[r].Cells["Место"].Value;
                        dataSet.Tables["Билеты"].Rows[r]["Код сотрудника"] = dataGridViewTickets.Rows[r].Cells["Код сотрудника"].Value;
                        dataSet.Tables["Билеты"].Rows[r]["Код мероприятия"] = dataGridViewTickets.Rows[r].Cells["Код мероприятия"].Value;

                        sqlDataAdapter.Update(dataSet, "Билеты");


                        dataGridViewTickets.Rows[r].Cells[7].Value = "Delete";
                    }


                    ReloadData();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }// метод срабатывает, когда происходит удаление строки

        private void ReloadData() // обновление бд
        {
            try
            {
                dataSet.Tables["Билеты"].Clear();
                sqlDataAdapter.Fill(dataSet, "Билеты");

                dataGridViewTickets.DataSource = dataSet.Tables["Билеты"];

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
            ReloadData();
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
                    wsh.Cells[i + 1, j + 1] = dataGridViewTickets[j, i].Value.ToString(); // заносим данные из грида в таблицу, которая пойдет в эксель
                }
            }

            exApp.Visible = true; // чтобы после завершения работы запустился Excel
        }

        
    }
}
