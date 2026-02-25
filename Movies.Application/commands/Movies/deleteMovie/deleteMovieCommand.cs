using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.commands.Movies.deleteMovie
{
    public record deleteMovieCommand(int id): IRequest<Unit>;
   
}
