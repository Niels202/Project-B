using System.Collections.Generic;
using System;
public class user
{
    public string name;
    public int id;
    public string email;
    public string phoneNumber;
    public string role;
    
    public user(string name, string email, string phoneNumber, string role)
    {   
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.role = role;

    }
    public string getName()
    {
        return this.name;
    }

}

