using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using StarterAssets;



public class GoldCoin : Collectible
{
    public static int gold = 2;

    void GetCollected()
    {
        Destroy(gameObject);
    }

    public override void Collected(Player player)
    {
        Debug.Log("Coin collected!");
        GameManager.Instance.IncreaseScore(1);
        base.Collected(player); 
        Destroy(gameObject);  
    }

}
