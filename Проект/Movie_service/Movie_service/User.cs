using System;
using System.Data;

namespace Movie_service
{
    public class User
    {
        private int user_id;
        private string login;
        private string hash_password;
        private DateTime registration_date;

        public void Registration(string login, string password)
        {
            this.login = login;
            int temp = password.GetHashCode();
            this.hash_password = temp.ToString();
            DateTime current_date = DateTime.Now;
            registration_date = current_date;
            ConnectionDB connectionDB = new ConnectionDB();
            connectionDB.InsertDB("INSERT INTO public.\"User\" (login, hash_password, registration_date)  VALUES ('" + login + "', '" + hash_password + "', '" + registration_date + "');");
        }
        public bool CheckPassword(string login_, string password_)
        {
            string hash_password_ = password_.GetHashCode().ToString();
            ConnectionDB connectionDB = new ConnectionDB();
            DataTable dataTable = connectionDB.SelectDB("SELECT * FROM public.\"User\" WHERE (login = '" + login_ + "' AND hash_password = '" + hash_password_ + "')");
            if (dataTable.Rows.Count > 0)
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
                ConnectionDB connectionDB = new ConnectionDB();
                string hash_password = password.GetHashCode().ToString();
                userState.currentId = Convert.ToInt32((connectionDB.SelectDB("SELECT user_id FROM public.\"User\" WHERE (login = '" + login + "' AND hash_password = '" + hash_password + "')")).Rows[0]["user_id"]);
                userState.EntryUser();
            }
        }

        public void Exit()
        {
            UserState userState = new UserState();
            userState.Exit();
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
