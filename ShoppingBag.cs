using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingBag : MonoBehaviour
{
    RaycastObject handGrabber;

    [SerializeField]
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private SphereCollider _sphereCollider;

    private void Awake()
    {
        handGrabber = FindObjectOfType<RaycastObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable" && other.gameObject.GetComponent<Product>() != null && handGrabber.isObjectHeld && handGrabber.heldItem == other.gameObject || other.gameObject.tag == "Pringles")
        {
            other.transform.SetParent(this.transform);
            other.transform.localPosition = Vector3.zero;
            other.transform.gameObject.SetActive(false);

            FindObjectOfType<SupermarketManager>().RegisterProduct(other.gameObject.GetComponent<Product>());

            handGrabber.RemoveItemFromHand();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (other.gameObject.tag == "Hand" && handGrabber.heldItem == null && this.transform.childCount > 0)
            {
                GameObject BagItem = this.transform.GetChild(this.transform.childCount - 1).gameObject;
                BagItem.SetActive(true);
                handGrabber.heldItem = BagItem;
                BagItem.transform.parent = handGrabber.handTransform;
                BagItem.GetComponent<Rigidbody>().useGravity = false;
                BagItem.GetComponent<Rigidbody>().isKinematic = true;
                BagItem.transform.localPosition = Vector3.zero;
                handGrabber.isObjectHeld = true;

                FindObjectOfType<SupermarketManager>().RemoveProduct(BagItem.GetComponent<Product>());
            }
        }
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            _sphereCollider.enabled = true;
            _meshRenderer.enabled = true;
        }
        else
        {
            _sphereCollider.enabled = false;
            _meshRenderer.enabled = false;
        }
    }
}
