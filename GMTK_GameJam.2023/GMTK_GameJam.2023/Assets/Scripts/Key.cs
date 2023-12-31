using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;



    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager.changeAmountOfKeys(1);
        gameManager.goals.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        gameManager.changeAmountOfKeys(-1);
        gameManager.goals.Remove(gameObject);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player>().keys += 1;
        }
    }

}
