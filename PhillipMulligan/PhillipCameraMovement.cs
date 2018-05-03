using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhillipCameraMovement : MonoBehaviour
{
    public GameObject _mainCamera;

    public float RotateSpeed;

    private void Start()
    {
        
    }

    void Update()
    {
        if (_mainCamera != null) 
        {
            transform.LookAt(_mainCamera.transform); 
            transform.RotateAround(_mainCamera.transform.position, Vector3.up, Time.deltaTime * RotateSpeed); 

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.RotateAround(_mainCamera.transform.position, Vector3.up, Time.deltaTime * RotateSpeed);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.RotateAround(_mainCamera.transform.position, Vector3.down, Time.deltaTime * RotateSpeed);
            }

        }
    }
}
