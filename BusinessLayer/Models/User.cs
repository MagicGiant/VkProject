using Database.Models;
using Database.Transactions;

namespace BusinessLayer.Entities;

public class User
{
    public User(UserData userData, UserGroupData userGroupData, UserStateData userStateData)
    {
        ArgumentNullException.ThrowIfNull(userData);
        ArgumentNullException.ThrowIfNull(userGroupData);
        ArgumentNullException.ThrowIfNull(userStateData);
        
        UserData = userData;
        UserGroupData = userGroupData;
        UserStateData = userStateData;
    }

    public UserData UserData { get;}
    
    public UserGroupData UserGroupData { get;}
    
    public UserStateData UserStateData { get; }

    public void MakeBlocked()
    {
        UserStateData.Code = StateCode.Blocked;
        new UserDataTransaction().Update(UserData);
    }

    public void MakeActive()
    {
        UserStateData.Code = StateCode.Active;
        new UserDataTransaction().Update(UserData);
    }
}