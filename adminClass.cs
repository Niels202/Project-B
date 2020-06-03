using System;
using System.Collections.Generic;


class admin : user
{
    public admin(string name, string email, string phoneNumber, string role, string password, int balance, List<string> shoppingCart) : base(name, email, phoneNumber, role, password, balance, shoppingCart)
    {   
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.role = role;
        this.password = password;
        this.balance = balance;
        this.shoppingCart = shoppingCart;
    }
}