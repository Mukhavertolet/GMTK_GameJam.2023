using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;


    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Tile[,] tiles;





    private void Awake()
    {
        tiles = new Tile[width, height];
    }

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);

                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.coordinates = new Vector2(x, y);

                bool isOffset = (x + y) % 2 == 1;
                spawnedTile.Initialize(isOffset);


                tiles[x, y] = spawnedTile;
            }
        }
    }



    public Vector2 GetSize()
    {
        return new Vector2(width, height);
    }


}
