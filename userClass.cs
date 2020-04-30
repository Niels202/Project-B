using System.Collections.Generic;
using System;
public class user
{
    public string name;
    public int id;
    public string email;
    public string phoneNumber;
    public List<object> shoppingCart;

    public user(string name, int id, string email, string phoneNumber, List<object> shoppingCart)
    {   
        this.name = name;
        this.id = id;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.shoppingCart = shoppingCart;
    }
    public int getId()
    {
        return this.id;
    }

}

