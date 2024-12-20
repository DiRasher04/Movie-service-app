using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_service
{
    public class Administrator
    {
        private int administrator_id;
        private string login;
        private string hash_password;
        private string firstname;
        private string lastname;
        private string patronymic;
        private DateTime birthday_date;
        private DateTime registration_date;
        public Administrator() { }
        public void Registration(string login, string password, string firstname, string lastname, string patronimyc, DateTime birthday_date)
        {
            this.login = login;
            int temp = password.GetHashCode();
            this.hash_password = temp.ToString();
            this.firstname = firstname;
            this.lastname = lastname;
            this.patronymic = patronimyc;
            DateTime current_date = DateTime.Now;
            registration_date = current_date;
            ConnectionDB connectionDB = new ConnectionDB();
            connectionDB.InsertDB("INSERT INTO public.\"Administrator\" (login, hash_password, firstname, lastname, patronymic, birthday_date, registration_date)  VALUES ('" + login + "', '" + hash_password + "', '" + firstname + "', '" + lastname + "', '" + patronimyc + "', '" + birthday_date + "', '" + registration_date + "');");

        }
        public bool CheckPassword(string login_, string password_)
        {
            string hash_password_ = password_.GetHashCode().ToString();
            ConnectionDB connectionDB = new ConnectionDB();
            DataTable dataTable = connectionDB.SelectDB("SELECT * FROM public.\"Administrator\" WHERE (login = '" + login_ + "' AND hash_password = '" + hash_password_ + "')");
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
                userState.currentId = Convert.ToInt32(connectionDB.SelectDB("SELECT administrator_id FROM public.\"Administrator\" WHERE (login = '" + login + "' AND hash_password = '" + hash_password + "')").Rows[0]["administrator_id"]);
                userState.EntryAdministrator();
            }
        }

        public void Exit()
        {

        }

        public void ChangeLogin()
        {

        }

        public void ChangePassword()
        {

        }

        public void CreateAdministrator()
        {

        }

        public void CreateContentPartner()
        {

        }

        public void DeleteAdministrator()
        {

        }

        public void DeleteContentPartner()
        {

        }
    }
}