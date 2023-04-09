using Microsoft.EntityFrameworkCore;
using MovieManagement.Core.Entities;
using MovieManagement.Core.Repository;
using MovieManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Infrastructure.Implementations
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieManagementDbContext context) : base(context)
        {

        }

        public IEnumerable<Actor> GetActorsWithMovies()
        {
            var actorsWithMovies = _context.tblActors.Include(x => x.Movies).ToList();

            return actorsWithMovies;
        }
    }
}
