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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
