using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Register : MonoBehaviour
{
    public bool scannerActive;

    public float scannerCoolDown;

    public TextMeshProUGUI registerProductsText;
    public TextMeshProUGUI registerTotalPriceText;

    [SerializeField]
    AudioSource BeepSound;
    [SerializeField]
    AudioClip BeepSoundClip;

    [HideInInspector]
    public string productName;
    [HideInInspector]
    public int totalPrice;

    public float productNameDissapears;

    public GameObject shopkeeper;

    public List<Product> scannedProducts = new List<Product>();

    private void Start()
    {
        scannerActive = true;

        BeepSound.clip = BeepSoundClip;

        productName = "Put your Product on te grey box to scan";
        registerProductsText.text = productName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (scannerActive) {
            if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Pringles"))
            {
                scannedProducts.Add(other.gameObject.GetComponent<Product>());
                scannerActive = false;

                AddToCanvas(other.GetComponent<Product>().Price);

                BeepSound.Play();

                StartCoroutine(CoolDown());
                StartCoroutine(ProductNameDissapear());
            }
        }
    }

    private void FixedUpdate()
    {
        registerTotalPriceText.text = ("€" + totalPrice + ",-");
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(scannerCoolDown);
        scannerActive = true;
    }

    public void AddToCanvas(int price)
    {
        foreach(Product product in scannedProducts)
        {
            productName = " + " + product.ProductName + "<BR>";
        }
        totalPrice += price;
        registerProductsText.text = productName;
    }

    private IEnumerator ProductNameDissapear()
    {
        yield return new WaitForSeconds(productNameDissapears);
        registerProductsText.GetComponent<TextMeshProUGUI>().text = "Put your Product on te grey box to scan";
    }
}
