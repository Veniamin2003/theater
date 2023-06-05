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

        DataTable tableEvents = new DataTable();
        DataTable tableHalls = new DataTable();
        DataTable tableEventTypes = new DataTable();
        DataTable tableSelectedEventTypes = new DataTable();

        string eventID;
        string hallID;
        string eventTypeID;
       

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
            getEventTypes();
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

        private void getEventTypes() // вывод !видов! мероприятий в comboBox
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
        }

        private void getSelectedEventType() // вывод !видов! мероприятий в comboBox
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
        }

        private void addTicket() //добавление записи в бд Билеты
        {
            if(comboBoxEvents.Text != "" && comboBoxHalls.Text != "" && txtRowNumber.Text != "" && txtPlaceNumber.Text != "")
            {
                try
                {
                    getSelectedEvent();//получение id выбранного мероприятия
                    getSelectedHalls();// зал=ы получение

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
                MessageBox.Show("Заполните все поля!");
            }
            
        }

        private void addEvent()// добавление записи в бд Мероприятия
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
        }

        

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            addTicket();
        }

        private void btnEventAdd_Click(object sender, EventArgs e)
        {
            addEvent();
        }
    }
}
