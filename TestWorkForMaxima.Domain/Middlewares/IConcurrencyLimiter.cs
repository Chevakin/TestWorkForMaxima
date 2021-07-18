using System.Threading.Tasks;

namespace TestWorkForMaxima.Domain.Middlewares
{
    public interface IConcurrencyLimiter
    {
        Task<bool> TryGo();

        void ReleaseOne();
    }
}
