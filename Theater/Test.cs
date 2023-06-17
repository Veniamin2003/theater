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

namespace Theater
{
    public partial class Test : Form
    {

        DataBase database = new DataBase();
        string eventTypeID;
        public Test()
        {
            InitializeComponent();
        }

        private void btnEventAdd_Click(object sender, EventArgs e)
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
    }
}
