using MicroErp.Domain.Repository.Orm.Abstract.Contexts;

namespace MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    Task<int> SaveChanges(CancellationToken cancellationToken = default);
    void OpenTransaction();
    void Commit();
    void Rollback(CancellationToken cancellationToken = default);
    void AddContext(IDbContext dataContext);
    void CloseTransaction();
}