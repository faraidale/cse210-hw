using System;

// Product class - represents a product in an order
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Calculate total cost for this product
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Get product name
    public string GetName()
    {
        return _name;
    }

    // Get product ID
    public string GetProductId()
    {
        return _productId;
    }
}
