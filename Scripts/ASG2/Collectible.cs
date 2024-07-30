using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using StarterAssets;

public class Collectible : MonoBehaviour
{
    // Base collection method
    public virtual void Collected(Player player)
    {
        Debug.Log($"{gameObject.name} collected by {player.gameObject.name}");
    }
}