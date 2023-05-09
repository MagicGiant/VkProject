using Database.Models;

namespace Database.Transactions;

public class UserStateTransaction : ITransactions<UserStateData>
{
    public void Save(UserStateData entity)
    {
        using (MyContext myContext = new MyContext())
        {
            myContext.UserStatesData.Add(entity);
            myContext.SaveChanges();
        }
    }

    public void Delete(UserStateData entity)
    {
        using (MyContext context = new MyContext())
        {
            context.UserStatesData.Remove(entity);
            context.SaveChanges();
        }
    }

    public void Delete(long id)
    {
        Delete(GetById(id));
    }

    public UserStateData GetById(long id)
    {
        using (MyContext context = new MyContext())
        {
            return context.UserStatesData.Find(id);
        }
    }

    public void Update(UserStateData entity)
    {
        using (MyContext context = new MyContext())
        {
            context.UserStatesData.Find(entity);
        }
    }

    public ICollection<UserStateData> GetAll()
    {
        using (MyContext context = new MyContext())
        {
            return context.UserStatesData.ToList();
        }
    }
}