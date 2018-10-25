using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class ActorRepository:  RepositoryBase<Actor>, IActorRepository
    {
        public ActorRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Actor> RetrieveActorWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Actor> result = new PaginationResult<Actor>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Actor>().OrderBy(a => a.FirstName)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Actor>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Actor>()
                  .Where(a => a.FirstName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(a => a.FirstName)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Actor>()
                        .Where(a => a.FirstName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }


    }
}
