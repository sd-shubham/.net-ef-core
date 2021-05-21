using CoreAPIAndEfCore.Common;

namespace CoreAPIAndEfCore.Services
{
    public interface IServiceContext : IScopedService
    {
        public int UserId { get; }
    }
}