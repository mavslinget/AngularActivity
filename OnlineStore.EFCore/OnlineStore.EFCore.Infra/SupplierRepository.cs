using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class SupplierRepository: RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Supplier> RetrieveSupplierWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Supplier> result = new PaginationResult<Supplier>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Supplier>().OrderBy(su => su.ContactName)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Supplier>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Supplier>()
                  .Where(su => su.ContactName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(su => su.ContactName)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Supplier>()
                        .Where(su => su.ContactName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }
    }
}
