using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;




    private Vector3 translation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translation = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void LateUpdate()
    {
        gameObject.transform.Translate(translation * movementSpeed * Time.deltaTime);
    }


}
