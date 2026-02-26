using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contracts.Responses;
using Movies.Infrastructure;
using Movies.Contracts.Exceptions;
using Movies.Domain.Entities;
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
             throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {nameof(request.Id)}"+$"was not found in database");
            
            }

            return movie.Adapt<GetMovieByIdResponse>();
        }
    }
}
