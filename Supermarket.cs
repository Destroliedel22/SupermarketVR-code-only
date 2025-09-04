using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supermarket : MonoBehaviour
{
    public List<Product> products = new List<Product>();

    private void Start()
    {
        Electronics electronics = new Electronics();
        electronics.ProductName = "LED lamp";
        electronics.Price = 5;
        electronics.Model = "Red";
        electronics.Brand = "Philips";

        Clothing clothing = new Clothing();
        clothing.ProductName = "Pants";
        clothing.Price = 10;
        clothing.Size = "M";
        clothing.Color = "Blue";

        //products.Add(clothing);
        //products.Add(electronics);
    }
}
