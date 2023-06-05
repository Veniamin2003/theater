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
    public partial class Login : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        SqlCommand command = new SqlCommand();
        UserData userData = new UserData();

        DataBase database = new DataBase();


        string loginUser;
        string passUser;

        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            database.openConnection();

            string querystring = $"select [Код сотрудника], Логин, Пароль from Сотрудники where Логин = '" + textBoxLogin.Text + "' or Пароль = '" + textBoxPassword.Text + "'";
            string sql = $"select Сотрудники.[Код сотрудника], Имя, Фамилия, Наименование, Логин, Пароль from Сотрудники inner join Должности on Сотрудники.[Код должности] = Должности.[Код должности] where Логин = '" + textBoxLogin.Text + "' or Пароль = '" + textBoxPassword.Text + "'";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            SqlCommand commandGetUserData = new SqlCommand(sql, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            try
            {
                if (table.Rows.Count == 1)
                {
                    SqlDataReader reader = commandGetUserData.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        userData.UserID = reader[0].ToString();
                        userData.UserFName = reader[1].ToString();
                        userData.UserLNmae = reader[2].ToString();
                        userData.UserWorkPosition = reader[3].ToString();
                        loginUser = reader[4].ToString();
                        passUser = reader[5].ToString();
                    }
                    reader.Close();
                }


                if (passUser == textBoxPassword.Text && loginUser == textBoxLogin.Text)
                {

                    if (userData.UserWorkPosition == "Кассир")
                    {
                        this.Hide();
                        Cashier cashier = new Cashier(userData);
                        cashier.Show();
                    }
                    else if (userData.UserWorkPosition == "Бухгалтер")
                    {
                        this.Hide();
                        Booker booker = new Booker(userData);
                        booker.Show();
                    }
                    else if (userData.UserWorkPosition == "Администратор")
                    {
                        this.Hide();
                        Admin admin = new Admin(userData);
                        admin.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели неправильный пароль или логин! ", "Ошибка!");
                }
                database.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверные данные!", "Ошибка!", MessageBoxButtons.OK);
            }
        }
    }
}
