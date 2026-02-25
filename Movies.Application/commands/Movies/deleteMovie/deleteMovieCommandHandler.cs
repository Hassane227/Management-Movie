using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.commands.Movies.deleteMovie
{
    public class deleteMovieCommandHandler: IRequestHandler<deleteMovieCommand, Unit>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public deleteMovieCommandHandler(MoviesDbContext moviesDbContext) { 

            _moviesDbContext = moviesDbContext;

        }

        public async Task<Unit> Handle(deleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _moviesDbContext.Movies.FirstOrDefaultAsync(m => m.Id == request.id, cancellationToken);

            if (movie == null)
            {
                throw new Exception("Movie not found");
                
            }
             _moviesDbContext.Movies.RemoveRange(movie);
            await _moviesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }

    }
}
