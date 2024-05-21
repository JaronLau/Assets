using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;



public class Collectible : MonoBehaviour
{
    /// <summary>
    /// text mesh for displaying keycards collected
    /// </summary>
    public TextMeshProUGUI cardText;
    /// <summary>
    /// text mesh for displaying keys collected
    /// </summary>
    public TextMeshProUGUI keyText;

    /// <summary>
    /// value of each coin
    /// </summary>
    public int scoreCoinGold = 2;
    /// <summary>
    /// counter for keycard
    /// </summary>
    public int keyCard = 0;
    /// <summary>
    /// counter for key
    /// </summary>
    public static int keys = 0;

    /// <summary>
    /// function to destroy the game object
    /// </summary>
    void GetCollected()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// adds collectible value to counters when player touches them to player script, and destroys collectible touched
    /// </summary>
    /// <param name="collision">when player collides with object</param>
    void OnCollisionEnter(Collision collision)
    {

        if ((collision.gameObject.tag == "Player") && (gameObject.tag == "Collectible"))
        {
            collision.gameObject.GetComponent<Player>().IncreaseScore(scoreCoinGold);
            GetCollected();
        }

        else if ((collision.gameObject.tag == "Player") && (gameObject.tag == "Card"))
        {
            keyCard += 1;
            collision.gameObject.GetComponent<Player>().IncreaseCard(1);
            GetCollected();
            cardText.text = keyCard.ToString() + "/1";
        }

        else if ((collision.gameObject.tag == "Player") && (gameObject.tag == "Key"))
        {
            keys += 1;
            collision.gameObject.GetComponent<Player>().IncreaseKey(1);
            GetCollected();
            keyText.text = keys.ToString() + "/2";
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
