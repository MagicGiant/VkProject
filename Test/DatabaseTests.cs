using BusinessLayer.Entities;
using Database.Entities;
using Database.Models;
using Database.Transactions;
using Xunit;
using Xunit.Abstractions;

namespace Test;

public class DatabaseTests
{
    [Fact]
    public void SaveUserGroup_NoException()
    {
        UserGroupData userGroupData = new UserGroupData { Code = GroupCode.User, Description = "lol" };
        UserGroupTransaction transaction = new UserGroupTransaction();
        transaction.Save(userGroupData);
    }

    [Fact]
    public void CreateEnumWithConverter_NoException()
    {
        StringToEnumConverter<GroupCode>.Execute(GroupCode.User.ToString());
    }

    [Fact]
    public void SaveUser_NoException()
    {
        new Manager().SaveUser(
            new UserBuilder()
                .SetLogin(new Login("Sherka"))
                .SetPassword(new Password("Root"))
                .SetGroupCode(GroupCode.User)
                .SetGroupDestruction("a")
                .SetStateDestruction("b")
                .Build());
    }
}