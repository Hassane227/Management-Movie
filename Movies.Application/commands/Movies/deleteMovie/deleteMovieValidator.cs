using FluentValidation;
using Movies.Domain.Entities;

using Movies.Application.commands.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.commands.Movies.deleteMovie
{
    public  class deleteMovieValidator: AbstractValidator<deleteMovieCommand>
    {
        public deleteMovieValidator() {

            RuleFor(x => x.id).NotEmpty()
                .WithMessage($"{nameof(Movie.Id)}").NotEmpty()
                .WithMessage($"{nameof(Movie.Id)} cannot be empty");
        
        }

    }
}
