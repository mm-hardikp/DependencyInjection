using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    public class LifetimeService : IScopedService, ISingletonService, ITransientService
    {
        private readonly Guid _operationId;

        private readonly ILogger<LifetimeService> _logger;

        public LifetimeService(ILogger<LifetimeService> logger)
        {
            _operationId = Guid.NewGuid();
            _logger = logger;
            _logger.LogInformation($"Created {GetType().Name} with ID {_operationId}");
        }
        public Guid GetOperationId()
        {
            return _operationId;
        }
    }
}
