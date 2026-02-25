using FluentValidation;
using Movies.Application.commands.Movies;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.commands.Movies.CreateMovie
{
    public class CreatMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {

        public CreatMovieCommandValidator()
        {
            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage($"{nameof(Movie.Category)} cannot be empty")
                .MaximumLength(30)
                .WithMessage($"{nameof(Movie.Category)} cannot exceed 30 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage($"{nameof(Movie.Description)} cannot be empty")
                .MaximumLength(1000)
                .WithMessage($"{nameof(Movie.Description)} cannot exceed 1000 characters");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage($"{nameof(Movie.Title)} cannot be empty")
                .MaximumLength(100)
                .WithMessage($"{nameof(Movie.Title)} cannot exceed 100 characters");

        }

    }
}
