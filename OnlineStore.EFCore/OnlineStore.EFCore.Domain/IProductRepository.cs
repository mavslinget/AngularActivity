using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IProductRepository : IRepository<Product>
    {
        //PaginationResult<Product> RetrieveShowWithPagination(int page, int ItemPerPage, string filter);
    }
}
