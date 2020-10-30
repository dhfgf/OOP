using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class OrderExecutionSystem
    {
        public class Shop
        {
            public int ShopId { get; }
            private string _name;
            private string _address;

            internal Dictionary<int, GoodInfo> Goods
                = new Dictionary<int, GoodInfo>();

            internal Shop(int shopId, string name, string address)
            {
                ShopId = shopId;
                _name = name;
                _address = address;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"{ShopId}, {_name}, {_address}");
            }

            public void ShowShipment()
            {
                foreach (var good in Goods)
                {
                    Console.WriteLine($"{good.Key}, {good.Value.Number}, {good.Value.Cost}");
                }
            }
        }
    }
}