using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface ICategoryRepository : IRepository<Category>
    {
        PaginationResult<Category> RetrieveCategoryWithPagination(int page, int ItemPerPage, string filter);
    }
}
