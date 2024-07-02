namespace Quizz.Domain.Core.Interfaces
{
    public interface ICRUDRepository<T, R>
    {
        Task<R> Add(T request);
        Task<bool> Delete(T request);
        Task<List<R>> getAll();
        Task<R> GetById(int id);
        Task<R> Update(T request);
    }
}