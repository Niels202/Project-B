using System;
using System.Collections.Generic;


class customer : user
{
    public string age;
 


    public customer(string name, string email, string phoneNumber, string role, string password, string age, int balance, List<string> shoppingCart) : base(name, email, phoneNumber, role, password, balance, shoppingCart)
    {   
        this.age = age;
        this.name = name;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.role = role;
        this.password = password;
        this.balance = balance;
        this.shoppingCart = shoppingCart;
    }

    //public string buyConsumables(int num, string name, int amount, float price)
    //{


    //}

    //public string makeReservation
    //{


    //}

}
