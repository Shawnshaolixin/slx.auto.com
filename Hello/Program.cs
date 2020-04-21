using NPOI.HSSF.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hello
{
    public static class Extensions
    {
        public static string Convert(this string template, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            if (parameters == null) return template;

            foreach (var item in parameters)
            {
                template = template.Replace(item.Key, item.Value);
            }

            template = Regex.Replace(template, "\r\n", "");
            return template;
        }
    }
    class FOrderCarEntity
    {
        public int Id { get; set; }
        public Decimal AuditPerDealPrice { get; set; }
    }
    class FInvoiceEntity
    {
        public int Id { get; set; }
        public Decimal CludeTaxAmount { get; set; }
    }

    class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int pid { get; set; }

    }
    class AreaTree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AreaTree> Childern { get; set; }
    }
    class Program
    {


        static void Export()
        {
            var book = new HSSFWorkbook();
            var sheet1 = book.CreateSheet("sheet1");
            var row = sheet1.CreateRow(0);
            var cell = row.CreateCell(0);
            cell.SetCellValue("sales report");
            var style = book.CreateCellStyle();
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            var font = book.CreateFont();
            font.FontHeight = 20 * 20;
            style.SetFont(font);
            cell.CellStyle = style;
            sheet1.AddMergedRegion(new CellRangeAddress(0, 5, 0, 0));
            sheet1.AddMergedRegion(new CellRangeAddress(0, 2, 1, 1));
            sheet1.AddMergedRegion(new CellRangeAddress(3, 5, 1, 1));

            FileStream file = new FileStream("test.xls", FileMode.Create);
            book.Write(file);
            file.Close();

        }

        static void Main(string[] args)
        {

            //  Export();
            List<Area> list = new List<Area>();
            #region MyRegion
            list.Add(new Area
            {
                Id = 1,
                Name = "黑龙江",
                pid = 0
            });
            list.Add(new Area
            {
                Id = 2,
                Name = "辽宁",
                pid = 0
            });
            list.Add(new Area
            {
                Id = 3,
                Name = "哈尔滨",
                pid = 1
            });
            list.Add(new Area
            {
                Id = 4,
                Name = "齐齐哈尔",
                pid = 1
            });
            list.Add(new Area
            {
                Id = 5,
                Name = "巴彦县",
                pid = 3
            });
            list.Add(new Area
            {
                Id = 6,
                Name = "沈阳",
                pid = 2
            });
            list.Add(new Area
            {
                Id = 7,
                Name = "大东区",
                pid = 6
            });

            #endregion


            int pid = 0;
            List<AreaTree> areaList = GetList(pid, list);
   










            int[] arr = new int[5];
            arr[0] = 1;
            arr[1] = 2;
            arr[0] = 5;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();

            Console.WriteLine(Math.Round(3.0 / 4, 2));
            Console.ReadKey();
            List<FInvoiceEntity> fInvoiceEntities = new List<FInvoiceEntity>();
            fInvoiceEntities.Add(new FInvoiceEntity
            {
                CludeTaxAmount = 50,
                Id = 1,
            });

            List<FOrderCarEntity> fOrderCarEntities = new List<FOrderCarEntity>();
            fOrderCarEntities.Add(new FOrderCarEntity
            {
                Id = 1,
                AuditPerDealPrice = 40,

            });
            fOrderCarEntities.Add(new FOrderCarEntity
            {
                Id = 2,
                AuditPerDealPrice = 20,

            });
            fOrderCarEntities.Add(new FOrderCarEntity
            {
                Id = 2,
                AuditPerDealPrice = 20,

            });
            AllocateInvoice(fInvoiceEntities, fOrderCarEntities);


        }

        private static List<AreaTree> GetList(int pid, List<Area> list)
        {
            List<AreaTree> tree = new List<AreaTree>();
            var list1 = list.Where(i => i.pid == pid);
            foreach (var item in list1)
            {
                AreaTree t = new AreaTree();
                t.Id = item.Id;
                t.Name = item.Name;
                t.Childern = GetList(item.Id, list);
                tree.Add(t);
            }
            return tree;
        }

        private static void AllocateInvoice(List<FInvoiceEntity> invoiceList, List<FOrderCarEntity> carList)
        {
            //  var invoiceList = new List<FInvoiceEntity>();// await _queries.GetInvoiceListByOrderId(orderId);

            Stack<KeyValuePair<int, decimal>> carStack = new Stack<KeyValuePair<int, decimal>>();
            Stack<KeyValuePair<int, decimal>> invoiceStack = new Stack<KeyValuePair<int, decimal>>();

            foreach (var i in invoiceList.OrderBy(i => i.CludeTaxAmount))
            {
                invoiceStack.Push(new KeyValuePair<int, decimal>(i.Id, i.CludeTaxAmount));
            }


            foreach (var i in carList.OrderBy(i => i.AuditPerDealPrice))
            {
                carStack.Push(new KeyValuePair<int, decimal>(i.Id, i.AuditPerDealPrice));
            }


            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            while (carStack.Count > 0 && invoiceStack.Count > 0)
            {
                var car = carStack.Peek();
                if (carStack.Count == 1)
                {
                    while (invoiceStack.Count > 0)
                    {
                        list.Add(new Tuple<int, int>(car.Key, invoiceStack.Pop().Key));
                    }
                    carStack.Pop();
                    return;
                }
                if (invoiceStack.Count > 0)
                {
                    var invoice = invoiceStack.Peek();
                    if (car.Value == invoice.Value)
                    {
                        list.Add(new Tuple<int, int>(carStack.Pop().Key, invoiceStack.Pop().Key));
                    }
                    else if (car.Value > invoice.Value)
                    {
                        var c = carStack.Pop();
                        var i = invoiceStack.Pop();
                        var cv = Math.Abs(c.Value - i.Value);
                        carStack.Push(new KeyValuePair<int, decimal>(c.Key, cv));
                        list.Add(new Tuple<int, int>(c.Key, i.Key));
                    }
                    else if (car.Value < invoice.Value)
                    {
                        var c = carStack.Pop();
                        var i = invoiceStack.Pop();
                        var cv = Math.Abs(c.Value - i.Value);
                        invoiceStack.Push(new KeyValuePair<int, decimal>(i.Key, cv));
                        list.Add(new Tuple<int, int>(c.Key, i.Key));
                    }
                }

            }
            return;
        }
        public static async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("方法1111111111111111");
                }
            });

        }

        public static async Task Method2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("方法22222222222222");
                }
            });
        }
    }
}
