using System;

// Customer class - represents a customer
public class Customer
{
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Check if customer is in USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    // Get customer name
    public string GetName()
    {
        return _name;
    }

    // Get customer address
    public Address GetAddress()
    {
        return _address;
    }
}
