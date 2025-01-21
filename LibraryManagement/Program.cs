using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Migrations;
using LibraryManagement.Views;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
//Add - Migration InitialCreate

//Update - Database
//Add - Migration AddDateOfBirthToMembers
 //Remove - Migration

