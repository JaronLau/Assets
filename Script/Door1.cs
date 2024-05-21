using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /// <summary>
    /// bool to check if door is opened or not
    /// </summary>
    bool firstopened = false;

    /// <summary>
    /// function to open the first door after collecting keycard and touching collider
    /// </summary>
    /// <param name="other">takes cardNum from player script</param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player>().cardNum >= 1 && !firstopened)
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.z += 50;
                transform.eulerAngles = currentRotation;
                firstopened = true;


            }
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
