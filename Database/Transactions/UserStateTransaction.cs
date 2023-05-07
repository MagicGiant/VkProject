using Database.Models;

namespace Database.Transactions;

public class UserStateTransaction : ITransactions<UserStateData>
{
    public void Save(UserStateData entity)
    {
        using (AppContext appContext = new AppContext())
        {
            appContext.UserStatesData.Add(entity);
            appContext.SaveChanges();
        }
    }

    public void Delete(UserStateData entity)
    {
        using (AppContext context = new AppContext())
        {
            context.UserStatesData.Remove(entity);
            context.SaveChanges();
        }
    }

    public UserStateData GetById(long id)
    {
        using (AppContext context = new AppContext())
        {
            return context.UserStatesData.Find(id);
        }
    }

    public void Update(UserStateData entity)
    {
        using (AppContext context = new AppContext())
        {
            context.UserStatesData.Find(entity);
        }
    }
}