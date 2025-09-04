using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenClicker : MonoBehaviour
{
    [SerializeField]
    private GameObject _raycastObject;

    public bool PrimaryController;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            RaycastInteraction();

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            RaycastInteraction();
    }

    private void RaycastInteraction()
    {
        RaycastHit objectHit;
        Vector3 fwd = _raycastObject.transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(_raycastObject.transform.position, fwd, out objectHit, 100)) 
        {
            if(objectHit.transform.GetComponent<VRUIButtonClick>() != null) 
            {
                objectHit.transform.GetComponent<VRUIButtonClick>().VRUnityUIButtonInvoke();
            }
        }
    }
}
