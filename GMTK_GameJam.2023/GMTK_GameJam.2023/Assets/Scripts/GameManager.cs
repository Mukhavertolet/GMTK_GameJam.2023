using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cameraObj, gridManagerObj;

    private GridManager gridManager;
    [SerializeField] private Canvas inGameUI;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject trapMenu;



    [SerializeField] private int gameState; //0 - preparation, 1 - attack



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
        if (Input.GetKeyDown(KeyCode.Tab))
            helpMenu.SetActive(!helpMenu.activeSelf);

        if (Input.GetKeyDown(KeyCode.Z))
            trapMenu.SetActive(!trapMenu.activeSelf);
    }


    public void ChangeGameStateTo(int gameState)
    {
        if(gameState != 0)
        {
            gridManager.ChangeTileInteractabilityTo(false);
        }
    }

}
