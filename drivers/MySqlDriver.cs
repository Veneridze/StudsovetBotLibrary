using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudsovetBot.interfaces;
using System.Data;

namespace StudsovetBot.drivers
{
    internal class MySqlDriver : Idatabasebdriver
    {
        private string ip;
        private string database;
        private string login;
        private string pass;
        private uint port;
        private MySqlConnection conn;
        public MySqlDriver(string ip, string database, string login, string pass, uint port = 3306)
        {
            this.ip = ip;
            this.port = port;
            this.login = login;
            this.database = database;
            this.pass = pass;
            if(!this.ConnectToDb())
            {
                throw new Exception("Не удалось произвести подключение к базе данных");
            }
        }
        private bool ConnectToDb()
        {
            // строка подключения к БД
            // создаём объект для подключения к БД
            conn = new MySqlConnection($"Server={ip};Port={port};Database={database};Uid={login};password={pass};");
            // устанавливаем соединение с БД
            conn.Open();
            //Проверка статуса соединения с БД
            return (conn.State == System.Data.ConnectionState.Open) ? true : false;

        }
        public IDataReader GetInfo(string query)
        {
            //if(conn.State == System.Data.ConnectionState.Closed)
            //{
                //conn.Open();
            //} 
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            MySqlDataReader result = command.ExecuteReader();
            //conn.Close();
            //command.Dispose();
            //command.Dispose();
            //result.Close();
            return result;

        }
    }
}
