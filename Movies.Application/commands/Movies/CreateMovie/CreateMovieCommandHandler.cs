using MediatR;
using Movies.Domain.Entities;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.commands.Movies.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly MoviesDbContext _moviesDbContext;
        public CreateMovieCommandHandler(MoviesDbContext moviesDbContext) {

            _moviesDbContext = moviesDbContext;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
                CreateDate = DateTime.UtcNow
            };

            await _moviesDbContext.Movies.AddAsync(movie);
           await _moviesDbContext.SaveChangesAsync();

            return movie.Id;

            
        }


       
    }
}
