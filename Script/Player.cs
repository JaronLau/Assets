using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    /// <summary>
    /// player score for collecting coins
    /// </summary>
    public int currentScore = 0;
    /// <summary>
    /// player counter for collection of keycards
    /// </summary>
    public int cardNum = 0;
    /// <summary>
    /// player counter for collection of keys
    /// </summary>
    public int keyNum = 0;
    /// <summary>
    /// number of collectibles left in the world
    /// </summary>
    public int totalCollect = 43;

    /// <summary>
    /// sets text mesh to enable score change in UI
    /// </summary>
    public TextMeshProUGUI scoreText;
    /// <summary>
    /// UI for collecting all collectibles
    /// </summary>
    public GameObject collectAllUI;
    
    /// <summary>
    /// function to increase the score of player by adding coin value to player score, and decreases total collectibles in world
    /// </summary>
    /// <param name="scoreToAdd">value from collectible script to add into current score</param>
    public void IncreaseScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString();
        totalCollect -= 1;
    }
    /// <summary>
    /// function to increase the number of keycards collected, and decreases total collectibles in world
    /// </summary>
    /// <param name="cardToAdd">value from collectible script to add into card value</param>
    public void IncreaseCard(int cardToAdd)
    {
        cardNum += cardToAdd;
        totalCollect -= 1;
    }
    /// <summary>
    /// function to increase the number of key collected, and decreases total collectibles in world
    /// </summary>
    /// <param name="keyToAdd"></param>
    public void IncreaseKey(int keyToAdd)
    {
        keyNum += keyToAdd;
        totalCollect -= 1;
    }
    /// <summary>
    /// function to enable UI when all collectibles are collected
    /// </summary>
    public void collectedMenu()
    {
        if (totalCollect <= 0)
        {
            collectAllUI.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        collectedMenu();
    }
}
