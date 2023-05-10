namespace App.Models;

public class AllDataForUser
{
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public bool IsAdmin { get; set; }

    public string GroupDestriction { get; set; }
    
    public string StateDescription { get; set; }
}