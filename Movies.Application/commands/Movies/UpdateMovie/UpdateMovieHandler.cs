using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contracts.Exceptions;
using Movies.Domain.Entities;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.commands.Movies.UpdateMovie
{
    public class UpdateMovieHandler: IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly MoviesDbContext _moviesDbContext;

        public UpdateMovieHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }


        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _moviesDbContext.Movies.FirstOrDefaultAsync(m => m.Id == request.id, cancellationToken);

            if (movie == null)
            {

                throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {nameof(request.id)}" + $"was not found in database");
            }

            movie.Title = request.Title;
                movie.Description = request.Description;
                movie.Category = request.Category;
                 _moviesDbContext.Movies.Update(movie);
                await _moviesDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
