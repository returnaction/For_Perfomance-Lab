using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Test
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Value { get; set; } = null!;
        public List<Test> Values { get; set; } = null!;
    }
}
