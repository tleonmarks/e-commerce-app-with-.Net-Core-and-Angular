using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
			try
			{
				if (!context.ProductBrands.Any()) {
					var brandsData = File.ReadAllText("../Infrasctructure/Data/SeedData/brands.json");
				}
			}
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
