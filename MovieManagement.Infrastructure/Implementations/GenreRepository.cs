using MovieManagement.Core.Entities;
using MovieManagement.Core.Repository;
using MovieManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Infrastructure.Implementations
{
    public class GenreRepository:GenericRepository<Genre>,IGenreRepository
    {
        public GenreRepository(MovieManagementDbContext context ):base(context)
        {
        }
    }
}
