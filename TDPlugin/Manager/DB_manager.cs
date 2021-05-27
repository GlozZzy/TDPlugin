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

        comments_table comments_ = new comments_table("comments", "id_comm", "text", "id_issue", "author", "status");
        issues_table issues_ = new issues_table("issues", "id_issue", "name", "severity", "id_file");
        files_table files_ = new files_table("files", "id_file", "name");

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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + files_.tab_title + 
                "` WHERE `" + files_.col_name + "` = @value", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = filename;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }

        public bool search_exist_issue(string filename, string issue)
        {
            int Fid = search_filename_id(filename);

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + issues_.tab_title +
                "` WHERE `" + issues_.col_name + "` = @value AND `" + issues_.col_foreign + "` = @id", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = issue;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }


        public Comment search_exist_author_comment(Issue issue, string author, int status)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + comments_.tab_title +
                "` WHERE `" + comments_.col_author + "` = @auth AND `" + comments_.col_status + "` = @st AND `" 
                + comments_.col_foreign + "` = @id", connection);
            command.Parameters.Add("@auth", MySqlDbType.VarChar).Value = author;
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = status;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = issue.id;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                var id = int.Parse(table.Rows[0][0].ToString());
                var id_issue = int.Parse(table.Rows[0][1].ToString());
                var text = table.Rows[0][2].ToString();
                var auth = table.Rows[0][3].ToString();
                var stat = int.Parse(table.Rows[0][4].ToString());
                return new Comment(id, id_issue, text, auth, stat);
            }
            else return null;
        }



        // Add
        public void add_new_record_file(string filename)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `" + files_.tab_title + "` (`"
                + files_.col_name + "`) VALUES (@value)", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = filename;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void add_new_record_issue(string filename, string issue, int severity)
        {
            int Fid = search_filename_id(filename);

            MySqlCommand command = new MySqlCommand("INSERT INTO `"+ issues_.tab_title + "` (`" 
                + issues_.col_name + "`, `"+ issues_.col_foreign + "`, `" + issues_.col_severity + 
                "`) VALUES(@cur_name, @cur_id, @cur_severity)", connection);
            command.Parameters.Add("@cur_name", MySqlDbType.VarChar).Value = issue;
            command.Parameters.Add("@cur_id", MySqlDbType.VarChar).Value = Fid;
            command.Parameters.Add("@cur_severity", MySqlDbType.VarChar).Value = severity;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void add_new_record_comment(string filename, string issue, string text, string author, int status)
        {
            int Fid = search_filename_id(filename);
            int Mid = search_issue_id(Fid, issue);

            MySqlCommand command = new MySqlCommand("INSERT INTO `"+ comments_.tab_title + "` (`" 
                + comments_.col_foreign + "`, `"+ comments_.col_author + "`, `"+ comments_.col_text 
                + "`, `" + comments_.col_status + "`) VALUES(@cur_fid, @cur_auth, @cur_text, @cur_st)", connection);
            command.Parameters.Add("@cur_fid", MySqlDbType.VarChar).Value = Mid;
            command.Parameters.Add("@cur_auth", MySqlDbType.VarChar).Value = author;
            command.Parameters.Add("@cur_text", MySqlDbType.VarChar).Value = text;
            command.Parameters.Add("@cur_st", MySqlDbType.VarChar).Value = status;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }



        // Edit
        public void edit_record_file(Filename filename, string Ename) 
        {
            int Fid = filename.id;

            MySqlCommand command = new MySqlCommand("UPDATE `" + files_.tab_title + "` SET `" + files_.col_name +
               "` = @val WHERE `" + files_.tab_title + "`.`" + files_.col_id + "` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = Ename;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void edit_record_issue(Issue issue, string Ename, int Eseverity) 
        {
            int Mid = issue.id;

            MySqlCommand command = new MySqlCommand("UPDATE `" + issues_.tab_title + "` SET `" + issues_.col_name +
               "` = @name, `" + issues_.col_severity + "` = @sev  WHERE `" + issues_.tab_title +
               "`.`" + issues_.col_id + "` = @id;", connection);
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = Ename;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;
            command.Parameters.Add("@sev", MySqlDbType.VarChar).Value = Eseverity;

            OpenConnection();
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void edit_record_comment(Comment comm, string Etext, string Eauthor, int Estatus) 
        {
            MySqlCommand command = new MySqlCommand("UPDATE `" + comments_.tab_title + "` SET `" + comments_.col_text +
               "` = @val, `" + comments_.col_author + "` = @auth, `" + comments_.col_status + "` = @st WHERE `" + comments_.tab_title + 
               "`.`" + comments_.col_id + "` = @id;", connection);
            command.Parameters.Add("@val", MySqlDbType.VarChar).Value = Etext;
            command.Parameters.Add("@auth", MySqlDbType.VarChar).Value = Eauthor;
            command.Parameters.Add("@st", MySqlDbType.VarChar).Value = Estatus;
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

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + issues_.tab_title +
                "` WHERE `" + issues_.col_foreign + "` = @value", connection);
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

                command2 = new MySqlCommand("DELETE FROM `" + issues_.tab_title +
                "` WHERE `" + issues_.col_id + "` = @id", connection);
                command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = j;

                OpenConnection();
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
            }

            MySqlCommand command3 = new MySqlCommand("DELETE FROM `" + files_.tab_title +
                "` WHERE `" + files_.col_id + "` = @id", connection);
            command3.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            OpenConnection();
            command3.ExecuteNonQuery();
            CloseConnection();
        }

        public void delete_record_issue(Issue issue)
        {
            int Mid = issue.id;

            MySqlCommand command1 = new MySqlCommand("DELETE FROM `" + comments_.tab_title + 
                "` WHERE `" + comments_.col_foreign + "` = @id", connection);
            command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            MySqlCommand command2 = new MySqlCommand("DELETE FROM `" + issues_.tab_title + 
                "` WHERE `" + issues_.col_id + "` = @id", connection);
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM " + files_.tab_title + " LEFT OUTER JOIN (SELECT " + files_.col_id +
                ", SUM(" + comments_.col_status + ") as " + comments_.col_status + " From (SELECT " + issues_.col_foreign + ", " +
                comments_.col_status + " FROM " + issues_.tab_title + " LEFT OUTER JOIN (SELECT " + comments_.col_foreign + ", SUM(" +
                comments_.col_status + ") as " + comments_.col_status + " FROM " + comments_.tab_title + " GROUP BY " + comments_.col_foreign +
                ") as com ON " + issues_.tab_title + "." + issues_.col_id + " = com." + comments_.col_foreign + " ORDER BY com." + comments_.col_status +
                " DESC) as T GROUP BY " + issues_.col_foreign + ") as fil ON fil." + issues_.col_foreign + " = " + files_.tab_title + "." + files_.col_id +
                " ORDER BY fil." + comments_.col_status + " DESC", connection);
            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i)
            {
                var id = int.Parse(table.Rows[i][0].ToString());
                var name = table.Rows[i][1].ToString();
                return new Filename(id, name);
            }
            else return null;
        }


        public Issue get_issue(Filename filename, int i)
        {
            int Fid = filename.id;
            
            MySqlCommand command = new MySqlCommand("SELECT * FROM " + issues_.tab_title + " LEFT OUTER JOIN (SELECT " +
                comments_.col_foreign + ", SUM(" + comments_.col_status + ") as " + comments_.col_status + " FROM " +
                comments_.tab_title + " GROUP BY " + comments_.col_foreign + ") as com ON " + issues_.tab_title + "." +
                issues_.col_id + " = com." + comments_.col_foreign + " WHERE " + issues_.col_foreign + " = @id ORDER BY com." +
                comments_.col_status + " DESC", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Fid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i)
            {
                var id = int.Parse(table.Rows[i][0].ToString());
                var name = table.Rows[i][1].ToString();
                var severity = int.Parse(table.Rows[i][2].ToString());
                var id_file = int.Parse(table.Rows[i][3].ToString());
                
                return new Issue(id, name, severity, id_file);
            }
            else return null;
        }


        public Comment get_comment(Issue issue, int i)
        {
            int Mid = issue.id;

            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + comments_.tab_title +
                "` WHERE `" + comments_.col_foreign + "` = @id AND `" + comments_.col_status + "` <> 1", connection);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Mid;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > i) 
            {
                var id = int.Parse(table.Rows[i][0].ToString());
                var id_mark = int.Parse(table.Rows[i][1].ToString());
                var text = table.Rows[i][2].ToString();
                var author = table.Rows[i][3].ToString();
                var status = int.Parse(table.Rows[i][4].ToString());
                return new Comment(id, id_mark, text, author, status); 
            }
            else return null;
        }



        private int search_filename_id(string filename)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + files_.tab_title +
                "` WHERE `"+ files_.col_name + "` = @value", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = filename;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return (int)table.Rows[0][0];
        }

        private int search_issue_id(int fval, string issue)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `" + issues_.tab_title + 
                "` WHERE `" + issues_.col_foreign + "` = @value AND `" + issues_.col_name + "` = @cur_name", connection);
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = fval;
            command.Parameters.Add("@cur_name", MySqlDbType.VarChar).Value = issue;

            table = new DataTable();
            adapter = new MySqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return (int)table.Rows[0][0];
        }
    }
}
