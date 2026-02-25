using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contracts.Responses;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries.Movies.GetMovieById
{
    public class GetMovieByIdQueryHandler: IRequestHandler<GetMovieByIdQuery, GetMovieByIdResponse>
    {

        private readonly MoviesDbContext _MovieDbContext;
        public GetMovieByIdQueryHandler(MoviesDbContext context)
        {

            _MovieDbContext = context;
        }

        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _MovieDbContext.Movies.FirstOrDefaultAsync(m=> m.Id == request.Id,cancellationToken);
            if(movie is null)
            {
             throw new Exception("Movie not found");
            
            }

            return movie.Adapt<GetMovieByIdResponse>();
        }
    }
}
