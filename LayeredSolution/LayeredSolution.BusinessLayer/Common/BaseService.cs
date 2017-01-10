using System;
using System.Linq;
using LayeredSolution.DataLayer;
using LayeredSolution.DataLayer.Schema;

namespace LayeredSolution.BusinessLayer
{
    public class BaseService
    {

        protected readonly ISampleContext Context;
        public BaseService(ISampleContext context)
        {
            Context = context;
        }
    }
}