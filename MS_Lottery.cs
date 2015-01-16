using System;
using System.Collections.Generic;
using System.Linq;

namespace Kun_Scopping
{
    public class MS_Lottery
    {
        public static void Main(string[] args)
        {
            var staffs = RegisterStaff();

            var luckyGuyByDepartment = staffs.GroupBy(s => s.Department)
                                            .Select(l => new {Department = l.Key, LuckyGuy = RandomlySelectOne(l.ToList())});

            // test
            foreach (var guy in luckyGuyByDepartment)
            {
                Console.WriteLine(string.Format("Department: {0}, Name: {1}", guy.Department, guy.LuckyGuy.Name));
            }
        }

        public class Staff 
        {
            public string Department { get; set; }
            public string Name { get; set; }

            public Staff(string dep, string name)
            {
                Department = dep;
                Name = name;
            }
        }

        public static IEnumerable<Staff> RegisterStaff()
        {
            return new List<Staff>()
            {
                new Staff("D1", "N1"),
                new Staff("D1", "N2"),
                new Staff("D2", "N3"),
                new Staff("D2", "N4"),
                new Staff("D2", "N5"),
            };
        }

        /// <summary>
        /// details to be implemented. Now only return the first
        /// </summary>
        /// <param name="staffs"></param>
        /// <returns></returns>
        public static Staff RandomlySelectOne(IEnumerable<Staff> staffs)
        {
            return staffs.FirstOrDefault();
        }
    }
}
