﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static ConcurrentQueue<byte[]> commands;
        [STAThread]
        static void Main()
        {
            commands = new ConcurrentQueue<byte[]>() { }; 
            ConnectionHandler test = new ConnectionHandler();
            test.OpenConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread app = new Thread(Run);
            Thread con = new Thread(test.Receive);
            app.Start();
            con.Start();
        }
        public static void Run()
        {
            Application.Run(new Form1());
        }
    }
}
