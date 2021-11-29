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
        /*
         *  arxikopoihsh twn metablitwn me ta antikeimena tou project.
         */
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TouchToMove();
        KeepPlayerOnScreen();
    }

    private void FixedUpdate()
    {
        ForceToMove();
    }

    /*
     *  metakinisi toy aeroplano stin o8oni analoga me to agkigma.
     */
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
    
    /*
     *  efarmofi tis epitaxynsis sto aeroplano.
     */
    private void ForceToMove()
    {
        if (movementDirection == Vector3.zero)
        {
            return;
        }
   
        rb.AddForce(movementDirection * forceMagnitude, ForceMode.Force);
   
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    } 
    
    /*
     *  me8odos gia tin metafora toy aeroplano stin o8oni etsi wste na emfanizetai panta mesa s' ayth.
     */
    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }
        else if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }
}