using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.EFCore.Domain
{
    public interface IActorRepository: IRepository<Actor>
    {
        PaginationResult<Actor> RetrieveActorWithPagination(int page, int ItemPerPage, string filter);
    }
}
