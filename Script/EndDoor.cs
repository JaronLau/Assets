using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDoor : MonoBehaviour
{
    /// <summary>
    /// bool to check if this door has been opened before
    /// </summary>
    public bool secondopened = false;
    /// <summary>
    /// game object to reference UI, to set UI active after open door
    /// </summary>
    public GameObject endScreen;


    /// <summary>
    /// function to open door after player collects 2 keys and touches the collider
    /// </summary>
    /// <param name="other">takes component keyNum from player script</param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player>().keyNum >= 2 && !secondopened)
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.z += 90;
                transform.eulerAngles = currentRotation;
                secondopened = true;
            }
        }
    }
    /// <summary>
    /// function to set the end screen UI active
    /// </summary>
    public void endMenu()
    {
        endScreen.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (secondopened == true)
        {
            endMenu();
        }
    }
}
