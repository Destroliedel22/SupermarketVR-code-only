using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slidingdoor : MonoBehaviour
{
    [SerializeField]
    private Transform _leftDoor;
    [SerializeField] 
    private Transform _rightDoor;

    [SerializeField]
    float openSpeed = 10;

    private Vector3 _leftDoorStartPos;
    private Vector3 _rightDoorStartPos;

    [SerializeField]
    private AudioSource slidingDoorSource;
    [SerializeField]
    private AudioClip openSlidingDoor;
    [SerializeField]
    private AudioClip closeSlidingDoor;

    private bool playerInsideDoorTrigger;
    // Start is called before the first frame update
    void Start()
    {
        _leftDoorStartPos = _leftDoor.position;
        _rightDoorStartPos = _rightDoor.position;
    }

    private void FixedUpdate()
    {
        if (playerInsideDoorTrigger)
        {
            if (_leftDoor.position.x > _leftDoorStartPos.x - 1)
            {
                Vector3 newPosLeft = new Vector3(_leftDoor.position.x - (openSpeed * Time.deltaTime), _leftDoor.position.y, _leftDoor.position.z);
                _leftDoor.position = newPosLeft;    
            }

            if (_rightDoor.position.x < _rightDoorStartPos.x + 1)
            {
                Vector3 newPosRight = new Vector3(_rightDoor.position.x + (openSpeed * Time.deltaTime), _rightDoor.position.y, _rightDoor.position.z);
                _rightDoor.position = newPosRight;
            }

            
        }

        else
        {
            if (_leftDoor.position.x < _leftDoorStartPos.x)
            {
                Vector3 newPosLeft = new Vector3(_leftDoor.position.x + (openSpeed * Time.deltaTime), _leftDoor.position.y, _leftDoor.position.z);
                _leftDoor.position = newPosLeft;
            }

            if (_rightDoor.position.x > _rightDoorStartPos.x)
            {
                Vector3 newPosRight = new Vector3(_rightDoor.position.x - (openSpeed * Time.deltaTime), _rightDoor.position.y, _rightDoor.position.z);
                _rightDoor.position = newPosRight;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("NPC"))
        {
            playerInsideDoorTrigger = true;
            slidingDoorSource.clip = openSlidingDoor;
            slidingDoorSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("NPC"))
        {
            playerInsideDoorTrigger= false;
            slidingDoorSource.clip = closeSlidingDoor;
            slidingDoorSource.Play();
        }
    }
}
