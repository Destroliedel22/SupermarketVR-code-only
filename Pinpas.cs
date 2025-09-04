using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pinpas : MonoBehaviour
{
    public int balance;

    public TextMeshProUGUI PinpasBalanceFront;
    public TextMeshProUGUI PinpasBalanceBack;

    public GameObject pinpasCanvas;

    bool PickedUp;

    public RaycastObject raycastObject;

    private void Start()
    {
        balance = Random.Range(1, 100);

        PickedUp = false;
    }

    private void FixedUpdate()
    {
        PinpasBalanceFront.text = "Pinpas balance: €" + balance;
        PinpasBalanceBack.text = "Pinpas balance: €" + balance;

        if(PickedUp)
        {
            pinpasCanvas.SetActive(false);
        }

        if(raycastObject.heldItem != null)
        {
            if (raycastObject.heldItem.transform.gameObject.CompareTag("pinpas"))
            {
                PickedUp = true;
            }
        }
    }
}
