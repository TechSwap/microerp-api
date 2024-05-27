using MicroErp.Domain.Repository.Orm.Abstract.Contexts;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Infra.Data.Repository.Orm.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace MicroErp.Infra.Data.Repository.Orm.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    protected IDbContext _context;
    protected IDbContextTransaction _transaction;                
   
    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangeAsync(cancellationToken);
    }

    public virtual void Commit()
    {
        if (_transaction == null)
        {
            return;
        }

        try
        {
            _context.SaveChangeAsync();
            _transaction.CommitAsync();
            _transaction = null;
        }
        catch
        {
            Rollback();
            throw;
        }
    }

    public virtual void Rollback(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            _transaction.RollbackAsync(cancellationToken);
            _transaction = null;
        }
    }        

    public void AddContext(IDbContext dataContext)
    {
        _context = dataContext;
    }

    public virtual void OpenTransaction()
    {
        if (_transaction == null)
        {
            _transaction = ((DbContext)_context).Database.BeginTransaction();
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }
    
    public void CloseTransaction()
    {
        _transaction?.Dispose();
    }
}