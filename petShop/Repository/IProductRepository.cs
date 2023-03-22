using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petShop.Repository{
    public interface IProductRepository{
        List<ProductModel> listarProdutos();
    }
}