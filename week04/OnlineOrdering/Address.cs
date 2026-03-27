using System;

// Address class - represents a physical address
public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Check if address is in USA
    public bool IsInUSA()
    {
        return _country == "USA";
    }

    // Get formatted address string
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}
