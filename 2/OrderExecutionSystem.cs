using System;
using System.Collections.Generic;
using Lab2.Exceptions;

namespace Lab2
{
    public partial class OrderExecutionSystem
    {
        private Dictionary<int, Shop> _shops = new Dictionary<int, Shop>();
        private Dictionary<int, Good> _goods = new Dictionary<int,Good>();

        public void AddShop(int shopId, string name, string address)
        {
            var shop = new Shop(shopId, name, address);
            _shops.Add(shop.ShopId, shop);
        }

        public void AddGood(int goodId, string name)
        {
            var good = new Good(goodId, name);
            _goods.Add(good.GoodId, good);
        }
        
        internal void AddShipment(int shop, int good, int number, int cost)
        {
            var gi = new GoodInfo() {Number = number, Cost = cost};
            
            if (!_shops.ContainsKey(shop))
                throw new ShopIdException(shop);

            if (!_goods.ContainsKey(good))
                throw new GoodIdException(good);
            
            if (!_shops[shop].Goods.ContainsKey(good))
                _shops[shop].Goods.Add(good, gi);
            else
            {
                _shops[shop].Goods[good].Number += number;
                _shops[shop].Goods[good].Cost = cost;
            }
        }

        private int CalcCost(Order order, int shopId)
        {
            var totalCost = 0;

            if (!_shops.ContainsKey(shopId))
                throw new ShopIdException(shopId); //unnecessary
                    
            Shop shop;
            shop = _shops[shopId];
            
            foreach (var detail in order.Details)
            {
                if (!shop.Goods.ContainsKey(detail.GoodId))
                    return -1;
                    
                if (shop.Goods[detail.GoodId].Number < detail.Number)
                    return -1;

                totalCost += shop.Goods[detail.GoodId].Cost * detail.Number;
            }

            return totalCost;
        }
        
        //                       SixtySix
        public void ExecuteOrder(Order order, int shopId) 
        {
            var totalCost = 0;

            if (!_shops.ContainsKey(shopId))
                throw new ShopIdException(shopId);
                    
            Shop shop;
            shop = _shops[shopId];
            
            foreach (var detail in order.Details)
            {
                if (!shop.Goods.ContainsKey(detail.GoodId))
                    throw new NoThisGoodInThisShopException(detail.GoodId, shopId);
                
                if (shop.Goods[detail.GoodId].Number < detail.Number)
                    throw new NotEnoughGoodException(detail.GoodId, shopId);

                shop.Goods[detail.GoodId].Number -= detail.Number;
                totalCost += shop.Goods[detail.GoodId].Cost * detail.Number;
            }

            Console.WriteLine($"Done! Total cost is {totalCost}");
        }

        public void FindLowestCost(Order order)
        {
            var minCost = -1;
            var minCostShopId = 0;
            
            foreach (var shop in _shops)
            {
                var calc = CalcCost(order, shop.Key);
                if ((minCost == -1 || calc < minCost) && calc != -1)
                {
                    minCost = calc;
                    minCostShopId = shop.Value.ShopId;
                }
            }

            if (minCost == -1)
            {
                Console.WriteLine("There is no way to buy this order");
            }
            else
            {
                Console.WriteLine($"Lowest cost for this order is {minCost} in shop {minCostShopId}");
            }
        }

        public void WhatCanBuy(int shop, int money)
        {
            Console.WriteLine($"In shop {shop} you can buy:");
            foreach (var good in _shops[shop].Goods)
            {
                var number = money / good.Value.Cost < good.Value.Number 
                    ? (int)money / good.Value.Cost 
                    : good.Value.Number;
                Console.WriteLine($"    {good.Key} - {number} units");
            }
            
        }
    }
}