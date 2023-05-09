using Database.Exceptions;
using Database.Models;

namespace Database.Transactions;

public class UserDataTransaction: ITransactions<UserData>
{
    public bool isExistAdmin()
    {
        UserGroupTransaction userGroupTransaction = new UserGroupTransaction();

        return userGroupTransaction.getAdminGroupData() is not null;
    }
    
    public void Save(UserData entity)
    {
        if (entity.IsAdmin && isExistAdmin())
            TransactionsException.AdminCountException();
        
        using (MyContext context = new MyContext())
        {
            context.UsersData.Add(entity);
            context.SaveChanges();
        }
    }

    public void Delete(UserData entity)
    {
        UserGroupData userGroupData = new UserGroupTransaction()
            .GetById(entity.UserGroupId);
        UserStateData userStateData = new UserStateTransaction()
            .GetById(entity.UserStateId);
        using (MyContext context = new MyContext())
        {
            context.UsersData.Remove(entity);
            context.UserGroupsData.Remove(userGroupData);
            context.UserStatesData.Remove(userStateData);
            context.SaveChanges();
        }
    }

    public void Delete(long id)
    {
        Delete(GetById(id));
    }

    public UserData GetByLogin(string login)
    {
        using (MyContext context = new MyContext())
        {
            return context.UsersData.FirstOrDefault(userData => userData.Login == login);
        }
    }

    public UserData GetById(long id)
    {
        using (MyContext context = new MyContext())
        {
            return context.UsersData.Find(id);
        }
    }

    public void Update(UserData entity)
    {
        using (MyContext context = new MyContext())
        {
            context.UsersData.Update(entity);
        }
    }

    public ICollection<UserData> GetAll()
    {
        using (MyContext context = new MyContext())
        {
            return context.UsersData.ToList();
        }
    }
}