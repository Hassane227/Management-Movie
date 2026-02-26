using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.commands.Movies.UpdateMovie
{
    internal class UpdateMovieCommandValidator: AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator() { 
        
                RuleFor(x => x.id).NotEmpty()
                    .WithMessage($"{nameof(UpdateMovieCommand.id)} cannot be empty");
    
                RuleFor(x => x.Category)
                    .NotEmpty()
                    .WithMessage($"{nameof(UpdateMovieCommand.Category)} cannot be empty")
                    .MaximumLength(30)
                    .WithMessage($"{nameof(UpdateMovieCommand.Category)} cannot exceed 30 characters");
    
                RuleFor(x => x.Description)
                    .NotEmpty()
                    .WithMessage($"{nameof(UpdateMovieCommand.Description)} cannot be empty")
                    .MaximumLength(1000)
                    .WithMessage($"{nameof(UpdateMovieCommand.Description)} cannot exceed 1000 characters");
    
                RuleFor(x => x.Title)
                    .NotEmpty()
                    .WithMessage($"{nameof(UpdateMovieCommand.Title)} cannot be empty")
                    .MaximumLength(100)
                    .WithMessage($"{nameof(UpdateMovieCommand.Title)} cannot exceed 100 characters");

        }
    }
}
