using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Core.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IActorRepository ActorRepository { get; }

        IMovieRepository MovieRepository { get; }

        IGenreRepository GenreRepository { get; }

        IBiographyRepository BiographyRepository { get; }

        int Save();


    }
}
