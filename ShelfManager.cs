using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] shelfSlot;

    [SerializeField]
    private GameObject shelfProduct;

    [SerializeField]
    private Vector3 Scale = new Vector3(2, 2, 2);

    [SerializeField]
    private Quaternion Rotation;

    private void Start()
    {
        SetupShelves();
    }

    public void SetupShelves()
    {
        for(int i = 0; i < 9; i++)
        {
            Instantiate(shelfProduct, shelfSlot[i].transform.position, shelfProduct.transform.rotation);
            shelfProduct.transform.localScale = Scale;
            shelfProduct.transform.localRotation = Rotation;
        }
    }
}
