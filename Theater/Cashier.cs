using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Theater
{
    public partial class Cashier : Form
    {
        DataBase database = new DataBase();
        public UserData userData;
        SqlDataAdapter adapter = new SqlDataAdapter();

        System.Data.DataTable tableEvents = new System.Data.DataTable();

        System.Data.DataTable tableHalls = new System.Data.DataTable();

        System.Data.DataTable tableEventTypes = new System.Data.DataTable();
       
        System.Data.DataTable tableSelectedEventTypes = new System.Data.DataTable();

        string eventID;
        string hallID;
        string eventTypeID;
        bool isEdentifyTicket;
       

        DateTime dateNow = DateTime.Now;

        public Cashier(UserData userData)
        {
            InitializeComponent();
            this.userData = userData;
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            ShowUserData();
            getEventOrder();
            getHalls();
            /*getEventTypes();*/
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

        private void getEventOrder() // вывод мероприятий в comboBox
        {
            database.openConnection();

            string sql = $"select [Код мероприятия], Наименование from Мероприятия";
            
            SqlCommand cmdGetEvent = new SqlCommand(sql, database.GetConnection());

            adapter.SelectCommand = cmdGetEvent;
            adapter.Fill(tableEvents);

            SqlDataReader reader = cmdGetEvent.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                eventID = reader[0].ToString();
            }
            reader.Close();

            comboBoxEvents.DataSource = tableEvents;
            comboBoxEvents.DisplayMember = "Наименование";
            comboBoxEvents.ValueMember = "Код мероприятия";
        }

        private void getSelectedEvent() // получение кода выбранного мероприятия
        {
            database.openConnection();

            string sql = $"select [Код мероприятия], Наименование from Мероприятия where Наименование = @nameSelectedEvent";

            SqlCommand cmdGetSelectedEvent = new SqlCommand(sql, database.GetConnection());
            cmdGetSelectedEvent.Parameters.Add(new SqlParameter("@nameSelectedEvent", comboBoxEvents.Text));

            SqlDataReader reader = cmdGetSelectedEvent.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                eventID = reader[0].ToString();
            }

            reader.Close();
        }

        private void getHalls() // вывод залов в comboBox
        {
            database.openConnection();

            string sql = $"select [Код зала], Наименование from Залы";

            SqlCommand cmdGetHalls = new SqlCommand(sql, database.GetConnection());

            adapter.SelectCommand = cmdGetHalls;
            adapter.Fill(tableHalls);

            SqlDataReader reader = cmdGetHalls.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                hallID = reader[0].ToString();
            }
            reader.Close();

            comboBoxHalls.DataSource = tableHalls;
            comboBoxHalls.DisplayMember = "Наименование";
            comboBoxHalls.ValueMember = "Код зала";
        }
        private void getSelectedHalls() // получение кода выбранного зала
        {
            database.openConnection();

            string sql = $"select [Код зала], Наименование from Залы where Наименование = @nameSelectedHall";

            SqlCommand cmdGetSelectedHall = new SqlCommand(sql, database.GetConnection());
            cmdGetSelectedHall.Parameters.Add(new SqlParameter("@nameSelectedHall", comboBoxHalls.Text));

            SqlDataReader reader = cmdGetSelectedHall.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                hallID = reader[0].ToString();
            }

            reader.Close();
        }

        /*private void getEventTypes() // вывод !видов! мероприятий в comboBox
        {
            database.openConnection();

            string sql = $"select [Код вида], Наименование from Вид";

            SqlCommand cmdGetEventType = new SqlCommand(sql, database.GetConnection());

            adapter.SelectCommand = cmdGetEventType;
            adapter.Fill(tableEventTypes);

            SqlDataReader reader = cmdGetEventType.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                eventTypeID = reader[0].ToString();
            }
            reader.Close();

            cmbEventTypes.DataSource = tableEventTypes;
            cmbEventTypes.DisplayMember = "Наименование";
            cmbEventTypes.ValueMember = "Код вида";
        }*/

        /*private void getSelectedEventType() // вывод !видов! мероприятий в comboBox
        {
            database.openConnection();

            string sql = $"select [Код вида], Наименование from Вид where Наименование = @nameEventType";

            SqlCommand cmdGetSelectedEventType = new SqlCommand(sql, database.GetConnection());
            cmdGetSelectedEventType.Parameters.Add(new SqlParameter("@nameEventType", cmbEventTypes.Text));

            SqlDataReader reader = cmdGetSelectedEventType.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                eventTypeID = reader[0].ToString();
            }

            reader.Close();
        }*/

        private void addTicket() //добавление записи в бд Билеты
        {
            if(comboBoxEvents.Text != "" && comboBoxHalls.Text != "" && txtRowNumber.Text != "" && txtPlaceNumber.Text != "")
            {
                if (Convert.ToInt32(txtRowNumber.Text) < 5 || Convert.ToInt32(txtPlaceNumber.Text) < 10)
                {
                    getSelectedEvent();//получение id выбранного мероприятия
                    getSelectedHalls();// залы получение
                    checkTicket();

                    if (isEdentifyTicket)
                    {
                        try
                        {
                            string sql = $"INSERT INTO Билеты([Дата покупки], [Код зала], Ряд, Место, [Код сотрудника], [Код мероприятия])VALUES" +
                                "('" + dateNow + "', '" + hallID + "', '" + txtRowNumber.Text + "', '" + txtPlaceNumber.Text + "', '" + userData.UserID + "', '" + eventID + "' )";

                            database.openConnection();

                            if (database.GetConnection().State != ConnectionState.Open)
                                database.openConnection();

                            SqlCommand command = new SqlCommand(sql, database.GetConnection());
                            int x = command.ExecuteNonQuery();

                            database.closeConnection();

                            txtRowNumber.Text = "";
                            txtPlaceNumber.Text = "";

                            MessageBox.Show(x.ToString() + " запись добавлена.");
                            database.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            database.closeConnection();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такой билет уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели несуществующий ряд или место");
                }

            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
            
        }

        private void checkTicket()
        {
            database.openConnection();

            string sql = $"select [Код билета], [Код зала], Ряд, Место, [Код мероприятия] from Билеты where " +
                $"[Код зала] = @idHall and Ряд = @row and Место = @place and [Код мероприятия] = @eventId";

            SqlCommand cmdGetSelectedTickets = new SqlCommand(sql, database.GetConnection());
            cmdGetSelectedTickets.Parameters.Add(new SqlParameter("@idHall", hallID));
            cmdGetSelectedTickets.Parameters.Add(new SqlParameter("@row", txtRowNumber.Text));
            cmdGetSelectedTickets.Parameters.Add(new SqlParameter("@place", txtPlaceNumber.Text));
            cmdGetSelectedTickets.Parameters.Add(new SqlParameter("@eventId", eventID));

            SqlDataReader reader = cmdGetSelectedTickets.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                isEdentifyTicket = false;
            }
            else
            {
                isEdentifyTicket = true;
            }

            reader.Close();
        }

       /* private void addEvent()// добавление записи в бд Мероприятия
        {
            if (txtEventName.Text != "" && cmbEventTypes.Text != ""
                && txtEventDesc.Text != "" && txtEventDate.Text != ""
                && txtEventStartTime.Text != "" && txtEventPrice.Text != ""
                && txtEventLength.Text != "")
            {
                try
                {
                    getSelectedEventType();// получаем выбранный вид мероприятия

                    var dateEvent = Convert.ToDateTime(txtEventDate.Text);

                    string sql = $"INSERT INTO Мероприятия(Наименование, Описание, [Код вида], Дата, [Время начала], Длительность, Стоимость)VALUES" +
                        "('" + txtEventName.Text + "', '" 
                        + txtEventDesc.Text + "', '" 
                        + eventTypeID + "',  @dateEvent, '" 
                        + txtEventStartTime.Text + "', '" 
                        + txtEventLength.Text + "', '" 
                        + txtEventPrice.Text + "' )";

                    database.openConnection();

                    if (database.GetConnection().State != ConnectionState.Open)
                        database.openConnection();

                    SqlCommand command = new SqlCommand(sql, database.GetConnection());
                    command.Parameters.Add(new SqlParameter("@dateEvent", dateEvent));
                    int x = command.ExecuteNonQuery();

                    database.closeConnection();

                    txtEventName.Text = "";
                    cmbEventTypes.Text = "";
                    txtEventDesc.Text = "";
                    txtEventDate.Text = "";
                    txtEventStartTime.Text = "";
                    txtEventPrice.Text = "";
                    txtEventLength.Text = "";

                    MessageBox.Show(x.ToString() + " запись добавлена.");
                }
                catch (Exception ex)
                {
                    database.closeConnection();
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }*/

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            addTicket();
        }

        private void btnEventAdd_Click(object sender, EventArgs e)
        {
          /*  addEvent();*/
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Cashier_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRearchRow_Click(object sender, EventArgs e)
        {
            if (comboBoxEvents.Text != "" && comboBoxHalls.Text != "" && txtRowNumber.Text != "")
            {
                dataGridViewEmployers.Rows.Clear();

                getSelectedEvent();//получение id выбранного мероприятия
                getSelectedHalls();// залы получение

                string rowNumber = txtRowNumber.Text;
                try
                {
                    database.openConnection();

                    string query = $"SELECT Место FROM Билеты where [Код мероприятия] = '{eventID}' and [Код зала] = '{hallID}' and Ряд = '{rowNumber}' ";

                    SqlCommand command = new SqlCommand(query, database.GetConnection());

                    SqlDataReader reader = command.ExecuteReader();

                    List<string[]> data = new List<string[]>();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            data.Add(new string[1]);

                            data[data.Count - 1][0] = reader[0].ToString();
                        }

                        reader.Close();

                        database.closeConnection();

                        foreach (string[] s in data)
                            dataGridViewEmployers.Rows.Add(s);
                    }
                    else
                    {
                        MessageBox.Show("Занятых мест не найдено.");
                    }
                }

                catch (Exception ex)
                {
                    database.closeConnection();
                    MessageBox.Show("Ошибка");
                }
            }
            else 
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void bntShowPlaces_Click(object sender, EventArgs e)
        {
            HallPlaces hallPlaces = new HallPlaces();
            hallPlaces.Show();
        }

        private void btnShowEvents_Click(object sender, EventArgs e)
        {
            dataGridViewEvent.Rows.Clear();
            LoadDataEvents();
        }

        private void LoadDataEvents() // загрузка данных из мероприятия
        {
            try
            {
                database.GetConnection();
                database.openConnection();

                string query = "SELECT [Код мероприятия], Мероприятия.Наименование, Описание, Вид.Наименование, Дата, [Время начала], Длительность, Стоимость FROM " +
                    "Мероприятия inner join Вид on Мероприятия.[Код вида] = Вид.[Код вида]";

                SqlCommand command = new SqlCommand(query, database.GetConnection());

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

                database.closeConnection();

                foreach (string[] s in data)
                    dataGridViewEvent.Rows.Add(s);
            }

            catch (Exception ex)
            {
                database.closeConnection();
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
