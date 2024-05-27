using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Bases;

public interface IBaseService : IDisposable
{
    ILogger logger { get; }
}