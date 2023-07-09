using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GridManager gridManager;

    [SerializeField] private bool isInteractable = true;


    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private SpriteRenderer contentPreview;
    [SerializeField] private Sprite[] contentPreviewVariants;
    public GameObject[] availableContents;

    [SerializeField] private Sprite filledSprite;
    [SerializeField] private Sprite cleanSprite;
    [SerializeField] private GameObject linings;


    public Vector2 coordinates;
    public bool isClean = false;


    public GameObject trapInstance;



    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
    }

    public void Initialize(bool isOffset)
    {
        renderer.color = isOffset ? offsetColor : baseColor;
    }



    private void OnMouseEnter()
    {
        if (isInteractable)
            highlight.SetActive(true);
        if (isClean)
            contentPreview.sprite = contentPreviewVariants[gameManager.selectedTrap];
    }

    private void OnMouseExit()
    {
        if (isInteractable)
            highlight.SetActive(false);
        if (isClean)
            contentPreview.sprite = contentPreviewVariants[0];
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isInteractable)
        {
            if (!isClean || gameManager.selectedTrap == 0)
            {
                isClean = true;
                renderer.sprite = cleanSprite;
                renderer.sortingOrder = 4;
                linings.SetActive(true);
                Debug.Log($"coordinates: {coordinates}");
            }
            else
            {

                if (trapInstance != null)
                {
                    if (trapInstance.GetComponent<Trap>().trapType == 6)
                        gridManager.entrances -= 1;
                    if (trapInstance.GetComponent<Trap>().trapType == 7)
                        gridManager.finishes -= 1;
                    Destroy(trapInstance);
                }

                trapInstance = Instantiate(availableContents[gameManager.selectedTrap], transform.position, Quaternion.identity);

                if (trapInstance.GetComponent<Trap>().trapType == 6)
                    gridManager.entrances += 1;
                if (trapInstance.GetComponent<Trap>().trapType == 7)
                    gridManager.finishes += 1;
            }
        }

        if (Input.GetMouseButtonDown(1) && isInteractable)
        {
            if (isClean && gameManager.selectedTrap == 0)
            {
                isClean = false;
                renderer.sprite = filledSprite;
                renderer.sortingOrder = 2;
                linings.SetActive(false);
                Debug.Log($"coordinates: {coordinates}");


                if (trapInstance.GetComponent<Trap>().trapType == 6)
                    gridManager.entrances -= 1;
                if (trapInstance.GetComponent<Trap>().trapType == 7)
                    gridManager.finishes -= 1;

                if (trapInstance != null)
                    Destroy(trapInstance);
            }
            else
            {
                if (trapInstance != null)
                    Destroy(trapInstance);


                if (trapInstance.GetComponent<Trap>().trapType == 6)
                    gridManager.entrances -= 1;
                if (trapInstance.GetComponent<Trap>().trapType == 7)
                    gridManager.finishes -= 1;

            }
        }



    }


    public void ChangeInteractabilityTo(bool interactability)
    {
        isInteractable = interactability;
    }


}
