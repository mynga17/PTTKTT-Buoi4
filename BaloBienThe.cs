using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _28_2033210033_VienMyNga
{
        class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Weight1 { get; set; }
        public int Weight2 { get; set; }
        public int Quantity { get; set; }
    }

    class BaloBienThe
    {
        static void Main(string[] args)
        {
            // Khai báo các mặt hàng
            Item[] items = {
        new Item { Name = "Sách", Value = 60, Weight1 = 10, Weight2 = 20, Quantity = 3 },
        new Item { Name = "Máy tính", Value = 100, Weight1 = 20, Weight2 = 10, Quantity = 2 },
        new Item { Name = "Đèn pin", Value = 120, Weight1 = 30, Weight2 = 15, Quantity = 1 }
    };

            // Tải trọng tối đa của balo
            int capacity1 = 50;
            int capacity2 = 40;

            // Gọi hàm giải bài toán balo
            int totalValue = SolveKnapsackProblem(items, capacity1, capacity2);

            Console.WriteLine("Tong gia tri cac mat hang trong balo: {0}", totalValue);
            Console.WriteLine("Cac mat hang trong balo:");
            foreach (var item in items)
            {
                if (item.Weight1 <= capacity1 && item.Weight2 <= capacity2 && item.Quantity > 0)
                {
                    Console.WriteLine("- {0} (So luong: {1})", item.Name, item.Quantity);
                    item.Quantity--;
                }
            }
            Console.ReadLine();
        }

        static int SolveKnapsackProblem(Item[] items, int capacity1, int capacity2)
        {
            // Sắp xếp các mặt hàng theo tỷ lệ giá trị/trọng lượng giảm dần
            Array.Sort(items, (a, b) => (b.Value * Math.Max(a.Weight1, a.Weight2)).CompareTo(a.Value * Math.Max(b.Weight1, b.Weight2)));

            int totalValue = 0;
            int currentWeight1 = 0;
            int currentWeight2 = 0;

            // Thực hiện thuật toán tham lam
            foreach (var item in items)
            {
                // Nếu thêm mặt hàng vào balo không vượt quá tải trọng tối đa của cả 2 balo và số lượng của mặt hàng vẫn còn
                if (currentWeight1 + item.Weight1 <= capacity1 && currentWeight2 + item.Weight2 <= capacity2 && item.Quantity > 0)
                {
                    // Thêm mặt hàng vào balo
                    totalValue += item.Value;
                    currentWeight1 += item.Weight1;
                    currentWeight2 += item.Weight2;
                    item.Quantity--;
                }
                else
                {
                    // Nếu không thể thêm mặt hàng vào balo, thoát khỏi vòng lặp
                    break;
                }
            }

            return totalValue;
        }
    }
}