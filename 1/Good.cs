using System;

namespace Lab2
{
    public partial class OrderExecutionSystem
    {
        internal class Good
        {
            public int GoodId { get; }
            private string _name;

            public Good(int goodId, string name)
            {
                GoodId = goodId;
                _name = name;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"{GoodId}, {_name}");
            }
        }
    }
}