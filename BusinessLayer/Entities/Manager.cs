using BusinessLayer.Exceptions;
using Database;
using Database.Models;
using Database.Transactions;

namespace BusinessLayer.Entities;

public class Manager
{
    public void SaveUser(User user)
    {
        using (MyContext context = new MyContext())
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    new UserGroupTransaction().Save(user.UserGroupData);
                    new UserStateTransaction().Save(user.UserStateData);

                    user.UserData.UserGroupId = user.UserGroupData.Id;
                    user.UserData.UserStateId = user.UserStateData.Id;

                    new UserDataTransaction().Save(user.UserData);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }
    }
    
    public User GetUser(Login login)
    {
        UserDataTransaction userDataTransaction = new UserDataTransaction();
        UserData userData = userDataTransaction.GetByLogin(login.ToString());

        return GetUser(userData);
    }

    public User GetUser(UserData userData)
    {
        UserGroupData userGroupData = new UserGroupTransaction().GetById(userData.UserGroupId);
        UserStateData userStateData = new UserStateTransaction().GetById(userData.UserStateId);

        return new User(userData, userGroupData, userStateData);
    }

    public ICollection<User> GetUsers()
    {
        UserDataTransaction userDataTransaction = new UserDataTransaction();
        List<User> users = new List<User>();

        foreach (var userData in userDataTransaction.GetAll())
            users.Add(GetUser(userData));

        return users;
    }

    public void MakeBlocked(Login login)
    {
        GetUser(login).MakeBlocked();
    }

    public void MakeBlocked(UserData userData) 
    {
        GetUser(userData).MakeBlocked();
        UserBuilder builder = new ();
    }

    public void MakeActive(Login login)
    {
        GetUser(login).MakeActive();
    }

    public void MakeActive(UserData userData)
    {
        GetUser(userData).MakeActive();
    }
}