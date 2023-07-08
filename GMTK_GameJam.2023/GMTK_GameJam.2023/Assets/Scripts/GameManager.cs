using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cameraObj, gridManagerObj;

    private GridManager gridManager;



    private void Awake()
    {
        gridManager = gridManagerObj.GetComponent<GridManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //set camera initial position to the middle of the grid
        cameraObj.transform.position = new Vector3(gridManager.GetSize().x / 2, gridManager.GetSize().y / 2, cameraObj.transform.position.z);
        Debug.Log($"new camera pos {cameraObj.transform.position}, should be {gridManager.GetSize() / 2}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
