using Database.Exceptions;
using Database.Models;

namespace Database.Transactions;

public class UserTransaction: ITransactions<UserData>
{
    public bool isExistAdmin()
    {
        UserGroupTransactions userGroupTransactions = new UserGroupTransactions();

        return userGroupTransactions.getAdminGroupData() is not null;
    }
    
    public void Save(UserData entity)
    {
        if (entity.IsAdmin && isExistAdmin())
            TransactionsException.AdminCountException();
        
        using (AppContext context = new AppContext())
        {
            context.UsersData.Add(entity);
            context.SaveChanges();
        }
    }

    public void Delete(UserData entity)
    {
        using (AppContext context = new AppContext())
        {
            context.UsersData.Remove(entity);
            context.SaveChanges();
        }
    }

    public UserData GetById(long id)
    {
        using (AppContext context = new AppContext())
        {
            return context.UsersData.Find(id);
        }
    }

    public void Update(UserData entity)
    {
        using (AppContext context = new AppContext())
        {
            context.UsersData.Update(entity);
        }
    }
}