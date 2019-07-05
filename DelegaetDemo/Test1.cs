using System;

namespace DelegaetDemo
{
    public class Test1
    {
        public static void Stock_PriceChanged(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine($"old={oldPrice},new = {newPrice}");
        }
    }
    public class PriceChangedEventArgs : System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;
        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    public class Stock
    {
        string symbol;
        decimal price;
        public Stock(string symbol)
        {
            this.symbol = symbol;
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;//如果没有i变化 则退出
                OnPriceChanged(new PriceChangedEventArgs(price, value));
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(price, value));

            }
        }
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged != null)
            {
                PriceChanged(this, e);
            }
        }
    }
    public class Mouse
    {
        public void Run()
        {
            Console.WriteLine("老鼠跑了");
        }
    }
    public class Person
    {
        public void Wake()
        {
            Console.WriteLine("人醒了");
        }
    }

    public class CatCallEventArgs : EventArgs
    {
        public CatCallEventArgs(string p1)
        {
            this.P1 = p1;
        }
        public string P1 { get; set; }
    }

    public class Cat
    {

        public event EventHandler<CatCallEventArgs> OnCatCall;
        public void Call(CatCallEventArgs e)
        {

            Console.WriteLine("猫叫了");
            if (OnCatCall != null)
            {
                OnCatCall(this, e);
            }
        }

    }

    public class Test2
    {
        public static string Num = "123";
        static Test2()
        {
            Console.WriteLine("Test2的静态构造方法执行了...");
        }
        public Test2()
        {
            Console.WriteLine("构造方法执行了...");
        }
        ~Test2()
        {
            Console.WriteLine("Test2被释放了......");
        }
    }
}

