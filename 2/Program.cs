using System;
using Lab2.Exceptions;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var exsys = new OrderExecutionSystem();
                exsys.AddShop(1000, "Metro", "31 street");
                exsys.AddShop(1001, "Ashan", "Some metro station");
                exsys.AddShop(1002, "OK", "Somewhere else");
                exsys.AddGood(1, "Good 1");
                exsys.AddGood(2, "Good 2");
                exsys.AddGood(3, "Good 3");
                exsys.AddGood(4, "Good 4");
                exsys.AddGood(5, "Good 5");
                exsys.AddGood(6, "Good 6");
                exsys.AddGood(7, "Good 7");
                exsys.AddGood(8, "Good 8");
                exsys.AddGood(9, "Good 9");
                exsys.AddGood(10, "Good 10");

                for (int i = 1; i < 11; i++)
                    exsys.AddShipment(1000, i, 100, 100 + i * 10);
                for (int i = 1; i < 6; i++)
                    exsys.AddShipment(1001, i, 50, 70);
                for (int i = 3; i < 10; i += 3)
                    exsys.AddShipment(1002, i, 20, 50);
                
                var order1 = new OrderExecutionSystem.Order(1, 10);
                order1.AddToOrder(2, 10);
                order1.AddToOrder(4, 20);
                exsys.FindLowestCost(order1);
                
                order1.AddToOrder(7, 10);
                exsys.FindLowestCost(order1);
                
                exsys.WhatCanBuy(1000, 1000);
                
                exsys.ExecuteOrder(order1, 1000);
            }
            catch (MainException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}