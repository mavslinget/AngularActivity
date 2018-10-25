using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface INameRepository : IRepository<Name>
    {
        PaginationResult<Name> RetrieveNameWithPagination(int page, int ItemPerPage, string filter);
    }
}
