using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TDPlugin.Tools;
using TDPlugin.DBclasses;

namespace TDPlugin
{
    class HandlerClass
    {
        public IDBManager db;

        public Filename file;
        public Issue issue;
        public Comment comm;

        public int curr_file;
        public int cur_issue;
        public int curr_comm;

        public HandlerClass ()
        {
            set_db_connection();
            curr_file = 0;
            cur_issue = 0;
            curr_comm = 0;
        }

        public void set_db_connection()
        {
            var DBinfo = get_dbinfo();
            db = new DB_manager(DBinfo[0], DBinfo[1], DBinfo[2], DBinfo[3], DBinfo[4]);
        }

        public string[] get_dbinfo()
        {
            return new string[] { ConnectionSettings.Default.host,
                                    ConnectionSettings.Default.port,
                                    ConnectionSettings.Default.username,
                                    ConnectionSettings.Default.password,
                                    ConnectionSettings.Default.namedb};
        }

        public void set_dbinfo(string host, string port, string username, string password, string namedb)
        {
            ConnectionSettings.Default.host = host;
            ConnectionSettings.Default.port = port;
            ConnectionSettings.Default.username = username;
            ConnectionSettings.Default.password = password;
            ConnectionSettings.Default.namedb = namedb;
            ConnectionSettings.Default.Save();
        }


        public bool mark_bad_code(string file, string issue, string comm, int line_from, int line_to)
        {
            var DBinfo = get_dbinfo();
            set_db_connection();

            if (db.check_connection())
            {
                if (db.search_exist_file(file))
                    if (db.search_exist_issue(file, issue))
                        db.add_new_record_comment(file, issue, comm, DBinfo[2], 0);
                    else
                    {
                        db.add_new_record_issue(file, issue, 0, line_from, line_to);
                        db.add_new_record_comment(file, issue, comm, DBinfo[2], 0);
                    }
                else
                {
                    db.add_new_record_file(file);
                    db.add_new_record_issue(file, issue, 0, line_from, line_to);
                    db.add_new_record_comment(file, issue, comm, DBinfo[2], 0);
                }
                return true;
            }
            else return false;
        }


        public void get_first_info()
        {
            curr_file = 0;
            cur_issue = 0;
            curr_comm = 0;
            file = db.get_file(curr_file);
            issue = db.get_issue(file, cur_issue);
            comm = db.get_comment(issue, curr_comm);
        }

        public void update_cur_com()
        {
            comm = db.get_comment(issue, curr_comm);
        }


        public void update_cur_issue()
        {
            issue = db.get_issue(file, cur_issue);
        }


        public void update_cur_file()
        {
            file = db.get_file(curr_file);
        }


        public void del_record(string rec)
        {
            if (rec == "file")
                db.delete_record_file(file);
            else if (rec == "issue")
                db.delete_record_issue(issue);
            else if(rec == "comment")
                db.delete_record_comment(comm);
        }


        public void edit_record_file(string name)
        {
            db.edit_record_file(file, name);
            update_cur_file();
        }

        public void edit_record_issue(string name, int val, int a, int b)
        {
            db.edit_record_issue(issue, name, val, a, b);
            update_cur_issue();
        }

        public void edit_record_comm(string text, string author, int status)
        {
            db.edit_record_comment(comm, text, author, status);
            update_cur_com();
        }
    }
}
