using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;


    [SerializeField] private float movementSpeed;
    [SerializeField] private float zoomSpeed;


    private Vector3 translation = Vector3.zero;
    private float zoomTranslation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        translation = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        zoomTranslation = Input.mouseScrollDelta.y;

        if (Input.GetMouseButtonDown(2))
            cam.transform.position = new Vector3(25f, 25f, -10);

    }

    private void LateUpdate()
    {
        gameObject.transform.Translate(translation * movementSpeed * Time.deltaTime);


        cam.orthographicSize -= zoomTranslation * zoomSpeed * Time.deltaTime;

        if (cam.orthographicSize < 1.5f)
            cam.orthographicSize = 1.5f;

        if (cam.orthographicSize > 28f)
            cam.orthographicSize = 28f;

    }


}
