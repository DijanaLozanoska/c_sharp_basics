using System;
using Shop1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop1.Services
{
    public interface IHomeService
    {
        public MergeProductCategory Merge(int? id);

        public List<Product> Cart();

        Task<IEnumerable<Product>> Add(int id);

        public List<Product> Delete(int? id);
    }
}

