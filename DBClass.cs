using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace nameDBClass
{
    class DBClass
    {

        protected string RetMsg { get; set; }

        public string dbHost = "192.168.1.21";//資料庫地址
        public string dbUser = "sa";//資料庫使用者帳號
        public string dbPass = "661ho728";//資料庫使用者密碼
        public string dbName = "test";//資料庫名稱



        public string GetReturnMsg()
        {
            return RetMsg;
        }




        public void CreateDB()
        {
            String retstr = "";

            MySqlConnection conn;
            MySqlCommand command;

            string connStr;

            string CommStr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();
            conn.Open();

            //刪除資料庫
            try
            {
                CommStr = "drop database IF EXISTS test01 ;";
                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();

                retstr = retstr + "刪除1筆資料庫test01\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }


            //建立資料庫
            try
            {
                CommStr = "create database test01 DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;";
                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();

                retstr = retstr + "建立1筆資料庫test01\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }


            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();

        }


        public void CreateUser()
        {

            MySqlConnection conn;
            MySqlCommand command;

            string connStr;

            string CommStr = "", retstr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();

            //刪除使用者帳號
            try
            {
                CommStr = "DROP USER IF EXISTS 'user'@'%';";
                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();

                retstr = retstr + "刪除1筆使用者帳號user\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }

            //建立使用者帳號&密碼
            try
            {
                CommStr = "CREATE USER 'user'@'%' IDENTIFIED BY 'password';";
                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();

                retstr = retstr + "建立1筆使用者帳號user\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }

            //建立使用者權限
            try
            {
                CommStr = "GRANT ALL PRIVILEGES ON test01.* TO 'user'@'%';";
                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();

                retstr = retstr + "使用者權限設定\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }


            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();

        }

        public void CreateTable()
        {
            MySqlConnection conn;
            MySqlCommand command;

            string connStr;

            string CommStr = "", retstr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();

            //建立資料表
            try
            {
                //string 前面 加上@ ,可以多行串接
                CommStr = @"CREATE TABLE member (  
                              mem_no INT NOT NULL AUTO_INCREMENT, 
                              mem_name varchar(50) NOT NULL,  
                              mem_addr varchar(50) not null,  
                              PRIMARY KEY(mem_no)     
                            ); ";

                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();

                retstr = retstr + "資料庫test01,建立1筆資料表member\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }



            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();



        }

        public void CreateSP()
        {

            MySqlConnection conn;
            MySqlCommand command;

            string connStr;

            string CommStr = "", retstr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();


            //建立存儲過程stored procedure
            try
            {
                //string 前面 加上@ ,可以多行串接
                CommStr = @"
                       
                        DROP PROCEDURE IF EXISTS sp01;
                        CREATE PROCEDURE sp01 (m_name varchar(50))
                        BEGIN
		                        SELECT mem_no,mem_name,mem_addr
		                        FROM member
		                        WHERE mem_name = m_name;
                        END;

                             ";

                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();

                retstr = retstr + "資料庫test01,建立1筆stored procedure\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }

            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();
        }



        public void MemberInsert()
        {

            MySqlConnection conn;
            MySqlCommand command;

            string connStr;

            string CommStr = "", retstr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();


            //新增會員資料
            try
            {

                for ( int i = 1 ; i < 11 ; i++ )
                {
                    //string 前面 加上@ ,可以多行串接
                    string str01 = "user" + Convert.ToString(i);
                    CommStr = @"INSERT INTO member (mem_no, mem_name,mem_addr)
                                 VALUES ( " + i + ", '" + str01 + "' ,'home') ;";

                    command.CommandText = CommStr;
                    n = command.ExecuteNonQuery();
                    String nn = Convert.ToString(i);

                    retstr = retstr + "建立" + nn + "筆資料member\n";
                }

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }


            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();
        }

        public void MemberUpdate()
        {

            MySqlConnection conn;
            MySqlCommand command;
            //MySqlDataReader reader;

            string connStr;

            string CommStr = "", retstr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();

            //修改資料member 
            try
            {

                //string 前面 加上@ ,可以多行串接
                //string str01 = "user" + Convert.ToString(i);
                CommStr = @"UPDATE member set mem_name='AAA'
                                 where mem_no='2' ;";

                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();
                String nn = Convert.ToString(n);

                retstr = retstr + "修改" + nn + "筆資料member\n";


            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息: " + ex.Message.ToString() + "\n";
            }


            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();
        }


        public void MemberList()
        {

            MySqlConnection conn;
            MySqlCommand command;
            MySqlDataReader reader;

            string connStr;

            string CommStr = "", retstr = "";
            //int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();

            //列單 資料member 
            try
            {

                //string 前面 加上@ ,可以多行串接
                //string str01 = "user" + Convert.ToString(i);
                CommStr = @"select * from member ;";

                command.CommandText = CommStr;
                reader = command.ExecuteReader(); //execure the reader

                while ( reader.Read() )
                {

                    String mem_no = reader.GetString(0);
                    String mem_name = reader.GetString("mem_name");
                    String mem_addr = reader["mem_addr"].ToString();


                    retstr = retstr + mem_no + "\t" + mem_name + "\t" + mem_addr;

                    retstr = retstr + "\n";
                }
                reader.Close(); //關閉..才能對資料表做動作(刪除)
                reader.Dispose();

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息A: " + ex.Message.ToString() + "\n";
            }




            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();
        }




        public void MemberList2()
        {

            MySqlConnection conn;
            MySqlCommand command;
            MySqlDataReader reader;

            string connStr;

            string retstr = "";
            //int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();


            //列單 資料member  stored procedure
            try
            {
                command.Parameters.Clear();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp01";
                command.Parameters.Add("?m_name", MySqlDbType.VarChar).Value = "BBB";

                reader = command.ExecuteReader(CommandBehavior.SingleResult);
                //reader = command.ExecuteReader(CommandBehavior.SingleRow);

                while ( reader.Read() )
                {

                    String mem_no = reader.GetString(0);
                    String mem_name = reader.GetString("mem_name");
                    String mem_addr = reader["mem_addr"].ToString();


                    retstr = retstr + mem_no + "\t" + mem_name + "\t" + mem_addr;

                    retstr = retstr + "\n";
                }
                reader.Close(); //關閉..才能對資料表做動作(刪除)
                reader.Dispose();

            }
            catch ( Exception ex )
            {

                retstr = retstr + "csAPP系統訊息B: " + ex.Message.ToString() + "\n";
            }

            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();
        }




        public void MemberDelete()
        {

            MySqlConnection conn;
            MySqlCommand command;
            //MySqlDataReader reader;

            string connStr;

            string CommStr = "", retstr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();


            //指定刪除某一筆資料 
            try
            {
                //string 前面 加上@ ,可以多行串接
                CommStr = "delete from member where mem_no=1 ";

                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();
                String nn = Convert.ToString(n);

                retstr = retstr + "刪除" + nn + "筆資料member\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息D1: " + ex.Message.ToString() + "\n";
            }

            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();
        }

        public void MemberDelAll()
        {

            MySqlConnection conn;
            MySqlCommand command;
            //MySqlDataReader reader;

            string connStr;
            string CommStr = "", retstr = "";
            int n = 0;

            //開始連線
            connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            conn = new MySqlConnection(connStr);
            command = conn.CreateCommand();

            conn.Open();


            //指定刪除某一筆資料 
            try
            {
                //string 前面 加上@ ,可以多行串接
                CommStr = "delete from member where mem_no ";

                command.CommandText = CommStr;
                n = command.ExecuteNonQuery();
                String nn = Convert.ToString(n);

                retstr = retstr + "刪除" + nn + "筆資料member\n";

            }
            catch ( Exception ex )
            {
                retstr = retstr + "csAPP系統訊息D1: " + ex.Message.ToString() + "\n";
            }


            RetMsg = retstr;//回傳訊息
            conn.Close();
            conn.Dispose();
        }




        //class end
    }
}
