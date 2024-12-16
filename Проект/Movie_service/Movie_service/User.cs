using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Movie_service.UserState;

namespace Movie_service
{
    public class User
    {
        private int user_id;
        private string login;
        private string hash_password;
        private string registration_date;

        public void Registration(string login, string password)
        {
            this.login = login;
            int temp = password.GetHashCode();
            this.hash_password = temp.ToString();
            DateTime current_date = DateTime.Now;
            registration_date = current_date.ToString();
            ConnectionDB connectionDB = new ConnectionDB();
            connectionDB.InsertDB("INSERT INTO public.\"User\" (login, hash_password, registration_date)  VALUES ('dirasher', '1234', '2024-01-01'),('" + login + "', '" + hash_password + "', '" + registration_date + "');");
        }
        public bool CheckPassword(string login_, string password_)
        {
            string hash_password_ = password_.GetHashCode().ToString();
            ConnectionDB connectionDB = new ConnectionDB();
            DataTable dataTable = connectionDB.SelectDB("SELECT * FROM public.\"User\" WHERE (login = '" + login_ + "' AND hash_password = '" + hash_password_ + "')");
            if(dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Entry(string login, string password)
        {
            if (CheckPassword(login, password))
            {
                UserState userState = new UserState();
                userState.EntryUser();
            }
        }

        public void Exit()
        {
            // Логика выхода
        }

        public void ChangeLogin()
        {
            // Логика изменения логина
        }

        public void ChangePassword()
        {
            // Логика изменения пароля
        }
    }
}
