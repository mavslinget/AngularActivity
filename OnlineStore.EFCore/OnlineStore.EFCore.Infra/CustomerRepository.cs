using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Customer> RetrieveCustomerWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Customer> result = new PaginationResult<Customer>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Customer>().OrderBy(cu => cu.ContactName)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Customer>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Customer>()
                  .Where(cu => cu.ContactName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(cu => cu.ContactName)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Customer>()
                        .Where(cu => cu.ContactName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }
    }
}
