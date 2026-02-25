using MediatR;
using Movies.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries.Movies.GetMovieById
{
    public record GetMovieByIdQuery(int Id): IRequest<GetMovieByIdResponse>;
    
}
