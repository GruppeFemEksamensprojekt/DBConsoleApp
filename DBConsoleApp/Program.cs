﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DbClient dbClient = new DbClient();

            dbClient.SelectAllHotels();

            Console.WriteLine();

            dbClient.SelectSpecificHotel(7);

            Console.WriteLine();

            //dbClient.Insert(9, "Fiskefars Bodel Hotel", "Fisketorvet 69, 4000 Roskilde");
            //dbClient.SelectAllHotels();

            //Console.WriteLine();

            //dbClient.Delete(9);
            //dbClient.SelectAllHotels();

            dbClient.UpdateHotel(1, "The Pepe", "Pepestreet 420");
            dbClient.SelectAllHotels();



            Console.ReadLine();
        }
    }
}