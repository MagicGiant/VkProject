using System.Xml.Linq;

namespace Database.Transactions;

public interface ITransactions <T>
{
    void Save(T entity);

    void Delete(T entity);

    void Delete(long id);

    T GetById(long id);

    void Update(T entity);

    ICollection<T> GetAll();
}