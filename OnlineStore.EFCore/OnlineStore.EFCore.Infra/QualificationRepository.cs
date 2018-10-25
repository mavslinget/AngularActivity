using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class QualificationRepository : RepositoryBase<Qualification>, IQualificationRepository
    {
        public QualificationRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Qualification> RetrieveQualificationWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Qualification> result = new PaginationResult<Qualification>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Qualification>().OrderBy(x => x.Description)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Qualification>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Qualification>()
                  .Where(x => x.Description.ToLower().Contains(filter.ToLower()))
                  .OrderBy(x => x.Description)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Qualification>()
                        .Where(x => x.Description.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }


    }
}