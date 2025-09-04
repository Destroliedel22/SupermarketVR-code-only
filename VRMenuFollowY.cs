using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMenuFollowY : MonoBehaviour
{
    [SerializeField]
    private Transform MainCamera;
    public int boundaryAngle;

    private void Start()
    {
        if(Camera.main != null)
        {
            MainCamera = Camera.main.transform;
        }
    }

    private void FixedUpdate()
    {
        float angle = Quaternion.Angle(MainCamera.rotation, transform.parent.rotation);

        if(angle > boundaryAngle)
        {
            transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, MainCamera.rotation, Time.time * 0.002f);
        }

        transform.parent.rotation = Quaternion.Euler(0, transform.parent.rotation.eulerAngles.y, 0);
    }
}
