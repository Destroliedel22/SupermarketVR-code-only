using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Interactable")
        {
            Destroy(collision.gameObject);
        }
    }
}
