using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;


    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Tile[,] tiles;

    public int entrances = 0;
    public int finishes = 0;



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
        for (int x = 0; x < width; x++)
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


    public void ChangeTileInteractabilityTo(bool interactability)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y].ChangeInteractabilityTo(interactability);
            }
        }
    }


    public Vector2 GetSize()
    {
        return new Vector2(width, height);
    }

    public Vector2 GetEntrancePosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (tiles[x, y].trapInstance != null && tiles[x, y].trapInstance.CompareTag("Respawn"))
                {
                    return new Vector2(x, y);
                }
                //Debug.Log(tiles[x, y].trapInstance);
            }
        }

        return Vector2.zero;

    }

    public Vector2 GetFinishPosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (tiles[x, y].trapInstance != null && tiles[x, y].trapInstance.CompareTag("Finish"))
                {
                    return new Vector2(x, y);
                }
                //Debug.Log(tiles[x, y].trapInstance);
            }
        }

        return Vector2.zero;

    }



    public List<Tile> GetSurroundingTiles(int x, int y)
    {
        return new List<Tile> {tiles[x + 1, y],
                            tiles[x, y + 1],
                            tiles[x - 1, y],
                            tiles[x, y - 1]};
    }



}
