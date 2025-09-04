using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
            {
                hit.transform.gameObject.SetActive(false);
            }
        }
    }
}
