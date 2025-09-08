namespace LinkShortener.BusinessLogic.Services;

internal abstract class BaseService<T>(IRepository<T> entityRepository) : IService<T>
    where T : BaseEntity
{
    private readonly IRepository<T> _entityRepository = entityRepository;

    public virtual async Task InsertAsync(T entity)
    {
        await ValidateAsync(entity);
        await _entityRepository.InsertAsync(entity);
    }

    public virtual async Task UpdateAsync(T entity)
    {
        await ValidateAsync(entity);
        await _entityRepository.UpdateAsync(entity);
    }

    public virtual async Task DeleteAsync(int id) =>
        await _entityRepository.DeleteAsync(id);
    public virtual async Task<T?> GetByIdAsync(int id) =>
        await _entityRepository.GetByIdAsync(id);
    public virtual async Task<IEnumerable<T>> GetAllAsync() =>
        await Task.FromResult(_entityRepository.GetAll().ToList());

    public abstract Task ValidateAsync(T entity);
}
