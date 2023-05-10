using BusinessLayer.Exceptions;
using Database;
using Database.Models;
using Database.Transactions;

namespace BusinessLayer.Entities;

public static class Manager
{
    public static void SaveUser(User user)
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
    
    public static User GetUser(Login login)
    {
        UserDataTransaction userDataTransaction = new UserDataTransaction();
        UserData userData = userDataTransaction.GetByLogin(login.ToString());

        return GetUser(userData);
    }

    public static User GetUser(UserData userData)
    {
        UserGroupData userGroupData = new UserGroupTransaction().GetById(userData.UserGroupId);
        UserStateData userStateData = new UserStateTransaction().GetById(userData.UserStateId);

        return new User(userData, userGroupData, userStateData);
    }

    public static User GetUserAndCheckPassword(Login login, Password password)
    {
        User user = GetUser(login);
        if (user.UserData.PasswordHashString != password.toHashString())
            throw ManagerException.WrongLoginOrPasswordException();

        return user;
    }

    public static ICollection<User> GetUsers()
    {
        UserDataTransaction userDataTransaction = new UserDataTransaction();
        List<User> users = new List<User>();

        foreach (var userData in userDataTransaction.GetAll())
            users.Add(GetUser(userData));

        return users;
    }

    public static void MakeBlocked(Login login)
    {
        GetUser(login).MakeBlocked();
    }

    public static void MakeBlocked(UserData userData) 
    {
        GetUser(userData).MakeBlocked();
        UserBuilder builder = new ();
    }

    public static void MakeActive(Login login)
    {
        GetUser(login).MakeActive();
    }

    public static void MakeActive(UserData userData)
    {
        GetUser(userData).MakeActive();
    }
}