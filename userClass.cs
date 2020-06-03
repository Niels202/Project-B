using System.Collections.Generic;
using System;
public class user
{
    public string name;
    public string email;
    public string phoneNumber;
    public string role;
    public string password;
    public int balance;
    public List<string> shoppingCart;
    
    public user(string name, string email, string phoneNumber, string role, string password, int balance, List<string> shoppingCart)
    {   
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.role = role;
        this.password = password;
        this.balance = balance;
        this.shoppingCart = shoppingCart;

    }
    public string getName()
    {
        return this.name;
    }

}

