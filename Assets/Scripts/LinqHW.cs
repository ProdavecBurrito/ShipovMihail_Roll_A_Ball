using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipovMihail_Roll_A_Boll
{
    class LinqHW
    {
        public void Counter<T>(List<T> nums)
        {
            var count = from num in nums
                        group num by num.GetHashCode() into newNums
                        select new { Name = newNums.Key, Count = newNums.Count() };

            foreach (var group in count)
            {
                Console.WriteLine($"{group.Name} {group.Count}");
            }

            Console.ReadLine();
        }
    }
}
