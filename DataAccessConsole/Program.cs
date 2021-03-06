﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Content;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.MenuItem;
using Microsoft.SqlServer.Server;


namespace DataAccessConsole
{
    class Program
    {
        private static Content.Content coreContent { get; set; }


        private Program()
        {
            coreContent = new Content.Content();
        }

        static void Main(string[] args)
        {
            var a = new MenuItemRepo().GetMenuAllItems().FirstOrDefault();

            Console.WriteLine(a.MenuItemDescription);

            //ContentRepos();
        }

        private static void ContentRepos()
        {
            string stringRepo = "";

            stringRepo = $"GetCoreContentByID\n\r{coreContent.GetCoreContentByID()}";
            stringRepo += $"GetCoreContents\r\n{coreContent.GetCoreContents()}";
            stringRepo += $"GetValidCoreContents\r\n{coreContent.GetValidCoreContents()}";

            Console.WriteLine(stringRepo);
        }
    }
}
