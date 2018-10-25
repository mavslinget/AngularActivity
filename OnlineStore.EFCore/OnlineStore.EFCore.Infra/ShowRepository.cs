using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class ShowRepository : RepositoryBase<Show>, IShowRepository
    {
        public ShowRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Show> RetrieveShowWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Show> result = new PaginationResult<Show>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Show>().OrderBy(t => t.Title)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Show>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Show>()
                  .Where(t => t.Title.ToLower().Contains(filter.ToLower()))
                  .OrderBy(t => t.Title)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Show>()
                        .Where(t => t.Title.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }


    }
}
