using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinPasScanner : MonoBehaviour
{
    public Register register;

    public GameObject PaidCanvas;

    int payPrice;

    bool paid = false;

    public bool endPaid = false;

    public void FixedUpdate()
    {
        payPrice = register.totalPrice;

        if(paid)
        {
            StartCoroutine(PaidCanvasActive());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pinpas") && paid == false && payPrice > 0)
        {
            int balance = other.GetComponent<Pinpas>().balance;
            if (balance >= payPrice)
            {
                balance -= payPrice;
                other.GetComponent<Pinpas>().balance = balance;
                StartCoroutine(PaymentComplete());
                StartCoroutine(shopkeeperWave());
                endPaid = true;
            }
            else
            {
                StartCoroutine(paymentFailed());
                StartCoroutine(shopkeeperSigh());
            }
        }
    }


    IEnumerator PaymentComplete()
    {
        register.totalPrice = 0;
        register.registerProductsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Payment completed";
        paid = true;
        yield return new WaitForSeconds(2);
        register.registerProductsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Put your Product on te grey box to scan";
        paid = false;
    }

    private IEnumerator paymentFailed()
    {
        register.registerProductsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Payment failed, balance too low";
        yield return new WaitForSeconds(2);
        register.registerProductsText.GetComponent<TMPro.TextMeshProUGUI>().text = "Put your Product on te grey box to scan";
    }

    private IEnumerator shopkeeperWave()
    {
        register.shopkeeper.GetComponent<ShopKeeper>().state = ShopKeeper.ShopKeeperState.Wave;
        yield return new WaitForSeconds(5);
        register.shopkeeper.GetComponent<ShopKeeper>().state = ShopKeeper.ShopKeeperState.Idle;
    }

    private IEnumerator shopkeeperSigh()
    {
        register.shopkeeper.GetComponent<ShopKeeper>().state = ShopKeeper.ShopKeeperState.Sigh;
        yield return new WaitForSeconds(5);
        register.shopkeeper.GetComponent<ShopKeeper>().state = ShopKeeper.ShopKeeperState.Idle;
    }

    IEnumerator PaidCanvasActive()
    {
        yield return new WaitForSeconds(2);
        PaidCanvas.SetActive(true);
        yield return new WaitForSeconds(5);
        PaidCanvas.SetActive(false);
    }
}
