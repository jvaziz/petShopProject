using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petShop.Repository
{
    public class ProductRepository : IProductRepository{
        private readonly PetShopContext pet_shopContext;
        public ProductRepository(PetShopContext petshopcontext){
            pet_shopContext = petshopcontext;
        }
        public List<ProductModel> listarProdutos(){
            return pet_shopContext.Products.ToList();
        }
    }
}