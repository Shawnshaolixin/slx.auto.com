using System;
using System.Runtime.Remoting.Proxies;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            IBuyer buyer = new Buyer();
           // buyer.BuyHouse();
            BuyerHouseProxy buyerHouseProxy = new BuyerHouseProxy(new Buyer());
            buyerHouseProxy.BuyHouse();
            Console.ReadKey();
        }
    }

    class Proxy: RealProxy
    {

    }
    interface IBuyer
    {
        void BuyHouse();
    }
    class Buyer : IBuyer
    {
        public void BuyHouse()
        {
            Console.WriteLine("买房子了");
        }
    }
    class BuyerHouseProxy : IBuyer
    {
        private IBuyer _buyer;
        public BuyerHouseProxy(IBuyer buyer)
        {
            _buyer = buyer;
        }
        public void BuyHouse()
        {
            Console.WriteLine("买房子前");
            _buyer.BuyHouse();
            Console.WriteLine("买房子后");
        }
    }
}
