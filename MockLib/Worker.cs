using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockLib
{
    public class Worker
    {
        public int Work()
        {
            var random = new Random(DateTime.Now.Millisecond);
            return random.Next(1, 100);
        }
    }
}
