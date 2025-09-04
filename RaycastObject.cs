using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RaycastObject : MonoBehaviour
{
    public Transform handTransform;
    public Transform lineTransform;

    private bool raycastActive;

    public bool isObjectHeld = false;
    public GameObject heldItem = null;

    public Transform trackingSpace;

    bool lampsActive = true;
    public GameObject Light;

    [SerializeField]
    float raycastRange;

    public GameObject Line;

    private void Start()
    {
        raycastActive = false;
    }

    void Update()
    {
        RaycastHit hit;
        if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if(Physics.Raycast(handTransform.position, lineTransform.forward, out hit, raycastRange))
            {
                if(hit.collider.gameObject.CompareTag("Interactable") || hit.collider.gameObject.CompareTag("pinpas") || hit.collider.gameObject.CompareTag("Pringles"))
                {
                    if(!isObjectHeld)
                    {
                        heldItem = hit.transform.gameObject;
                        heldItem.transform.parent = handTransform;
                        heldItem.transform.localPosition = Vector3.zero;
                        heldItem.GetComponent<Rigidbody>().useGravity = false;
                        heldItem.GetComponent<Rigidbody>().isKinematic = true;
                        isObjectHeld = true;
                    }
                }
            }
        }

        if(!OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && isObjectHeld)
        {
            heldItem.GetComponent<Rigidbody>().useGravity = true;
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            heldItem.transform.localPosition = Vector3.zero;

            Vector3 linearVelocity = trackingSpace.rotation * OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            Vector3 angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch);
            heldItem.GetComponent<Rigidbody>().velocity = linearVelocity;
            heldItem.GetComponent<Rigidbody>().angularVelocity = angularVelocity;

            heldItem.transform.parent = null;
            RemoveItemFromHand();
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (Physics.Raycast(handTransform.position, lineTransform.forward, out hit, raycastRange))
            {
                if (hit.collider.gameObject.CompareTag("LightSwitch"))
                {
                    if (lampsActive == true)
                    {
                        Light.SetActive(true);
                        StartCoroutine(LightsOut());
                    }
                    else
                    {
                        Light.SetActive(false);
                        StartCoroutine(LightsOn());
                    }
                }
                if (hit.collider.gameObject.CompareTag("Button"))
                {
                    if (raycastActive == false)
                    {
                        raycastActive = true;
                        hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                        StartCoroutine(SetRaycastFalse());
                    }
                }
            }
        }

        if (heldItem != null)
        {
            Line.SetActive(false);
        }
        else
        {
            Line.SetActive(true);
        }
    }

    public void RemoveItemFromHand()
    {
        isObjectHeld = false;
        heldItem = null;
    }

    IEnumerator SetRaycastFalse()
    {
        yield return new WaitForSeconds(0.5f);
        raycastActive = false;
    }

    IEnumerator LightsOut()
    {
        yield return new WaitForSeconds(0.5f);
        lampsActive = false;
    }
    IEnumerator LightsOn()
    {
        yield return new WaitForSeconds(0.5f);
        lampsActive = true;
    }
}
