using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject cameraObj, gridManagerObj;

    private GridManager gridManager;
    [SerializeField] private Canvas inGameUI;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject trapMenu;
    [SerializeField] private Image[] trapSelect;

    [SerializeField] private Color selectedTrapColor;
    [SerializeField] private Color unselectedTrapColor;


    [SerializeField] private int gameState; //0 - preparation, 1 - attack



    public int selectedTrap = 0; //0 - room, 1 - key, 2 - chest, 3 - skelekok, 4 - spikes, 5 - keyhole, 6 - oneWayDoor;



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

        trapSelect[selectedTrap].color = unselectedTrapColor;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTrap = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTrap = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTrap = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedTrap = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedTrap = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedTrap = 5;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            selectedTrap = 6;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            selectedTrap = 7;
        }

        trapSelect[selectedTrap].color = selectedTrapColor;

        //else if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    selectedTrap = 6;
        //}

        //Debug.Log(selectedTrap);


    }


    public void ChangeGameStateTo(int gameState)
    {
        if(gameState != 0 && gridManager.entrances == 1 && gridManager.finishes == 1)
        {
            gridManager.ChangeTileInteractabilityTo(false);
        }
    }

}
