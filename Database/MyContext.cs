﻿using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class MyContext:DbContext
{
    public DbSet<UserData> UsersData { get; set; }
    public DbSet<UserGroupData> UserGroupsData { get; set; }
    public DbSet<UserStateData> UserStatesData { get; set; }

    public MyContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=user;Username=postgres;Password=root");
    }
}