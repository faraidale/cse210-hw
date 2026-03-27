using System;
using System.Collections.Generic;

// Order class - represents a customer order
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculate total cost including shipping
    public double CalculateTotal()
    {
        double subtotal = 0;
        
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        // Add shipping cost
        double shippingCost;
        if (_customer.IsInUSA())
        {
            shippingCost = 5.00;
        }
        else
        {
            shippingCost = 35.00;
        }

        return subtotal + shippingCost;
    }

    // Get packing label
    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";
        
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        
        return label;
    }

    // Get shipping label
    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL:\n";
        label += _customer.GetName() + "\n";
        label += _customer.GetAddress().GetFullAddress();
        
        return label;
    }
}
