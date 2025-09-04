using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    public PinPasScanner pinpasScanner;

    private void Update()
    {
        if(pinpasScanner.endPaid)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
        pinpasScanner.endPaid = false;
    }
}
