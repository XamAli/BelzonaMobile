using System.Threading.Tasks;
using System.Collections.Generic;

namespace BelzonaMobile.Services
{
    public interface IProductSqlService
    {
        Task AddMovies(IList<BelzonaMobile.Models.dbProduct> products);

        Task<IList<BelzonaMobile.Models.dbProduct>> GetMovies();
    }
}

