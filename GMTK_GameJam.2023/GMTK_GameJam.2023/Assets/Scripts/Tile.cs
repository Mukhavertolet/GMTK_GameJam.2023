using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool isInteractable = true;


    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    [SerializeField] private Sprite filledSprite;
    [SerializeField] private Sprite cleanSprite;
    [SerializeField] private GameObject linings;


    public Vector2 coordinates;
    public bool isClean = false;

    public List<GameObject> contents;



    public void Initialize(bool isOffset)
    {
        renderer.color = isOffset ? offsetColor : baseColor;
    }



    private void OnMouseEnter()
    {
        if (isInteractable)
            highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (isInteractable)
            highlight.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isInteractable)
        {
            isClean = true;
            renderer.sprite = cleanSprite;
            renderer.sortingOrder = 4;
            linings.SetActive(true);
            Debug.Log($"coordinates: {coordinates}");
        }

        if (Input.GetMouseButtonDown(1) && isInteractable)
        {
            isClean = false;
            renderer.sprite = filledSprite;
            renderer.sortingOrder = 2;
            linings.SetActive(false);
            Debug.Log($"coordinates: {coordinates}");
        }



    }


    public void ChangeInteractabilityTo(bool interactability)
    {
        isInteractable = interactability;
    }


}
