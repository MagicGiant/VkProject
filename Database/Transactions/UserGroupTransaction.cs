using Database.Models;

namespace Database.Transactions;

public class UserGroupTransaction: ITransactions<UserGroupData>
{
    public void Save(UserGroupData entity)
    {
        using (MyContext myContext = new MyContext())
        {
            myContext.UserGroupsData.Add(entity);
            myContext.SaveChanges();
        }
    }

    public void Delete(UserGroupData entity)
    {
        using (MyContext context = new MyContext())
        {
            context.UserGroupsData.Remove(entity);
            context.SaveChanges();
        }
    }

    public void Delete(long id)
    {
        Delete(GetById(id));
    }

    public UserGroupData GetById(long id)
    {
        using (MyContext context = new MyContext())
        {
            return context.UserGroupsData.Find(id);
        }
    }

    public void Update(UserGroupData entity)
    {
        using (MyContext context = new MyContext())
        {
            context.UserGroupsData.Find(entity);
        }
    }

    public ICollection<UserGroupData> GetAll()
    {
        using (MyContext context = new MyContext())
        {
            return context.UserGroupsData.ToList();
        }
    }

    public UserGroupData getAdminGroupData()
    {
        using (MyContext context = new MyContext())
        {
            return context.UserGroupsData
                .FirstOrDefault(userGroupData => userGroupData.Code == GroupCode.Admin);
        }
    }
}