using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace petShop.Data{
    public class PetShopContext : DbContext{
        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options){}
        public DbSet<PetModel> Pets{get;set;}
        public DbSet<UserModel> Users{get;set;}
        public DbSet<ProductModel> Products{get;set;}

        
    }
}