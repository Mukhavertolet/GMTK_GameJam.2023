using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousTrap : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;



    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager.changeAmountOfTraps(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        gameManager.changeAmountOfTraps(-1);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.GetComponent<Player>().healthCurrent -= 1;
        }
    }


}

