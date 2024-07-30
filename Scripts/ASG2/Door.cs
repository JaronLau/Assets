using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    public void OpenDoor()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y -= 90;
        transform.eulerAngles = currentRotation;
        isOpen = true;
    }

    public void CloseDoor()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y += 90;
        transform.eulerAngles = currentRotation;
        isOpen = false;
    }

    public void DoorToggle()
    {
        if (!isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
