using System;

public class Admin : User
{
    public Customer(string email, string password, string firstName, string lastName, string phone, string address, USER_TYPE type, int id) : base(email, password, firstName, lastName, phone, address, USER_TYPE.Admin, id)
    {

    }
}
