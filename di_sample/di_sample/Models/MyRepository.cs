using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace di_sample.Models
{
    public interface IRepository
    {
        int GetnUpdateCounter();
    }
    public class MyRepository : IRepository
    {
        private int i;
        public int GetnUpdateCounter()
        {
            return i++;
        }
    }
}
