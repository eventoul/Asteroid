using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    
    private Camera mainCamera;
    private Rigidbody rb;

    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TouchToMove();
    }

    private void FixedUpdate()
    {
        ForceToMove();
    }

    private void TouchToMove()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue(); // elegxos patimatos tis o8onis

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition); // metatroph twn syntetagmenwn apo tn analysh tis o8onis stis syntetagmenes toy world Unity.

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }
    
    private void ForceToMove()
    {
        if (movementDirection == Vector3.zero)
        {
            return;
        }
   
        rb.AddForce(movementDirection * forceMagnitude, ForceMode.Force);
   
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    } 
    
}