using DDD.Domain;
using FluentValidation;
using MediatR;

namespace DDD.Kitchen.Application.Behaviours;

public class ValidationPipelineBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
     : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
     where TResponse : Result
{
     private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

     /// <summary>
     /// 1. Validate request
     /// 2. If there is any errors, return validation result
     /// 3. Otherwise, return next();
     /// </summary>
     /// <param name="request"></param>
     /// <param name="next"></param>
     /// <param name="cancellationToken"></param>
     /// <returns></returns>
     public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
     {
          if (!_validators.Any())
          {
               return await next();
          }
          
          var errors = _validators
               .Select(v => v.Validate(request))
               .SelectMany(validationResult => validationResult.Errors)
               .Where(validationResult => validationResult is not null)
               .Select(failure => new Error(failure.PropertyName, failure.ErrorMessage))
               .Distinct()
               .ToArray();

          if (errors.Length != 0)
          {
               return CreateValidationResult<TResponse>(errors);
          }
          
          return await next();
     }

     private static TResult CreateValidationResult<TResult>(Error[] errors)
          where TResult : Result
     {
          if (typeof(TResult) == typeof(Result))
          {
               return (ValidationResult.WithErrors(errors) as TResult)!;
          }

          object validationResult = typeof(ValidationResult<>)
               .GetGenericTypeDefinition()
               .MakeGenericType(typeof(TResult).GetGenericArguments()[0])
               .GetMethod(nameof(ValidationResult.WithErrors))!
               .Invoke(null, [errors])!;

          return (TResult)validationResult;
     }
}