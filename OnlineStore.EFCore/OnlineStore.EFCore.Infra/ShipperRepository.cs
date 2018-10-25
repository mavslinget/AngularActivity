using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.EFCore.Infra
{
    public class ShipperRepository : RepositoryBase<Shipper> , IShipperRepository 
    {
        public ShipperRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public PaginationResult<Shipper> RetrieveShipperWithPagination(int page, int ItemPerPage, string filter)
        {
            PaginationResult<Shipper> result = new PaginationResult<Shipper>();

            if (string.IsNullOrEmpty(filter))
            {
                result.Results = context.Set<Shipper>().OrderBy(s => s.CompanyName)
                  .Skip(page).Take(ItemPerPage).ToList();
                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Shipper>().Count();
                }
            }
            else
            {
                result.Results = context.Set<Shipper>()
                  .Where(s => s.CompanyName.ToLower().Contains(filter.ToLower()))
                  .OrderBy(s => s.CompanyName)
                  .Skip(page)
                  .Take(ItemPerPage).ToList();

                if (result.Results.Count > 0)
                {
                    result.TotalRecords = context.Set<Shipper>()
                        .Where(s => s.CompanyName.ToLower().Contains(filter.ToLower()))
                        .Count();
                }
            }


            return result;
        }
    }
}
