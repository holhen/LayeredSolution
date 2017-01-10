using System.Collections.Generic;

namespace LayeredSolution.BusinessLayer
{
    public class Page<T>
    {
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}