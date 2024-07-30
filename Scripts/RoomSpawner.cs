using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //bottom, top, left, right

    private RoomTemplates template;
    private int rand;
    private bool spawned;

    public static int roomsSpawned = 0;
    public float maxRoomsSpawned;

    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        maxRoomsSpawned = template.maxRoomsSpawned;
        Invoke("Spawn", .5f);

    }
    
    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        {
            Spawn();
        }
    }

    
    /*bring back all direction room, cut out bends
     * use external checker to check
     * if external checker hits destroyer, spawnpoint spawns end room
     * external checker is a bool 
     * this means no bends, just left up right paths
    */
    void Spawn()
    {
        if(spawned == false)
        {
            Debug.Log("spawning");
            if (openingDirection == 1)
            {
                if (roomsSpawned >= maxRoomsSpawned)
                {
                    Instantiate(template.bottomEndRoom, transform.position, template.bottomEndRoom.transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, template.bottomRoom.Length);
                    Debug.Log("instantiate");
                    Instantiate(template.bottomRoom[rand], transform.position, template.bottomRoom[rand].transform.rotation);
                    roomsSpawned++;
                }
            }
            else if (openingDirection == 2)
            {
                if (roomsSpawned >= maxRoomsSpawned)
                {
                    Instantiate(template.topEndRoom, transform.position, template.topEndRoom.transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, template.bottomRoom.Length);
                    Debug.Log("instantiate");
                    Instantiate(template.topRoom[rand], transform.position, template.topRoom[rand].transform.rotation);
                    roomsSpawned++;
                }
            }
            else if (openingDirection == 3)
            {
                if (roomsSpawned >= maxRoomsSpawned)
                {
                    Instantiate(template.leftEndRoom, transform.position, template.leftEndRoom.transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, template.bottomRoom.Length);
                    Debug.Log("instantiate");
                    Instantiate(template.leftRoom[rand], transform.position, template.leftRoom[rand].transform.rotation);
                    roomsSpawned++;
                }
            }
            else if (openingDirection == 4)
            {
                if (roomsSpawned >= maxRoomsSpawned)
                {
                    Instantiate(template.rightEndRoom, transform.position, template.rightEndRoom.transform.rotation);
                }
                else
                {
                    rand = Random.Range(0, template.bottomRoom.Length);
                    Debug.Log("instantiate");
                    Instantiate(template.rightRoom[rand], transform.position, template.rightRoom[rand].transform.rotation);
                    roomsSpawned++;
                }
            }
            spawned = true;
            Debug.Log(roomsSpawned);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            RoomSpawner otherSpawner = other.GetComponent<RoomSpawner>();
            if (other.CompareTag("Destroyer"))
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
                SpawnCornerRoom(openingDirection, otherSpawner.openingDirection);
            }
            
            Destroy(gameObject);
        }
    }
    void SpawnCornerRoom(int dir1, int dir2)
    {
        // Spawn corner rooms based on the combination of directions
        if (dir1 == 1 && dir2 == 3 || dir1 == 3 && dir2 == 1)
        {
            if(openingDirection == 1)
            {
                Instantiate(template.topRightCornerRoom, transform.position, Quaternion.identity);
            }
        }
        else if (dir1 == 1 && dir2 == 4 || dir1 == 4 && dir2 == 1)
        {
            if(openingDirection == 1)
            {
                Instantiate(template.topLeftCornerRoom, transform.position, Quaternion.identity);
            }
        }
        else if (dir1 == 2 && dir2 == 3 || dir1 == 3 && dir2 == 2)
        {
            if(openingDirection == 2)
            {
                Instantiate(template.bottomRightCornerRoom, transform.position, Quaternion.identity);
            }
        }
        else if (dir1 == 2 && dir2 == 4 || dir1 == 4 && dir2 == 2)
        {
            if (openingDirection == 2)
            {
                Instantiate(template.bottomLeftCornerRoom, transform.position, Quaternion.identity);
            }
        }
    }
}
