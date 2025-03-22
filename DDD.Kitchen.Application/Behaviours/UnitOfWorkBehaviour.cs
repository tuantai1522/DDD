using DDD.Domain;
using FluentValidation;
using MediatR;

namespace DDD.Kitchen.Application.Behaviours;

public sealed class UnitOfWorkBehaviour<TRequest, TResponse>(IUnitOfWork unitOfWork)
     : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
     where TResponse : Result
{
     private readonly IUnitOfWork _unitOfWork = unitOfWork;
     
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
          // This is query, no need to wrap in transaction
          if (IsNotCommand())
          {
               return await next();
          }

          var response = await next();
          
          await _unitOfWork.SaveChangesAsync(cancellationToken);

          return response;
     }

     private static bool IsNotCommand()
     {
          return !typeof(TRequest).Name.EndsWith("Command");
     }
}