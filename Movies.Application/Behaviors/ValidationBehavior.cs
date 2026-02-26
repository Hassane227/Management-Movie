using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Movies.Contracts.Errors;
using System.Data;
using Movies.Contracts.Exceptions;


namespace Movies.Application.Behaviors
{
    public class ValidationBehavior<TRequest,TReponse>: IPipelineBehavior<TRequest,TReponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _Validator;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> Validator) { 
        
            _Validator = Validator;
        }


        public async Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
        {

             var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _Validator.Select(x => x.ValidateAsync(context, cancellationToken))
                );

            var failures = validationResults.Where(x => !x.IsValid)
                .SelectMany(x => x.Errors)
                .Select(x => new ValidationError
                {
                  Property = x.PropertyName,
                  ErrorMessage = x.ErrorMessage
                }).ToList();
            if (failures.Any())
            {
                throw new CustomValidationException(failures);
            }

            var Response  = await next();

            return Response;
        
        }
    }
}
