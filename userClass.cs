using System.Collections.Generic;
using System;
public class user
{
    public string name;
    public int id;
    public string password;
    public string email;
    public string phoneNumber;

    public user(string name, int id, string email, string phoneNumber)
    {   
        this.name = name;
        this.id = id;
        this.email = email;
        this.phoneNumber = phoneNumber;
    }
    public int getId()
    {
        return this.id;
    }

}

