using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IShowRepository : IRepository<Show>
    {
        PaginationResult<Show> RetrieveShowWithPagination(int page, int ItemPerPage, string filter);
    }
}
