using System;

public abstract class User
{
    public string Email { get; set; }
    protected string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public USER_TYPE Type { get; }
    public int Id { get; }

    public User(string email, string password, string firstName, string lastName, string phone, string address, USER_TYPE type, int id)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Address = address;
        Type = type;
        Id = id;
    }
}

public enum USER_TYPE
{
    Admin,
    Customer
}
