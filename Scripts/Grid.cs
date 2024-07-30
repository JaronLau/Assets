using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int width, length, gridSize;

    [SerializeField] private GameObject tilePrefab;


    void Start()
    {
        GenerateGrid();
    }
    void GenerateGrid()
    {
        for(int z = 0; z < width; z++)
        {
            for(int x = 0; x < length; x++)
            {
                Vector3 position = new Vector3(x * gridSize + gridSize / 2, 0, z * gridSize + gridSize / 2);
                var spawnedTile = Instantiate(tilePrefab, position, Quaternion.identity);
                spawnedTile.name = $"Tile {x} {z}";
            }
        }
    }
}
