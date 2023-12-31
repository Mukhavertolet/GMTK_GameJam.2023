using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;



    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager.changeAmountOfDoors(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        gameManager.changeAmountOfDoors(-1);

    }

}
