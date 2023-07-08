using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    public Vector2 coordinates;



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

    private void OnMouseDown()
    {
        Debug.Log($"coordinates: {coordinates}");
    }

}
