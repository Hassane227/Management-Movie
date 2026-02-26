using FluentValidation;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries.Movies.GetMovieById
{
    public class  GetMoviByIdQueryValidator: AbstractValidator<GetMovieByIdQuery>
    {

        public GetMoviByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
              .WithMessage($"{nameof(Movie.Id)}").NotEmpty()
              .WithMessage($"{nameof(Movie.Id)} cannot be empty");
        }
        
    }

}
