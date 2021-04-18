using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.Data;

namespace TDPlugin
{
    class BD_manager
    {
        MySqlConnection connection;
        DataTable table;
        MySqlDataAdapter adapter;

        public BD_manager(string host, string port, string username, string password, string nameBD)
        {
            string str = String.Format("server={0};port={1};username={2};password={3};database={4}", 
                host, port, username, password, nameBD);
            connection = new MySqlConnection(str);
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public bool search_exist_nametd(string nameTD)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `technical_depths` WHERE `Name` = @nTD", connection);
            command.Parameters.Add("@nTD", MySqlDbType.VarChar).Value = nameTD;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }

        public void add_new_record_td(string nameTD, int value, string comment)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `technical_depths` " +
                "(`Name`, `avg_Value`) VALUES (@nTD, 0)", connection);
            command.Parameters.Add("@nTD", MySqlDbType.VarChar).Value = nameTD;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();

            add_new_record_comment(nameTD, value, comment);
        }

        public void add_new_record_comment(string nameTD, int value, string comment)
        {
            int TDid = search_TD_id(nameTD);

            MySqlCommand command = new MySqlCommand("INSERT INTO `comments` (`TD_id`, `value`, `comment`) VALUES(@id, @val, @text)", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = TDid;
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = value;
            command.Parameters.Add("@text", MySqlDbType.VarChar).Value = comment;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void delete_record_td(string nameTD)
        {
            int TDid = search_TD_id(nameTD);

            MySqlCommand command1 = new MySqlCommand("DELETE FROM `comments` WHERE `TD_id` = @id", connection);
            command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = TDid;

            MySqlCommand command2 = new MySqlCommand("DELETE FROM `technical_depths` WHERE `TD_id` = @nTD", connection);
            command2.Parameters.Add("@nTD", MySqlDbType.VarChar).Value = TDid;

            OpenConnection();
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            CloseConnection();
        }

        public void delete_record_comment(string nameTD, string comment)
        {
            int TDid = search_TD_id(nameTD);

            MySqlCommand command = new MySqlCommand("DELETE FROM `comments` WHERE `TD_id` = @id AND `comment` = @com", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = TDid;
            command.Parameters.Add("@com", MySqlDbType.VarChar).Value = comment;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public (string name, int val) get_TD(int i)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `technical_depths` ORDER BY avg_Value DESC", connection);
            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i)
                return (name: table.Rows[i][1].ToString(), val: (int)table.Rows[i][2]);
            else return (name:"", val: -1);
        }

        public string get_comment(string nameTD, int i)
        {
            int TDid = search_TD_id(nameTD);

            MySqlCommand command = new MySqlCommand("SELECT * FROM `comments` WHERE `TD_id` = @id", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = TDid;
            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i)
                return table.Rows[i][3].ToString();
            else return "";
        }

        public void recount_avg_value(string nameTD)
        {
            int TDid = search_TD_id(nameTD);

            MySqlCommand command = new MySqlCommand("SELECT * FROM `comments` WHERE `TD_id` = @id", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = TDid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            int val = 0;
            for (int i = 0;  i < table.Rows.Count; i++)
            {
                val += (int)table.Rows[i].ItemArray[2];
            }
            val /= table.Rows.Count;

            command = new MySqlCommand("UPDATE `technical_depths` SET `avg_Value` = @val WHERE `technical_depths`.`TD_id` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = val;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = TDid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public int search_TD_id(string nameTD)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `technical_depths` WHERE `Name` = @nTD", connection);
            command.Parameters.Add("@nTD", MySqlDbType.VarChar).Value = nameTD;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return (int)table.Rows[0][0];
        }
    }
}
