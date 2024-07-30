using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform playerCamera;

    [SerializeField]
    private float interactionDistance = 5f;

    private Collectible currentCollectible;
    public Transform handPosition;

    public float rotationSpeed = 100f;
    private float rotationInput = 0;


    public void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("muse is clicked");
            Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
            RaycastHit hitInfo;
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
            {
                if (hitInfo.transform.tag=="Collectible")
                {
                    Debug.Log("Collectible in sight: " + hitInfo.transform.name);
                    
                }
                else
                {
                    currentCollectible = null;
                }
            }
        }
        
    }
    

    //bow behavior
    /*
     the longer you hold the button down, the stronger the force
    on release, send the projectile out with the force.
    bow should have arrow transform, instantiate arrow, and arrow minus
    */
}
