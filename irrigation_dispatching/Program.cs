﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using irrigation_dispatching.Controller;

namespace irrigation_dispatching
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            NavigationController navigationController = new NavigationController();
        }
    }
}
