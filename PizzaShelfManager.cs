using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaShelfManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PizzaSlot;

    [SerializeField]
    private GameObject shelfPizza;

    [SerializeField]
    private Vector3 PizzaScale;

    [SerializeField]
    private Quaternion PizzaRotation;

    private void Start()
    {
        SetupPizzaShelves();
    }
    public void SetupPizzaShelves()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(shelfPizza, PizzaSlot[i].transform.position, shelfPizza.transform.rotation);
            shelfPizza.transform.localScale = PizzaScale;
            shelfPizza.transform.localRotation = PizzaRotation;
        }
    }
}
