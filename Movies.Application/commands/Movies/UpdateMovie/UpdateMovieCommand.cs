using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Movies.Domain.Entities;

namespace Movies.Application.commands.Movies.UpdateMovie
{
    public record UpdateMovieCommand(int id, string Title, string Description, string Category ) : IRequest<Unit>;

 
}
