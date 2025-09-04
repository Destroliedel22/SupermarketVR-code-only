using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermarketManager : MonoBehaviour
{
    [SerializeField]
    private List<Product> products = new List<Product>();

    public void RegisterProduct(Product product)
    {
        if(!products.Contains(product))
        {
            products.Add(product);
        }
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }
}
