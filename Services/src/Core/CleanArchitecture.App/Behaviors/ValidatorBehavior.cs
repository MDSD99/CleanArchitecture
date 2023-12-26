using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.App.Behaviors
{
    public class ValidatorBehavior<TRequest, IResponse> : IPipelineBehavior<TRequest, IResponse> where TRequest : class, IRequest<IResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<IResponse> Handle(TRequest request, RequestHandlerDelegate<IResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return await next();
            var context = new ValidationContext<TRequest>(request);
            var errorDictionary = _validators.Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(x => x.PropertyName, s => s.ErrorMessage, (properyName, errorMessage) => new
            {
                Key=properyName,
                Values =errorMessage.Distinct().ToArray()
            }).ToDictionary(s => s.Key, s => s.Values[0]);
            if (errorDictionary.Any())
            {
                var errors = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });
                throw new FluentValidation.ValidationException(errors);

            }
            return await next();
        }
    }
}
