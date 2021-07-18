using Microsoft.Extensions.Options;
using TestWorkForMaxima.Domain.Extensions;

namespace TestWorkForMaxima.Domain.Middlewares
{
    public class ConcurrencyRequestOptionsValidate : IValidateOptions<ConcurrentRequestOptions>
    {
        public ValidateOptionsResult Validate(string name, ConcurrentRequestOptions options)
        {
            if (options.Max > 0)
            {
                return ValidateOptionsResult.Success;
            }

            return ValidateOptionsResult.Fail($"{nameof(ConcurrentRequestOptions.Max)} должен быть больше 0");
        }
    }
}
