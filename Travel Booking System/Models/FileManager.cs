using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

public class FileManager
{
    private static string filePath = //relative path;
    private static List<User> users = new List<User>();

    //gets updated list from file
    private List<User> getList()
    {
        string userData = File.ReadAllText(filePath);

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new UserConverter() },
        };
        try
        {
            List<User> userList = JsonSerializer.Deserialize<List<User>>(userData, options);
            return userList;
        }
        catch (JsonException)
        {
            Console.WriteLine("List Empty");
        }
        return null;
    }


    public static List<User> getCustomersList()
    {
        List<User> userList = FileManager.getList();
        List<User> customerList = userList.FindAll(user => user.Type == USER_TYPE.);
        return customerList;
    }

    //search by email - can change to whatever
    public static Customer searchCustomer(string email)
    {
        foreach (Customer customer in getCustomersList())
        {
            if (customer.Email == email) 
                return customer;
        }
        return null;
    }

    //search by booking
    public static Customer searchCustomer(int bookingNumber)
    {
        foreach (Customer customer in getCustomersList())
        {
            if (customer.bookings.ContainsKey(bookingNumber) = true)
            {
                return customer
            }
        }
        return null;
    }

    public static addUser(User user)
    {
        users = getList();
        users.Add(user);
        saveData();
    }

    public static void saveData()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new UserConverter() },
        };
        string writeUsers = JsonSerializer.Serialize(users, options);
        File.WriteAllText(filePath, writeUsers);
    }

    public static void addBooking(Customer user, KeyValuePair<int, string> bookingID)
    {
        users = getList();
        try
        {
            int index = users.FindIndex(obj => obj.ID == user.ID);
            if (user.Type == USER_TYPE.Customer)
            {
                if (((Customer)users[index]).bookings != null)
                {
                    ((Customer)users[index]).bookings.Add(bookingID);
                }
                else
                {
                    Console.WriteLine("Check addBooking Method - bookings list is null")
                        // initialise bookings and add bookingID for quick fix - but something is wrong (clearing the dictionary data, or not being written properly)
                }
            }
            saveData();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    //update method (altering profile info)
}


public class UserConverter : JsonConverter<User>
{
    public override User Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;
            if (root.TryGetProperty("Type", out var typeProp) && typeProp.GetInt32() == 1)
            {
                return JsonSerializer.Deserialize<Customer>(root.GetRawText());
            }
            else if (root.TryGetProperty("Type", out typeProp) && typeProp.GetInt32() == 0)
            {
                return JsonSerializer.Deserialize<Admin>(root.GetRawText());
            }
            else
            {
                Console.WriteLine("Error with file");
                Console.ReadKey();
                return JsonSerializer.Deserialize<User>(root.GetRawText());
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("Email", value.Email);
        writer.WriteString("Password", value.Password);
        writer.WriteString("First Name", value.FirstName);
        writer.WriteString("Last Name", value.LastName);
        writer.WriteString("Phone", value.Phone);
        writer.WriteString("Address", value.Address);
        writer.WriteNumber("Type", (int)value.Type)
        writer.WriteNumber("ID", (int)value.ID);

        if (value is Customer customer && customer.Bookings != null)
        {
            writer.WriteStartObject("Bookings");
            foreach (var booking in customer.Bookings)
            {
                writer.WritePropertyName(booking.Key.ToString());
                writer.WriteStringValue(booking.Value);
            }
            writer.WriteEndObject();
        }
        writer.WriteEndObject();
    }



}



