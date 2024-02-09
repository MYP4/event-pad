﻿namespace EventPad.Context;

public class DbSettings
{
    public DbType Type { get; set; }
    public string ConnectionString { get; private set; }
    public DbInitSettings Init { get; private set; }
}

public class DbInitSettings
{
    public bool AddDemoData { get; private set; }
    public bool AddAdmin { get; private set; }
    public UserCredentials Admin { get; private set; }
}

public class UserCredentials
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}