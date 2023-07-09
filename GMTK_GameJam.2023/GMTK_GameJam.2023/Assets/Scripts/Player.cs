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

    public Vector2 mainTarget;
    public Vector2 target;
    public Vector2 previousTile;




    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
    }



    // Start is called before the first frame update
    void Start()
    {


        healthCurrent = healthMax;

        previousTile = new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));

        mainTarget = gridManager.GetFinishPosition();



        //FindPath(new Vector2(transform.position.x, transform.position.y), target);



    }

    // Update is called once per frame
    void Update()
    {
        gameManager.ChangePlayerHP();
        gameManager.ChangePlayerKeys();


        if (Input.GetKeyDown(KeyCode.G))
        {
            MakeTurn();
        }
    }


    public void MakeTurn()
    {
        Vector2 closestTarget = mainTarget;

        for (int i = 0; i < gameManager.goals.Count; i++)
        {
            if (Vector3.Distance(transform.position, gameManager.goals[i].transform.position) < Vector3.Distance(transform.position, closestTarget))
            {
                closestTarget = gameManager.goals[i].transform.position;
            }
        }
        transform.position = FindPath(transform.position, closestTarget).transform.position;
        //if(can)
    }



    public Tile FindPath(Vector2 startPos, Vector2 targetPos)
    {

        Tile lookingAt = null;
        Tile lowestDistance = null;
        List<Tile> walkable = new List<Tile>();

        //check neighbors
        for (int i = 0; i < 4; i++)
        {
            lookingAt = gridManager.GetSurroundingTiles((int)startPos.x, (int)startPos.y)[i];

            if (lookingAt.isClean && lookingAt.coordinates != previousTile)
                walkable.Add(lookingAt);
        }

        for (int i = 0; i < walkable.Count; i++)
        {
            if (i == 0)
            {
                lowestDistance = walkable[i];
                continue;
            }

            //if ((walkable[i].coordinates != previousTile || i == 3) && (targetPos.x + targetPos.y) - (walkable[i].coordinates.x + walkable[i].coordinates.y) < (targetPos.x + targetPos.y) - (lowestDistance.coordinates.x + lowestDistance.coordinates.y))
            //    lowestDistance = walkable[i];

            if (Vector3.Distance(walkable[i].transform.position, targetPos) < Vector3.Distance(startPos, targetPos))
            {
                if (lowestDistance.coordinates == previousTile)
                    continue;
                lowestDistance = walkable[i];
            }

            //if (lowestDistance == null)
            //    lowestDistance = gridManager.GetTileWithCoordinates((int)previousTile.x, (int)previousTile.y);


        }

        previousTile = startPos;

        Debug.Log(lowestDistance);
        return lowestDistance;

    }



}
