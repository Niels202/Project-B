using System.Collections.Generic;
using System;
public class user
{
    public string name;
    public int id;
    public string email;
    public string phoneNumber;
    public string role;
    public int balance;
    public List<string> shoppingCart;
    
    public user(string name, string email, string phoneNumber, string role, int balance, List<string> shoppingCart)
    {   
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.role = role;
        this.balance = balance;
        this.shoppingCart = shoppingCart;

    }
    public string getName()
    {
        return this.name;
    }

}

