using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    [SerializeField] private Sprite filledSprite;
    [SerializeField] private Sprite cleanSprite;


    public Vector2 coordinates;
    public bool isClean = false;

    public List<GameObject> contents;



    public void Initialize(bool isOffset)
    {
        renderer.color = isOffset ? offsetColor : baseColor;
    }



    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.isClean = true;
            this.renderer.sprite = cleanSprite;
            Debug.Log($"coordinates: {coordinates}");
        }

        if (Input.GetMouseButtonDown(1))
        {
            this.isClean = false;
            this.renderer.sprite = filledSprite;
            Debug.Log($"coordinates: {coordinates}");
        }



    }



}
