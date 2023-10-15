// using System;
// using System.ComponentModel.Design;
// using System.Diagnostics;
// using System.Dynamic;
// using System.Reflection.Metadata;
// using System.Text.Json;
// using System.Text.Json.Serialization;
// using System.Xml;


// // This class manages serialization and deserialization of user account details (name, email, password etc.) to a txt file
// // We will eventually need another class that communicates with an actual DB such as Postgres (for bonus marks by introducing external DB with LINQ).
// public class FileManager
// {
//     private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models", "user_details.txt");
//     private static List<User> users = new List<User>();

//     // Deserializes the JSON txt file of user account details as a list of User objects
//     private List<User> readUsersFromFile()
//     {
//         string userData = File.ReadAllText(filePath);

//         JsonSerializerOptions options = new JsonSerializerOptions
//         {
//             WriteIndented = true,
//             Converters = { new UserConverter() },
//         };
//         try
//         {
//             List<User> userList = JsonSerializer.Deserialize<List<User>>(userData, options);
//             return userList;
//         }
//         catch (JsonException)
//         {
//             Console.WriteLine("List Empty");
//         }
//         return null;
//     }


//     public static List<User> getCustomersList()
//     {
//         List<User> userList = readUsersFromFile();
//         List<User> customerList = userList.FindAll(user => user.Type == USER_TYPE.);
//         return customerList;
//     }

//     public static Customer searchCustomer(string email)
//     {
//         foreach (Customer customer in getCustomersList())
//         {
//             if (customer.Email == email) 
//                 return customer;
//         }
//         return null;
//     }

//     public static Customer searchCustomer(int bookingNumber)
//     {
//         foreach (Customer customer in getCustomersList())
//         {
//             if (customer.bookings.ContainsKey(bookingNumber) = true)
//             {
//                 return customer
//             }
//         }
//         return null;
//     }

//     public static addUser(User user)
//     {
//         users = readUsersFromFile();
//         users.Add(user);
//         writeUsersToFile();
//     }

//     // for changing account details e.g 'First Name'
//     // NOT FOR Updating Booking - Check BookingManager.UpdateBooking(...)
//     public static void UpdateCustomerDetails<T>(Customer customer, string accountDetail, T change) where T : struct
//     {
//         List<User> users = readUsersFromFile();
//         int i = users.IndexOf((User)customer);
//         PropertyInfo prop = typeof(User).GetProperty(accountDetail);
//         if (prop != null && prop.CanWrite)
//         {
//             prop.SetValue(users[i], change);
//         }
//         else
//         {
//             Console.WriteLine("Update Customer Method: property (accountDetail) is null - check typo");
//         }
//     }


//     private static void writeUsersToFile()
//     {
//         JsonSerializerOptions options = new JsonSerializerOptions
//         {
//             WriteIndented = true,
//             Converters = { new UserConverter() },
//         };
//         string writeUsers = JsonSerializer.Serialize(users, options);
//         File.WriteAllText(filePath, writeUsers);
//     }

//     public static void addBooking(Customer user, KeyValuePair<int, string> bookingID)
//     {
//         users = readUsersFromFile();
//         try
//         {
//             int index = users.FindIndex(obj => obj.ID == user.ID);
//             if (user.Type == USER_TYPE.Customer)
//             {
//                 if (((Customer)users[index]).bookings != null)
//                 {
//                     ((Customer)users[index]).bookings.Add(bookingID);
//                 }
//                 else
//                 {
//                     // something is wrong since bookings dictionary can be empty, but should never be null (bookings was deleted or nullified, or not written properly to the file)
//                     // if this happens, you can initialise bookings and add bookingID for quick fix, but root issue should be investigated
//                     Console.WriteLine("Check addBooking Method in FileManager - bookings list is null") 
//                 }
//             }
//             writeUsersToFile();
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }


// public class UserConverter : JsonConverter<User>
// {
//     public override User Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//     {
//         using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
//         {
//             var root = doc.RootElement;
//             if (root.TryGetProperty("Type", out var typeProp) && typeProp.GetInt32() == 1)
//             {
//                 return JsonSerializer.Deserialize<Customer>(root.GetRawText());
//             }
//             else if (root.TryGetProperty("Type", out typeProp) && typeProp.GetInt32() == 0)
//             {
//                 return JsonSerializer.Deserialize<Admin>(root.GetRawText());
//             }
//             else
//             {
//                 Console.WriteLine("Error with file");
//                 Console.ReadKey();
//                 return JsonSerializer.Deserialize<User>(root.GetRawText());
//             }
//         }
//     }

//     public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options)
//     {
//         writer.WriteStartObject();
//         writer.WriteString("Email", value.Email);
//         writer.WriteString("Password", value.Password);
//         writer.WriteString("First Name", value.FirstName);
//         writer.WriteString("Last Name", value.LastName);
//         writer.WriteString("Phone", value.Phone);
//         writer.WriteString("Address", value.Address);
//         writer.WriteNumber("Type", (int)value.Type)
//         writer.WriteNumber("ID", (int)value.ID);

//         if (value is Customer customer && customer.Bookings != null)
//         {
//             writer.WriteStartObject("Bookings");
//             foreach (var booking in customer.Bookings)
//             {
//                 writer.WritePropertyName(booking.Key.ToString());
//                 writer.WriteStringValue(booking.Value);
//             }
//             writer.WriteEndObject();
//         }
//         writer.WriteEndObject();
//     }
// }



