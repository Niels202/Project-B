using System.Collections.Generic;
using System;
public class user
{
    public string name;
    public int id;
    public string email;
    public string phoneNumber;
    public List<object> shoppingCart;

    public user(string name, string email, string phoneNumber, List<object> shoppingCart)
    {   
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.shoppingCart = shoppingCart;
    }
    public int getId()
    {
        return this.id;
    }

}

