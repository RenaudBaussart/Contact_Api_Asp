using Contact_api_asp.net.Classes;
namespace Contact_api_asp.net.services
{
    public interface IRepository<T, TKey>
    {
        Task<T> GetById(TKey id);         // Read by id
        Task<IEnumerable<T>> GetAll();    // Read all
        void Add(T model);           // Create
        void Update(T model, TKey id);        // Update
        void Delete(TKey id);        // Delete
    }
}
