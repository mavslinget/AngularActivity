using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class NameRepository : RepositoryBase<Name>, INameRepository
    {
        public NameRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Name> RetrieveNameWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Name> result = new PaginationResult<Name>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Name>().OrderBy(x => x.FirstName)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Name>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Name>()
                  .Where(x => x.FirstName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.FirstName)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Name>()
                        .Where(x => x.FirstName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }


    }
}