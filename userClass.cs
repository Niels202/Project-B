using System.Collections.Generic;
using System;
public class user
{
    public string name;
    public string email;
    public string phoneNumber;
    public string role;
    public string password;
    
    public user(string name, string email, string phoneNumber, string role, string password)
    {   
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.role = role;
        this.password = password;

    }
    public string getName()
    {
        return this.name;
    }

}

