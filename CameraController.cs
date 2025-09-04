using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;

    private bool coolingDown;

    private void Update()
    {
        Vector2 moveStickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float moveX = moveStickInput.x * moveSpeed * Time.deltaTime;
        float moveZ = moveStickInput.y * moveSpeed * Time.deltaTime;

        Vector3 forwardMovement = Camera.main.transform.forward * moveZ;
        Vector3 rightMovement = Camera.main.transform.right * moveX;
        Vector3 totalMovement = forwardMovement + rightMovement;

        transform.Translate(totalMovement);


    }
}


