using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class OrderExecutionSystem
    {
        public class Order
        {
            protected internal class OrderDetails
            {
                public int GoodId;
                public int Number;
            }
            
            internal List<OrderDetails> Details { get; } = new List<OrderDetails>();

            public void AddToOrder(int good, int number)
            {
                Details.Add(new OrderDetails() {GoodId = good, Number = number});
            }

            public Order(int good, int number)
            {
                
            }

            public void ShowOrder()
            {
                foreach (var detail in Details)
                {
                    Console.WriteLine($"{detail.GoodId} - {detail.Number} units");
                }
            }
        }
    }
}