using Database.Models;

namespace Database.Transactions;

public class UserGroupTransactions: ITransactions<UserGroupData>
{
    public void Save(UserGroupData entity)
    {
        using (AppContext appContext = new AppContext())
        {
            appContext.UserGroupsData.Add(entity);
            appContext.SaveChanges();
        }
    }

    public void Delete(UserGroupData entity)
    {
        using (AppContext context = new AppContext())
        {
            context.UserGroupsData.Remove(entity);
            context.SaveChanges();
        }
    }

    public UserGroupData GetById(long id)
    {
        using (AppContext context = new AppContext())
        {
            return context.UserGroupsData.Find(id);
        }
    }

    public void Update(UserGroupData entity)
    {
        using (AppContext context = new AppContext())
        {
            context.UserGroupsData.Find(entity);
        }
    }

    public UserGroupData getAdminGroupData()
    {
        using (AppContext context = new AppContext())
        {
            var que = context.UserGroupsData
                .Where(userGroupData => userGroupData.Code == GroupCode.Admin);
            if (que.Any())
                return que.First();
            return null;
        }
    }
}