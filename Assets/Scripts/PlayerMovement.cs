using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue(); // elegxos patimatos tis o8onis

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition); // metatroph twn syntetagmenwn apo tn analysh tis o8onis stis syntetagmenes toy world Unity.
            Debug.Log(worldPosition);
        }
    }
}
