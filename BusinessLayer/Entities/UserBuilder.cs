using BusinessLayer.Exceptions;
using Database;
using Database.Models;
using Database.Transactions;

namespace BusinessLayer.Entities;

public class UserBuilder
{
    private string _login;

    private string _password;

    private GroupCode _groupCode;

    private string _groupDestruction;

    private string _stateDestruction;

    public UserBuilder SetLogin(Login login)
    {
        ArgumentNullException.ThrowIfNull(login);
        if (new UserDataTransaction().GetByLogin(login.ToString()) is not null)
            throw UserBuilderException.CreateUserWithExistLogin(login.ToString());

        _login = login.ToString();
        return this;
    }

    public UserBuilder SetPassword (Password password)
    {
        ArgumentNullException.ThrowIfNull(password);
        _password = password.ToString();
        return this;
    }
    
    public UserBuilder SetGroupCode(GroupCode groupCode)
    {
        ArgumentNullException.ThrowIfNull(groupCode);
        if (groupCode == GroupCode.Admin && new UserGroupTransaction().getAdminGroupData() is not null)
            throw UserBuilderException.AdminException();

        _groupCode = groupCode;

        return this;
    }

    public UserBuilder SetGroupDestruction(string groupDestruction)
    {
        if (string.IsNullOrEmpty(groupDestruction))
            throw new ArgumentNullException();
        
        _groupDestruction = groupDestruction;
        return this;
    }

    public UserBuilder SetStateDestruction(string stateDestruction)
    {
        if (string.IsNullOrEmpty(stateDestruction))
            throw new ArgumentNullException();

        _stateDestruction = stateDestruction;
        return this;
    }

    public User Build()
    {
        if (IsNull(_login, _password, _groupDestruction, _stateDestruction, _groupCode))
            throw new ArgumentNullException();

        UserGroupData userGroupData = new UserGroupData
        {
            Code = _groupCode,
            Description = _groupDestruction
        };

        UserStateData userStateData = new UserStateData
        {
            Code = StateCode.Active,
            Description = _stateDestruction
        };


        UserData userData = new UserData
        {
            CreatedDate = DateTime.Now.ToString(),
            Login = _login,
            PasswordHashString = Password.GetHash(_password),
            IsAdmin = _groupCode == GroupCode.Admin,
            UserGroupId = userGroupData.Id,
            UserStateId = userStateData.Id
        };
        return new User(userData, userGroupData, userStateData);
    }

    private bool IsNull(params object[] args)
    {
        foreach (var arg in args)
        {
            if (arg is null)
                return true;
        }

        return false;
    }

}