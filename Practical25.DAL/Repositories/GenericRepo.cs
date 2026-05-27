using Practical25.DAL.Data;

namespace Practical25.DAL.Repositories;

public class GenericRepo<TEntity>(AppDbContext dbContext) where TEntity : BaseEntity
{
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        dbContext.Set<TEntity>().Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
