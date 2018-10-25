using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineStore.EFCore.Infra
{
    public class EmployeeRepository
        : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OnlineStoreDbContext context)
            : base(context)
        {

        }

        

        public PaginationResult<Employee> RetrieveEmployeeWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Employee> result = new PaginationResult<Employee>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Employee>().OrderBy(e => e.FirstName)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Employee>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Employee>()
                  .Where(a => a.FirstName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(a => a.FirstName)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Employee>()
                        .Where(e => e.FirstName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }


    }
}
