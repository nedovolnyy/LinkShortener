namespace LinkShortener.DataAccess.Repositories;

internal class BaseRepository<T>(IDatabaseContext databaseContext) : IRepository<T>
    where T : BaseEntity
{
    private readonly IDatabaseContext _databaseContext = databaseContext;
    private readonly DbSet<T> _dbSet = databaseContext.Instance.Set<T>();

    public virtual async Task InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _databaseContext.Instance.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _databaseContext.Instance.Entry(entity).State = EntityState.Modified;
        await _databaseContext.Instance.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await _databaseContext.Instance.SaveChangesAsync();
        }
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking();
    }
}
