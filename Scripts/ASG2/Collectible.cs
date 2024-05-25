using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using StarterAssets;

public class Collectible : MonoBehaviour
{
    public void AddJump(Collision collision)
    {
        collision.gameObject.GetComponent<FirstPersonController>().JumpHeight = 3.0f;
    }
    public void AddSpeed(Collision collision)
    {
        collision.gameObject.GetComponent<FirstPersonController>().MoveSpeed = 10.0f;
    }
}
