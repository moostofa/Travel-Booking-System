using System;

public class Customer : User
{
    // key, booking id; value, type (hotel, airline)
    Dictionary<int, string> bookings = new Dictionary<int, string>();
    
    public Customer(string email, string password, string firstName, string lastName, string phone, string address, USER_TYPE type, int id) : base(email, password, firstName, lastName, phone, address, USER_TYPE.Customer, id)
    {

    }


    public string this[int key]
    {
        get { return bookings[key]; }
        set { bookings[key] = value; }
    }

}
