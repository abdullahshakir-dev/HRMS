using HRMS.Domain.Enums;

namespace HRMS.Domain.Entities;

public sealed class Employee : Entity
{
    public Employee(string firstName, string lastName,string email,string phoneNumber, string address, decimal salary, bool gender)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("First name, last name and email are required");
        }
        
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        Salary = salary;
        Gender = gender;
    }

    private Employee ()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
        Address = string.Empty;
        // False = Female , True = male
        Gender = true;
    }
    
    public string FirstName { get; private set; } 
    public string LastName { get;  private set; } 
    public string Email { get;  private set; } 
    public string PhoneNumber { get;  private set; } 
    public string Address { get;  private set; }
    public decimal Salary { get; private set; }
    public bool Gender { get; private set; }
    public Guid ProfileId { get; private set; }
    public Profile Profile { get; private set; } = null!;

}
