using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GridManager gridManager;

    public int healthCurrent;
    public int healthMax;
    public int keys;
    public int damage;




    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
    }



    // Start is called before the first frame update
    void Start()
    {
        FindPath(new Vector2(transform.position.x, transform.position.y), gridManager.GetFinishPosition());
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MakeTurn()
    {
        //findPath
        //if(can)
    }



    public void FindPath(Vector2 startPos, Vector2 targetPos)
    {
        Tile lookingAt = null;
        Tile lowestDistance = null;
        List<Tile> walkable = new List<Tile>();

        //check neighbors
        for (int i = 0; i < 4; i++)
        {
            lookingAt = gridManager.GetSurroundingTiles((int)startPos.x, (int)startPos.y)[i];

            if (lookingAt.isClean)
                walkable.Add(lookingAt);
        }

        for (int i = 0; i < walkable.Count; i++)
        {
            if (i == 0)
            {
                lowestDistance = walkable[i];
                continue;
            }

            if ((targetPos.x + targetPos.y) - (walkable[i].coordinates.x + walkable[i].coordinates.y) < (targetPos.x + targetPos.y) - (lowestDistance.coordinates.x + lowestDistance.coordinates.y))
                lowestDistance = walkable[i];

        }


            Debug.Log(lowestDistance);

    }



}
