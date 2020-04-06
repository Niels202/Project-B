using System;
public class user
{
    public string name;
    public int id;
    public string password;
    public string email;
    public string phoneNumber;

    public user(string name, int id, string password, string email, string phoneNumber)
    {   
        this.name = name;
        this.id = id;
        this.password = password;
        this.email = email;
        this.phoneNumber = phoneNumber;
    }
    public int getId()
    {
        return this.id;
    }
    public string login()
    {
        
        Console.WriteLine("Enter your password");
        string enteredPassword = Console.ReadLine();
        if (enteredPassword == this.password)
        {
            return "Login succesful";
        }
        else
        {
            return "Login failed";
        }
    }

}

