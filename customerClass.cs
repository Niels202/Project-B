using System;


class customer : user
{
    public string age;
    


    public customer(string name, string email, string phoneNumber, string role, string password, string age) : base(name, email, phoneNumber, role, password)
    {   
        this.age = age;
    }

}


