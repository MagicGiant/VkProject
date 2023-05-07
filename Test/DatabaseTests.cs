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
        UserGroupTransactions transactions = new UserGroupTransactions();
        transactions.Save(userGroupData);
    }

    [Fact]
    public void CreateEnumWithConverter_NoException()
    {
        StringToEnumConverter<GroupCode>.Execute(GroupCode.User.ToString());
    }
}