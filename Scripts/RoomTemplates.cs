using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [Header("room spawning variables")]
    public int playerCondition;
    public float maxRoomsSpawned;

    [Header("bottom templates")]
    public GameObject[] bottomRoom;
    public GameObject bottomEndRoom;
    public GameObject bottomLeftCornerRoom;
    [Header("top templates")]
    public GameObject[] topRoom;
    public GameObject topEndRoom;
    public GameObject bottomRightCornerRoom;
    [Header("left templates")]
    public GameObject[] leftRoom;
    public GameObject leftEndRoom;
    public GameObject topLeftCornerRoom;
    [Header("right templates")]
    public GameObject[] rightRoom;
    public GameObject rightEndRoom;
    public GameObject topRightCornerRoom;

    [Header("boss template")]
    public bool spawnBoss;
    private bool spawnedBoss;
    public GameObject bossAltar;

    [Header("list of rooms")]
    public List<GameObject> rooms;


    void Start()
    {
        maxRoomsSpawned = playerCondition * 1.3f;
    }
    
    void Update()
    {
        if(spawnBoss &&  spawnedBoss == false) 
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(bossAltar, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
    }

}
