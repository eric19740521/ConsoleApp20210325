using System;

namespace ConsoleApp20210325
{
    class Program
    {
        static void Main(string[] args)
        {


            String str = "";

            var db = new nameDBClass.DBClass();


            //
            db.dbHost = "192.168.1.21";//資料庫位址
            db.dbUser = "sa";//資料庫使用者帳號
            db.dbPass = "661ho728";//資料庫使用者密碼
            db.dbName = "test";//資料庫名稱

            //建立資料庫test01
            db.CreateDB();
            str = db.GetReturnMsg();
            Console.WriteLine(str);

            //建立使用者帳號密碼 權限
            db.CreateUser();
            str = db.GetReturnMsg();
            Console.WriteLine(str);


            //用剛建立的資料庫與使用者連線
            db.dbHost = "192.168.1.21";//資料庫位址
            db.dbUser = "user";//資料庫使用者帳號
            db.dbPass = "password";//資料庫使用者密碼
            db.dbName = "test01";//資料庫名稱

            //
            db.CreateTable();
            str = db.GetReturnMsg();
            Console.WriteLine(str);

            //
            db.CreateSP();
            str = db.GetReturnMsg();
            Console.WriteLine(str);


            //
            db.MemberInsert();
            str = db.GetReturnMsg();
            Console.WriteLine(str);

            //
            db.MemberList();
            str = db.GetReturnMsg();
            Console.WriteLine(str);

            //
            db.MemberList2();
            str = db.GetReturnMsg();
            Console.WriteLine(str);

            //
            db.MemberUpdate();
            str = db.GetReturnMsg();
            Console.WriteLine(str);


            //
            db.MemberDelete();
            str = db.GetReturnMsg();
            Console.WriteLine(str);

            //
            db.MemberDelAll();
            str = db.GetReturnMsg();
            Console.WriteLine(str);




        }
    }
}
