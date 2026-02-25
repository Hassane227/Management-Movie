using MediatR;
using Movies.Contracts.Responses;
using Movies.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Mapster;


namespace Movies.Application.Queries.Movies.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, GetMoviesResponse>
    {

        private readonly MoviesDbContext _MovieDbContext;
        public GetMoviesQueryHandler(MoviesDbContext context) { 
            
            _MovieDbContext = context ;
        }
        public async Task<GetMoviesResponse> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _MovieDbContext.Movies.ToListAsync(cancellationToken);
           
            return movies.Adapt<GetMoviesResponse>();
        }
    }
}
