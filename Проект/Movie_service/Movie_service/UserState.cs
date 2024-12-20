using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Movie_service
{
    internal class UserState
    {
        public States userState;
        public int currentId;
        public enum States
        {
            NotAvtorized,
            AvtorizedUser,
            AvtorizedAdministrator,
            AvtorizedContentPartner
        }


        public void Exit()
        {
            WriteToFileState("NotAvtorized");
            WriteToFileId("0");
            userState = States.NotAvtorized;
            currentId = 0;
        }
        public void EntryUser()
        {
            WriteToFileState("AvtorizedUser");
            WriteToFileId(currentId.ToString());
            userState = States.AvtorizedUser;
        }
        public void EntryAdministrator()
        {
            WriteToFileState("AvtorizedAdministrator");
            WriteToFileId(currentId.ToString());
            userState = States.AvtorizedAdministrator;
        }

        public void EntryContentPartner()
        {
            WriteToFileState("AvtorizedContentPartner");
            WriteToFileId(currentId.ToString());
            userState = States.AvtorizedContentPartner;
        }
        public void CheckState()
        {
            userState = ParseToState(ReadFileState());
            currentId = int.Parse(ReadFileId());
        }

        public string ParseToString()
        {
            switch (userState)
            {
                case States.NotAvtorized:
                    return "NotAvtorized";
                case States.AvtorizedUser:
                    return "AvtorizedUser";
                case States.AvtorizedAdministrator:
                    return "AvtorizedAdministrator";
                case States.AvtorizedContentPartner:
                    return "AvtorizedContentPartner";
                default:
                    throw new Exception("Ошибка состояния");
            }
        }

        public States ParseToState(string str)
        {
            switch (str)
            {
                case "NotAvtorized":
                    return States.NotAvtorized;
                case "AvtorizedUser":
                    return States.AvtorizedUser;
                case "AvtorizedAdministrator":
                    return States.AvtorizedAdministrator;
                case "AvtorizedContentPartner":
                    return States.AvtorizedContentPartner;
                default:
                    throw new Exception("Ошибка состояния");
            }
        }

        public static void WriteToFileState(string newContent)
        {
            string filePath = "C:\\Лабораторные работы\\5 Семестр\\Системы управления базами данных\\Курсовая работа\\Проект\\Movie_service\\Movie_service\\State.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8)) 
                {
                    writer.Write(newContent);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
        public static void WriteToFileId(string newContent)
        {
            string filePath = "C:\\Лабораторные работы\\5 Семестр\\Системы управления базами данных\\Курсовая работа\\Проект\\Movie_service\\Movie_service\\CurrentId.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.Write(newContent);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
        public static string ReadFileState()
        {
            string filePath = "C:\\Лабораторные работы\\5 Семестр\\Системы управления базами данных\\Курсовая работа\\Проект\\Movie_service\\Movie_service\\State.txt";
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл {filePath} не найден.");
                    return null;
                }

                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: файл не найден: {ex.Message}");
                return null;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: папка не найдена: {ex.Message}");
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
                return null;
            }
        }
        public static string ReadFileId()
        {
            string filePath = "C:\\Лабораторные работы\\5 Семестр\\Системы управления базами данных\\Курсовая работа\\Проект\\Movie_service\\Movie_service\\CurrentId.txt";
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл {filePath} не найден.");
                    return null;
                }

                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: файл не найден: {ex.Message}");
                return null;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: папка не найдена: {ex.Message}");
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
                return null;
            }
        }
    }
}
