using System;

namespace DelegaetDemo
{
    public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);



    delegate void TestDel(string name);

    delegate int Transformer(int x);
    class Program
    {

        static void DogCloud(string name)
        {
            Console.WriteLine(name + "狗叫了");
        }

        static void Personward(string name)
        {
            Console.WriteLine(name + "人醒了");
        }
        static void MouseRun(string name)
        {
            Console.WriteLine(name + "老鼠跑了");
        }
        static void ChildKu()
        {
            Console.WriteLine("小孩哭了");
            TestDel d = DogCloud;
            d += Personward;
            d += MouseRun;
            d.Invoke("小明");
        }
        static void Main(string[] args)
        {
            Cat cat = new Cat();

            cat.OnCatCall += Cat_OnCatCall;
            cat.OnCatCall += Cat_OnCatCall1;
            cat.Call(new CatCallEventArgs("P1......."));
            //Stock stock = new Stock("");
            //stock.Price = 23;
            //stock.PriceChanged += Stock_PriceChanged;
            //stock.Price = 11;
            //stock.Price = 13;
            Console.ReadKey();
        }

        private static void Cat_OnCatCall1(object sender, CatCallEventArgs e)
        {
            Mouse mouse = new Mouse();
            Console.WriteLine(e.P1);
            mouse.Run();
        }

        private static void Cat_OnCatCall(object sender, CatCallEventArgs e)
        {
            Person p = new Person();
            p.Wake();
        }

        private static void Stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            Console.WriteLine($"old={e.LastPrice},new={e.NewPrice}");
        }

        public static void Transform(int[] value, Transformer t)
        {
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = t(value[i]);
            }
        }
        static int Square(int x)
        {
            return x * x;
        }
        static int AddOne(int x)
        {
            return x + 1;
        }
    }

    public class Stock1
    {
        string symbol;
        decimal price;
        public Stock1(string symbol)
        {
            this.symbol = symbol;
        }
        public event PriceChangedHandler PriceChanged;
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;//如果没有i变化 则退出
                decimal oldPrice = price;
                price = value;
                if (PriceChanged != null)
                {
                    PriceChanged(oldPrice, price);
                }

            }
        }
    }

}
