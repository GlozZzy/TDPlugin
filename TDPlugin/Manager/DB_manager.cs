using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using MySql.Data.MySqlClient;
using System.Data;
using TDPlugin.ClassTables;
using System.Data.SqlClient;
using System.Net.Sockets;
using TDPlugin.DBclasses;

namespace TDPlugin.Tools
{
    class DB_manager : IDBManager
    {
        MySqlConnection connection;
        DataTable table;
        MySqlDataAdapter adapter;

        comments_table comments_ = new comments_table("comments", "id_comm", "comment", "value", "id_mark");
        marks_table marks_ = new marks_table("marks", "id_mark", "name", "id_file", "avg_val");
        filenames_table filenames_ = new filenames_table("filenames", "id_file", "name", "avg_val");

        public DB_manager(string host, string port, string username, string password, string nameBD)
        {
            string str = String.Format("server={0};port={1};username={2};password={3};database={4}", 
                host, port, username, password, nameBD);
            connection = new MySqlConnection(str);
        }


        public bool check_connection()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
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




        public bool search_exist_file(string filename)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + filenames_.tab_title + 
                "` WHERE `" + filenames_.col_name + "` = @value", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = filename;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }

        public bool search_exist_mark(string filename, string markname)
        {
            int Fid = search_filename_id(filename);

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + marks_.tab_title +
                "` WHERE `" + marks_.col_name + "` = @value AND `" + marks_.col_foreign + "` = @id", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = markname;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }



        // Add
        public void add_new_record_file(string filename)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `" + filenames_.tab_title + "` (`"
                + filenames_.col_name + "`, `"+ filenames_.col_avg + "`) VALUES (@value, 1)", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = filename;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void add_new_record_mark(string filename, string markname)
        {
            int Fid = search_filename_id(filename);

            MySqlCommand command = new MySqlCommand("INSERT INTO `"+ marks_.tab_title + "` (`" 
                + marks_.col_name + "`, `"+ marks_.col_foreign + "`, `" + marks_.col_avg 
                + "`) VALUES(@cur_name, @cur_id, 1)", connection);
            command.Parameters.Add("@cur_name", MySqlDbType.VarChar).Value = markname;
            command.Parameters.Add("@cur_id", MySqlDbType.VarChar).Value = Fid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void add_new_record_comment(string filename, string markname, int val, string text)
        {
            int Fid = search_filename_id(filename);
            int Mid = search_mark_id(Fid, markname);

            MySqlCommand command = new MySqlCommand("INSERT INTO `"+ comments_.tab_title + "` (`" 
                + comments_.col_foreign + "`, `"+ comments_.col_val + "`, `"+ comments_.col_text 
                + "`) VALUES(@cur_fid, @cur_val, @cur_text)", connection);
            command.Parameters.Add("@cur_fid", MySqlDbType.VarChar).Value = Mid;
            command.Parameters.Add("@cur_val", MySqlDbType.VarChar).Value = val;
            command.Parameters.Add("@cur_text", MySqlDbType.VarChar).Value = text;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }



        // Edit
        public void edit_record_file(Filename filename, string Ename) 
        {
            int Fid = filename.id;

            MySqlCommand command = new MySqlCommand("UPDATE `" + filenames_.tab_title + "` SET `" + filenames_.col_name +
               "` = @val WHERE `" + filenames_.tab_title + "`.`" + filenames_.col_id + "` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = Ename;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void edit_record_mark(Mark markname, string Ename) 
        {
            int Mid = markname.id;

            MySqlCommand command = new MySqlCommand("UPDATE `" + marks_.tab_title + "` SET `" + marks_.col_name +
               "` = @val WHERE `" + marks_.tab_title + "`.`" + marks_.col_id + "` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = Ename;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void edit_record_comment(Comment comm, string Etext) 
        {
            MySqlCommand command = new MySqlCommand("UPDATE `" + comments_.tab_title + "` SET `" + comments_.col_text +
               "` = @val WHERE `" + comments_.tab_title + "`.`" + comments_.col_id + "` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = Etext;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = comm.id;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }



        // Delete
        public void delete_record_file(Filename filename)
        {
            MySqlCommand command1;
            MySqlCommand command2;

            int Fid = filename.id;

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + marks_.tab_title +
                "` WHERE `" + marks_.col_foreign + "` = @value", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = Fid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var j = (int)table.Rows[i][0];
                command1 = new MySqlCommand("DELETE FROM `" + comments_.tab_title +
                "` WHERE `" + comments_.col_foreign + "` = @id", connection);
                command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = j;

                command2 = new MySqlCommand("DELETE FROM `" + marks_.tab_title +
                "` WHERE `" + marks_.col_id + "` = @id", connection);
                command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = j;

                OpenConnection();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
            }

            MySqlCommand command3 = new MySqlCommand("DELETE FROM `" + filenames_.tab_title +
                "` WHERE `" + filenames_.col_id + "` = @id", connection);
            command3.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            OpenConnection();
            command3.ExecuteNonQuery();
            CloseConnection();
        }

        public void delete_record_mark(Mark markname)
        {
            int Mid = markname.id;

            MySqlCommand command1 = new MySqlCommand("DELETE FROM `" + comments_.tab_title + 
                "` WHERE `" + comments_.col_foreign + "` = @id", connection);
            command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            MySqlCommand command2 = new MySqlCommand("DELETE FROM `" + marks_.tab_title + 
                "` WHERE `" + marks_.col_id + "` = @id", connection);
            command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            OpenConnection();
            command1.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            CloseConnection();
        }

        public void delete_record_comment(Comment comm)
        {
            int Cid = comm.id;

            MySqlCommand command = new MySqlCommand("DELETE FROM `" + comments_.tab_title + 
                "` WHERE  `" + comments_.col_id + "` = @id", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Cid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }




        public Filename get_file(int i)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + filenames_.tab_title +
                "` ORDER BY `" + filenames_.col_avg + "` DESC", connection);
            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i)
            {
                var id = int.Parse(table.Rows[i][0].ToString());
                var name = table.Rows[i][1].ToString();
                var avg_val = (int)table.Rows[i][2];
                return new Filename(id, name, avg_val);
            }
            else return null;
        }


        public Mark get_mark(Filename filename, int i)
        {
            int Fid = filename.id;

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + marks_.tab_title + 
                "` WHERE `" + marks_.col_foreign + "` = @id ORDER BY `" + marks_.col_avg + "` DESC", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i)
            {
                var id = int.Parse(table.Rows[i][0].ToString());
                var name = table.Rows[i][1].ToString();
                var id_file = int.Parse(table.Rows[i][2].ToString());
                var avg_val = int.Parse(table.Rows[i][3].ToString());
                return new Mark(id, name, id_file, avg_val); ;
            }
            else return null;
        }


        public Comment get_comment(Mark markname, int i)
        {
            int Mid = markname.id;

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + comments_.tab_title +
                "` WHERE `" + comments_.col_foreign + "` = @id ORDER BY `" + comments_.col_val + "` DESC", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i) 
            {
                var id = int.Parse(table.Rows[i][0].ToString());
                var id_mark = int.Parse(table.Rows[i][1].ToString());
                var val = int.Parse(table.Rows[i][2].ToString());
                var text = table.Rows[i][3].ToString();
                return new Comment(id, id_mark, text, val); 
            }
            else return null;
        }


        public void recount_file_avg_value(string filename)
        {
            int Fid = search_filename_id(filename);

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + marks_.tab_title +
                "` WHERE `" + marks_.col_foreign + "` = @id", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            int val = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                val += (int)table.Rows[i][3];
            }
            if (table.Rows.Count != 0) val /= table.Rows.Count;
            else val = 1;

            command = new MySqlCommand("UPDATE `" + filenames_.tab_title + "` SET `" + filenames_.col_avg +
                "` = @val WHERE `" + filenames_.tab_title + "`.`" + filenames_.col_id + "` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = val;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }


        public void recount_mark_avg_value(string filename, string markname)
        {
            int Fid = search_filename_id(filename);
            int Mid = search_mark_id(Fid, markname);

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + comments_.tab_title + 
                "` WHERE `" + comments_.col_foreign + "` = @id", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            int val = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                val += (int)table.Rows[i][2];
            }
            if (table.Rows.Count != 0) val /= table.Rows.Count;
            else val = 1 ;

            command = new MySqlCommand("UPDATE `" + marks_.tab_title + "` SET `" + marks_.col_avg + 
                "` = @val WHERE `" + marks_.tab_title + "`.`" + marks_.col_id + "` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = val;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }




        public int search_filename_id(string filename)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + filenames_.tab_title +
                "` WHERE `"+ filenames_.col_name + "` = @value", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = filename;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return (int)table.Rows[0][0];
        }

        public int search_mark_id(int fval, string markname)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + marks_.tab_title + 
                "` WHERE `" + marks_.col_foreign + "` = @value AND `" + marks_.col_name + "` = @cur_name", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = fval;
            command.Parameters.Add("@cur_name", MySqlDbType.VarChar).Value = markname;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return (int)table.Rows[0][0];
        }
    }
}
