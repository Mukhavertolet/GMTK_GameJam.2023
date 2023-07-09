using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject cameraObj, gridManagerObj;

    public GameObject heroPlayer;
    public GameObject heroPlayerInstance;


    private GridManager gridManager;
    [SerializeField] private Canvas inGameUI;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject playerMenu;
    [SerializeField] private GameObject trapMenu;
    [SerializeField] private Image[] trapSelect;
    [SerializeField] private TMP_Text treasureCounter;
    [SerializeField] private TMP_Text treasureCounterReq;
    [SerializeField] private TMP_Text keyCounter;
    [SerializeField] private TMP_Text keyCounterReq;

    [SerializeField] private Color selectedTrapColor;
    [SerializeField] private Color unselectedTrapColor;


    [SerializeField] private int gameState; //0 - preparation, 1 - attack

    [SerializeField] private int amountOfTraps = 0;
    [SerializeField] private int amountOfTreasures = 0;
    [SerializeField] private int amountOfTreasuresReq = 0;
    [SerializeField] private int amountOfKeys = 0;
    [SerializeField] private int amountOfKeysReq = 0;
    [SerializeField] private int amountOfDoors = 0;


    public int turnCounter = 0;


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
        amountOfTreasuresReq = amountOfTraps / 4;
        amountOfKeysReq = amountOfTreasures + amountOfDoors;


        treasureCounter.text = amountOfTreasures.ToString();
        treasureCounterReq.text = amountOfTreasuresReq.ToString();
        keyCounter.text = amountOfKeys.ToString();
        keyCounterReq.text = amountOfKeysReq.ToString();

        if (Input.GetKeyDown(KeyCode.Tab))
            helpMenu.SetActive(!helpMenu.activeSelf);

        if (Input.GetKeyDown(KeyCode.Z) && gameState == 0)
            trapMenu.SetActive(!trapMenu.activeSelf);

        trapSelect[selectedTrap].color = unselectedTrapColor;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTrap = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
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


        if (Input.GetKeyDown(KeyCode.Space) && gridManager.entrances == 1 && gridManager.finishes == 1 && amountOfTreasures == amountOfTreasuresReq && amountOfKeys == amountOfKeysReq)
        {
            StartAttack();
        }

        //else if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    selectedTrap = 6;
        //}

        //Debug.Log(selectedTrap);


    }



    public void SpawnPlayer(Vector2 pos)
    {
        heroPlayerInstance = Instantiate(heroPlayer, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
    }    

    public void StartAttack()
    {
        gridManager.ChangeTileInteractabilityTo(false);
        SpawnPlayer(gridManager.GetEntrancePosition());
        ChangeGameStateTo(1);

        helpMenu.SetActive(false);
        trapMenu.SetActive(false);
        playerMenu.SetActive(true);


    }


    public IEnumerator Turn()
    {





        yield return new WaitForSeconds(3f);
    }







    public void ChangeGameStateTo(int gameStateChange)
    {
        gameState = gameStateChange;
    }

    public void changeAmountOfKeys(int changeBy)
    {
        amountOfKeys += changeBy;
    }

    public void changeAmountOfTreasures(int changeBy)
    {
        amountOfTreasures += changeBy;
    }
    public void changeAmountOfDoors(int changeBy)
    {
        amountOfDoors += changeBy;
    }
    public void changeAmountOfTraps(int changeBy)
    {
        amountOfTraps += changeBy;
    }
}
