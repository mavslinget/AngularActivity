using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IQualificationRepository : IRepository<Qualification>
    {
        PaginationResult<Qualification> RetrieveQualificationWithPagination(int page, int ItemPerPage, string filter);
    }
}
