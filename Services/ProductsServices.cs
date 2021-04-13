using System;
using System.Collections.Generic;
using CsharpMorningChallenge1.Models;
using CsharpMorningChallenge1.Repositories;

namespace CsharpMorningChallenge1.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _repo;

        public ProductsService(ProductsRepository repo)
        {
            _repo = repo;
        }

        //GET
        public IEnumerable<Product> Get()
        {
            return _repo.Get();
        }

        //GET
        internal Product GetById(string id)
        {
            Product products = _repo.Get(id);
            if (products == null)
            {
                throw new Exception("invalid id");
            }
            return products;
        }

        //CREATE/POST
        internal Product Create(Product newProducts)
        {
            return _repo.Create(newProducts);
        }

        //EDIT/PUT
        internal Product Edit(Product editProducts)
        {
            Product original = GetById(editProducts.productId);

            original.Name = editProducts.Name != null ? editProducts.Name : original.Name;
            original.Description = editProducts.Description != null ? editProducts.Description : original.Description;
            original.Price = editProducts.Price != null ? editProducts.Price : original.Price;

            return _repo.Edit(original);
        }

        //DELORT
        internal Product Delete(string id)
        {
            Product original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}