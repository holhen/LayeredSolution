using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.BusinessLayer
{
    public interface IProductService
    {
        List<ProductModel> GetAllProduct(string search);
        BindingList<ProductModel> GetProductEditModel();
        void SaveProduct();
    }
}
