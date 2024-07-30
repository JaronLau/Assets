using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Transform playerCamera;

    [SerializeField]
    private float interactionDistance = 5f;

    private Collectible currentCollectible;


    private void Update()
    {
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent<Collectible>(out currentCollectible))
            {
                Debug.Log("Collectible in sight: " + hitInfo.transform.name);
            }
            else
            {
                currentCollectible = null;
            }
        }
        else
        {
            currentCollectible = null;
        }
    }
    void OnUI()
    {
        if (currentCollectible != null)
        {
            currentCollectible.Collected(this);
        }
    }




}